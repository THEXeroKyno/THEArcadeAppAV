using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AudioToolbox;
using THEArcadeAppAV.Models;

namespace THEArcadeAppAV;

public partial class Cat : ContentPage
{
    public Cat()
	{
		InitializeComponent();
		BindingContext = new Catinfo();
	}
}