using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using w3bot.Script;

namespace w3bot.Script
{
    public abstract class AbstractScript : Bot
    {
        private bool _running, _pausing;
        private Thread _scriptThread, _drawThread;

        /// <summary>
        /// Gets the name of the script.
        /// </summary>
        public string Name
        {
            get
            {
                return ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "name").GetType().Name;
            }
        }

        /// <summary>
        /// Gets the author of the script.
        /// </summary>
        public string Author 
        { 
            get 
            {
                return ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "author").GetType().Name;
            }
        }

        /// <summary>
        /// Gets the version of the script.
        /// </summary>
        public double Version
        {
            get
            {
                return Double.Parse(ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "version").GetType().Name);
            }
        }

        /// <summary>
        /// Gets the description of the script.
        /// </summary>
        public string Description
        {
            get
            {
                return ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "description").GetType().Name;
            }
        }

        /// <summary>
        /// Gets the target app of the script.
        /// </summary>
        public string TargetApp
        {
            get
            {
                return ScriptManifest.GetCustomAttributes(typeof(AbstractScript)).Single(t => t.GetType().Name == "targetApp").GetType().Name;
            }
        }

        public Bot GetBot()
        {
            return ContainerConfig.Configure().Resolve<Bot>();
        }

        /// <summary>
        /// Gets the script manifest of the app.
        /// </summary>
        /// <returns>Returns an array of attributes with ScriptManifest informations.</returns>
        public Attribute[] GetManifest()
        {
            return ScriptManifest.GetCustomAttributes(typeof(AbstractScript));
        }

        /// <summary>
        /// Stops the script.
        /// </summary>
        public virtual void OnFinish()
        {
            _running = false;
        }

        /// <summary>
        /// Called when the script gets started.
        /// </summary>
        /// <returns>Returns true when the script gets started.</returns>
        public virtual bool OnStart()
        {
            _running = true;
            return true;
        }

        /// <summary>
        /// Called by the script executer.
        /// </summary>
        /// <returns>Returns the tick rate of the script.</returns>
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

        /// <summary>
        /// This method gets called when the script gets paused.
        /// </summary>
        public void OnPause()
        {
            _pausing = true;
        }

        /// <summary>
        /// This method gets called when the script gets resumed.
        /// </summary>
        public void OnResume()
        {
            _pausing = false;
        }

        /// <summary>
        /// Gets the current runtime of the script.
        /// </summary>
        /// <returns>Returns the current runtime in seconds.</returns>
        public int GetRuntime()
        {
            return 0;
        }

        /// <summary>
        /// Gets the total runtime of the script.
        /// </summary>
        /// <returns>Returns the total runtime in seconds.</returns>
        public int GetTotalRuntime()
        {
            return 0;
        }

        /// <summary>
        /// Pauses the current running script for 1000 milliseconds (1 second)
        /// </summary>
        public static void Sleep()
        {
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Pauses the current running script for a given time.
        /// </summary>
        /// <param name="delay"></param>
        public static void Sleep(int delay)
        {
            Thread.Sleep(delay);
        }

        /// <summary>
        /// Pauses the current running script for a given time. The time will be a random value between the two given parameters
        /// </summary>
        /// <param name="minDelay">The minimum time in milliseconds to sleep</param>
        /// <param name="maxDelay">The maximum time in milliseconds to sleep</param>
        public static void Sleep(int minDelay, int maxDelay)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            int delay = ran.Next(minDelay, maxDelay + 1);
            Thread.Sleep(delay);
        }
    }
}
