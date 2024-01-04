using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.service
{
    interface LayoutsService
    {
        void deleteLayouts( DataRow list);
        DataTable returnLayouts();
        void addLayouts(EntityLayouts entityLayouts);
        void editLayouts(EntityLayouts entityLayouts);
        bool isInt(string userInput);
        bool determineNotNull(string userInput);
    }
}
