using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace AppDSEtec
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotAllowed : ContentPage
    {
        public NotAllowed()
        {
            InitializeComponent();
        }

        private async void ShowPermissoes_Clicked(object sender, EventArgs e)
        {
            AppInfo.ShowSettingsUI();
        }
    }
}