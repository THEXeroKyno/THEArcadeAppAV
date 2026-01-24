using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace THEArcadeAppAV.Models;

[Table("users")]
public class Users
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set;}
    [MaxLength(250), Unique]
    public string Username { get; set;}
    [MaxLength(250), Unique]
    public string Password { get; set;}
    

    //store card data
    public int abigal {get; set;}
	public int blue {get; set;}
	public int coral {get; set;}
	public int cursed {get; set;}
	public int hot_pepper {get; set;}
	public int noback {get; set;}
	public int robin {get; set;}
	public int greenman {get; set;}
	public int tuna {get; set;}
	public int yay {get; set;}
	public int yayy {get; set;}
	public int testingimage {get; set;}

    public Users()
    {
        abigal = 0;
        blue = 0;
        coral = 0;
        cursed = 0;
        hot_pepper = 0;
        noback = 0;
        robin = 0;
        greenman = 0;
        tuna = 0;
        yay = 0;
        yayy = 0;
        testingimage = 0;
    }
}