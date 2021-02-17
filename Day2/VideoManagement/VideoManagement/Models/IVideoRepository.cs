using System.Collections.Generic;

namespace VideoManagement.Models
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetAllVideos();
        IEnumerable<Video> GetVideosCategory(string category);
    }
}