using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;





namespace Model
{
    [Table("games")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BallSpeedLeft { get; set; }
        public int BallSpeedTop { get; set; }
        public int BallPositionLeft { get; set; }
        public int BallPositionTop { get; set; }
        public int BatPositionLeft { get; set; }
        public bool IsFinished { get; set; }

        public int UserId { get; set; }
        public int ScoreId { get; set; }

        public virtual User User { get; set; }
        public virtual Score Score { get; set; }


        public override string ToString()
        {
            return
                $"ID: {Id}, " +
                $"ball speed [left, top]: [{BallSpeedTop}, {BallSpeedLeft}], " +
                $"ball position [left, top]: [{BallPositionLeft}, {BallPositionTop}], " +
                $"bat position [left]: [{BatPositionLeft}], " +
                $"finished: {IsFinished}" +
                $"user ID: {UserId}" +
                $"score:\n{Score}";
        }
    }
}
