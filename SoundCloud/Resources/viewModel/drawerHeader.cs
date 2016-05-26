
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FFImageLoading.Views;
using FFImageLoading;

namespace SoundCloud
{
	[Activity (Label = "drawerHeader")]			
	public class drawerHeader : Activity
	{
		JsonConverter json=new JsonConverter();
		TextView txtUsername;
		TextView txtLastmodifier;
		ImageViewAsync imgThunbailUsername;
		MainActivity mainActivity=new MainActivity();
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.drawer_header);
			txtUsername = FindViewById<TextView> (Resource.Id.txtUsername);
			txtLastmodifier = FindViewById<TextView> (Resource.Id.txtlast_modified);
			imgThunbailUsername = FindViewById<ImageViewAsync> (Resource.Id.imgThunbailUser);

			string token = mainActivity.token;
			AccountInformation (token);
			// Create your application here

		}
		private async void AccountInformation(string token)
		{

			var result= await json.GetStringbyJson("https://api.soundcloud.com/me?oauth_token="+token);
			if (result != null) {
				var items = Newtonsoft.Json.JsonConvert.DeserializeObject<Me.RootObject> (result);
				txtUsername.Text = items.username;
				txtLastmodifier.Text = items.last_modified;
				ImageService.LoadUrl(items.avatar_url)

					.Retry(5, 200)
					.Into(imgThunbailUsername);
			}
		}
	}
}

