using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace FingerPrintLogin
{
	[Activity(Label = "FingerPrintLogin", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		Button signIn, signUp;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
			Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen, Android.Views.WindowManagerFlags.Fullscreen);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

			signIn = FindViewById<Button>(Resource.Id.sign_in);
			signUp = FindViewById<Button>(Resource.Id.sign_up);

			signIn.Click += (sender, e) =>
			{
				StartActivity(new Intent(this, typeof(LoginActivity)));
			};

			signUp.Click += (sender, e) =>
			{
				StartActivity(new Intent(this, typeof(SignUpActivity)));
			};
		}
	}
}

