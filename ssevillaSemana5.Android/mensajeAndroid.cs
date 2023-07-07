using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ssevillaSemana5.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//jhjh

[assembly:Xamarin.Forms.Dependency(typeof(mensajeAndroid))]

namespace ssevillaSemana5.Droid
{
    public class mensajeAndroid : Mensaje
    {
        public void longAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();
        }

        public void shorAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}