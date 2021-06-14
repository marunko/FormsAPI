using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormsAPI
{
    class Validator
    {

        public int Name(string name)
        {
            if(name.Length > 2 && name.Length < 50)
            {
                if(Regex.IsMatch(name, @"[A-z]"))
                return 1;
            }

            return -1;
        }
        public int Password(string pass)
        {
            
            if (pass.Length > 8 && pass.Length < 100)
            {
                if(Regex.IsMatch(pass, @"[0-9]") && Regex.IsMatch(pass, @"[A-Z]"))
                {
                    return 1;
                }
            }
            return -1;
        }
        public bool age(int age)
        {
            if(age >= 0 && age < 120) return true;
            return false;
        }
        public int Email(string email)
        {
            return -1;
        }

        public bool Body(string body)
        {
            if(body.Length > 40 && body.Length < 4500)
            {
                return true;
            }
            return false;
        }
        public bool Title(string body)
        {
            if (body.Length > 5 && body.Length < 255)
            {
                return true;
            }
            return false;
        }

    }
}
