using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using w3bot.GUI;

namespace w3bot.Tests.UnitTests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Initialize_WhenCoreInitialized_ReturnsBotInstance()
        {
            // Arrange
            Core.Core.Initialize(new Core.Core(), new Bot.Bot(), new Core.FormControl());

            // Act
            var bot = Core.Core.bot;

            // Assert
            Assert.ReferenceEquals(new Bot.Bot(), bot);
        }

        [TestMethod]
        public void Initialize_WhenCoreInitialized_ReturnsCoreInstance()
        {
            Core.Core.Initialize(new Core.Core(), new Bot.Bot(), new Core.FormControl());
            var core = Core.Core._core;
            Assert.ReferenceEquals(new Core.Core(), core);
        }

        [TestMethod]
        public void Initialize_WhenCoreInitialized_ReturnsFormControlInstance()
        {
            Core.Core.Initialize(new Core.Core(), new Bot.Bot(), new Core.FormControl());

            var core = Core.Core._core;
            var logbox = core.logbox;
            var tabs = core.tabs;
            var mainWindow = core.mainWindow;

            Assert.ReferenceEquals((new Core.Core()).logbox, logbox);
            Assert.ReferenceEquals((new Core.Core()).tabs, tabs);
            Assert.ReferenceEquals((new Core.Core()).mainWindow, mainWindow);
        }

        [TestMethod]
        public void ReInit_TabPagesCleared_ReturnsInteger()
        {
            var main = new Main();

            var core = Core.Core._core;
            core.tabs.TabPages.Add("Test");
            core.tabs.TabPages.Add("Test 2");
            Core.Core.ReInit();
            
            Assert.AreEqual(0, core.tabs.TabPages.Count);
        }

        [TestMethod]
        public void AppendTextToLog_LogMessageIsEqual_ReturnsString()
        {
            var main = new Main();
            Dictionary<string, Color> msgList = new Dictionary<string, Color>();
            
            msgList.Add("This is an error.", Color.Red);
            msgList.Add("This is a log message.", Color.Black);
            msgList.Add("This is a warning.", Color.Orange);

            foreach (KeyValuePair<string, Color> msg in msgList)
            {
                Assert.AreEqual(String.Format("[{0}:{1}:{2}]\t\t{3}\n", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, msg.Key), Core.Core.AppendTextToLog(msg.Key, msg.Value));
            }
        }
    }
}
