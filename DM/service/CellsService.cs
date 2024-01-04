using DM.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.service
{
    interface CellsService
    {
        void deleteCells( DataRow list);
        DataTable returnCells();
        void editCells(EntityCells entityCells, List<string> options1, List<string> options2);
        void addCells(EntityCells entityCells, List<string> options1, List<string> options2);
        List<string> returnColData2();
        List<string> returnColData1();
        bool isFloat(string input);
        bool isInt(string input);
        bool determineNotNull(string userInput);
        List<string> returnColData5(string layoutname);
    }
}
