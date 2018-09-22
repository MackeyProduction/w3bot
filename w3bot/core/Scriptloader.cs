using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using w3bot.evt;
using w3bot.interfaces;
using w3bot.listener;

namespace w3bot.core
{
    internal class Scriptloader
    {
        /// <summary>
        /// Loads all scripts from the compiled folder.
        /// </summary>
        /// <returns>Returns a list of scripts.</returns>
        internal List<ScriptItem> LoadScripts()
        {
            var dir = BotDirectories.compiledDir;
            var scriptItem = new ScriptItem();
            var scriptItemList = new List<ScriptItem>();

            try
            {
                if (Directory.Exists(dir) || !Directory.EnumerateFileSystemEntries(dir).Any())
                {
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        // loading assembly file
                        var assembly = Assembly.LoadFile(file);
                        var types = assembly.GetTypes();
                        Attribute[] attributes = null;
                        ScriptManifest manifest = null;

                        // loading attributes
                        for (int i = 0; i < types.Length; i++)
                        {
                            attributes = Attribute.GetCustomAttributes(types[i]);

                            // get information from assembly file
                            for (int j = 0; j < attributes.Length; j++)
                            {
                                manifest = (ScriptManifest)attributes[j];
                                dynamic classInformation = Activator.CreateInstance(types[i]); // creates an instance of an assembly file

                                // is the class of type IScript?
                                if (classInformation is IScript)
                                {
                                    scriptItem.script = (IScript)classInformation;

                                    // exists an manifest?
                                    if (manifest != null)
                                        scriptItem.manifest = manifest;
                                    else
                                        scriptItem.manifest = null;

                                    scriptItemList.Add(scriptItem);
                                }
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e) { }

            return (scriptItemList.Count > 0) ? scriptItemList : null;
        }

        /// <summary>
        /// Compiles a raw .cs file from the src directory in a dll file.
        /// </summary>
        internal void CompileScripts()
        {
            var dir = BotDirectories.sourceDir;
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            try
            {
                if (Directory.Exists(dir) || !Directory.EnumerateFileSystemEntries(dir).Any())
                {
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        if (file.EndsWith(".cs"))
                        {
                            // add assemblies
                            foreach (var assemblies in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
                            {
                                if (!assemblies.Name.StartsWith("CefSharp"))
                                    parameters.ReferencedAssemblies.Add(assemblies.Name + ".dll");
                            }
                            parameters.ReferencedAssemblies.Add("w3bot.exe");

                            // disable generate in memory and generate executable to build file in folder
                            parameters.OutputAssembly = file.Remove(file.Length - 3, 3) + ".dll";
                            parameters.GenerateExecutable = false;
                            parameters.GenerateInMemory = false;

                            // compiles to a dll file
                            CompilerResults results = provider.CompileAssemblyFromFile(parameters, file);

                            if (results.Errors.HasErrors)
                            {
                                StringBuilder sb = new StringBuilder();

                                foreach (CompilerError error in results.Errors)
                                {
                                    sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                                }

                                Status.Warning(sb.ToString());
                            } else
                            {
                                var split = file.Split('\\');
                                var fileName = split[split.Length - 1];
                                var fileDir = fileName.Remove(fileName.Length - 3, 3) + ".dll";
                                var compiledFileDir = BotDirectories.compiledDir + "\\" + fileDir;
                                var srcFileDir = BotDirectories.sourceDir + "\\" + fileDir;

                                if (File.Exists(compiledFileDir))
                                {
                                    var curFile = new FileInfo(compiledFileDir).Length;
                                    var generatedFile = new FileInfo(srcFileDir).Length;

                                    // is the file size larger then the file size in the compiled folder?
                                    if (generatedFile > curFile)
                                        File.Move(srcFileDir, compiledFileDir);
                                    else
                                        File.Delete(srcFileDir);
                                }
                                else
                                {
                                    File.Move(srcFileDir, compiledFileDir);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Download a script from www and compiles to a dll file.
        /// </summary>
        /// <param name="url">URL to raw pastebin paste.</param>
        internal void CompileScriptFromWWW(string url)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                if (url.Contains("pastebin") && url.Contains("raw"))
                {
                    string htmlCode = client.DownloadString(url);

                    if (htmlCode.Contains("class"))
                    {
                        var index = htmlCode.IndexOf("class");
                        var newCode = htmlCode.Substring(index, 100);
                        var split = newCode.Split(' ');

                        client.DownloadFile(url, BotDirectories.sourceDir + @"\" + split[1] + ".cs");
                        CompileScripts();
                    }
                }
            }
        }
    }
}
