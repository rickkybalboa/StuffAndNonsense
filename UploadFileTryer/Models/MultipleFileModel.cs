﻿namespace UploadFileTryer.Models
{
    public class MultipleFilesModel : ResponseModel
    {
        //[Required(ErrorMessage = "Please select files")]
        public List<IFormFile> Files { get; set; }
    }
}
