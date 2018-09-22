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
        private static List<Core.Drawable> debugs = new List<Core.Drawable>();

        internal static Bot _bot;
        internal static int paintPos = 0;
        private static Font font = new Font("Arial", 8);
        private static int height = 13;

        internal static bool toggle(Core.Drawable drawable)
        {
            bool added = true;
            if (debugs.Contains(drawable))
            {
                debugs.Remove(drawable);
                Core.paintings -= drawable;
                added = false;
            }
            else
            {
                debugs.Add(drawable);
                Core.paintings += drawable;
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
            Core.paintings += ResetHeight;
        }
    }
}
