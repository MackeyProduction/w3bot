using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Api;
using w3bot.Core.Processor;
using w3bot.Core.Utilities;
using w3bot.Wrapper;

namespace w3bot.Tests.UnitTests
{
    [TestClass]
    public class FrameTests
    {
        [TestMethod]
        public void FindText_Frame_ReturnsRectangleWithTextPosition()
        {
            IBotBrowser botBrowser = new ChromiumBrowserAdapter();
            WebProcessor processor = new WebProcessor(botBrowser);
            ProcessorValueContext processorValueContext = new ProcessorValueContext();
            processorValueContext.Processor = processor;
            Frame f = new Frame(processorValueContext);

            f.FindText("foo");
        }
    }
}
