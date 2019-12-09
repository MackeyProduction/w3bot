using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace w3bot.Script
{
    public abstract class AbstractScript : Bot.Bot
    {
        private bool _running, _pausing;
        private Thread _scriptThread, _drawThread;

        public string Name
        {
            get
            {
                return ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "name").GetType().Name;
            }
        }

        public string Author 
        { 
            get 
            {
                return ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "author").GetType().Name;
            }
        }

        public double Version
        {
            get
            {
                return Double.Parse(ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "version").GetType().Name);
            }
        }

        public string Description
        {
            get
            {
                return ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "description").GetType().Name;
            }
        }

        public string TargetApp
        {
            get
            {
                return ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "targetApp").GetType().Name;
            }
        }

        public Bot.Bot GetBot()
        {
            return ContainerConfig.Configure().Resolve<Bot.Bot>();
        }

        public Attribute[] GetManifest()
        {
            return ScriptManifest.GetCustomAttributes(typeof(AbstractScript));
        }

        public virtual void OnFinish()
        {
            _running = false;
        }

        public virtual bool OnStart()
        {
            _running = true;
            return true;
        }

        public virtual int OnUpdate()
        {
            int delay;

            // script thread
            _scriptThread = new Thread(new ThreadStart(delegate
            {
                if (OnStart())
                {
                    while (_running)
                    {
                        delay = OnUpdate();

                        while (_pausing)
                            Thread.Sleep(100);

                        if (delay < 1)
                            OnFinish();

                        Thread.Sleep(delay);
                    }
                }
                //_bot.core.mainWindow.Invoke((MethodInvoker)delegate { _scriptStopped(); }); //let upper instances know that the script is now stopped
            }));

            // paint thread
            _drawThread = new Thread(new ThreadStart(delegate
            {
                while (_running)
                {
                    //_bot.core.Invalidate(); // main processor have to repaint the paint
                    Thread.Sleep(65);
                }
            }));

            // start threads
            _scriptThread.Start();
            _drawThread.Start();

            return 100;
        }

        public void OnPause()
        {
            _pausing = true;
        }

        public void OnResume()
        {
            _pausing = false;
        }
    }
}
