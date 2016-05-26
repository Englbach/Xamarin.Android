
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Collections;
using Android.Provider;
using Java.Util;

namespace SoundCloud
{
	public class GenreFragment : Fragment
	{
		ListView lst;
		string[] items = new string[] { "Alternative Rock","Classical", "Country","Dance & EDM","Dancehall","Deep House","Disco","Drum & Bass","Electronic","Hip Hop & Rap","Rock","Soundtrack","Techno","Audiobooks","Business" 
			,"Comedy","Entertainment","New Politics","Science","Sports","Storytelling","Technology"};
		
		public string mData;
		public void Data(string mdata)
		{
			mData = mdata;
		}
		
		//private CustomAdapter mAdapter;
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);


			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);



			return inflater.Inflate (Resource.Layout.GenerFragment, container, false);
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);

			//listItems = new List<string> (items);

			lst = View.FindViewById<ListView> (Resource.Id.lstGenres);
	
			lst.Adapter = new ArrayAdapter<string>(Activity, Resource.Layout.textGenreItems,Resource.Id.textHeaderGenre, items);
			//lst = View.FindViewById<ListView> (Resource.Id.lst_genre);

			//lst.SetAdapter(new ArrayAdapter<String>(this.Activity, Resource.Layout.textGenreItems, items));
			//lst.Adapter=new CustomAdapter(Android.App.Application.Context,items);


		
			lst.ItemClick += delegate(object sender, AdapterView.ItemClickEventArgs e) {

				//var intent = new Intent (this, typeof(TracksByGenres));
				//intent.PutStringArrayListExtra ("keys",	items);
				//StartActivity (intent);
				FragmentTransaction fragmentTx=this.FragmentManager.BeginTransaction();
				TracksByGenres fragTrack=new TracksByGenres();
				fragTrack.AddData(items[e.Position]);
				//get our item from listview

				fragmentTx.Replace(Resource.Id.fragmentContainer,fragTrack);	
				fragmentTx.AddToBackStack(null);
				fragmentTx.Commit();


			};
			
		}
		/*
		public class CustomAdapter : BaseAdapter{

			private  const int TYPE_ITEM = 0;
			private const int TYPE_SEPARATOR = 1;

			string[] mnData;
			//private TreeSet sectionHeader;

			LayoutInflater mInflater;
			TreeSet sectionHeader;

			public CustomAdapter(Context context, string[] Data) {
				mInflater = LayoutInflater.FromContext (context);

				mnData=Data;
			}



			public override int GetItemViewType (int position)
			{
				return mnData[position] ? TYPE_SEPARATOR : TYPE_ITEM;
			}

			public int ViewTypeCount
			{
				get{return 2;}
			}

			public override int Count {
				get {return mnData.Length;}
			}


			public override Java.Lang.Object GetItem(int position) {
				return mnData[position];
			}

			public override long GetItemId(int position) {
				return position;
			} 

			public override View GetView(int position, View convertView, ViewGroup parent) {
				ViewHolder holder = null;
				//var data = mData [position];
				var item=mnData[position];
				int row = GetItemViewType (position);
				if (convertView == null) {
					holder = new ViewHolder ();
					switch (row) {
					case TYPE_ITEM:
						convertView = mInflater.Inflate (Resource.Layout.textGenreItems, parent, false);
						holder.textView= (TextView)convertView.FindViewById (Resource.Id.textTitleGenre);
						break;
					case TYPE_SEPARATOR:
						convertView = mInflater.Inflate (Resource.Layout.textGenreHeaderItems, parent, false);
						holder.textView = (TextView)convertView.FindViewById (Resource.Id.textHeaderGenre);
						break;
					}

					convertView.Tag = holder;
				} else {
					holder = (ViewHolder)convertView.Tag as ViewHolder;
				}
				holder.textView.Text = item;



				return convertView;
			}
		}

		public  class ViewHolder:Java.Lang.Object {
			public TextView textView{ get; set; }
			//public TextView textViewSeparator{ get; set; }
		}
*/

	}








}
