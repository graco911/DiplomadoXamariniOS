using Foundation;
using System;
using UIKit;
using Modelo;
using System.Threading.Tasks;
using NorthWind;

namespace PatronMVC
{
    public partial class ValidateController : UIViewController
    {
        public ValidateController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ValidateButton.TouchUpInside += async delegate
            {
                await ValidateAsync();
            };
        }
        private async Task ValidateAsync()
        {
            var Client = new SALLab07.ServiceClient();
            NorthWindModel p = new NorthWindModel();
            var Result = await Client.ValidateAsync(EmailInput.Text, PassInput.Text, p);

            var Alert = UIAlertController.Create("Resultado",
                                                 $"{Result.Status}\n{Result.FullName}\n{Result.Token}",
                                                 UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok",
                                                 UIAlertActionStyle.Default, null));
            PresentViewController(Alert, true, null);
        }
    }
}