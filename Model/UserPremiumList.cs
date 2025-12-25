using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  
    
        public class UserPremiumList : List<UserPremium>
        {
        public UserPremiumList() { }
        public UserPremiumList(IEnumerable<UserPremium> list) : base(list) { }
        public UserPremiumList(IEnumerable<BaseEntity> list) : base(list.Cast<UserPremium>().ToList()) { }
    }
}
