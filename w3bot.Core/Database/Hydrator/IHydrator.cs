using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core.Database.Hydrator
{
    interface IHydrator
    {
        T Hydrate<T>(dynamic result);
    }
}
