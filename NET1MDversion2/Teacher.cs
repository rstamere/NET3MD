using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NET1MDversion2
{
    //2 UZD
    public class Teacher : Person  //subclass
    {
        public Teacher() { } //parameterless constructor for serialization
        public Teacher(string name, string surname, GenderType gender, DateTime contractDate) //konstruktors, jo bija error (VS piedāvājo šo, kā labojumu)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            ContractDate = contractDate;
        }

        [XmlElement("ContractDate")]
        public DateTime ContractDate { get; set; }
        public override string ToString() => $"{base.ToString()}, Date: {ContractDate.ToShortDateString()}\n"; //
    }
}
