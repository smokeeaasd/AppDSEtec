using AppDSEtec.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDSEtec
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchUser : ContentPage
    {
        public SearchUser()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Pesquisar_Usuario(object sender, EventArgs e)
        {
            NetworkAccess networkAccess = Connectivity.NetworkAccess;

            if (!(networkAccess == NetworkAccess.Internet || networkAccess == NetworkAccess.ConstrainedInternet))
            {
                await Navigation.PushAsync(new NotInternet());
            } else
            {
                Button btn = (Button)sender;

                btn.IsEnabled = false;

                object response = await Github.GetUser(entryUsuario.Text);
                string serialized = JsonConvert.SerializeObject(response);

                Dictionary<string, string> content = JsonConvert.DeserializeObject<Dictionary<string, string>>(serialized);

                if (content.ContainsKey("message"))
                {
                    if (content["message"] == "Not Found")
                    {
                        await DisplayAlert("Parece que temos um problema!", "Usuário não foi encontrado", "OK");
                            btn.IsEnabled = true;
                        return;
                    }
                }
                App.Current.MainPage = new MainPage()
                {
                    BindingContext = new GithubUser()
                    {
                        AvatarUrl = content["avatar_url"],
                        Followers = $"{content["followers"]} seguidores",
                        Following = $"{content["following"]} seguindo",
                        PublicRepos = $"{content["public_repos"]} repositórios públicos",
                        User = content["login"], // 2000-01-30
                        JoinedAt = $"Entrou em {content["created_at"].Substring(8, 2)}/{content["created_at"].Substring(5, 2)}/{content["created_at"].Substring(0, 4)}"
                    }
                };
            }
        }
    }
}