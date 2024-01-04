using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.entity
{
    public class EntityScanareas
    {
        private int id;
        /// <summary>
        /// 区域编号
        /// </summary>
        private string areano;
        /// <summary>
        /// 偏移x
        /// </summary>
        private string offsetx;
        /// <summary>
        /// 偏移y
        /// </summary>
        private string offsety;
        /// <summary>
        /// 偏移z
        /// </summary>
        private string offsetz;
        /// <summary>
        /// 扫查距离
        /// </summary>
        private string scanlen;
        /// <summary>
        /// 步进距离
        /// </summary>
        private string indexlen;
        /// <summary>
        /// 扫查精度
        /// </summary>
        private string scanres;
        /// <summary>
        /// 步进精度
        /// </summary>
        private string indexres;

        /// <summary>
        /// 所属产品
        /// </summary>
        private string idt_products;


        public int idSg
        {
            set { id = value; }
            get { return id; }
        }
        public string areanoSg
        {
            set { areano = value; }
            get { return areano; }
        }
        public string offsetxSg
        {
            set { offsetx = value; }
            get { return offsetx; }
        }
        public string offsetySg
        {
            set { offsety = value; }
            get { return offsety; }
        }
        public string offsetzSg
        {
            set { offsetz = value; }
            get { return offsetz; }
        }
        public string scanlenSg
        {
            set { scanlen = value; }
            get { return scanlen; }
        }
        public string indexlenSg
        {
            set { indexlen = value; }
            get { return indexlen; }
        }
        public string scanresSg
        {
            set { scanres = value; }
            get { return scanres; }
        }
        public string indexresSg
        {
            set { indexres = value; }
            get { return indexres; }
        }
        public string idt_productsSg
        {
            set { idt_products = value; }
            get { return idt_products; }
        }
    }
}
