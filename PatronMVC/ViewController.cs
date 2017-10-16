using System;
using System.Net.Http.Headers;
using UIKit;
using System.Threading.Tasks;
using ModelIO;
using NorthWind;
using System.Net.Http;
using Newtonsoft.Json;

namespace PatronMVC
{
    public partial class ViewController : UIViewController, INorthWindModel, IChangeStatusEventArgs
    {
        Modelo modelo = new Modelo();

        public StatusOptions Status { get; set; }

        public event ChangeStatusEventHandler ChangeStatus;

        protected ViewController(
        IntPtr handle) : base(handle)
        {
        }

        public ViewController() { }

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
            modelo = (PatronMVC.Modelo)await GetProductByIDAsync(Convert.ToInt32(IDInput.Text));
            NameLabel.Text = modelo.ProductName;
            PriceLabel.Text = modelo.UnitPrice.ToString();
            ExistenceLabel.Text = modelo.UnitsInStock.ToString();
            CategoryLabel.Text = modelo.CategoryID.ToString();

        }

        public async Task<IProduct> GetProductByIDAsync(int ID)
        {
            using (var Client = new System.Net.Http.HttpClient())
            {
                Client.BaseAddress =
                          new Uri("https://ticapacitacion.com/webapi/northwind/");
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Response = await Client.GetAsync($"product/{ID}");

                StatusLabel.Text = ChangeStatus.ToString();
      

                if (Response.IsSuccessStatusCode)
                {
                    var JSONProduct =
                        await Response.Content.ReadAsStringAsync();
                    modelo = JsonConvert.DeserializeObject<Modelo>(JSONProduct);

                    if (modelo != null)
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
            }
            return modelo;
        }
    }
}
