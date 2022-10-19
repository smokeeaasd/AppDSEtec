using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDSEtec
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            flyout.listView.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;

            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                flyout.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
