namespace MyAcademyPortfolio.Entities
{
    public class SkillItem
    {
        public int SkillItemId { get; set; }
        public string SkillItemName { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
