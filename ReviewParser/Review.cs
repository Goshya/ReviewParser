using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;

namespace ReviewParser
{
	public class Review(string username, string reviewText, int mark)
	{
		public Review() : this("", "", 0) { }
		public string? Username { get; private set; } = username;
		public string? ReviewText { get; private set; } = reviewText;
		public int? Mark {  get; private set; } = mark;

	}
}
