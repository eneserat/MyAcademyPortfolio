namespace MyAcademyPortfolio.Entities
{
    public class ProjectSkill
    {
        public int ProjectSkillId { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int SkillItemId { get; set; }
        public SkillItem SkillItem { get; set; }
    }
}