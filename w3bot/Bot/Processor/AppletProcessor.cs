using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Util;

namespace w3bot.Bot.Processor
{
    class AppletProcessor : IProcessor
    {
        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void AllowInput()
        {
            throw new NotImplementedException();
        }

        public void BlockInput()
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public void DropFocus()
        {
            throw new NotImplementedException();
        }

        public void GetFocus()
        {
            throw new NotImplementedException();
        }

        public bool IsValidProcessor(ProcessorType type)
        {
            return type == ProcessorType.AppletProcessor;
        }
    }
}
