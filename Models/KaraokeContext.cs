using Microsoft.EntityFrameworkCore;

namespace KaraokeApi.Models
{
    public class KaraokeContext : DbContext
    {
        public KaraokeContext(DbContextOptions<KaraokeContext> options)
            : base(options)
        {
        }


        public DbSet<Song> Songs { get; set; }
        public DbSet<KaraokeSession> Sessions {get; set; }
        public DbSet<StageName> StageNames {get;set;}
        public DbSet<AdminUser> AdminUsers {get;set;}
        

    }
}