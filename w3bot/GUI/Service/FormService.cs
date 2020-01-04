using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Script;

namespace w3bot.GUI.Service
{
    public class FormService
    {
        public FormService()
        {

        }

        public Control GetFormControl(string controlName)
        {
            Control controlResult;

            try
            {
                controlResult = Bot._form.Controls.Find(controlName, true).FirstOrDefault(); // TODO: Remove this hack and add form in constructor.
            }
            catch (Exception e)
            {
                throw e;
            }

            return controlResult;
        }
    }
}
