using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noamedia__Show_Media_By_Noam_Levi
{
    public class Video : BaseEntity
    {
        private DateTime videoUploadedDate;
        private int lengthInMinutes;
        private User whoUploadedTheVideo;
        private string videoName;
        private Genre genre;
        private AgeOfVideos ageOfVideo;
        private string videoAddress;

        public DateTime VideoUploadedDate { get => videoUploadedDate; set => videoUploadedDate = value; }
        public int LengthInMinutes { get => lengthInMinutes; set => lengthInMinutes = value; }
        public User WhoUploadedTheVideo { get => whoUploadedTheVideo; set => whoUploadedTheVideo = value; }
        public string VideoName { get => videoName; set => videoName = value; }
        public Genre Genre { get => genre; set => genre = value; }
        public AgeOfVideos AgeOfVideo { get => ageOfVideo; set => ageOfVideo = value; }
        public string VideoAddress { get => videoAddress; set => videoAddress = value; }
    }
}
