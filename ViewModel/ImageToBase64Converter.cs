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
                if (!File.Exists(imagePath)) return ""; // מחזיר מחרוזת ריקה אם הקובץ לא קיים
                byte[] imageBytes = File.ReadAllBytes(imagePath); // קריאת הקובץ לבייטים
                return Convert.ToBase64String(imageBytes); // המרת הבייטים למחרוזת Base64
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); 
                return null;
            }
        }
    }
}