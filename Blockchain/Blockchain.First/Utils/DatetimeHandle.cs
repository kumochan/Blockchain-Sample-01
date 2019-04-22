using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.First.Utils
{
    public class DatetimeHandle
    {
        /// <summary>
        /// set up datetime
        /// </summary>
        /// <param name="TheDate"></param>
        /// <returns></returns>
        public static long GetTime()
        {
            long retval = 0;
            var st = new DateTime(1970, 1, 1);
            TimeSpan t = (DateTime.Now.ToUniversalTime() - st);
            retval = (Int64)(t.TotalMilliseconds + 0.5);
            return retval;
        }
    }
}
