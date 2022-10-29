using Firebase.Database;
using Firebase.Database.Query;
using NotificationsDemo2.Models;
using NotificationsDemo2.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NotificationsDemo2.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {

        FirebaseClient client;
        public string Name { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }
        public Command RegisterCommand { get; set; }
        public Command SkipCommand { get; set; }
        
        public RegisterViewModel()
        {
            client = new FirebaseClient("https://realtimedb-39f9d-default-rtdb.firebaseio.com/");
            Token = Preferences.Get("DeviceToken", "شنو انت؟");
            RegisterCommand = new Command(async () => await RegisterAsync());
            SkipCommand = new Command(async () => await SkipAsync());

        }

        private async Task SkipAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new LandingPage());

        }

        private async Task RegisterAsync()
        {
            try
            {
                await client.Child("Subscribers").PostAsync(new Subscriber
                {
                    Address = Address,
                    Name = Name,
                    Token = Token
                });
                Preferences.Set("Username", Name);
                Preferences.Set("Address", Address);
                await App.Current.MainPage.Navigation.PushAsync(new LandingPage());
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("TTT", e.Message, "OK");
            }
        }
    }
}
