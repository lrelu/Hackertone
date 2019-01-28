using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dump
{
	class Program
	{
		public static void Main(string[] args)
		{
			string temp = RunNaverAPI();
			Console.WriteLine(temp);
		}

		public static string MakeJson()
		{
			JObject json = new JObject();
			json.Add("node1", "node1_value");
			json.Add("node2", "node2_value");

			return json.ToString();
		}

		public static string RunNaverAPI()
		{
			//string query = "손흥민";
			string url = "http://www.google.com";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream stream = response.GetResponseStream();
			StreamReader reader = new StreamReader(stream, Encoding.UTF8);
			string text = reader.ReadToEnd();

			return text;
		}
	}
}
