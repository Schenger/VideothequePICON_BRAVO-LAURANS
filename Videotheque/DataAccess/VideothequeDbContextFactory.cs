using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace Videotheque.DataAccess
{
    class VideothequeDbContextFactory : IDesignTimeDbContextFactory<VideothequeDbContext>
    {
        public VideothequeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VideothequeDbContext>();
            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), "database.db"));

            return new VideothequeDbContext(optionsBuilder.Options);
        }
    }
}
