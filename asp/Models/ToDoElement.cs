using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models
{
    [Table("to_do_elements")]
    public class ToDoElement : Entity
    {
        [Column("text")]
        public string Text { get; set; }

        [Column("completed")]
        public bool Completed { get; set; }

        public ToDoElement(string text)
        {
            Id = 0;
            Text = text;
            Completed = false;
        }
    }
}