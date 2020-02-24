using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Core.Utilities;
using w3bot.Event;
using w3bot.Util;
using w3bot.Wrapper;

namespace w3bot.Core.Processor
{
    class AppletProcessor : Panel, IProcessor
    {
        public Bitmap Frame { get; }

        public Point MousePos { get; set; }

        public Panel Panel { get; set; }

        public IMouseEvent MouseHandler { get; set; }
        public IKeyboardEvent KeyboardHandler { get; set; }
        public IPaintEvent PaintHandler { get; set; }

        public AppletProcessor()
        {

        }

        public void Activate()
        {
            
        }

        public void AllowInput()
        {
            
        }

        public void BlockInput()
        {
            
        }

        public void Destroy()
        {
            
        }

        public void DropFocus()
        {
            
        }

        public void GetFocus()
        {
            this.Focus();
        }

        public bool IsValidProcessor(ProcessorType type)
        {
            return type == ProcessorType.AppletProcessor;
        }

        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        public void OnPaint(Graphics g)
        {
            
        }

        public void OnRender(EventHandler<Graphics> handler)
        {
            
        }
    }
}
