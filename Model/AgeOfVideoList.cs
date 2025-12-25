using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    
        public class AgeOfVideoList : List<AgeOfVideos>
        {
            public AgeOfVideoList() { }
            public AgeOfVideoList(IEnumerable<AgeOfVideos> list) : base(list) { }
            public AgeOfVideoList(IEnumerable<BaseEntity> list) : base(list.Cast<AgeOfVideos>().ToList()) { }
        }
    }



