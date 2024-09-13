using HtmlAgilityPack;
using System;
using System.Text;

namespace ReviewParser
{
	public class Program
	{
		public static void Main()
		{
			WBParser test = new WBParser("C:\\Users\\Goshya\\Desktop\\wb3.html");

			//test.Load();

			Console.WriteLine(test.clientResult);
			List<Review> revs = new List<Review>();

			//revs = test.ParseReviews();


			test.WriteReviewsIntoFile("C:\\Users\\Goshya\\Desktop\\reviews.txt");
			/*
			StreamWriter stream = new StreamWriter("C:\\Users\\Goshya\\Desktop\\reviews.txt", true, Encoding.UTF8);
			//FileStream file = new FileStream("C:\\Users\\Goshya\\Desktop\\reviews.txt", FileMode.OpenOrCreate);

			foreach (Review rev in revs)
			{
				if (rev.ReviewText != "")
				{
					string text = $"{rev.ReviewText}	{rev.Mark}";
					byte[] buffer = Encoding.Default.GetBytes(text);
					//StreamWriter stream = new StreamWriter("C:\\Users\\Goshya\\Desktop\\reviews.txt", true, Encoding.Default, buffer.Length);
					//file.Write(buffer, 0, buffer.Length);
					stream.WriteLine(text);
					Console.WriteLine(rev.Mark);
				}
			}
			*/

		}
	}
}