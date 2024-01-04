using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.service
{
    interface GlobalparsService
    {
        void deleteGlobalpars( DataRow list);
        DataTable returnGlobalpars();
        void editGlobalpars(EntityGlobalpars entityGlobalpars);
        void addGlobalpars(EntityGlobalpars entityGlobalpars);
        bool determineNotNull(string userInput);
    }
}
