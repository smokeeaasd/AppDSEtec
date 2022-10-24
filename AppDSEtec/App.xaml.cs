using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static Xamarin.Essentials.Permissions;

namespace AppDSEtec
{
    public partial class App : Application
    {
        public App()
        {
            NetworkAccess networkAccess = Connectivity.NetworkAccess;

            InitializeComponent();

            if (networkAccess == NetworkAccess.Internet || networkAccess == NetworkAccess.ConstrainedInternet)
            {
                MainPage = new NavigationPage(new SearchUser());
            }
            else
            {
                MainPage = new NotInternet();
            }
        }

        protected async override void OnStart()
        {
        }

        protected async override void OnSleep()
        {

        }

        protected override void OnResume()
        {
            NetworkAccess networkAccess = Connectivity.NetworkAccess;

            Geolocation.GetLocationAsync();

            if (!(networkAccess == NetworkAccess.Internet || networkAccess == NetworkAccess.ConstrainedInternet))
            {
                MainPage = new NotInternet();
            }
        }
    }
}
