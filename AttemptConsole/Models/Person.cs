﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AttemptConsole
{
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