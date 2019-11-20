using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Interfaces;

namespace w3bot.Evt
{
    public class Keyboard : IKeyboardInput
    {
        void IKeyboardInput.KeyEvent(char c)
        {
            throw new NotImplementedException();
        }
    }
}
