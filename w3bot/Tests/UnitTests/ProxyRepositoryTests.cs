using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using w3bot.Core.Database.Entity;
using w3bot.Core.Database.Repository;

namespace w3bot.Tests.UnitTests
{
    [TestClass]
    public class ProxyRepositoryTests
    {
        [TestMethod]
        public void FetchId_EntityProxy_ReturnsOneProxyWithExistingId()
        {
            var httpClient = new HttpClient();
            var userAgentRepository = new ProxyRepository(httpClient);

            var result = userAgentRepository.FetchById<Proxy>(1);
            var expectedUserAgent = new UserAgent
            {
                Id = 1,
            };

            Assert.AreEqual(expectedUserAgent.Id, result.Id);
        }

        [TestMethod]
        public void FetchAll_EntityProxyList_ReturnsListOfProxiesWithExistingIds()
        {
            var httpClient = new HttpClient();
            var proxyRepository = new ProxyRepository(httpClient);

            var result = proxyRepository.FetchAll<Proxy>();
            var expectedProxy = new List<Proxy>
            {
                new Proxy
                {
                    Id = 1,
                },
                new Proxy
                {
                    Id = 2,
                },
            };

            for (int i = 0; i < expectedProxy.Count; i++)
            {
                Assert.AreEqual(expectedProxy[i].Id, result[i].Id);
            }
        }
    }
}
