using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NorthWind;

namespace Modelo
{
    public class NorthWindModel : IChangeStatusEventArgs, INorthWindModel
    {
        public StatusOptions Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event ChangeStatusEventHandler ChangeStatus;

        async Task<IProduct> INorthWindModel.GetProductByIDAsync(int ID)
        {
            Product producto = new Product();
            using (var Client = new System.Net.Http.HttpClient())
            {
                Client.BaseAddress =
                          new Uri("https://ticapacitacion.com/webapi/northwind/");
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ChangeStatus += (object sender, IChangeStatusEventArgs e) =>
                {

                };

                HttpResponseMessage Response = await Client.GetAsync($"product/{ID}");

                ChangeStatus += (object sender, IChangeStatusEventArgs e) =>
                {
                };

                if (Response.IsSuccessStatusCode)
                {
                    var JSONProduct =
                        await Response.Content.ReadAsStringAsync();
                    producto = JsonConvert.DeserializeObject<Product>(JSONProduct);

                    ChangeStatus += (object sender, IChangeStatusEventArgs e) =>
                    {
                    };
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
