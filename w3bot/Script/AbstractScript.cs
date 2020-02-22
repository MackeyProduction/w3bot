using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using w3bot.Input;
using w3bot.Util;

namespace w3bot.Script
{
    public abstract class AbstractScript : Bot, IScript
    {
        private Thread _scriptThread;
        private ScriptManifest _scriptManifest;

        public AbstractScript()
        {

        }

        /// <summary>
        /// Gets the name of the script.
        /// </summary>
        public string Name
        {
            get
            {
                return Manifest.name;
            }
        }

        /// <summary>
        /// Gets the author of the script.
        /// </summary>
        public string Author 
        { 
            get 
            {
                return Manifest.author;
            }
        }

        /// <summary>
        /// Gets the version of the script.
        /// </summary>
        public double Version
        {
            get
            {
                return Manifest.version;
            }
        }

        /// <summary>
        /// Gets the description of the script.
        /// </summary>
        public string Description
        {
            get
            {
                return Manifest.description;
            }
        }

        /// <summary>
        /// Gets the target app of the script.
        /// </summary>
        public string TargetApp
        {
            get
            {
                return Manifest.targetApp;
            }
        }

        /// <summary>
        /// Gets the current state of the script.
        /// </summary>
        public ScriptUtils.State CurrentState { get; set; }

        /// <summary>
        /// Gets the script manifest of the app.
        /// </summary>
        public ScriptManifest Manifest
        {
            get
            {
                return GetManifest();
            }

            set
            {
                _scriptManifest = value;
            }
        }

        /// <summary>
        /// Gets the script manifest of the app.
        /// </summary>
        /// <returns>Returns the ScriptManifest with all relevant information.</returns>
        private ScriptManifest GetManifest()
        {
            try
            {
                if (_scriptManifest != null)
                {
                    return _scriptManifest;
                }

                var assembly = Assembly.GetAssembly(this.GetType());
                var attributes = Attribute.GetCustomAttributes(assembly.GetTypes().FirstOrDefault());
                _scriptManifest = (ScriptManifest)attributes.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }

            return _scriptManifest;
        }

        /// <summary>
        /// Stops the script.
        /// </summary>
        public virtual void OnFinish()
        {
            CurrentState = ScriptUtils.State.STOP;
        }

        /// <summary>
        /// Called when the script gets started.
        /// </summary>
        /// <returns>Returns true when the script gets started.</returns>
        public virtual void OnStart()
        {
            CurrentState = ScriptUtils.State.START;
        }

        /// <summary>
        /// Called by the script executer.
        /// </summary>
        /// <returns>Returns the tick rate of the script.</returns>
        public virtual int OnUpdate()
        {
            // script thread
            //GetExecutable(CurrentState).Start();

            return 100;
        }

        /// <summary>
        /// This method gets called when the script gets paused.
        /// </summary>
        public void OnPause()
        {
            CurrentState = ScriptUtils.State.PAUSING;
        }

        /// <summary>
        /// This method gets called when the script gets resumed.
        /// </summary>
        public void OnResume()
        {
            CurrentState = ScriptUtils.State.RESUME;
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

        public Thread GetExecutable(ScriptUtils.State state)
        {
            int delay;

            // avoid multiple initialization of script thread
            if (_scriptThread != null)
            {
                return _scriptThread;
            }

            try
            {
                // script thread
                _scriptThread = new Thread(new ThreadStart(delegate
                {
                    OnStart();
                    while (CurrentState.Equals(ScriptUtils.State.START))
                    {
                        delay = OnUpdate();

                        while (CurrentState.Equals(ScriptUtils.State.PAUSING))
                            Thread.Sleep(100);

                        if (delay < 1)
                            OnFinish();

                        Thread.Sleep(delay);
                    }
                    //_bot.core.mainWindow.Invoke((MethodInvoker)delegate { _scriptStopped(); }); //let upper instances know that the script is now stopped
                }));
            } catch (Exception e)
            {
                Status.Warning(e.Message);
            }

            return _scriptThread;
        }
    }
}
