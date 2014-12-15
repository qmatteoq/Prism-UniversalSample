using System.Collections.Generic;
using System.Threading.Tasks;
using Prism_Navigation.Entities;

namespace Prism_Navigation.Services
{
    public interface IFeedService
    {
        Task<IEnumerable<News>> GetNews();
    }
}
