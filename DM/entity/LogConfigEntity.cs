using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.entity
{
    public class LogConfigEntity
    {
        /// <summary>
        /// 日志配置ID
        /// </summary>
        private int id;
        /// <summary>
        /// 日志配置名称
        /// </summary>
        private string logName;
        /// <summary>
        /// 日志配置key
        /// </summary>
        private string logKey;
        /// <summary>
        /// 日志模板
        /// </summary>
        private int strTemplate;

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

        public string LogName
        {
            get
            {
                return logName;
            }

            set
            {
                logName = value;
            }
        }

        public string LogKey
        {
            get
            {
                return logKey;
            }

            set
            {
                logKey = value;
            }
        }

        public int StrTemplate
        {
            get
            {
                return strTemplate;
            }

            set
            {
                strTemplate = value;
            }
        }
    }
}
