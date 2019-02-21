using System;
using System.Text;
using System.Net;
using System.IO;

namespace TOEC2
{
	class Program
	{
		static void Main(string[] args)
		{
			
			string url = "http://ec2-54-180-114-92.ap-northeast-2.compute.amazonaws.com:8080/IoTSV/getState";  //테스트 사이트
																											   //string url = "localhost";  //테스트 사이트
			string responseText = string.Empty;
			//string data = "{\"thingName\":\"thingMANSEOP\",\"host\":\"a122bm80082l9x-ats.iot.ap-northeast-2.amazonaws.com\",\"accesskey\":\"AKIAJHFEGJVL6SZKXVSA\",\"secretkey\":\"[{"key":"accesskey","value":"AKIAISP4KMD2RGDZS2CQ","type":"text","enabled":true,"description":""},{"key":"secretkey","value":"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","type":"text","enabled":true,"description":""}]\"}";
			//string data = "thingName:NDMCU\nhost:a20szi6ywho1ip-ats.iot.ap-northeast-2.amazonaws.com\naccesskey:AKIAISP4KMD2RGDZS2CQ\nsecretkey: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";
			string thingName = "thingMANSEOP";//사물 이름
			string host = "a122bm80082l9x-ats.iot.ap-northeast-2.amazonaws.com";
			string accesskey = "AKIAJHFEGJVL6SZKXVSA";
			string secretkey = "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";
			

			//string url = "http://ec2-13-209-77-238.ap-northeast-2.compute.amazonaws.com:8080/IoTSV/getState";  //테스트 사이트
			//																								   //string url = "localhost";  //테스트 사이트
			//string responseText = string.Empty;
			////string data = "{\"thingName\":\"NDMCU\",\"host\":\"a20szi6ywho1ip-ats.iot.ap-northeast-2.amazonaws.com\",\"accesskey\":\"AKIAISP4KMD2RGDZS2CQ\",\"secretkey\":\"[{"key":"accesskey","value":"AKIAISP4KMD2RGDZS2CQ","type":"text","enabled":true,"description":""},{"key":"secretkey","value":"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","type":"text","enabled":true,"description":""}]\"}";
			////string data = "thingName:NDMCU\nhost:a20szi6ywho1ip-ats.iot.ap-northeast-2.amazonaws.com\naccesskey:AKIAISP4KMD2RGDZS2CQ\nsecretkey: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";
			//string thingName = "Thermo";
			//string host = "ayk3uywq3no3p-ats.iot.ap-northeast-2.amazonaws.com";
			//string accesskey = "AKIAJDLRRTXMHHCJYV6A";
			//string secretkey = "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";


			string data = string.Format("thingName={0}&host={1}&accesskey={2}&secretkey={3}", thingName, host, accesskey, secretkey);

			//Console.WriteLine(data);

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "POST";
			request.Accept = "application/json";
			request.ContentType = "application/x-www-form-urlencoded";
			request.Timeout = 30 * 1000;
			//request.Headers.Add("Authorization", "BASIC SGVsbG8=");

			// POST할 데이타를 Request Stream에 쓴다
			byte[] bytes = Encoding.ASCII.GetBytes(data);
			request.ContentLength = bytes.Length; // 바이트수 지정

			//Console.WriteLine(bytes.Length);

			using (Stream reqStream = request.GetRequestStream())
			{
				reqStream.Write(bytes, 0, bytes.Length);
			}

			// Response 처리
			using (WebResponse resp = request.GetResponse())
			{
				Stream respStream = resp.GetResponseStream();
				using (StreamReader sr = new StreamReader(respStream))
				{
					responseText = sr.ReadToEnd();
				}
			}
			Console.WriteLine(data);
			Console.WriteLine(responseText);
			Console.WriteLine();
			/*
            var obj = JObject.Parse(responseText);
            var result = obj["data"]["shadow"]["state"]["reported"]["temperature"];
            Console.WriteLine(result);
            */
		}
	}
}