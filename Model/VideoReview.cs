using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class VideoReview : BaseEntity
    {
        public User whoUpdatedTheReview;
        public Video whichVideoDidTheUserReview;
        public DateTime reviewDate;
        public string reviewDescription;

        
        public User WhoUpdatedTheReview { get => whoUpdatedTheReview; set => whoUpdatedTheReview = value; }
        public Video WhichVideoDidTheUserReview { get => whichVideoDidTheUserReview; set => whichVideoDidTheUserReview = value; }
        public DateTime ReviewDate { get => reviewDate; set => reviewDate = value; }
        public string ReviewDescription { get => reviewDescription; set => reviewDescription = value; }
    }
}
