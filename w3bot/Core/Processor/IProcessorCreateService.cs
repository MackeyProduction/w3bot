using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core.Utilities;

namespace w3bot.Core.Processor
{
    interface IProcessorCreateService
    {
        void Add(ProcessorType processorType);
        void Remove(ProcessorType processorType, int index = 0);
        IList<IProcessor> GetAll();
    }
}
