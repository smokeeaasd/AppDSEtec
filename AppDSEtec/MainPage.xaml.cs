using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using AppDSEtec.Controls;

namespace AppDSEtec
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();

            foreach (Xamarin.Forms.View view in flyout.InicialStackLayout.Children.ToList())
            {
                if (typeof(TargetButton) == view.GetType())
                {
                    TargetButton botao = (TargetButton)view;

                    botao.Clicked += Page_Clicked;
                }
            }
        }

        private void Page_Clicked(object sender, EventArgs e)
        {
            TargetButton botao = (TargetButton)sender;

            Detail = new NavigationPage((Page)Activator.CreateInstance(botao.TargetPage));
            IsPresented = false;
        }
    }
}
