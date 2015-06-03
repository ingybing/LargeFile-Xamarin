using System;

using UIKit;
using Foundation;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace DotNetReleaseTest
{
	public partial class ViewController : UIViewController
	{
		private double numberOfTimes = 1;
		
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewDidAppear (bool animated)
		{
			this.numberOfTimes = this.Slider.Value;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}	

		partial void SliderValueChanged (NSObject sender)
		{
			this.numberOfTimes = Math.Round(this.Slider.Value,0);
			this.NumberOfTimesLabel.Text = numberOfTimes.ToString();
		}

		void UpdateProgress (double iteration)
		{
			this.InvokeOnMainThread (() => 
				{
					var progress = (float)(iteration / numberOfTimes);
					this.ProgressBar.SetProgress (progress, true);
					this.ProgressPercentageLabel.Text = string.Format ("{0}%", Math.Round (progress * 100, 0));
				});
		}

		partial void Go (NSObject sender)
		{
			this.GoButton.Enabled = false;
			this.Slider.Enabled = false;

			var task = new Task(this.DoWorkTask);
			task.Start();
		}

		private void DoWorkTask()
		{
			for (double i=1; i <= numberOfTimes; i++)
			{
				DoWork();
				UpdateProgress(i);
			}

			InvokeOnMainThread (() => 
				{
					this.GoButton.Enabled = true;
					this.Slider.Enabled = true;
				});
		}

		private void DoWork ()
		{
			//var filePath = Path.Combine(NSBundle.MainBundle.ResourcePath, "Better.txt");		//33,554,432 byte file. Mostly runs 100 iterations ok.
			var filePath = Path.Combine(NSBundle.MainBundle.ResourcePath, "WillCrash.txt");   //33,554,433 byte file. Fails with in 5 iterations.
			string contents;

			// Reading via File Static doesn't work.
			contents = File.ReadAllText (filePath);
		}

		/*****************************************************************
		 * I Have also tried reading the file contents via the following *
		 *****************************************************************
		 
			// reading via stream reader doesn't work.
			using (var reader = File.OpenText(filePath))
			{
				contents = reader.ReadToEnd();
				reader.Close();
			}



			// Reading via files stream doesn't work.
			var buffer = new byte[50000000]; // 50 mb buffer.

			using (var fileStream = File.OpenRead (filePath)) 
			{
				fileStream.Read (buffer, 0, buffer.Length);
				fileStream.Close();
			}

			contents = Encoding.UTF8.GetString (buffer);



		 	// Reading via files stream doesn't work.
			var buffer = new byte[1000000]; // 1 mb buffer.
			var stringBuilder = new StringBuilder();

			using (var fileStream = File.OpenRead (filePath)) 
			{
				var bytesRead = 0;
				do 
				{
					bytesRead = fileStream.Read (buffer, 0, buffer.Length);
					if(bytesRead > 0)
					{
						stringBuilder.Append(Encoding.UTF8.GetString(buffer));
					}
				} while(bytesRead == buffer.Length);

				fileStream.Close ();
			}

			contents = stringBuilder.ToString ();
		*/

		partial void GarbageCollect (NSObject sender)
		{
			GC.Collect();
		}
	}
}

