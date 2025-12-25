using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        private string name;
        private string pass;
        private DateTime dateOfBirth;
        private string mail;
        private string userName;
        public string Name { get => name; set => name = value; }
        public string Pass { get => pass; set => pass = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Mail { get => mail; set => mail = value; }
        public string UserName { get => userName; set => userName = value; }
    }
}
