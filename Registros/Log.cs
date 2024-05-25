﻿namespace VeiculosAPI.Logs {
    public static class Log {

        public static void LogToFile(string title, string logMessage) {

            string fileName = DateTime.Now.ToString("ddMMyyyy") + ".txt";

            StreamWriter swLog;

            if (File.Exists(fileName)) {

                swLog = File.AppendText(fileName);

            }else {

                swLog = new StreamWriter(fileName);

            }

            swLog.WriteLine("Log:");
            swLog.WriteLine(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString);

            swLog.WriteLine($"Título da Mensagem: {title}");
            swLog.WriteLine($"Mensagem: {logMessage}");

            swLog.WriteLine("-------------------------------------------");
            swLog.WriteLine("");
            swLog.Close(); 

        }

    }
}
