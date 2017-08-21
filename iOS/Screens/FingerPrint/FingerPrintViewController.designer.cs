// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FingerPrintAuthentication.iOS.Screens.FingerPrint
{
	[Register ("FingerPrintViewController")]
	partial class FingerPrintViewController
	{
		[Outlet]
		UIKit.UIButton authenButton { get; set; }

		[Outlet]
		UIKit.UIButton authenticationButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (authenticationButton != null) {
				authenticationButton.Dispose ();
				authenticationButton = null;
			}

			if (authenButton != null) {
				authenButton.Dispose ();
				authenButton = null;
			}
		}
	}
}
