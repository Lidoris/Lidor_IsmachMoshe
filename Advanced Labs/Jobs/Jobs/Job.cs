using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Jobs
{
    static class NativeJob
    {
        [DllImport("kernel32")]
        public static extern IntPtr CreateJobObject(IntPtr sa, string name);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AssignProcessToJobObject(IntPtr hjob, IntPtr hprocess);

        [DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr h);

        [DllImport("kernel32")]
        public static extern bool TerminateJobObject(IntPtr hjob, uint code);
    }

    public class Job : IDisposable
    {
        private IntPtr _hJob;
        private List<Process> _processes;
        private bool Disposed;
        private long SizeInByte;

        public Job(string name, long sizeInByte)
        {
            if (sizeInByte > 0)
            {
                SizeInByte = sizeInByte;
                _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
                if (_hJob.Equals(IntPtr.Zero))
                {
                    throw new InvalidOperationException();
                }

                _processes = new List<Process>();
                Disposed = false;
                GC.AddMemoryPressure(SizeInByte);
                Console.WriteLine("The Job was created");
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        public Job() : this(null, 1)
        {
        }

        protected void AddProcessToJob(IntPtr hProcess)
        {
            CheckIfDisposed();
            if (!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
            {
                throw new InvalidOperationException("Failed to add process to job");
            }
        }

        private void CheckIfDisposed()
        {
            if (Disposed)
            {
                throw new NotImplementedException();
            }
        }

        public void AddProcessToJob(int pid)
        {
            AddProcessToJob(Process.GetProcessById(pid));
        }

        public void AddProcessToJob(Process proc)
        {
            Debug.Assert(proc != null);
            AddProcessToJob(proc.Handle);
            _processes.Add(proc);
        }

        public void Kill()
        {
            CheckIfDisposed();
            NativeJob.TerminateJobObject(_hJob, 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    foreach (Process process in _processes)
                    {
                        process.Dispose();
                    }
                }
                NativeJob.CloseHandle(_hJob);
                Disposed = true;
            }
        }

        ~Job()
        {
            Dispose(false);
            GC.RemoveMemoryPressure(SizeInByte);
            Console.WriteLine("The Job was released");
        }
    }

}
