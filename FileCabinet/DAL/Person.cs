using System;
using System.Xml.Serialization;

namespace FileCabinet
{
    /// <summary>
    /// Class of Person with fields and [attridutes] for designed XML serialization
    /// </summary>
    [XmlRoot("person")]
    public class Person
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("Firstname")]
        public string Firstname { get; set; }

        [XmlElement("Lastname")]
        public string Lastname { get; set; }

        [XmlElement("BirthDate")]
        public DateTime BirthDate { get; set; }

    }
}
