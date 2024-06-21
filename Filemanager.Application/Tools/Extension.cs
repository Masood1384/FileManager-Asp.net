
namespace Filemanager.Application.Tools
{
    public static class Extension
    {
        public static string ToPersianDate(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + pc.GetDayOfMonth(date);
        }
        public static string ConvertByteArrayToBase64string(byte[] ImageBytes)
        {
            string imageBase64Data = Convert.ToBase64String(ImageBytes);
            string imgDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            return imgDataURL;
        }
        public static byte[] ConvertIFormFileToByteforImage(IFormFile formFile)
        {
            using MemoryStream memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            return imageBytes;
        }

        public static byte[] ConvertIFormFileToByteforFile(IFormFile formFile)
        {
            using MemoryStream memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            return imageBytes;
        }
    }
}
