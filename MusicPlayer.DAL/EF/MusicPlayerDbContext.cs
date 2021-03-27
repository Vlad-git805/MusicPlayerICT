using System;
using System.Data.Entity;
using System.Linq;

namespace MusicPlayer.DAL.EF
{
    public class MusicPlayerDbContext : DbContext
    {
      
        public MusicPlayerDbContext()
            : base("name=MusicPlayerDbContext")
        {
        }

        public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

   
}