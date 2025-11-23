using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserPremium : User
    {
        private string identityCard;

        public string IdentityCard { get => identityCard; set => identityCard = value; }
    }
}
