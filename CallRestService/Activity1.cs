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
using System.Net;
using System.IO;
using System.Json;

namespace CallRestService
{
    [Activity (Label = "CallRestService", MainLauncher = true)]
	public class Activity1 : Activity
    {
		HttpWebRequest httpReq;
		TextView textView;
		String a;
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
			SetContentView (Resource.Layout.LAY);

			string url = "http://enlhighcouncil.eb2a.com/verfiyUser.php?agentName=dragoneel&email=samerzmd@gmail.com";
			textView = FindViewById<TextView> (Resource.Id.mtText);
            httpReq = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
         
            httpReq.BeginGetResponse ((ar) => {
             
                var request = (HttpWebRequest)ar.AsyncState;
            
                using (var response = (HttpWebResponse)request.EndGetResponse (ar)) {
                 
                    var s = response.GetResponseStream ();
                 
                    var j = (JsonObject)JsonObject.Load (s);
					 a=(j["status"].ToString());
            

            
					RunOnUiThread (() => {
						textView.Text=a;
                    });
                }            

            }, httpReq);
        }

    }
}


