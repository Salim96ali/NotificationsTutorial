using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotificationsDemo2.Droid
{
    internal class MainApplication : Application
    {
        public MainApplication(IntPtr handle,JniHandleOwnership transfer) : base(handle, transfer)
        {

        }
        public override void OnCreate()
        {
            base.OnCreate();
            // Set the default notification channel for app when running android
            if (Build.VERSION.SdkInt>= Android.OS.BuildVersionCodes.O)
            {
                // change your default notification channel id here
                FirebasePushNotificationManager.DefaultNotificationChannelId =
                    "FirebasePushNotificationChannel";
                // change your default notification channel id here
                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";


            }
            // if debug you should reset the token each time
#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
            FirebasePushNotificationManager.Initialize(this, false);
#endif
            // handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                
            };
        }
    }
}