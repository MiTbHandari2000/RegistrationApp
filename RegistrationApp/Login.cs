using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class Login : AppCompatActivity
    {
        TextView createnew, textView1;
        Button mainloginBT;
        ImageButton googleBT, facebookBT;
        ImageView loginWTgoogle, loginWTfacebook;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            createnew = FindViewById<TextView>(Resource.Id.createlogic);
            createnew.Click += Createnew_Click;

            loginWTgoogle = FindViewById<ImageView>(Resource.Id.Loginwithgoogle);
            mainloginBT = FindViewById<Button>(Resource.Id.LoginButton);
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            loginWTfacebook = FindViewById<ImageView>(Resource.Id.Loginwithfacebook);
            loginWTgoogle.Click += LoginWTgoogle_Click;
            loginWTfacebook.Click += LoginWTfacebook_Click;
            mainloginBT.Click += MainloginBT_Click;
            TextPaint paint = textView1.Paint;
            float width = paint.MeasureText(textView1.Text);

            int[] vs = new int[]{
                           Color.ParseColor("#f20505"),
                           Color.ParseColor("#2f2ff6"),
                        Color.ParseColor("#00faff")

                    };
            Shader textShader = new LinearGradient(0, 0, width, textView1.TextSize,
                    vs, null, Shader.TileMode.Clamp);

            textView1.Paint.SetShader(textShader);
            // Create your application here
        }
        private void MainloginBT_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "login Successfull", ToastLength.Short).Show();

        }

        private void LoginWTfacebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You have been Logged in by Google", ToastLength.Short).Show();
        }

        private void LoginWTgoogle_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You have been Logged in by Google", ToastLength.Short).Show();
        }



        private void Createnew_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}