using Foundation;
using System;
using UIKit;

namespace PhoneApp
{
    public partial class ValidateViewController : UIViewController
    {
        public ValidateViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ValidateButton.TouchUpInside += delegate 
            {
                Validate();
            };;
        }

        private async void Validate()
        {
            var Client = new SALLab06.ServiceClient();

            var Result = await Client.ValidateAsync(
                EmailInput.Text, PassInput.Text, this);
            var Alert = UIAlertController.Create("Resultado",
                                                 $"{Result.Status}\n{Result.FullName}\n{Result.Token}", 
                                                 UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok",
                                                 UIAlertActionStyle.Default, null));
            PresentViewController(Alert, true, null);
        }
    }
}