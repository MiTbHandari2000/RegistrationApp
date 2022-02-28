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

namespace RegistrationApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        TextView textView, loginPG;
        ImageView googleBT, facebookBT;
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
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
        }

        private void RegisterBT_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Registered Successfully", ToastLength.Short).Show();
        }

        private void UIreferences()
        {
            facebookBT = FindViewById<ImageView>(Resource.Id.Regwithfacebook);
            googleBT = FindViewById<ImageView>(Resource.Id.Regwithgoogle);
            registerBT = FindViewById<Button>(Resource.Id.registerButton);
            textView = FindViewById<TextView>(Resource.Id.textView1);
            loginPG = FindViewById<TextView>(Resource.Id.loginTextView);
        }
    }
}
