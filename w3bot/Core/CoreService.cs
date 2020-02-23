using System;
using w3bot.Core.Database.Repository;
using w3bot.Core.Processor;
using w3bot.Core.Script;
using w3bot.Core.Utilities;

namespace w3bot.Core
{
    internal class CoreService
    {
        internal CoreInformation Information { get { return new CoreInformation(); } }
        private readonly IRepositoryService _repositoryService;
        private readonly IProcessorService _processorService;
        private readonly IProcessorCreateService _processorCreateService;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes the core.
        /// </summary>
        /// <param name="form">The form instance.</param>
        internal CoreService(IRepositoryService repositoryService, IProcessorService processorService, IProcessorCreateService processorCreateService, ILogger logger)
        {
            _repositoryService = repositoryService;
            _processorService = processorService;
            _processorCreateService = processorCreateService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the repository service for creating a repository.
        /// </summary>
        /// <returns>Returns the repository service.</returns>
        internal IRepositoryService GetRepositories()
        {
            return _repositoryService;
        }

        /// <summary>
        /// Gets the processor service for bot initialization.
        /// </summary>
        /// <returns>Returns a service which holds the processors.</returns>
        internal IProcessorService GetProcessors()
        {
            return _processorService;
        }

        /// <summary>
        /// Gets the create service for create new instances of processors.
        /// </summary>
        /// <returns>Returns a service which creates new instances and add to the processor list.</returns>
        internal IProcessorCreateService GetCreateService()
        {
            return _processorCreateService;
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <returns>Returns an logger instance.</returns>
        internal ILogger GetLogger()
        {
            return _logger;
        }

        /// <summary>
        /// Initializes the script loader.
        /// </summary>
        /// <returns>Returns an instance of the script loader.</returns>
        internal Scriptloader GetScriptloader()
        {
            return new Scriptloader();
        }
    }
}
