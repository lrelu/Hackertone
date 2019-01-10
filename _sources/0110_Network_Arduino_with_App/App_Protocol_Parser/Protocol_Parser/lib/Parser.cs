using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol_Parser.lib
{
	class Parser
	{
		public static bool Text(string data, out string temperature, out string huminity, out string bright, out string distance)
		{
			// 파싱할 값 초기화
			temperature = string.Empty;
			huminity = string.Empty;
			bright = string.Empty;
			distance = string.Empty;

			// 정의한 프로토콜에 따라 값 분할
			string[] datas = data.Split('|');

			try
			{
				temperature = datas[0];
				huminity = datas[1];
				bright = datas[2];
				distance = datas[3];

				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Json(string data, out string temperature, out string huminity, out string bright, out string distance)
		{
			// 파싱할 값 초기화
			temperature = string.Empty;
			huminity = string.Empty;
			bright = string.Empty;
			distance = string.Empty;

			try
			{
				// Json형식일 경우에 양쪽의 {, }를 지워줌
				data = data.Substring(1, data.Length - 2);

				// 쉼포에 의해 분할
				string[] datas = data.Split(',');

				temperature = datas[0].Split(':')[1];
				huminity = datas[1].Split(':')[1];
				bright = datas[2].Split(':')[1];
				distance = datas[3].Split(':')[1];

				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool IsJson(string data)
		{
			// 간단하게 시리얼로 입력받은 데이터의 시작과 끝이 {, }이면 Json 타입이라고 생각함
			if (data.StartsWith("{") && data.EndsWith("}"))
				return true;
			else
				return false;
		}
	}
}
