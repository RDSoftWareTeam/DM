using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.entity
{
    public class EntityProducts
    {
        private int id;
        /// <summary>
        /// 名称
        /// </summary>
        private string productname;
        /// <summary>
        /// 扫查顺序
        /// </summary>
        private string scanorder;
        /// <summary>
        /// 备注
        /// </summary>
        private string notes;

        public int idSg
        {
            set { id = value; }
            get { return id; }
        }
        public string productnameSg
        {
            set { productname = value; }
            get { return productname; }
        }
        public string scanorderSg
        {
            set { scanorder = value; }
            get { return scanorder; }
        }
        public string notesSg
        {
            set { notes = value; }
            get { return notes; }
        }
    }
}
