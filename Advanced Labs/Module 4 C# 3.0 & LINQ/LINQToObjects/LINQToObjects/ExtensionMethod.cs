using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToObjects
{
    static class ExtensionMethod
    {
        public static void CopyTo(this object sourceObj, object destObj)
        {
            if (sourceObj != null)
            {
                var sourceProp = from prop in sourceObj.GetType().GetProperties()
                                 where prop.CanRead
                                 select prop;

                var destProp = from prop in destObj.GetType().GetProperties()
                               where prop.CanWrite
                               select prop;
                
                var Result = sourceProp.Join(destProp, source => new { source.PropertyType, source.Name }, target => new { target.PropertyType, target.Name },
                        (source, target) => new
                        {
                            SourceProp = source,
                            TargetProp = target
                        });
               
                foreach (var prop in Result)
                {
                    prop.TargetProp.SetValue(destObj, prop.SourceProp.GetValue(sourceObj, null), null);
                }
            }
        }

        public static bool IsSystem (this Process process)
        {
            try
            {
                var startTime = process.StartTime;
                return true;
            }
            catch (Win32Exception)
            {
                return false;
            }
        }
    }
}
