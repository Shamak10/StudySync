using SQLite;

namespace StudySync.Models
{
    public class StudyTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Subject { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}