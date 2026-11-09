namespace MyAcademyPortfolio.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillTitle { get; set; }
        public string SubTitle { get; set; }
        public List<SkillItem> SkillItems { get; set; }
    }
}
