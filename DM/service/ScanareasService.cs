using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DM.service
{
    interface ScanareasService
    {
        void deleteScanareas( DataRow list);
        DataTable returnScanareas();
        void editScanareas(EntityScanareas entityScanareas, List<string> options1);
        void addScanareas(EntityScanareas entityScanareas, List<string> options1);
        List<string> returnColData4();
        bool isFloat(string input);
        bool isInt(string input);
        bool determineNotNull(string userInput);

    }
}
