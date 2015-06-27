using System;
using FireSharp;

namespace CameraParameterDeriverService
{
	public class WebListener
	{
		private FirebaseClient cloudsClient; 
		
		public WebListener() {
			FirebaseConfig config = new FirebaseConfig {
				BasePath = "https://splatmap.firebase.com/clouds"
			}
			cloudsClient = new FirebaseClient(config);
			
			// start listening
			await cloudsClient.OnAsync("push", (sender, args) => {
			       System.Console.WriteLine(args.Data);
			});
			
		}
	}
	
	static int Main(string[] args)
	{
	    WebListener list = new WebListener();
	}
	
}