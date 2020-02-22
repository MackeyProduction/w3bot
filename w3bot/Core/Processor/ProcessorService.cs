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

        internal ProcessorService(IList<IProcessor> processors)
        {
            _processors = processors;
        }

        public object Clone()
        {
            var p = new List<IProcessor>();

            foreach (var item in _processors)
            {
                p.Add(item);
            }

            return new ProcessorService(p);
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
