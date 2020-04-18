using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespiratorGraphDemo.Views
{
    public interface ISelectPortView
    {
        bool Show();
        string PortName { get; }
    }
}
