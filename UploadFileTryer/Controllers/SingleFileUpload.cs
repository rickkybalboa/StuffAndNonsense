using Microsoft.AspNetCore.Mvc;
using UploadFileTryer.Models;

namespace UploadFileTryer.Controllers
{
    public class SingleFileUpload : Controller
    {
        public IActionResult Index()
        {
            var pathOutput = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Output.docx");
            var pathDB = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Events.xlsx");

            if (System.IO.File.Exists(pathOutput) || System.IO.File.Exists(pathDB))
            {
                System.IO.File.Delete(pathOutput);
                System.IO.File.Delete(pathDB);
            }


            SingleFileModel model = new SingleFileModel();
            return View(model);
        }



        // Gets the file from user
        [HttpPost]
        public IActionResult Upload(SingleFileModel model)
        {
            try
            {
                if (model.File.Length > 0)
                {
                    model.IsResponse = true;

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                    //create folder if not exist
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    //get file extension
                    FileInfo fileInfo = new FileInfo(model.File.FileName);
                    //string fileName = model.FileName + fileInfo.Extension;
                    string fileName = "Events" + fileInfo.Extension;

                    string fileNameWithPath = Path.Combine(path, fileName);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        model.File.CopyTo(stream);
                    }
                    model.IsSuccess = true;
                    model.Message = "File upload successfully";


                    string dayName = model.FileName.ToString();
                    
                    new Generator().Generate(dayName);
                    //return RedirectToAction("Generate", "Generator", new { dayName = dayName });

                    return Json(new { success = true });
                    //return View("Index", model);

                    //ALL I WANT is for a message to display when the user has uploaded the file.
                    // return View("Index", model);

                    //return View(myModel.Upload, myModel.Confirm);

                }
                else
                {

                }


            }
            catch (Exception e)
            {
                //model.IsSuccess = false;
                //model.Message = e.ToString();
                //return View("Index", model);

                return Json(new { success = false, Exception = e.ToString() });
            }

            return Json(new { success = false });

        }
    }
}

