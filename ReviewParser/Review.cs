using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;

namespace ReviewParser
{
	public class Review(string url)
	{
		public Review() : this("") { }
		public string Url { get; private set; } = url;
		public string? Username { get; private set; }
		public string? ReviewText { get; private set; }
		public int? Mark {  get; private set; }
		HttpClient client = new HttpClient();

	}
}
