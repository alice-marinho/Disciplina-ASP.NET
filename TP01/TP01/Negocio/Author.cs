using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Negocio
{
    internal class Author
    {
        private String name;
        private String email;
        private char gender;

        public Author(string name, string email, char gender)
        {
            this.name = name;
            this.email = email;
            this.gender = gender;
        }

        public string GetName() {return name;}

        public string GetEmail() {return email;}

        public char GetGender(){ return gender;}

        public override string ToString()
        {
            return $"Author[name={name}, email={email},genre={gender}]";
        }

    }
}
