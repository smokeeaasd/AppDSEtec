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
        static LocationAlways locationAlways = new LocationAlways();
        static LocationWhenInUse locationWhenInUse = new LocationWhenInUse();

        static PermissionStatus locAlwaysStatus = locationAlways.CheckStatusAsync().Result;

        static PermissionStatus locWhenInUseStatus = locationWhenInUse.CheckStatusAsync().Result;

        public App()
        {
            NetworkAccess networkAccess = Connectivity.NetworkAccess;

            Geolocation.GetLocationAsync();

            InitializeComponent();

            if (networkAccess == NetworkAccess.Internet || networkAccess == NetworkAccess.ConstrainedInternet)
            {
                if (locAlwaysStatus == PermissionStatus.Granted || locWhenInUseStatus == PermissionStatus.Granted)
                {
                    MainPage = new MainPage();
                }
                else
                {
                    MainPage = new NotAllowed();
                }
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

            if (networkAccess == NetworkAccess.Internet || networkAccess == NetworkAccess.ConstrainedInternet)
            {
                if (locAlwaysStatus == PermissionStatus.Granted || locWhenInUseStatus == PermissionStatus.Granted)
                {
                    MainPage = new MainPage();
                }
                else
                {
                    MainPage = new NotAllowed();
                }
            }
            else
            {
                MainPage = new NotInternet();
            }
        }
    }
}
