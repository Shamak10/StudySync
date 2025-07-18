using SQLite;

namespace StudySync.Models
{
    public class StudyGoal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Subject { get; set; }
        public int TargetTasks { get; set; }

        [Ignore] // This property is calculated in the ViewModel
        public int CompletedTasks { get; set; }

        [Ignore]
        public double Progress => TargetTasks > 0 ? (double)CompletedTasks / TargetTasks : 0;

        [Ignore]
        public bool IsCompleted => Progress >= 1;
    }
}