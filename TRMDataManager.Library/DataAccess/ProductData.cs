using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<PrductModel> GetPrducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            

            var output = sql.LoadData<PrductModel, dynamic>("dbo.spProduct_GetAll", new { }, "TRMData");
            return output;

        }
    }
}
