using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookLib
{
    /// <summary>
    /// Класс для OnPrint.
    /// </summary>
    public class PrintEventArgs : EventArgs
    {
        public string Info { get; set; }
        public PrintEventArgs(string info)
        {
            Info = info;
        }
    }
}
