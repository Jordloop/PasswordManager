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

        //Generates a "random" password
        public static string GeneratePassword()
        {            
            char[] upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] lower = "abcdefghijklmnopqustuvqxyz".ToCharArray();
            char[] number = "0123456789".ToCharArray();
            char[] symbol = " !#$%&()*+,-./:;<=?@[]^_`{|}~".ToCharArray();
            string result = "";
            Random rng = new Random();

            for (int i = 0; i < 4; i++)
            {
                result += upper[rng.Next(0, 27)].ToString();
                result += lower[rng.Next(0, 27)].ToString();
                result += number[rng.Next(0, 10)].ToString();
                result += symbol[rng.Next(0, 30)].ToString();
            }
            result = Shuffle(result);
            return result;
        }

        //Randomizes the order of characters in an inputted string
        public static string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }


    }
 }