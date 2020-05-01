using Twitter_Auto__Alt_Text.OCR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;

namespace Twitter_Auto__Alt_Text.OCR.Tests
{
    [TestClass()]
    public class ProcessImageTests
    {
        [TestMethod()]
        public void ExtractTextTest()
        {
            ProcessImage.Init();
            var imagepath = "OCR/testimage.jpg";
            Assert.IsTrue(
        File.Exists(imagepath),
        "Deployment failed: {0} did not get deployed.",
        imagepath
        );
            var text = ProcessImage.ExtractText(imagepath);
            Assert.IsNotNull(text);
            Debug.WriteLine(text);

        }

        [TestMethod()]
        public void InitTest()
        {
            ProcessImage.Init();
            Assert.IsTrue(true);
        }
    }
}