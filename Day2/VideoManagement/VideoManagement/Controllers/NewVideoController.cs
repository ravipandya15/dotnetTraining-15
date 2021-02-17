using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoManagement.Models;

namespace VideoManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewVideoController : ControllerBase
    {
        private readonly IVideoRepository videoRepository;

        public NewVideoController(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        [HttpGet]
        public IEnumerable<Video> Get()
        {
            return this.videoRepository.GetAllVideos();
        }

        [HttpGet("{category}")]
        public IEnumerable<Video> Get(string category)
        {
            return this.videoRepository.GetVideosCategory(category);
        }
    }
}
