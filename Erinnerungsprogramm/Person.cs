using System;
using System.Collections.Generic;
using System.Text;

namespace Erinnerungsprogramm
{
    /* we only need the primary key data*/
    public struct Person
    {
        public string firstName, lastName, phone1;
        public Person()
        {
            firstName = ""; lastName = ""; phone1 = "";
        }
        public Person(string firstName, string lastName, string phone1)
        {
            this.firstName = firstName; this.lastName = lastName; this.phone1 = phone1;
        }

        override
        public string ToString()
        {
            return firstName + " " + lastName + " " + phone1; 
        }
  
    }



}
