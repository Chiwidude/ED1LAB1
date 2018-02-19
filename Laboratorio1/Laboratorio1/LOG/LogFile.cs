using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace Laboratorio1.LOG
{
    public class LogFile
    {
        private Stopwatch time;
     
        public LogFile()
        {
            time = new Stopwatch();
            time.Start();
        }
    
    public void StartTimer()
    {

    }  
      public void Logcreate(string action)
        {
            string date = DateTime.Today.Day.ToString() + "_" + DateTime.Today.DayOfWeek.ToString() +"_" + DateTime.Today.Month.ToString()+"_" + DateTime.Today.Year.ToString();
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filepath = filepath + @"\Log" + date +".txt";
            FileStream stream = File.Create(filepath);
            StreamWriter writer = new StreamWriter(stream);
            time.Stop();
            writer.WriteLine(action + ":" + " " + time.ElapsedMilliseconds + " " +  "Milisegundos" + " " + DateTime.Now);
            writer.Close();
            stream.Close();
        }
        
    }
}