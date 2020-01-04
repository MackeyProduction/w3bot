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

        /// <summary>
        /// Search in form controls for a control with the given name.
        /// </summary>
        /// <param name="controlName">The name of the control.</param>
        /// <returns>Returns the control.</returns>
        public Control GetFormControlByName(string controlName)
        {
            Control controlResult;

            try
            {
                controlResult = Bot._form.Controls.Find(controlName, true).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }

            return controlResult;
        }

        /// <summary>
        /// Search in form controls for a control with the given type.
        /// </summary>
        /// <param name="type">The type of the control.</param>
        /// <returns>Returns the first or default result by the controls enumerable.</returns>
        public Control GetFormControlByType(Type type)
        {
            var controls = Bot._form.Controls.Cast<Control>();

            return controls.Where(ctrl => ctrl.GetType() == type).FirstOrDefault();
        }
    }
}
