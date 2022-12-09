using Newtonsoft.Json.Linq;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMdesktopUI.Library.Api;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class ProductEndpoint : IProductEndpoint
    {
        private IAPIHelper _apiHelper;
        public ProductEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using (HttpResponseMessage respone = await _apiHelper.ApiClient.GetAsync("/api/Product"))
            {
                if (respone.IsSuccessStatusCode)
                {
                    var result = await respone.Content.ReadAsAsync<List<ProductModel>>();
                    return result;

                }
                else
                {
                    throw new Exception(respone.ReasonPhrase);
                }

            }
        }
    }
}
