using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Web.Syndication;
using Prism_Navigation.Entities;

namespace Prism_Navigation.Services
{
    public class FeedService : IFeedService
    {
        public async Task<IEnumerable<News>> GetNews()
        {
            SyndicationClient client = new SyndicationClient();
            SyndicationFeed feed = await client.RetrieveFeedAsync(new Uri("http://feeds.feedburner.com/qmatteoq_eng", UriKind.Absolute));
            IEnumerable<News> news = feed.Items.Select(x => new News {Title = x.Title.Text, Summary = x.Summary.Text});
            return news;
        }
    }
}
