using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.entity
{
    public class EntityGlobalpars
    {
        private int id;
        /// <summary>
        /// 参数名称
        /// </summary>
        private string parname;
        /// <summary>
        /// 参数值
        /// </summary>
        private string parvalue;
        /// <summary>
        /// 参数含义
        /// </summary>
        private string dispname;

        public int idSg
        {
            set { id = value; }
            get { return id; }
        }
        public string parnameSg
        {
            set { parname = value; }
            get { return parname; }
        }
        public string parvalueSg
        {
            set { parvalue = value; }
            get { return parvalue; }
        }
        public string dispnameSg
        {
            set { dispname = value; }
            get { return dispname; }
        }
    }
}
