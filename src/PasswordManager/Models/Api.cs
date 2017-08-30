using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PasswordManager.Models
{
    [Table("Apis")]
    public class Api
    {
        [Key]
        public int Id { get;set; }
        public string Name { get;set; }
        public string Key { get;set; }
        public string Link { get;set; }
        public virtual ApplicationUser User { get; set; }

    }
}
