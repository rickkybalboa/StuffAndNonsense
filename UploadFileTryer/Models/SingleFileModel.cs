using System.ComponentModel.DataAnnotations;
namespace UploadFileTryer.Models
{
    public class SingleFileModel : ResponseModel
    {
        [Required(ErrorMessage = "Please enter file name")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "Please select file")]
        public IFormFile File { get; set; }
    }


}
