using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    
        public class VideoList : List<Video>
        {
            public VideoList() { }
            public VideoList(IEnumerable<Video> list) : base(list) { }
            public VideoList(IEnumerable<BaseEntity> list) : base(list.Cast<Video>().ToList()) { }
        }
}
