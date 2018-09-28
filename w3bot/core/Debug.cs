using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.bot;

namespace w3bot.core
{
    class Debug
    {
        private static List<Bot.Drawable> debugs = new List<Bot.Drawable>();

        internal static Bot _bot;
        internal static int paintPos = 0;
        private static Font font = new Font("Arial", 8);
        private static int height = 13;

        internal static bool toggle(Bot.Drawable drawable)
        {
            bool added = true;
            if (debugs.Contains(drawable))
            {
                debugs.Remove(drawable);
                Bot.paintings -= drawable;
                added = false;
            }
            else
            {
                debugs.Add(drawable);
                Bot.paintings += drawable;
            }
            _bot.core.Invalidate(); //causes repaint
            return added;
        }

        internal static void Mouse(Graphics g)
        {
            Pen greenPen = new Pen(Color.Green); //draws the mouse
            Point m = _bot.botWindow._processor.MousePos;
            g.DrawLine(greenPen, new Point(m.X - 5, m.Y - 5), new Point(m.X + 5, m.Y + 5));
            g.DrawLine(greenPen, new Point(m.X - 5, m.Y + 5), new Point(m.X + 5, m.Y - 5));
        }

        internal static void MousePosition(Graphics g)
        {
            paintPos++;
            g.DrawString("Mouse: " + _bot.botWindow._processor.MousePos.X + ", " + _bot.botWindow._processor.MousePos.Y, font, Brushes.Green, 5, paintPos * height);
        }

        internal static void ResetHeight(Graphics g)
        {
            paintPos = 0;
        }

        internal static void AddConfiguration(Bot bot)
        {
            _bot = bot;
            Bot.paintings += ResetHeight;
        }

        internal static void PixelColor(Graphics g)
        {
            //paintPos++;
            //Pixel p = Frame.GetPixel(Core.bot.MousePos);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(p.R, p.G, p.B)), 5, (paintPos * height) + 2, 10, 8);
            //g.DrawRectangle(Pens.Black, 5, (paintPos * height) + 2, 10, 8);
            //g.DrawString("R: " + p.R + ", G:" + p.G + " , B:" + p.B, font, Brushes.Green, 15, paintPos * height);
        }
    }
}
