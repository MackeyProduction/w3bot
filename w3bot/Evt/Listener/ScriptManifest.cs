using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Evt.Listener
{
    public class ScriptManifest : Attribute
    {
        public string name, targetApp, description, author;
        public double version, minApi, maxApi;
        public ScriptManifest(string name, string targetApp, string description, string author, double version = 0.0, double minApi = 0.0, double maxApi = 0.0)
        {
            this.name = name;
            this.targetApp = targetApp;
            this.description = description;
            this.author = author;
            this.version = version;
            this.minApi = minApi;
            this.maxApi = maxApi;
        }

        public ScriptManifest(bool defaultValues = true)
        {
            if (defaultValues)
            {
                this.name = "Unnamed";
                this.targetApp = "Not specified";
                this.description = "No description available";
                this.author = "Unknown";
            }
        }
    }
}
