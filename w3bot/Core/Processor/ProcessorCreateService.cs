using Autofac.Features.Indexed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core.Utilities;

namespace w3bot.Core.Processor
{
    internal class ProcessorCreateService : IProcessorCreateService
    {
        private IList<IProcessor> _processorList = new List<IProcessor>();
        private IIndex<ProcessorType, IProcessor> _processorFactory;

        internal ProcessorCreateService(IIndex<ProcessorType, IProcessor> processorFactory)
        {
            _processorFactory = processorFactory;
        }

        public void Add(ProcessorType processorType)
        {
            _processorList.Add(_processorFactory[processorType]);
        }

        public IList<IProcessor> GetAll()
        {
            return _processorList;
        }

        public void Remove(ProcessorType processorType, int index = 0)
        {
            var processor = _processorList.Where(t => t.IsValidProcessor(processorType)).ToList();

            if (processor.Count == 0)
                throw new InvalidOperationException(String.Format("The processor by the name {0} could not be found.", processorType));

            if (index < 0 || index > processor.Count || index == processor.Count) 
                throw new InvalidOperationException("The index could not be higher, smaller or equals than the processor list index.");

            _processorList.Remove(processor[index]);
        }
    }
}
