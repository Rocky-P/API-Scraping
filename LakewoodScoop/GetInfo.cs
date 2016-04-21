using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;

namespace LakewoodScoop
{
    public class GetInfo
    {
        public IEnumerable<Data> GetStories()
        {
            var client = new WebClient();
            string html = client.DownloadString("http://www.thelakewoodscoop.com/");
            HtmlParser parser = new HtmlParser();
            var document = parser.Parse(html);
            var itemDetails = document.QuerySelectorAll(".post");
            List<Data> stories = new List<Data>();
            foreach (var itemDetail in itemDetails)
            {
                Data story = new Data();
                var anchor = itemDetail.QuerySelector("h2 a");
                story.Title = anchor.TextContent;
                story.Url = anchor.GetAttribute("href");
                var excerpt = itemDetail.QuerySelector("p");
                if (excerpt != null)
                {
                    story.Blurb = excerpt.TextContent;
                }
                var commentsTd = itemDetail.QuerySelector(".backtotop a").TextContent;
                //story.Comments = int.Parse(commentsTd);
                story.Comments = commentsTd;
                var imageHolder = itemDetail.QuerySelector("p a img");
                if (imageHolder != null)
                {
                    story.Image = imageHolder.GetAttribute("src");
                }
                stories.Add(story);
            }
            return stories;
        }
    }
}
