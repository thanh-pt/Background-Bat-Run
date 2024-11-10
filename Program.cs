using System;
using System.Diagnostics;
using System.IO;

namespace BackgroundBatRun
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            string batFilePath = args[0];

            if (!File.Exists(batFilePath))
            {
                return;
            }

            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = batFilePath,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };

                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi chạy file .bat: {ex.Message}");
            }
        }
    }
}
