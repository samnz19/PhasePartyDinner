using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScrapperLibrary
{
     
	[XmlRoot(ElementName="p")]
	public class P {
		[XmlElement(ElementName="br")]
		public List<string> Br { get; set; }
		[XmlElement(ElementName="em")]
		public string Em { get; set; }
	}

	[XmlRoot(ElementName="img")]
	public class Img {
		[XmlAttribute(AttributeName="src")]
		public string Src { get; set; }
		[XmlAttribute(AttributeName="width")]
		public string Width { get; set; }
		[XmlAttribute(AttributeName="height")]
		public string Height { get; set; }
		[XmlAttribute(AttributeName="alt")]
		public string Alt { get; set; }
	}

	[XmlRoot(ElementName="a")]
	public class A {
		[XmlElement(ElementName="img")]
		public Img Img { get; set; }
		[XmlAttribute(AttributeName="href")]
		public string Href { get; set; }
		[XmlAttribute(AttributeName="rel")]
		public string Rel { get; set; }
		[XmlAttribute(AttributeName="title")]
		public string Title { get; set; }
	}

	[XmlRoot(ElementName="div")]
	public class Div {
		[XmlElement(ElementName="p")]
		public P P { get; set; }
		[XmlElement(ElementName="a")]
		public A A { get; set; }
		[XmlAttribute(AttributeName="class")]
		public string Class { get; set; }
	}

	[XmlRoot(ElementName="xml")]
	public class Xml {
		[XmlElement(ElementName="div")]
		public Div Div { get; set; }
	}

}