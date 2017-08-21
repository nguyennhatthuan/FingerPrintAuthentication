using System;
using Acr.UserDialogs;
using LocalAuthentication;
using UIKit;

namespace FingerPrintAuthentication.iOS.Screens.FingerPrint
{
    public partial class FingerPrintViewController : UIViewController
    {
        public FingerPrintViewController() : base("FingerPrintViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            authenticationButton.TouchUpInside += (sender, e) =>
            {
                var context = new LAContext();
                var result = context.EvaluatePolicyAsync(LAPolicy.DeviceOwnerAuthentication, "Authentication Request").GetAwaiter().GetResult();

                if (result.Item1)
                {
                    UserDialogs.Instance.Alert("Authentication");
                }
                else
                {
                    var code = Convert.ToInt16(result.Item2.Code);
                    var status = (LAStatus)code;
                    UserDialogs.Instance.Alert(status.ToString());
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

