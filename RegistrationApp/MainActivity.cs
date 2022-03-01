using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;
using Android.Graphics;
using Android.Text;
using Android.Content;
using Google.Android.Material.TextField;
using System.Text.RegularExpressions;

namespace RegistrationApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", WindowSoftInputMode = SoftInput.AdjustPan, NoHistory = true)]
    public class MainActivity : AppCompatActivity
    {
        TextInputLayout passwordlayout;
        TextView textView, loginPG;
        ImageView googleBT, facebookBT;
        TextInputEditText nametext, emailtext, usernametext, passwordtext;

        Button registerBT;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            UIreferences();

            TextPaint paint = textView.Paint;
            float width = paint.MeasureText(textView.Text);

            int[] vs = new int[]{
                           Color.ParseColor("#fc0000"),
                           Color.ParseColor("#2f2ff6"),
                        Color.ParseColor("#00faff")

                    };
            Shader textShader = new LinearGradient(0, 0, width, textView.TextSize,
                    vs, null, Shader.TileMode.Clamp);
            textView.Paint.SetShader(textShader);
            registerBT.Click += RegisterBT_Click;
            loginPG.Click += LoginPG_Click;
            googleBT.Click += GoogleBT_Click;
            facebookBT.Click += FacebookBT_Click;

        }

        private void RegisterBT_Click(object sender, System.EventArgs e)
        {
            if (!usernameok() && !emailok() && !nameok() && !passwordok())
            {
                Toast.MakeText(this, "Task Failed Successfully", ToastLength.Long).Show();
                return;
            }

            if (usernameok() && emailok() && nameok() && passwordok())
            {
                Toast.MakeText(this, "user successfully loggedin", ToastLength.Long).Show();

            }
        }
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
        private void FacebookBT_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You have been Registered in by Facebook", ToastLength.Short).Show();
        }

        private void GoogleBT_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You have been Registered in by Google", ToastLength.Short).Show();
        }

        private void LoginPG_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(Login));
            StartActivity(intent);
            //FinishAffinity();

        }


        private void UIreferences()
        {
            facebookBT = FindViewById<ImageView>(Resource.Id.Regwithfacebook);
            googleBT = FindViewById<ImageView>(Resource.Id.Regwithgoogle);
            registerBT = FindViewById<Button>(Resource.Id.registerButton);
            textView = FindViewById<TextView>(Resource.Id.textView1);
            loginPG = FindViewById<TextView>(Resource.Id.loginTextView);
            passwordtext = FindViewById<TextInputEditText>(Resource.Id.editText3);
            emailtext = FindViewById<TextInputEditText>(Resource.Id.editText1);
            passwordlayout = FindViewById<TextInputLayout>(Resource.Id.passwordlay);
            nametext = FindViewById<TextInputEditText>(Resource.Id.editText2);
            usernametext = FindViewById<TextInputEditText>(Resource.Id.myEditText0);
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

        private bool nameok()
        {
            bool isEmail = Regex.IsMatch(emailtext.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (emailtext.Text.Trim().Equals(""))
            {
                Toast.MakeText(this, "email of user is empty", ToastLength.Long).Show();
                emailtext.Error = "email of the user is not inserted";
                return false;
            }
            if (!isEmail)
            {
                Toast.MakeText(this, "Invalid Email", ToastLength.Long).Show();
                emailtext.Error = "Invalid email address";
                return false;
            }


            return true;
        }

        private bool emailok()
        {

            if (usernametext.Text == "")
            {
                Toast.MakeText(this, "username is empty", ToastLength.Long).Show();
                usernametext.Error = "username of the user is not inserted";
                return false;
            }
            else
                return true;
        }

        private bool passwordok()
        {
            var length1 = passwordtext.Length();
            if (passwordtext.Text.Length < 8)
            {
                Toast.MakeText(this, "password of user is empty or less than 8", ToastLength.Long).Show();
                passwordlayout.Error = "password of the user is should not be less than 8";
                return false;
            }
            else
                return true;
        }
    }
}

