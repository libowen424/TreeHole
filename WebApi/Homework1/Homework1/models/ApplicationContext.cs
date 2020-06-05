
using Microsoft.EntityFrameworkCore;

namespace Homework1.models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Anon> Anons { get; set; }
        public DbSet<Subreply> Subreplies { get; set; }
        public DbSet<Channel> Channels { get; set; }

    }
}
