using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace THEArcadeAppAV.Models
{
    [Table("cards")]
    public class Cards
    {
        [PrimaryKey, AutoIncrement]
        public int Id {get; set;}
        public string Name {get; set;}
        public string Image {get; set;}
        public int Attack {get; set;}
        public int Hitpoint {get; set;}
        public string Rarity {get; set;}
    }
}