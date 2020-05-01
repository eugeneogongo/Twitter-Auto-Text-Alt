using FileUploadService.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                var result = tesseractEngine.Process(Pix.LoadFromFile(path));
                return result.GetText().Trim();

            }catch(Exception ex)
            {
                Log.E(ex.Message);
                return null;
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
    }
}
