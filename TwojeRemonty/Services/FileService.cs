using System;
namespace TwojeRemonty.Services
{
	public class FileService
	{
		public string SavePicture(IFormFile formFile)
        {
			var fileName = Guid.NewGuid() + ".jpg";
			var newFile = File.Create("wwwroot/" + fileName);
			formFile.CopyTo(newFile);
			newFile.Close();
			return fileName;
        }
	}
}

