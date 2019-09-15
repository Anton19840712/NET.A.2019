using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FileCabinet
{
    /// <summary>
    /// Class of Person with fields and [attridutes] for designed XML serialization
    /// </summary>

    [XmlRoot("person")]
    public class Person
    {
        //private string _Firstname;

        [XmlAttribute("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is compulsory")]
        [StringLength(8, ErrorMessage = "Please less then 8 character")]
        [RegularExpression(@"^[A-Z][a-z]{1,8}$")]
        [XmlElement("FirstName")]

        public string FirstName { get; set; }

        [StringLength(15, ErrorMessage = "Please less then 20 character")]
        [RegularExpression(@"^[A-Z][a-z]{1,20}$")]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("BirthDate")]
        public DateTime BirthDate { get; set; }

    }
}
