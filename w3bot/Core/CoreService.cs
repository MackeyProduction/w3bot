using System;
using w3bot.Core.Database.Repository;
using w3bot.Core.Processor;
using w3bot.Core.Script;
using w3bot.Core.Utilities;

namespace w3bot.Core
{
    internal class CoreService
    {
        internal static CoreInformation Information { get { return new CoreInformation(); } }
        private readonly IRepositoryService _repositoryService;
        private readonly IProcessorService _processorService;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes the core.
        /// </summary>
        /// <param name="form">The form instance.</param>
        internal CoreService(IRepositoryService repositoryService, IProcessorService processorService, ILogger logger)
        {
            _repositoryService = repositoryService;
            _processorService = processorService;
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
