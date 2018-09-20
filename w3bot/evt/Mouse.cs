using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.enumeration;
using w3bot.interfaces;

namespace w3bot.evt
{
    class Mouse : IMouseInput
    {
        void IMouseInput.Click(Keys.Button button, Keys.Event evt)
        {
            throw new NotImplementedException();
        }

        void IMouseInput.Move(int x, int y)
        {
            throw new NotImplementedException();
        }

        void IMouseInput.Wheel(Keys.Wheel wheel, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
