using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using static NET1MDversion2.Person;
using System.ComponentModel.DataAnnotations;

namespace NET1MDversion2
{
    //1 UZD
    public abstract class Person //izmantoju https://www.w3schools.com/cs/cs_properties.php
    {
        [Key]
        public int ID { get; set; }
        public enum GenderType //izmantoju https://stackoverflow.com/questions/37585134/how-to-name-a-gender-property-of-type-gender-in-c-sharp-according-to-naming-conv
        {
            [XmlEnum("Man")]
            Man,
            [XmlEnum("Woman")]
            Woman,
            [XmlEnum("Other")]
            Other,
            [XmlEnum("Unknown")] //nezinu, vai sim ir kada jega, bet bija problemas ar xml
            Unknown
        }
        private GenderType _gender;
        private string _name;
        private string _surname;

        [XmlElement("Name")]
        public string Name
        {
            get { return _name; }
            set { if (!string.IsNullOrEmpty(value)) { _name = value; } } //pārbauda, vai jaunā vērtība ir tukša - šī koda daļa tika izstrādāta ar AI rīka palīdzību
        }
        [XmlElement("Surname")]
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string FullName //izmantoju https://stackoverflow.com/questions/3917796/how-to-implement-a-read-only-property
        {
            get { return $"{Name} {Surname}"; }
        }

        [XmlElement("Gender")]
        public GenderType Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public override string ToString() //izmantoju https://stackoverflow.com/questions/18200427/override-tostring-method-c-sharp
        {
            return $"Name:{Name}, Surname:{Surname}, Full Name:{FullName}, Gender: {Gender}";
        }
    }
}
