using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using UploadFileTryer.Helpers;

namespace UploadFileTryer.Controllers
{
    public class Generator : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Generate(string dayName)
        {

            //Licensing:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //Should only declare this one somewhere, not each time method gets called...
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHFqVVhkW1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF9jT39RdEZmX39aeHJUQg==;Mgo+DSMBPh8sVXJ0S0d+XE9AcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3xTcERhW3xbdnRRTmdfVQ==;ORg4AjUWIQA/Gnt2VVhhQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkNiW31ddXJVQmhUVEA=;NjU1MTg0QDMyMzAyZTMxMmUzME1wSE83YUpmZ1ExRnJobUxJZWpkTER4NzRNTWtBVjNXajN0d3dFRTVaRTA9;NjU1MTg1QDMyMzAyZTMxMmUzMGl0R1RZbXhRaVczQ0tNTVhlMm5tczJVamRzUlRsRkovRS8yZWg3RERhVEk9;NRAiBiAaIQQuGjN/V0Z+XU9EaFtFVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdEVlWH1cc3FTRmRVVEFy;NjU1MTg3QDMyMzAyZTMxMmUzMFM4K29VTjYrWWt2eDBCU1Y0amkrdW8rUGFOMGkyazlLcjdQUElac3BjYm89;NjU1MTg4QDMyMzAyZTMxMmUzMFdWWVJDOTUrckxnWlZ3djdjQW1heTB5b3NRT3ErRVZFRkZPclRsOWh2ZWM9;Mgo+DSMBMAY9C3t2VVhhQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkNiW31ddXJVQ2BeUkA=;NjU1MTkwQDMyMzAyZTMxMmUzMFFOWkJQclFOZ01BTEJGNGFDK25pSS9Bd0RtTVNLaTJQKzhmWUxJYk9TTlk9;NjU1MTkxQDMyMzAyZTMxMmUzMFZWL2liR1YxWkZQcTZwdElVVjJJb2dwK25uNDBTSkE0REZOQlFiTFNFVTg9");

            //File locations:
            var fileNameTemplate = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Template.docx");
            var fileNameOutput = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Output.docx");
            var fileExcelSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Events.xlsx");


            //Does the thing.
            WriteDocHelper.WriteDoc(dayName, fileNameTemplate, fileNameOutput, fileExcelSheet);

            return View("Index");
        }


        public ActionResult DownloadDocument()
        {
            var path = (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\Output.docx"));
            string fileName = "Output.docx";

            try
            {

                byte[] fileBytes = System.IO.File.ReadAllBytes(path);

                var pathOutput = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Output.docx");
                var pathDB = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Events.xlsx");

                // ADD METHOD TO DELETE FILES
                System.IO.File.Delete(path);
                System.IO.File.Delete(pathDB);

                return File(fileBytes, "application/force-download", fileName);
            }

            catch (FileNotFoundException)
            {
                return RedirectToAction("NoDownload");
            }
            

        }

        public IActionResult NoDownload()
        {
            return View("NoDownload");
        }
    }
}