using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CustomHttpHandler.App_Start
{
    public class SimpleHttpModule : IHttpModule
    {
        private StreamWriter sw;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            if (!File.Exists("logger.txt"))
            {
                sw = new StreamWriter(@"C:\Users\User\source\repos\CustomHttpHandler\CustomHttpHandler\logger.txt");
            }
            else
            {
                sw = File.AppendText("logger.txt");
            }
            sw.WriteLine("User Sends Request at {0}", DateTime.Now);
            sw.Close();
        }
    }
}