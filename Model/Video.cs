using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noamedia__Show_Media_By_Noam_Levi
{
    public class Video : Base_entity
    {
        private DateTime videoUploadedDate;
        private int lengthInMinutes;
        private string whoUploadedTheVideo;
        private string videoName;
        private string genre;
        private int ageOfVideo;
        private string videoAddress;

        public DateTime VideoUploadedDate { get => videoUploadedDate; set => videoUploadedDate = value; }
        public int LengthInMinutes { get => lengthInMinutes; set => lengthInMinutes = value; }
        public string WhoUploadedTheVideo { get => whoUploadedTheVideo; set => whoUploadedTheVideo = value; }
        public int Id { get => id; set => id = value; }
        public string VideoName { get => videoName; set => videoName = value; }
        public string Genre { get => genre; set => genre = value; }
        public int AgeOfVideo { get => ageOfVideo; set => ageOfVideo = value; }
        public string VideoAddress { get => videoAddress; set => videoAddress = value; }
    }
}
