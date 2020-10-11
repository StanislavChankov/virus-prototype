using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Xna.Framework;
using Synergy.VirusPrototype.Shared;

namespace Synergy.VirusPrototype.Android
{
	[Activity(
		Label = "@string/app_name",
		MainLauncher = true,
		Icon = "@drawable/icon",
		AlwaysRetainTaskState = true,
		LaunchMode = LaunchMode.SingleInstance,
		ScreenOrientation = ScreenOrientation.FullUser,
		ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
	)]
	public class MainActivity : AndroidGameActivity
	{
		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			await SharedProgram.Main(Array.Empty<string>()).ConfigureAwait(continueOnCapturedContext: false);

			View view = SharedProgram.Game.Services.GetService(typeof(View)) as View;

			SetContentView(view);

			SharedProgram.Game.Run();
		}
	}
}
