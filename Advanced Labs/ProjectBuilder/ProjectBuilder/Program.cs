using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectATask = new Task(() =>
            {
                Project projectA = new Project(1);
                projectA.BuildProject();
            });

            var projectBTask = new Task(() =>
            {
                Project projectB = new Project(2);
                projectB.BuildProject();
            });

            var projectCTask = new Task(() =>
            {
                Project projectC = new Project(3);
                projectC.BuildProject();
            });

            var projectDTask = projectATask.ContinueWith(x =>
            {
                Project projectD = new Project(4);
                projectD.BuildProject();
            });

            var projectETask = Task.Factory.ContinueWhenAll(new Task[] { projectATask, projectBTask, projectCTask } ,(x =>
            {
                Project projectE = new Project(5);
                projectE.BuildProject();
            }));

            var projectFTask = Task.Factory.ContinueWhenAll(new Task[] { projectCTask, projectDTask }, (x =>
            {
                Project projectF = new Project(6);
                projectF.BuildProject();
            }));

            var projectGTask = Task.Factory.ContinueWhenAll(new Task[] { projectETask, projectFTask }, (x =>
            {
                Project projectG = new Project(7);
                projectG.BuildProject();
            }));

            var projectHTask = Task.Factory.ContinueWhenAll(new Task[] { projectETask}, (x =>
            {
                Project projectH = new Project(8);
                projectH.BuildProject();
            }));

            projectATask.Start();
            projectBTask.Start();
            projectCTask.Start();
            projectDTask.Wait();
            projectETask.Wait();
            projectFTask.Wait();
            projectGTask.Wait();
            projectHTask.Wait();
        }
    }
}
