using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoManagement.Models
{
    public class VideoRepository : IVideoRepository
    {
        private readonly VideoDataContext _ctx;
        public VideoRepository(VideoDataContext ctx)
        {
            this._ctx = ctx;
        }

        public IEnumerable<Video> GetAllVideos()
        {
            return _ctx.Videos.OrderBy(p => p.Title).ToList();
        }

        public IEnumerable<Video> GetVideosCategory(string category)
        {
            return _ctx.Videos.Where(p => p.Category == category).ToList();
        }

        //public Video CreateVideo(Video video)
        //{
        //    Video v = _ctx.Videos.FirstOrDefault(v => v.Title.ToLower() == video.Title.ToLower());

        //    if (v == default(Video))
        //    {

        //    }
        //}

        //public Video UpdateVideo(Video video)
        //{
        //    Video v = _ctx.Videos.FirstOrDefault(v => v.Title.ToLower() == video.Title.ToLower());

        //    if (v == default(Video))
        //    {

        //    }
        //}
    }
}
