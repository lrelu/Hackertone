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
			string temp = MakeJson();
			temp = NaverOpenAPI.FindLocation("도서관");
			Console.WriteLine(temp);
		}

		public static string MakeJson()
		{
			JObject json = new JObject();
			json.Add("node1", "node1_value");
			json.Add("node2", "node2_value");

			return json.ToString();
		}

		public static void RunNaverAPI()
		{
			string url = "https://openapi.naver.com/v1/datalab/shopping/categories";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Headers.Add("X-Naver-Client-Id", "hf5c3GitwQe5RNtxnlHz");
			request.Headers.Add("X-Naver-Client-Secret", "p22c2JJzMj");
			request.ContentType = "application/json";
			request.Method = "POST";
			string body = "{\"startDate\":\"2017-08-01\",\"endDate\":\"2017-09-30\",\"timeUnit\":\"month\",\"category\":[{\"name\":\"패션의류\",\"param\":[\"50000000\"]},{\"name\":\"화장품/미용\",\"param\":[\"50000002\"]}],\"device\":\"pc\",\"ages\":[\"20\",\"30\"],\"gender\":\"f\"}";
			byte[] byteDataParams = Encoding.UTF8.GetBytes(body);
			request.ContentLength = byteDataParams.Length;
			Stream st = request.GetRequestStream();
			st.Write(byteDataParams, 0, byteDataParams.Length);
			st.Close();
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream stream = response.GetResponseStream();
			StreamReader reader = new StreamReader(stream, Encoding.UTF8);
			string text = reader.ReadToEnd();
			stream.Close();
			response.Close();
			reader.Close();
			Console.WriteLine(text);
		}
	}
}
