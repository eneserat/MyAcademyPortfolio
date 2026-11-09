using Microsoft.EntityFrameworkCore;
using MyAcademyPortfolio.Entities;

namespace MyAcademyPortfolio.Context
{
    public class PortfolioContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-K8G0IBR\\SQLEXPRESS;Database=PortfolioDbMyAcademy;integrated security=true; trust server certificate=true");
        }
        public DbSet<About>Abouts { get; set; }
        public DbSet<Education>Educations { get; set; }
        public DbSet<Experience>Experiences { get; set; }
      
        public DbSet<Message>Messages { get; set; }
        public DbSet<Contact>Contacts { get; set; }
        public DbSet<HeroSection>HeroSections  { get; set; }
        public DbSet<Project>Projects { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Skill>Skills { get; set; }
        public DbSet<SkillItem>SkillItems { get; set; }
        public DbSet<ProjectSkill>ProjectSkills { get; set; }
        public DbSet<SiteSetting>SiteSettings { get; set; }
    }
}
