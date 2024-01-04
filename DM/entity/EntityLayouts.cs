using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.entity
{
    public class EntityLayouts
    {
        private int id;
        /// <summary>
        /// 名称
        /// </summary>
        private string layoutname;
        /// <summary>
        /// 行数
        /// </summary>
        private string rows;
        /// <summary>
        /// 列数
        /// </summary>
        private string cols;

        public int idSg
        {
            set { id = value; }
            get { return id; }
        }
        public string layoutnameSg
        {
            set { layoutname = value; }
            get { return layoutname; }
        }
        public string rowsSg
        {
            set { rows = value; }
            get { return rows; }
        }
        public string colsSg
        {
            set { cols = value; }
            get { return cols; }
        }
    }
}
