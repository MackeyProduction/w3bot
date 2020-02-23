using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core.Utilities;

namespace w3bot.Core.Processor
{
    interface IProcessorService
    {
        IList<IProcessor> GetAllByType(ProcessorType processorType);
        IProcessor GetById(int id);
        IProcessor GetProcessor(ProcessorType processorType);
    }
}
