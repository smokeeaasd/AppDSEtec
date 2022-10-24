using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDSEtec
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotInternet : ContentPage
    {
        public NotInternet()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}