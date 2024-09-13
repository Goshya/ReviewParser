using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewParser
{
	public class WBParser(string url)
	{
		public string Url { get; private set; } = url;
		HttpClient client = new HttpClient();
		public string clientResult;

		public void Load()
		{
			clientResult = client.GetStringAsync(Url).Result;
		}

		public List<Review> ParseReviews()
		{
			var document = new HtmlDocument();
			if (!Url.StartsWith("http"))
			{
				document.Load(Url);
			}
			else
			{
				this.Load();
				document.LoadHtml(clientResult);
			}
			List<Review> reviews = new List<Review>();
			foreach (var review in document.DocumentNode.SelectNodes("//li[@itemprop='review']").ToArray())
			{
				var innerHtml = new HtmlDocument();
				innerHtml.LoadHtml(review.InnerHtml);

				string username = innerHtml.DocumentNode.SelectSingleNode("//p[@class='feedback__header']").InnerText;
				string reviewText = "";
				if (innerHtml.DocumentNode.SelectSingleNode("//p[@itemprop='reviewBody']") is not null)
				{
					reviewText = innerHtml.DocumentNode.SelectSingleNode("//p[@itemprop='reviewBody']").GetDirectInnerText();
				}
				//Console.WriteLine(reviewText);
				int reviewMark = 0;
				for (int i=1; i <= 5; i++)
				{
					if (innerHtml.DocumentNode.SelectSingleNode($"//span[@class='feedback__rating stars-line star{i}']") is not null)
					{
						reviewMark = i;
					}
				}

				reviews.Add(new Review(username, reviewText, reviewMark));
			}

			return reviews;
		}

		public void WriteReviewsIntoFile(string path)
		{
			List<Review> reviews = this.ParseReviews();
			StreamWriter stream = new StreamWriter(path, true, Encoding.UTF8);
			int goodReviews = 0;
			int badReviews = 0;

			foreach (var review in reviews) 
			{
				//string text = review.ReviewText;
				Console.WriteLine(goodReviews + "	" + badReviews);
				if (review.Mark < 5) badReviews++; 
				if (review.ReviewText != "" && (goodReviews <= badReviews || review.Mark < 5))
				{
					if (review.Mark == 5) goodReviews++;
					//Console.WriteLine(review.ReviewText);
					string text = "";
					string[] reviewWords = review.ReviewText.Split();
					for (int i = 0;i < reviewWords.Length - 1; i++)
					{
						text += $"{reviewWords[i]} ";
					}
					text += $"{reviewWords[reviewWords.Length - 1]}";
					text += $"	{review.Mark}";
					stream.WriteLine(text);
				}
				
				//stream.WriteLine($"{review.ReviewText}	{review.Mark}");
			}
		}
	}

}
