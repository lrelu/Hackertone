// 네이버 한글인명-로마자변환 Open API 예제
using System;
using System.Net;
using System.Text;
using System.IO;

namespace Dump
{
	public class NaverOpenAPI
	{
		public static string FindLocation(string query)
		{
			string text;
			//string query = "네이버 Open API"; // 검색할 문자열
			string url = "https://openapi.naver.com/v1/search/blog?query=" + query; // 결과가 JSON 포맷
			// string url = "https://openapi.naver.com/v1/search/blog.xml?query=" + query;  // 결과가 XML 포맷
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Headers.Add("X-Naver-Client-Id", "VsuLDbtiZNBqcWXJ9_Xn"); // 클라이언트 아이디
			request.Headers.Add("X-Naver-Client-Secret", "XQrTuSJC07");       // 클라이언트 시크릿
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			string status = response.StatusCode.ToString();
			if (status == "OK")
			{
				Stream stream = response.GetResponseStream();
				StreamReader reader = new StreamReader(stream, Encoding.UTF8);
				text = reader.ReadToEnd();
				Console.WriteLine(text);
			}
			else
			{
				Console.WriteLine("Error 발생=" + status);
				text = "error";
			}

			return text;
		}

		public static string NameChange(string query)
		{
			//string query = "손흥민";
			string url = "https://openapi.naver.com/v1/krdict/romanization?query=" + query;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Headers.Add("X-Naver-Client-Id", "wAc8SUgNjg9SuzV61Wp_");
			request.Headers.Add("X-Naver-Client-Secret", "LuWJT9hip9");
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream stream = response.GetResponseStream();
			StreamReader reader = new StreamReader(stream, Encoding.UTF8);
			string text = reader.ReadToEnd();

			return text;
		}

		public static string SMT(string query)
		{
			string url = "https://openapi.naver.com/v1/language/translate";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Headers.Add("X-Naver-Client-Id", "EqyP97OxXoV7KkaYmyrv"); // 개발자센터에서 발급받은 Client ID
			request.Headers.Add("X-Naver-Client-Secret", " "); // 개발자센터에서 발급받은 Client Secret
			request.Method = "POST";
			//string query = "오늘 날씨는 어떻습니까?";
			
			byte[] byteDataParams = Encoding.UTF8.GetBytes("source=ko&target=en&text=" + query);
			request.ContentType = "application/x-www-form-urlencoded";
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

			return text;
		}
	}
}
