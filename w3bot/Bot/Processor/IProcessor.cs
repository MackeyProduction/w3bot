using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Util;

namespace w3bot.Bot.Processor
{
    public interface IProcessor
    {
        void Activate();
        void Destroy();
        void AllowInput();
        void BlockInput();
        void GetFocus();
        void DropFocus();
        bool IsValidProcessor(ProcessorType type);
    }
}
