using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EntityProductlines
    {
        private int id;
        /// <summary>
        /// 名称
        /// </summary>
        private string linename;
        /// <summary>
        /// key
        /// </summary>
        private string linekey;
        /// <summary>
        /// 扫查速度
        /// </summary>
        private string scanspeed;
        /// <summary>
        /// 步进速度
        /// </summary>
        private string indexspeed;
        /// <summary>
        /// 升降速度
        /// </summary>
        private string auxspeed;
        /// <summary>
        /// x空行速度
        /// </summary>
        private string scanspeed_empty;
        /// <summary>
        /// y空行速度
        /// </summary>
        private string indexspeed_empty;
        /// <summary>
        /// z空行速度
        /// </summary>
        private string auxspeed_empty;
        /// <summary>
        /// 采用布局
        /// </summary>
        private string idt_layouts;


        public int idSg
        {
            set { id = value; }
            get { return id; }
        }
        public string linenameSg
        {
            set { linename = value; }
            get { return linename; }
        }
        public string linekeySg
        {
            set { linekey = value; }
            get { return linekey; }
        }
        public string scanspeedSg
        {
            set { scanspeed = value; }
            get { return scanspeed; }
        }
        public string indexspeedSg
        {
            set { indexspeed = value; }
            get { return indexspeed; }
        }
        public string auxspeedSg
        {
            set { auxspeed = value; }
            get { return auxspeed; }
        }
        public string scanspeed_emptySg
        {
            set { scanspeed_empty = value; }
            get { return scanspeed_empty; }
        }
        public string indexspeed_emptySg
        {
            set { indexspeed_empty = value; }
            get { return indexspeed_empty; }
        }
        public string auxspeed_emptySg
        {
            set { auxspeed_empty = value; }
            get { return auxspeed_empty; }
        }
        public string idt_layoutsSg
        {
            set { idt_layouts = value; }
            get { return idt_layouts; }
        }
    }
}
