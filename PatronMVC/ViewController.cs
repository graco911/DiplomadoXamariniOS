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
    public partial class ViewController : UIViewController, INorthWindModel
    {
        NorthWindModel nw = new NorthWindModel();
        Product Product = new Product();

        public event ChangeStatusEventHandler ChangeStatus;

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
            Product = (Modelo.Product)await GetProductByIDAsync(Convert.ToInt32(IDInput.Text));
            NameLabel.Text = Product.ProductName;
            PriceLabel.Text = Product.UnitPrice.ToString();
            ExistenceLabel.Text = Product.UnitsInStock.ToString();
            CategoryLabel.Text = Product.CategoryID.ToString();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public async Task<IProduct> GetProductByIDAsync(int ID)
        {
            Product producto = new Product();
            using (var Client = new System.Net.Http.HttpClient())
            {
                Client.BaseAddress =
                          new Uri("https://ticapacitacion.com/webapi/northwind/");
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				ChangeStatus += (object sender, IChangeStatusEventArgs e) =>
				{
                    e.Status = StatusOptions.CallingWebAPI;
				};

                HttpResponseMessage Response = await Client.GetAsync($"product/{ID}");

                ChangeStatus += (object sender, IChangeStatusEventArgs e) => 
                {
                    e.Status = StatusOptions.VerifyingResult;
                };

                if (Response.IsSuccessStatusCode)
                {
                    var JSONProduct =
                        await Response.Content.ReadAsStringAsync();
                    producto = JsonConvert.DeserializeObject<Product>(JSONProduct);

                    if (Product != null)
                    {
						ChangeStatus += (object sender, IChangeStatusEventArgs e) =>
						{
                            
						};
                    }else
                    {
						ChangeStatus += (object sender, IChangeStatusEventArgs e) =>
						{
                            
						};
                    }
                }
                else
                {
					ChangeStatus += (object sender, IChangeStatusEventArgs e) =>
					{

					};
                }
            }
            return producto;
        }
    }
}
