using System;
using System.IO;

namespace ViewModel
{
    public static class ImageToBase64Converter
    {
        public static string ImageToBase64(string imagePath)
        {
            try
            {
                if (!File.Exists(imagePath)) return "";
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                return Convert.ToBase64String(imageBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}