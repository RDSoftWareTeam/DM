using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.service
{
    interface ProductsService
    {
        void deleteProducts( DataRow list);
        DataTable returnProducts();
        void editProducts(EntityProducts entityProducts);
        void addProducts(EntityProducts entityProducts);

        bool determineNotNull(string userInput);
    }

}
