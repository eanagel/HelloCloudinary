using System;
using System.IO;
using System.CodeDom.Compiler;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;


namespace HelloCloudinary
{
	public partial class MainClass
	{
		// NOTE: Secrets.cs contains the definitions for CLOUD_NAM, API_KEY and API_SECRET

		public static string AddPhoto(Stream photoStream)
		{
			var cloudinary = new Cloudinary(new Account(CLOUD_NAME, API_KEY, API_SECRET));

			ImageUploadResult result = cloudinary.Upload(new ImageUploadParams {
				File = new FileDescription("my-image.jpg", photoStream),
			});

			if (result.Error != null)
				throw new Exception(result.Error.Message);

			return result.Uri.ToString();
		}


		public static void Main(string[] args)
		{
			Console.WriteLine("Hello Cloudinary!");

			Console.WriteLine("Uploading lucy.jpg...");

			try
			{
				using (var file = new FileStream("lucy.jpg", FileMode.Open))
				{
					Console.WriteLine("file length = {0} bytes", file.Length);
					string url = AddPhoto(file);
					Console.WriteLine("Uploaded to: {0}", url);
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Upload failed: {0}", ex.Message);
			}
		}
	}
}
