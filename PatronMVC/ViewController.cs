using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using UIKit;
using NorthWind;
using Modelo;
using System.Threading.Tasks;

namespace PatronMVC
{
    public partial class ViewController : UIViewController
    {
        NorthWindModel nw = new NorthWindModel();
        Product product = new Product();
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            SearchButton.TouchUpInside += async delegate
            {
                await SearchProductAsync();
            };
        }

        private async Task SearchProductAsync()
        {
            product = await nw.GetProductByIDAsync(Convert.ToInt32(IDInput.Text));
            NameLabel.Text = product.ProductName;
            PriceLabel.Text = product.UnitPrice.ToString();
            ExistenceLabel.Text = product.UnitsInStock.ToString();
            CategoryLabel.Text = product.CategoryID.ToString();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
