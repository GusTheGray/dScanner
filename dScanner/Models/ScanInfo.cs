using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dScanner.Models
{
	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(Nmaprun));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (Nmaprun)serializer.Deserialize(reader);
	// }

	[XmlRoot(ElementName = "scaninfo")]
	public class Scaninfo
	{

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }

		[XmlAttribute(AttributeName = "protocol")]
		public string Protocol { get; set; }

		[XmlAttribute(AttributeName = "numservices")]
		public int Numservices { get; set; }

		[XmlAttribute(AttributeName = "services")]
		public DateTime Services { get; set; }
	}

	[XmlRoot(ElementName = "verbose")]
	public class Verbose
	{

		[XmlAttribute(AttributeName = "level")]
		public int Level { get; set; }
	}

	[XmlRoot(ElementName = "debugging")]
	public class Debugging
	{

		[XmlAttribute(AttributeName = "level")]
		public int Level { get; set; }
	}

	[XmlRoot(ElementName = "status")]
	public class Status
	{

		[XmlAttribute(AttributeName = "state")]
		public string State { get; set; }

		[XmlAttribute(AttributeName = "reason")]
		public string Reason { get; set; }
	}

	[XmlRoot(ElementName = "address")]
	public class Address
	{

		[XmlAttribute(AttributeName = "addr")]
		public string Addr { get; set; }

		[XmlAttribute(AttributeName = "addrtype")]
		public string Addrtype { get; set; }
	}

	[XmlRoot(ElementName = "hostname")]
	public class Hostname
	{

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName = "hostnames")]
	public class Hostnames
	{

		[XmlElement(ElementName = "hostname")]
		public List<Hostname> Hostname { get; set; }
	}

	[XmlRoot(ElementName = "extrareasons")]
	public class Extrareasons
	{

		[XmlAttribute(AttributeName = "reason")]
		public string Reason { get; set; }

		[XmlAttribute(AttributeName = "count")]
		public int Count { get; set; }
	}

	[XmlRoot(ElementName = "extraports")]
	public class Extraports
	{

		[XmlElement(ElementName = "extrareasons")]
		public Extrareasons Extrareasons { get; set; }

		[XmlAttribute(AttributeName = "state")]
		public string State { get; set; }

		[XmlAttribute(AttributeName = "count")]
		public int Count { get; set; }
	}

	[XmlRoot(ElementName = "state")]
	public class State
	{

		[XmlAttribute(AttributeName = "state")]
		public string StateAttribute { get; set; }

		[XmlAttribute(AttributeName = "reason")]
		public string Reason { get; set; }

		[XmlAttribute(AttributeName = "reason_ttl")]
		public int ReasonTtl { get; set; }
	}

	[XmlRoot(ElementName = "service")]
	public class Service
	{
		[XmlElement(ElementName = "cpe")]
		public List<string> Cpe { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "product")]
		public string Product { get; set; }

		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }

		[XmlAttribute(AttributeName = "extrainfo")]
		public string Extrainfo { get; set; }

		[XmlAttribute(AttributeName = "ostype")]
		public string Ostype { get; set; }

		[XmlAttribute(AttributeName = "method")]
		public string Method { get; set; }

		[XmlAttribute(AttributeName = "conf")]
		public int Conf { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "script")]
	public class Script
	{

		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }

		[XmlAttribute(AttributeName = "output")]
		public string Output { get; set; }
	}

	[XmlRoot(ElementName = "port")]
	public class Port
	{

		[XmlElement(ElementName = "state")]
		public State State { get; set; }

		[XmlElement(ElementName = "service")]
		public Service Service { get; set; }

		[XmlElement(ElementName = "script")]
		public Script Script { get; set; }

		[XmlAttribute(AttributeName = "protocol")]
		public string Protocol { get; set; }

		[XmlAttribute(AttributeName = "portid")]
		public int Portid { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "ports")]
	public class Ports
	{

		[XmlElement(ElementName = "extraports")]
		public Extraports Extraports { get; set; }

		[XmlElement(ElementName = "port")]
		public List<Port> Port { get; set; }
	}

	[XmlRoot(ElementName = "portused")]
	public class Portused
	{

		[XmlAttribute(AttributeName = "state")]
		public string State { get; set; }

		[XmlAttribute(AttributeName = "proto")]
		public string Proto { get; set; }

		[XmlAttribute(AttributeName = "portid")]
		public int Portid { get; set; }
	}

	[XmlRoot(ElementName = "osclass")]
	public class Osclass
	{

		[XmlElement(ElementName = "cpe")]
		public string Cpe { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }

		[XmlAttribute(AttributeName = "vendor")]
		public string Vendor { get; set; }

		[XmlAttribute(AttributeName = "osfamily")]
		public string Osfamily { get; set; }

		[XmlAttribute(AttributeName = "osgen")]
		public string Osgen { get; set; }

		[XmlAttribute(AttributeName = "accuracy")]
		public int Accuracy { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "osmatch")]
	public class Osmatch
	{

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "accuracy")]
		public int Accuracy { get; set; }

		[XmlAttribute(AttributeName = "line")]
		public int Line { get; set; }
	}

	[XmlRoot(ElementName = "os")]
	public class Os
	{

		[XmlElement(ElementName = "portused")]
		public List<Portused> Portused { get; set; }

		[XmlElement(ElementName = "osclass")]
		public Osclass Osclass { get; set; }

		[XmlElement(ElementName = "osmatch")]
		public Osmatch Osmatch { get; set; }
	}

	[XmlRoot(ElementName = "uptime")]
	public class Uptime
	{

		[XmlAttribute(AttributeName = "seconds")]
		public int Seconds { get; set; }

		[XmlAttribute(AttributeName = "lastboot")]
		public string Lastboot { get; set; }
	}

	[XmlRoot(ElementName = "distance")]
	public class Distance
	{

		[XmlAttribute(AttributeName = "value")]
		public int Value { get; set; }
	}

	[XmlRoot(ElementName = "tcpsequence")]
	public class Tcpsequence
	{

		[XmlAttribute(AttributeName = "index")]
		public int Index { get; set; }

		[XmlAttribute(AttributeName = "difficulty")]
		public string Difficulty { get; set; }

		[XmlAttribute(AttributeName = "values")]
		public string Values { get; set; }
	}

	[XmlRoot(ElementName = "ipidsequence")]
	public class Ipidsequence
	{

		[XmlAttribute(AttributeName = "class")]
		public string Class { get; set; }

		[XmlAttribute(AttributeName = "values")]
		public double Values { get; set; }
	}

	[XmlRoot(ElementName = "tcptssequence")]
	public class Tcptssequence
	{

		[XmlAttribute(AttributeName = "class")]
		public string Class { get; set; }

		[XmlAttribute(AttributeName = "values")]
		public string Values { get; set; }
	}

	[XmlRoot(ElementName = "hop")]
	public class Hop
	{

		[XmlAttribute(AttributeName = "ttl")]
		public int Ttl { get; set; }

		[XmlAttribute(AttributeName = "ipaddr")]
		public string Ipaddr { get; set; }

		[XmlAttribute(AttributeName = "rtt")]
		public double Rtt { get; set; }

		[XmlAttribute(AttributeName = "host")]
		public string Host { get; set; }
	}

	[XmlRoot(ElementName = "trace")]
	public class Trace
	{

		[XmlElement(ElementName = "hop")]
		public List<Hop> Hop { get; set; }

		[XmlAttribute(AttributeName = "port")]
		public int Port { get; set; }

		[XmlAttribute(AttributeName = "proto")]
		public string Proto { get; set; }
	}

	[XmlRoot(ElementName = "times")]
	public class Times
	{

		[XmlAttribute(AttributeName = "srtt")]
		public int Srtt { get; set; }

		[XmlAttribute(AttributeName = "rttvar")]
		public int Rttvar { get; set; }

		[XmlAttribute(AttributeName = "to")]
		public int To { get; set; }
	}

	[XmlRoot(ElementName = "host")]
	public class Host
	{

		[XmlElement(ElementName = "status")]
		public Status Status { get; set; }

		[XmlElement(ElementName = "address")]
		public Address Address { get; set; }

		[XmlElement(ElementName = "hostnames")]
		public Hostnames Hostnames { get; set; }

		[XmlElement(ElementName = "ports")]
		public Ports Ports { get; set; }

		[XmlElement(ElementName = "os")]
		public Os Os { get; set; }

		[XmlElement(ElementName = "uptime")]
		public Uptime Uptime { get; set; }

		[XmlElement(ElementName = "distance")]
		public Distance Distance { get; set; }

		[XmlElement(ElementName = "tcpsequence")]
		public Tcpsequence Tcpsequence { get; set; }

		[XmlElement(ElementName = "ipidsequence")]
		public Ipidsequence Ipidsequence { get; set; }

		[XmlElement(ElementName = "tcptssequence")]
		public Tcptssequence Tcptssequence { get; set; }

		[XmlElement(ElementName = "trace")]
		public Trace Trace { get; set; }

		[XmlElement(ElementName = "times")]
		public Times Times { get; set; }

		[XmlAttribute(AttributeName = "starttime")]
		public int Starttime { get; set; }

		[XmlAttribute(AttributeName = "endtime")]
		public int Endtime { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "finished")]
	public class Finished
	{

		[XmlAttribute(AttributeName = "time")]
		public int Time { get; set; }

		[XmlAttribute(AttributeName = "timestr")]
		public string Timestr { get; set; }

		[XmlAttribute(AttributeName = "elapsed")]
		public double Elapsed { get; set; }

		[XmlAttribute(AttributeName = "summary")]
		public string Summary { get; set; }

		[XmlAttribute(AttributeName = "exit")]
		public string Exit { get; set; }
	}

	[XmlRoot(ElementName = "hosts")]
	public class Hosts
	{

		[XmlAttribute(AttributeName = "up")]
		public int Up { get; set; }

		[XmlAttribute(AttributeName = "down")]
		public int Down { get; set; }

		[XmlAttribute(AttributeName = "total")]
		public int Total { get; set; }
	}

	[XmlRoot(ElementName = "runstats")]
	public class Runstats
	{

		[XmlElement(ElementName = "finished")]
		public Finished Finished { get; set; }

		[XmlElement(ElementName = "hosts")]
		public Hosts Hosts { get; set; }
	}

	[XmlRoot(ElementName = "nmaprun")]
	public class Nmaprun
	{

		[XmlElement(ElementName = "scaninfo")]
		public Scaninfo Scaninfo { get; set; }

		[XmlElement(ElementName = "verbose")]
		public Verbose Verbose { get; set; }

		[XmlElement(ElementName = "debugging")]
		public Debugging Debugging { get; set; }

		[XmlElement(ElementName = "host")]
		public Host Host { get; set; }

		[XmlElement(ElementName = "runstats")]
		public Runstats Runstats { get; set; }

		[XmlAttribute(AttributeName = "scanner")]
		public string Scanner { get; set; }

		[XmlAttribute(AttributeName = "args")]
		public string Args { get; set; }

		[XmlAttribute(AttributeName = "start")]
		public int Start { get; set; }

		[XmlAttribute(AttributeName = "startstr")]
		public string Startstr { get; set; }

		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }

		[XmlAttribute(AttributeName = "xmloutputversion")]
		public DateTime Xmloutputversion { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

}
