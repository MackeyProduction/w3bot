using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w3bot.Core.Processor
{
    interface IProcessor
    {
        void Activate();
        void Destroy();
        void AllowInput();
        void BlockInput();
        void GetFocus();
        void DropFocus();
    }
}
