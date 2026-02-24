using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{


    public class MyLikesList : List<MyLikes>
    {
        public MyLikesList() { }
        public MyLikesList(IEnumerable<MyLikes> list) : base(list) { }
        public MyLikesList(IEnumerable<BaseEntity> list) : base(list.Cast<MyLikes>().ToList()) { }
    }
}



