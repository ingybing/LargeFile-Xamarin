// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DotNetReleaseTest
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton GoButton { get; set; }

		[Outlet]
		UIKit.UILabel NumberOfTimesLabel { get; set; }

		[Outlet]
		UIKit.UIProgressView ProgressBar { get; set; }

		[Outlet]
		UIKit.UILabel ProgressPercentageLabel { get; set; }

		[Outlet]
		UIKit.UISlider Slider { get; set; }

		[Action ("GarbageCollect:")]
		partial void GarbageCollect (Foundation.NSObject sender);

		[Action ("Go:")]
		partial void Go (Foundation.NSObject sender);

		[Action ("SliderValueChanged:")]
		partial void SliderValueChanged (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (GoButton != null) {
				GoButton.Dispose ();
				GoButton = null;
			}

			if (NumberOfTimesLabel != null) {
				NumberOfTimesLabel.Dispose ();
				NumberOfTimesLabel = null;
			}

			if (ProgressBar != null) {
				ProgressBar.Dispose ();
				ProgressBar = null;
			}

			if (ProgressPercentageLabel != null) {
				ProgressPercentageLabel.Dispose ();
				ProgressPercentageLabel = null;
			}

			if (Slider != null) {
				Slider.Dispose ();
				Slider = null;
			}
		}
	}
}
