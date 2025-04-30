using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Model
{
    [Table("scores")]
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Bounces { get; set; }
        public int PlayedSeconds { get; set; }

        public virtual Game Game { get; set; }


        public override string ToString()
        {
            return
                $"ID: {Id}" +
                $"bounces: {Bounces}" +
                $"playtime: {PlayedSeconds} s";
        }
    }
}
