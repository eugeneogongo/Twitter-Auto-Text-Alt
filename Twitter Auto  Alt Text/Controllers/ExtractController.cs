using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Twitter_Auto__Alt_Text.OCR;

namespace Twitter_Auto__Alt_Text.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExtractController : ControllerBase
    {
        [HttpPut]
        public ActionResult Index()
        {

            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    ProcessImage.GrayScale(fullPath);
                    var dictresponse = new Dictionary<string, string>();
                    var alttext = ProcessImage.ExtractText(ProcessImage.GetGrayedImage(fullPath));
                    if (alttext.Length > 0)
                    {
                        alttext = "Image may contain the following text: " + alttext;
                    }
                    dictresponse.Add("text",alttext);
                    //clean file
                    ProcessImage.DeleteFile(fullPath);

                    return Content(JsonConvert.SerializeObject(dictresponse), "application/json");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            
        }
    }
}