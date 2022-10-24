using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace AppDSEtec.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicial : ContentPage
    {
        public Inicial()
        {
            InitializeComponent();

            ushort horas = Convert.ToUInt16(DateTime.Now.Hour);

            if (horas >= 6 && horas <= 12)
            {
                lblTitulo.Text = "Bom dia!";
            }
            else if (horas > 12 && horas <= 17)
            {
                lblTitulo.Text = "Boa tarde!";
            }
            else if (horas > 17 || (horas < 6))
            {
                lblTitulo.Text = "Boa noite!";
            }
        }
    }
}