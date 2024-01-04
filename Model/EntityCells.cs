using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EntityCells
    {
        private int id;
        /// <summary>
        /// 行号
        /// </summary>
        private string rowno;
        /// <summary>
        /// 列号
        /// </summary>
        private string colno;
        /// <summary>
        /// 安全点x
        /// </summary>
        private string safypointx;
        /// <summary>
        /// 安全点y
        /// </summary>
        private string safypointy;
        /// <summary>
        /// 安全点z
        /// </summary>
        private string safypointz;
        /// <summary>
        /// 零点x
        /// </summary>
        private string zeropointx;
        /// <summary>
        /// 零点y
        /// </summary>
        private string zeropointy;
        /// <summary>
        /// 零点z
        /// </summary>
        private string zeropointz;
        /// <summary>
        /// 所属布局
        /// </summary>
        private string idt_layouts;
        /// <summary>
        /// 放置产品
        /// </summary>
        private string idt_products;


        public int idSg
        {
            set { id = value; }
            get { return id; }
        }
        public string rownoSg
        {
            set { rowno = value; }
            get { return rowno; }
        }
        public string colnoSg
        {
            set { colno = value; }
            get { return colno; }
        }
        public string safypointxSg
        {
            set { safypointx = value; }
            get { return safypointx; }
        }
        public string safypointySg
        {
            set { safypointy = value; }
            get { return safypointy; }
        }
        public string safypointzSg
        {
            set { safypointz = value; }
            get { return safypointz; }
        }
        public string zeropointxSg
        {
            set { zeropointx = value; }
            get { return zeropointx; }
        }
        public string zeropointySg
        {
            set { zeropointy = value; }
            get { return zeropointy; }
        }
        public string zeropointzSg
        {
            set { zeropointz = value; }
            get { return zeropointz; }
        }
        public string idt_layoutsSg
        {
            set { idt_layouts = value; }
            get { return idt_layouts; }
        }
        public string idt_productsSg
        {
            set { idt_products = value; }
            get { return idt_products; }
        }
    }
}
