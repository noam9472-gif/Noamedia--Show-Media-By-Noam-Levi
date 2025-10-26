using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class AgeOfVideos
    {
        private string identityCard;
        private string description;

        public string IdentityCard { get => identityCard; set => identityCard = value; }
        public string Description { get => description; set => description = value; }
    }
}
