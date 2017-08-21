using System;
using Acr.UserDialogs;
using Foundation;
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

                var can = context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out Foundation.NSError error);

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

            authenButton.TouchUpInside += (sender, e) =>
            {
                var context = new LAContext();
                var myReason = new NSString("To add a new chore");

                if (context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out NSError AuthError))
                {
                    var replyHandler = new LAContextReplyHandler((success, error) => {
                        this.InvokeOnMainThread(() => {
                            if (success)
                            {
                                UserDialogs.Instance.Alert("Login Success");
                            }
                            else
                            {
                                //Show fallback mechanism here
                            }
                        });
                    });
                    context.EvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, myReason, replyHandler);
                };
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

