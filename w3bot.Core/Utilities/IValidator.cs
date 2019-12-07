using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core.Utilities
{
    public interface IValidator
    {
        /// <summary>
        /// Proof the incoming value if is valid.
        /// </summary>
        /// <param name="validator">The value which you want to proof.</param>
        /// <returns>Returns true if the validation is successful. Otherwise returns false.</returns>
        bool IsValid(string validator);
    }
}
