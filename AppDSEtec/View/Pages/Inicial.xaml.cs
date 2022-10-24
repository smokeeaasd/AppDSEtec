using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using AppDSEtec.Model;

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

            /*
            Task.Run(async () =>
            {
                Weather clima = new Weather("0a36245bb1a30c1f0a1f2fe343a1401a");
                
                string lat = location.Latitude.ToString();
                string lon = location.Longitude.ToString();

                object res = await clima.GetWeather(lat, lon);

                Device.BeginInvokeOnMainThread(() => {
                    lblClima.Text = res.ToString();
                });
            });
            */
        }
    }
}