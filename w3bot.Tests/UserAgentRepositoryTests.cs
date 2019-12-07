using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using w3bot.Core.Database.Entity;
using w3bot.Core.Database.Repository;

namespace w3bot.Tests.UnitTests
{
    [TestClass]
    public class UserAgentRepositoryTests
    {
        [TestMethod]
        public void FetchId_EntityUserAgent_ReturnsOneUserAgentWithExistingId()
        {
            var httpClient = new HttpClient();
            var userAgentRepository = new UserAgentRepository(httpClient);

            var result = userAgentRepository.FetchById<UserAgent>(1070);
            var expectedUserAgent = new UserAgent
            {
                Id = 1070,
                OperatingSystem = new OperatingSystem
                {
                    Id = 1074,
                    Name = "Windows",
                    Version = "7",
                },
                Software = new Software
                {
                    Id = 1072,
                    Name = "Internet Explorer",
                    Version = "11.0",
                    LEName = "Trident",
                    LEVersion = "7.0",
                },
                Agent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko\r",
            };

            Assert.AreEqual(expectedUserAgent.Id, result.Id);
        }

        [TestMethod]
        public void FetchAll_EntityUserAgentList_ReturnsListOfUserAgentsWithExistingIds()
        {
            var httpClient = new HttpClient();
            var proxyRepository = new UserAgentRepository(httpClient);
            
            var result = proxyRepository.FetchAll<UserAgent>();
            var expectedUserAgent = new List<UserAgent>
            {
                new UserAgent
                {
                    Id = 1070,
                },
                new UserAgent
                {
                    Id = 1071
                },
            };

            for (int i = 0; i < expectedUserAgent.Count; i++)
            {
                Assert.AreEqual(expectedUserAgent[i].Id, result[i].Id);
            }
        }
    }
}
