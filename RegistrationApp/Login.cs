using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class Login : AppCompatActivity
    {
        TextView createnew, textView1;
        Button mainloginBT;
        ImageButton googleBT, facebookBT;
        TextInputEditText nametext, passwordtext;
       
        ImageView loginWTgoogle, loginWTfacebook;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            createnew = FindViewById<TextView>(Resource.Id.createlogic);
            createnew.Click += Createnew_Click;
            nametext = FindViewById<TextInputEditText>(Resource.Id.editText2);
            passwordtext = FindViewById<TextInputEditText>(Resource.Id.editText3);
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

            if (!usernameok()  && !passwordok())
            {
                Toast.MakeText(this, "Task Failed Successfully", ToastLength.Long).Show();
                return;
            }

            if (usernameok() &&  passwordok())
            {
                Toast.MakeText(this, "user successfully loggedin", ToastLength.Long).Show();

            }

        }

        private void LoginWTfacebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You have been Logged in by Google", ToastLength.Short).Show();
        }

        private void LoginWTgoogle_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You have been Logged in by Google", ToastLength.Short).Show();
        }

        private bool passwordok()
        {
            var length1 = passwordtext.Length();
            if (passwordtext.Text.Length < 8)
            {
                Toast.MakeText(this, "password of user is empty or less than 8", ToastLength.Long).Show();
                passwordtext.Error = "password of the user is should not be less than 8";
                return false;
            }
            else
                return true;
        }
        private bool usernameok()
        {
            if (nametext.Text == "")
            {
                Toast.MakeText(this, "name of user is empty", ToastLength.Long).Show();
                nametext.Error = "name of the user is not inserted";
                return false;
            }
            else
                return true;
        }

        private void Createnew_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}