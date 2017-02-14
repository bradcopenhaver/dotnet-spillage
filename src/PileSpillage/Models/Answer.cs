using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PileSpillage.Models
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public int QuestionId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual Question Question { get; set; }
    }
}
