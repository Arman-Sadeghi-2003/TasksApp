using System.Text.Json.Serialization;

namespace TasksApp.Model
{
    public class TaskModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime AddedDateTime { get; } = DateTime.Now;
        public DateTime TargetDate { get; set; } = DateTime.Now.AddDays(1);
        public bool IsDone { get; set; } = false;

        [JsonIgnore]
        public Brush taskColor { get; set; } = new SolidColorBrush(new Color());

        [Obsolete]
        public string TaskColorHex
        {
            get { return ((SolidColorBrush)taskColor).Color.ToHex(); }
            set { taskColor = new SolidColorBrush(Color.FromHex(value)); }
        }
    }
}
