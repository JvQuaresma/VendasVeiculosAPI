namespace VeiculosAPI.Logs {
    public static class Functions {

        public static void LogToFile(string title, string logMessage) {

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var projectDirectory = Directory.GetParent(baseDirectory)?.Parent?.Parent?.Parent?.FullName;


            string path = Path.Combine(projectDirectory,"SalesLog",DateTime.Now.ToString("ddMMyyyy") + ".txt");

            StreamWriter swLog;

            if (File.Exists(path)) {

                swLog = File.AppendText(path);

            }else {

                swLog = new StreamWriter(path);

            }

            swLog.WriteLine("Log:");
            swLog.WriteLine(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());

            swLog.WriteLine($"Título da Mensagem: {title}");
            swLog.WriteLine($"Mensagem: {logMessage}");

            swLog.WriteLine("--------------------------------------------");
            swLog.WriteLine("");
            swLog.Close(); 

        }

    }
}
