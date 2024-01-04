using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.entity
{
    public class MonitorParaEntity
    {
        /// <summary>
        /// 监控参数ID
        /// </summary>
        private int id;
        /// <summary>
        /// 监控参数名称
        /// </summary>
        private string ioName;
        /// <summary>
        /// 监控参数上阈值
        /// </summary>
        private string upThreshv;
        /// <summary>
        /// 监控参数上启用标志
        /// </summary>
        private int upEnableFlg;
        /// <summary>
        /// 监控参数上颜色
        /// </summary>
        private int upColor;
        /// <summary>
        /// 监控参数下阈值
        /// </summary>
        private string dwnThreshv;
        /// <summary>
        /// 监控参数下启用标志
        /// </summary>
        private int dwnEnableFlg;
        /// <summary>
        /// 监控参数下颜色
        /// </summary>
        private int dwnColor;
        /// <summary>
        /// 监控参数阈值类型
        /// </summary>
        private string dataType;
        /// <summary>
        /// 监控参数起始地址
        /// </summary>
        private string startAddr;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string IoName
        {
            get
            {
                return ioName;
            }

            set
            {
                ioName = value;
            }
        }

        public string UpThreshv
        {
            get
            {
                return upThreshv;
            }

            set
            {
                upThreshv = value;
            }
        }

        public int UpEnableFlg
        {
            get
            {
                return upEnableFlg;
            }

            set
            {
                upEnableFlg = value;
            }
        }

        public int UpColor
        {
            get
            {
                return upColor;
            }

            set
            {
                upColor = value;
            }
        }

        public string DwnThreshv
        {
            get
            {
                return dwnThreshv;
            }

            set
            {
                dwnThreshv = value;
            }
        }

        public int DwnEnableFlg
        {
            get
            {
                return dwnEnableFlg;
            }

            set
            {
                dwnEnableFlg = value;
            }
        }

        public int DwnColor
        {
            get
            {
                return dwnColor;
            }

            set
            {
                dwnColor = value;
            }
        }

        public string DataType
        {
            get
            {
                return dataType;
            }

            set
            {
                dataType = value;
            }
        }

        public string StartAddr
        {
            get
            {
                return startAddr;
            }

            set
            {
                startAddr = value;
            }
        }
    }
}
