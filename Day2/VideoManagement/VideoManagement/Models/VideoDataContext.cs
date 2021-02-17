using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoManagement.Models
{
    public class VideoDataContext : DbContext
    {
        public VideoDataContext(DbContextOptions<VideoDataContext> options)
            : base(options)
        {

        }
        public DbSet<Video> Videos { get; set; }
    }
}
