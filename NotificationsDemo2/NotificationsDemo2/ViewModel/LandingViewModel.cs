using Firebase.Database;
using FirebaseAdmin.Messaging;
using NotificationsDemo2.Helpers;
using NotificationsDemo2.Models;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NotificationsDemo2.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {

        FirebaseClient client;
        public string Name { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }
        public Subscriber SelectedSubscriber { get; set; }
        public Command HiCommand { get; set; }
        public ObservableCollection<Subscriber> Subscribers { get; set; }
        public LandingViewModel()
        {
            client = new FirebaseClient("https://realtimedb-39f9d-default-rtdb.firebaseio.com/");
            HiCommand = new Command(async () => await HiAsync());
            Subscribers = new ObservableCollection<Subscriber>();
            Subscribers = client.Child("Subscribers").AsObservable<Subscriber>().AsObservableCollection();
        }

        private Task HiAsync()
        {
            // هنا لازم ياخذ التوكن من الفايربيس ويرسل اشعار من الكود
            var token = SelectedSubscriber.Token;
            //FirebaseHelper firebaseHelper = new FirebaseHelper(token);
            Notification notification = new Notification()
            {
                Title = "هذا الاشعار من :" + Preferences.Get("Username", "انونيموس"),
                Body = "اهلا وسهلا عزيزي, جاي اسلم عليك من " + Preferences.Get("Address","يوتوبيا"),                
            };
            FirebaseHelper firebaseHelper = new FirebaseHelper(token, notification);

            return Task.CompletedTask;
        }
    }
}
