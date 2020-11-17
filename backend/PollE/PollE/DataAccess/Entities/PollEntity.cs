namespace PollE.DataAccess.Entities
{
    public class PollEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public CategoryEntity Category { get; set; }

        public CodeEntity Code { get; set; }
    }
}