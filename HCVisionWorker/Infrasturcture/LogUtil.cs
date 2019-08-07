using System;
using System.IO;

namespace HCVisionWorker.Infrasturcture
{
    public static class LogUtil
    {
        public static void Write(string str, string name = "")
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = string.Format(@"{0}\log\{1}-{2}.txt", baseDirectory, name, DateTime.Now.ToString("yyyy-MM-dd"));

            if (!Directory.Exists($"{baseDirectory}\\log"))
                Directory.CreateDirectory($"{baseDirectory}\\log");

            FileStream fs;
            if (!File.Exists(filePath))
                fs = new FileStream(filePath, FileMode.Create);
            else
                fs = new FileStream(filePath, FileMode.Append);

            str = $"{DateTime.Now.ToString()}: ${str} \r\n";
            StreamWriter sw = new StreamWriter(fs);
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            sw.WriteLine(System.Text.Encoding.Default.GetChars(data));
            sw.Close();
            fs.Close();
        }
    }
}
