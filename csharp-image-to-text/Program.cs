using System;
using System.IO;
using System.Reflection;

namespace csharp_image_to_text
{
    internal class Program
    {
        private static readonly string BIN_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private static readonly string TesseractPATH = "C:\\Program Files (x86)\\Tesseract-OCR";


        private static string ConvertImageToText(string path)
        {
            var service = new TesseractService(TesseractPATH, "eng", $"{TesseractPATH}\\tessdata", $"{BIN_PATH}\\output");
            var stream = File.OpenRead(path);
            return service.GetText(stream);
        }

        static void Main(string[] args)
        {
            string text = ConvertImageToText($"{BIN_PATH}\\image.png");
            Console.WriteLine(text);

            Console.WriteLine("\nEnter any key to exit.");
            Console.ReadLine();
        }
    }
}
