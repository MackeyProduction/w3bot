using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core.Utilities;

namespace w3bot.Core.Processor
{
    internal class ProcessorService : IProcessorService
    {
        private IList<IProcessor> _processors;
        private IProcessorCreateService _processorCreateService;

        internal ProcessorService(IProcessorCreateService processorCreateService)
        {
            _processorCreateService = processorCreateService;
            _processors = _processorCreateService.GetAll();
        }

        public IList<IProcessor> GetAll()
        {
            return _processors;
        }

        public IList<IProcessor> GetAllByType(ProcessorType processorType)
        {
            return _processors.Where(item => item.IsValidProcessor(processorType)).ToList();
        }

        public IProcessor GetById(int id)
        {
            if ((_processors.Count - 1) < id || id < 0)
                return null;

            return _processors[id];
        }

        public IProcessor GetProcessor(ProcessorType processorType)
        {
            return _processors.Where(item => item.IsValidProcessor(processorType)).FirstOrDefault();
        }
    }
}
