﻿using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace NotificationsDemo2.Helpers
{
    internal class FirebaseHelper
    {

        public FirebaseHelper(string token)
        {
            
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson("{\r\n  \"type\": \"service_account\",\r\n  \"project_id\": \"realtimedb-39f9d\",\r\n  \"private_key_id\": \"837df2d81c351a72667913fe93321fd974b4203b\",\r\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQChL8zSA3saHfc6\\nlkdMHHMU74rXsLuTm7X18U0TU2au5/RVS67uDC1LfzvxOHmTpJbB0KfEL6hKpo/4\\nHsjdc7hguxOmGQg+12wwOkRSIQ8C1mbFdaJ36q70w1LYPfyGU+zFafnkry6ndyx+\\nisb+VUvYOkktwkNrg1iq2PjVynIuYY5SQcbZOxHpVATAQoEyAg0As9DiI0zRq9en\\n+xmKilqjiCKWq6tBqbX5CSMShw/XE9mL04l3qaTJH0451x+Q9kkFBhiO1IMrIuH/\\nSibZ5Em/6BjauMr+NqllSqJQqlDw65zqlVcB7Uvr78vW5NN1aJ3rRf1/LZ4P8Na/\\nqHrb0zEvAgMBAAECggEAAfdYEeZKgPawA1JxGVZ61lzXJMS+oUied8WohrtkAwim\\nLVFiDus/LHdaoCIFhrQH+QSJd+UUQyjbC7q/VnHPSqm2EjbqsGYVuFTASmZyoodT\\nd86OTsPVVaaKke6CCef4xfsKqQWSb1ow1dr+yHxPz00wlFTy8coHejoK/0hb8kVW\\nzV0Z90ukTivctck45iXKiKfMLsBXua6kLkiC82GL3KVVSdZuDMlUASxEyf0g3Z5+\\ngt8wj5pr1oNBF0FzTJ8nS7oJeDwuje2BSTaceVuJHwpS+DVHvw3sil2WQPisha65\\nx7PscCP9a/ROUujOUdNvQ1/Iy393RFl1U9npR7gkxQKBgQDc7eg7G182TKCFDGOp\\nvfgN35lGbY7r1Fzs6nAxBlV7vVbN1rEKeAeInnU8elW7UKPRGB/K9KR+AHcYd9Ec\\nLGVQCQSh+Qsy4y++TetR3R0HkpLgDYl0Jt0etrQu/lw9WA8tXWGOu4lTxagf4nyu\\nCbKLeyuaFpwWCxPDWa8C8OoKBQKBgQC6xhT0VuHNmnLZ2jZtrmtnpagngBQM027r\\nYjdkldoay3dM4bbh+we5VdYVHaAqIhzcQsgnStN14TBeinui5WXixFm4Cajz5H1Y\\nTNzglvFwbO/QRObavgIL9f1P0lrVlUfR3NzkRjX0QrfKQ70iwK6agpjS4pZjf1/P\\ndumpGDyQowKBgQCruNAVgUUUc6MhR2v/+ATi47XDpEy+yaYhEGh78qxnLdhWzlV2\\nCa3xZxlBFOWmXxu13sZ3foiM19e6UQdcmrV07E2JiIZH24a0qOQMEY4K4McBGASL\\nH9onkWOkU1lm5ReG71pxExu+3Ze8kNLQhAEfoXFWp9RS3fFSmlcKNi/z8QKBgBTe\\nq1q+Fo8d0fWLz4cj9TZoqUh4pETmnz9IAz6HDA7wa00473GC1lMcR0amv83Vb/og\\nsDLLxqMmXXxC5xvFnEPhgtDwq2NNRcBHHmsuEp5oXcec21rX3mytuPdhXur8ukC1\\n+Cy9t6uqhNTiCtFGTHxRWXg+/2Twx6jr9aICZkoXAoGAHCEKbOYj+jEzziEEHEw4\\nxIYw9t7qUqe7/RsxQY04Edowqu3hfi/Gx7NvqNVEiam9gTP2wA2NrxjMx1xWbffI\\ndsytRdlxo4rbYPaK9q83Cu526mB5lSCSmI3Duv/YEcvB/xCODa72MmB2n83T7zyk\\n8a587aA40xs+MbGdWcKBIZA=\\n-----END PRIVATE KEY-----\\n\",\r\n  \"client_email\": \"firebase-adminsdk-vekd0@realtimedb-39f9d.iam.gserviceaccount.com\",\r\n  \"client_id\": \"106924208910376056616\",\r\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\r\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\r\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\r\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-vekd0%40realtimedb-39f9d.iam.gserviceaccount.com\"\r\n}\r\n")
            }) ;
            // This registeration token comes from the client FCM SDKs.
            var registerationToken = token;

            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "MyData","1337"},
                },
                Token = registerationToken,
                Notification = new Notification()
                {
                    Title = "Title - Test From Code",
                    Body = "Body - Test from code",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/06/King_Abdullah_II_Stadium%2C_Amman%2C_Jordan.jpg"
                }

            };
            // Send a message to device corresponding to the provided regestration token
            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            // Response is a message ID string
            App.Current.MainPage.DisplayAlert("Successfully sent message", response, "OK");

        }
        public FirebaseHelper(string token,Notification notification)
        {
            //var registerationToken = token;
            
            //FirebaseApp.Create(new AppOptions()
            //{
            //    Credential = GoogleCredential.FromJson("{\r\n  \"type\": \"service_account\",\r\n  \"project_id\": \"realtimedb-39f9d\",\r\n  \"private_key_id\": \"837df2d81c351a72667913fe93321fd974b4203b\",\r\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQChL8zSA3saHfc6\\nlkdMHHMU74rXsLuTm7X18U0TU2au5/RVS67uDC1LfzvxOHmTpJbB0KfEL6hKpo/4\\nHsjdc7hguxOmGQg+12wwOkRSIQ8C1mbFdaJ36q70w1LYPfyGU+zFafnkry6ndyx+\\nisb+VUvYOkktwkNrg1iq2PjVynIuYY5SQcbZOxHpVATAQoEyAg0As9DiI0zRq9en\\n+xmKilqjiCKWq6tBqbX5CSMShw/XE9mL04l3qaTJH0451x+Q9kkFBhiO1IMrIuH/\\nSibZ5Em/6BjauMr+NqllSqJQqlDw65zqlVcB7Uvr78vW5NN1aJ3rRf1/LZ4P8Na/\\nqHrb0zEvAgMBAAECggEAAfdYEeZKgPawA1JxGVZ61lzXJMS+oUied8WohrtkAwim\\nLVFiDus/LHdaoCIFhrQH+QSJd+UUQyjbC7q/VnHPSqm2EjbqsGYVuFTASmZyoodT\\nd86OTsPVVaaKke6CCef4xfsKqQWSb1ow1dr+yHxPz00wlFTy8coHejoK/0hb8kVW\\nzV0Z90ukTivctck45iXKiKfMLsBXua6kLkiC82GL3KVVSdZuDMlUASxEyf0g3Z5+\\ngt8wj5pr1oNBF0FzTJ8nS7oJeDwuje2BSTaceVuJHwpS+DVHvw3sil2WQPisha65\\nx7PscCP9a/ROUujOUdNvQ1/Iy393RFl1U9npR7gkxQKBgQDc7eg7G182TKCFDGOp\\nvfgN35lGbY7r1Fzs6nAxBlV7vVbN1rEKeAeInnU8elW7UKPRGB/K9KR+AHcYd9Ec\\nLGVQCQSh+Qsy4y++TetR3R0HkpLgDYl0Jt0etrQu/lw9WA8tXWGOu4lTxagf4nyu\\nCbKLeyuaFpwWCxPDWa8C8OoKBQKBgQC6xhT0VuHNmnLZ2jZtrmtnpagngBQM027r\\nYjdkldoay3dM4bbh+we5VdYVHaAqIhzcQsgnStN14TBeinui5WXixFm4Cajz5H1Y\\nTNzglvFwbO/QRObavgIL9f1P0lrVlUfR3NzkRjX0QrfKQ70iwK6agpjS4pZjf1/P\\ndumpGDyQowKBgQCruNAVgUUUc6MhR2v/+ATi47XDpEy+yaYhEGh78qxnLdhWzlV2\\nCa3xZxlBFOWmXxu13sZ3foiM19e6UQdcmrV07E2JiIZH24a0qOQMEY4K4McBGASL\\nH9onkWOkU1lm5ReG71pxExu+3Ze8kNLQhAEfoXFWp9RS3fFSmlcKNi/z8QKBgBTe\\nq1q+Fo8d0fWLz4cj9TZoqUh4pETmnz9IAz6HDA7wa00473GC1lMcR0amv83Vb/og\\nsDLLxqMmXXxC5xvFnEPhgtDwq2NNRcBHHmsuEp5oXcec21rX3mytuPdhXur8ukC1\\n+Cy9t6uqhNTiCtFGTHxRWXg+/2Twx6jr9aICZkoXAoGAHCEKbOYj+jEzziEEHEw4\\nxIYw9t7qUqe7/RsxQY04Edowqu3hfi/Gx7NvqNVEiam9gTP2wA2NrxjMx1xWbffI\\ndsytRdlxo4rbYPaK9q83Cu526mB5lSCSmI3Duv/YEcvB/xCODa72MmB2n83T7zyk\\n8a587aA40xs+MbGdWcKBIZA=\\n-----END PRIVATE KEY-----\\n\",\r\n  \"client_email\": \"firebase-adminsdk-vekd0@realtimedb-39f9d.iam.gserviceaccount.com\",\r\n  \"client_id\": \"106924208910376056616\",\r\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\r\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\r\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\r\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-vekd0%40realtimedb-39f9d.iam.gserviceaccount.com\"\r\n}\r\n")
            //});
            // This registeration token comes from the client FCM SDKs.
            SendNotification(token,notification);


            
           
        }

        void SendNotification(string token, Notification notification)
        {
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "MyData","1337"},
                },
                Token = token,
                Notification = new Notification()
                {
                    Title = notification.Title,
                    Body = notification.Body,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/06/King_Abdullah_II_Stadium%2C_Amman%2C_Jordan.jpg"
                }

            };
            // Send a message to device corresponding to the provided regestration token
            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            // Response is a message ID string
            Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Successfully sent message", response, "OK");
        }
    }
}
