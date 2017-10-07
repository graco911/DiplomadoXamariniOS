using System;
using System.Text;
using UIKit;

namespace ActividadOpcional
{
    public partial class ViewController : UIViewController
    {
        StringBuilder text = new StringBuilder();
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
            Button0.TouchUpInside += delegate { SetNumber("0"); };
            Button1.TouchUpInside += delegate { SetNumber("1"); };
            Button2.TouchUpInside += delegate { SetNumber("2"); };
            Button3.TouchUpInside += delegate { SetNumber("3"); };
            Button4.TouchUpInside += delegate { SetNumber("4"); };
            Button5.TouchUpInside += delegate { SetNumber("5"); };
            Button6.TouchUpInside += delegate { SetNumber("6"); };
            Button7.TouchUpInside += delegate { SetNumber("7"); };
            Button8.TouchUpInside += delegate { SetNumber("8"); };
            Button9.TouchUpInside += delegate { SetNumber("9"); };
        }

        private void SetNumber(string number)
        {
            text.Append(number);
            if (text.Length <= 9)
            {
                NumberLabel.Text = text.ToString();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
