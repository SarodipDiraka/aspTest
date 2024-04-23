using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models
{
    public class Entity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}