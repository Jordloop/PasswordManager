using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PasswordManager.Models
{
    [Table("Sites")]
    public class Site
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ApplicationUser User { get; set; }


        public static string GeneratePassword()
        {            
            string pass = "Test";
            return pass;
        }
    }
 }