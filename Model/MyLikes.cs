using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyLikes : BaseEntity
    {
        private Video videoId;
        private User userId;

        public Video VideoId { get => videoId; set => videoId = value; }
        public User UserId { get => userId; set => userId = value; }
    }
}
