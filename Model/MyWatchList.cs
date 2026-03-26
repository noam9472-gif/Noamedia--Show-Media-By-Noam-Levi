using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyWatchList : BaseEntity
    {
        private User userId;
        private Video videoId;

        public User UserId { get => userId; set => userId = value; }
        public Video VideoId { get => videoId; set => videoId = value; }
    }
}
