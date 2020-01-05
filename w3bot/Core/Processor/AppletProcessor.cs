using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Core.Utilities;
using w3bot.Util;

namespace w3bot.Core.Processor
{
    class AppletProcessor : IProcessor
    {
        public Bitmap Frame => throw new NotImplementedException();

        public Point MousePos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Panel Panel => throw new NotImplementedException();

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

        public void Dispose()
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
