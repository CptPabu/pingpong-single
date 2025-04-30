using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Model
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<Game> Games { get; set; }


        public override string ToString()
        {
            return
                $"ID: {Id}, " +
                $"name: {Name}, " +
                $"e-mail: {Email}, " +
                $"games:\n{Games}";
        }
    }
}
