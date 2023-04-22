// Test API

// using System.Net.Http;
using System;
using System.Net;
using System.IO;

class TestAPI
{
	public static void Main(String[] args)
	{
		Console.Write("Enter the location: ");
		String location = Console.ReadLine();
		HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + location + "&appid=abe3a0f4d0b6cebfbe7393b4b4e3aa28&units=metric"));
		WebReq.Method = "GET";
		HttpWebResponse WebRes = (HttpWebResponse)WebReq.GetResponse();
		// Console.WriteLine(WebRes.StatusCode);
		Stream dataStream = WebRes.GetResponseStream();
		StreamReader reader = new StreamReader(dataStream);
		var data = reader.ReadToEnd();
		int indexOfTemperature = data.IndexOf("temp");
		indexOfTemperature = indexOfTemperature + 6;
		Console.WriteLine("Temperature of " + location + " is: " + data.Substring(indexOfTemperature, 4));
	}
}