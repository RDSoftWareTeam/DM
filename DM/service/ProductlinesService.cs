using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.service
{
    interface ProductlinesService
    {
        void deleteProductlines( DataRow list);
        DataTable returnProductlines();
        void editProductlines(EntityProductlines entityProductlines, List<string> options1);
        void addProductlines(EntityProductlines entityProductlines, List<string> options1);
        List<string> returnColData3();
        bool isFloat(string input);
        bool isInt(string input);
        bool determineNotNull(string userInput);
    }
}
