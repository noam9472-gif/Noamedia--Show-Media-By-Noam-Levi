using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VideoReviewList:List<VideoReview>
    {
        public VideoReviewList() { }
        public VideoReviewList(IEnumerable<VideoReview> list) : base(list) { }
        public VideoReviewList(IEnumerable<BaseEntity>list):base(list.Cast<VideoReview>().ToList()) { }
    }
}
