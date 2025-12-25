using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class VideoReview : BaseEntity
    {
        private User whoUpdatedTheReview;
        private Video whichVideoDidTheUserReview;
        private DateTime reviewDate;
        private string reviewDescription;

        
        public User WhoUpdatedTheReview { get => whoUpdatedTheReview; set => whoUpdatedTheReview = value; }
        public Video WhichVideoDidTheUserReview { get => whichVideoDidTheUserReview; set => whichVideoDidTheUserReview = value; }
        public DateTime ReviewDate { get => reviewDate; set => reviewDate = value; }
        public string ReviewDescription { get => reviewDescription; set => reviewDescription = value; }
    }
}
