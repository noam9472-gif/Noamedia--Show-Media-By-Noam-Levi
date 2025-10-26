using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class VideoReview
    {
        private string identityCard;
        private string WhoUpdatedTheReview;
        private string WhichVideoDidTheUserReview;
        private DateTime ReviewDate;
        private string ReviewDescription;

        public string IdentityCard { get => identityCard; set => identityCard = value; }
        public string WhoUpdatedTheReview1 { get => WhoUpdatedTheReview; set => WhoUpdatedTheReview = value; }
        public string WhichVideoDidTheUserReview1 { get => WhichVideoDidTheUserReview; set => WhichVideoDidTheUserReview = value; }
        public DateTime ReviewDate1 { get => ReviewDate; set => ReviewDate = value; }
        public string ReviewDescription1 { get => ReviewDescription; set => ReviewDescription = value; }
    }
}
