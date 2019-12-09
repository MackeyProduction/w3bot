using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core.Utilities;

namespace w3bot.Core.Processor
{
    internal class ProcessorService
    {
        private IEnumerable<IProcessor> _processors;

        internal ProcessorService(IEnumerable<IProcessor> processors)
        {
            _processors = processors;
        }

        internal IProcessor GetProcessor(ProcessorType processorType)
        {
            return _processors.Single(item => item.IsValidProcessor(processorType));
        }
    }
}
