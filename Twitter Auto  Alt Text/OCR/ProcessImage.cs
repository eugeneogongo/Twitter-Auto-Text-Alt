using FileUploadService.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tesseract;

namespace Twitter_Auto__Alt_Text.OCR
{
    public class ProcessImage
    {
        private static TesseractEngine tesseractEngine;
        public static string ExtractText(string path)
        {
            try
            {
                tesseractEngine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);

                var result = tesseractEngine.Process(Pix.LoadFromFile(path), PageSegMode.Auto);
                
                return result.GetText().Trim();

            } catch (Exception ex)
            {
                Log.E(ex.StackTrace);
                return "";
            }
        }

        /// <summary>
        /// Initialize TesseractEngine
        /// </summary>
        public static void Init()
        {
            if (tesseractEngine == null)
            {
                tesseractEngine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);
            }
        }
        public static string GetGrayedImage(string path)
        {
            var filepath = Path.GetPathRoot(path);
            var filename = Path.GetFileName(path);
            return Path.Combine(filepath, "g" + filename);
        }


    public static void DeleteFile(string filename)
        {
            Thread t = new Thread(() =>
            {
                File.Delete(filename);
            });

            t.Start();
        }
    }
}
