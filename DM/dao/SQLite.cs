using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DM.dao
{
    class SQLite
    {
        /// <summary>
        /// 数据库路径
        /// </summary>
        public static string connectionString = "Data Source=" + Application.StartupPath + "\\m_sqlite.db;Version=3;";
        public static string query1 = "SELECT layoutname FROM t_layouts";
        public static string query2 = "SELECT productname FROM t_products";
        public static string query3 = "SELECT rows cols FROM t_layouts WHERE layoutname =@layoutname";
        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="connectionString"></param>
        public static void CreateTable(string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                //用户表
                string query_users =
                @"CREATE TABLE IF NOT EXISTS t_users (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                username VARCHAR(50) NOT NULL,
                userpwd VARCHAR(100) NOT NULL,
                realname VARCHAR(50) NOT NULL,
                photo VARCHAR(100), 
                idt_role INTEGER NOT NULL,
                FOREIGN KEY (idt_role) REFERENCES t_roles(id))";

                using (SQLiteCommand command_users = new SQLiteCommand(query_users, connection))
                {
                    command_users.ExecuteNonQuery();
                }

                //角色表
                string query_roles =
                 @"CREATE TABLE IF NOT EXISTS t_roles (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                rolename VARCHAR(50) NOT NULL,
                notes VARCHAR(255))";

                using (SQLiteCommand command_roles = new SQLiteCommand(query_roles, connection))
                {
                    command_roles.ExecuteNonQuery();
                }

                //功能表
                string query_modules =
                @"CREATE TABLE IF NOT EXISTS t_modules (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                modulename VARCHAR(50) NOT NULL,
                modulekey VARCHAR(255) UNIQUE)";

                using (SQLiteCommand command_modules = new SQLiteCommand(query_modules, connection))
                {
                    command_modules.ExecuteNonQuery();
                }

                //角色-功能授权表
                string query_roleandmodule =
                @"CREATE TABLE IF NOT EXISTS r_roleandmodule (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                idt_roles INTEGER NOT NULL,
                idt_modules INTEGER NOT NULL,
                UNIQUE(idt_roles, idt_modules),
                FOREIGN KEY (idt_roles) REFERENCES t_roles(id),
                FOREIGN KEY (idt_modules) REFERENCES t_modules(id))";

                using (SQLiteCommand command_roleandmodule = new SQLiteCommand(query_roleandmodule, connection))
                {
                    command_roleandmodule.ExecuteNonQuery();
                }

                //易损/点检配件表
                string query_accessories =
                @"CREATE TABLE IF NOT EXISTS t_accessories (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                accname VARCHAR(50) NOT NULL,
                starttime TEXT NOT NULL,
                acctype INTEGER,
                updatetime TEXT,
                circletime INTEGER,
                circleunit INTEGER)";

                using (SQLiteCommand command_accessories = new SQLiteCommand(query_accessories, connection))
                {
                    command_accessories.ExecuteNonQuery();
                }

                //I/O信息表
                string query_ios =
                @"CREATE TABLE IF NOT EXISTS t_ios (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                ioname VARCHAR(50) NOT NULL,
                truetext VARCHAR(50) DEFAULT 'close',
                falsetext VARCHAR(50) DEFAULT 'open',
                iotype INTEGER,
                control INTEGER,
                addr1 VARCHAR(50),
                addr2 VARCHAR(50))";

                using (SQLiteCommand command_ios = new SQLiteCommand(query_ios, connection))
                {
                    command_ios.ExecuteNonQuery();
                }

                //监控参数
                string query_keyparameters =
                @"CREATE TABLE IF NOT EXISTS t_keyparameters (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                ioname VARCHAR(50) NOT NULL,
                upthreshv REAL,
                upenableflg INTEGER DEFAULT 1,
                upcolor INTEGER,
                dwnthreshv DEAL,
                dwnenableflg INTEGER,
                dwncolor INTEGER,
                datatype VARCHAR(50),
                startaddr VARCHAR(50))";

                using (SQLiteCommand command_keyparameters = new SQLiteCommand(query_keyparameters, connection))
                {
                    command_keyparameters.ExecuteNonQuery();
                }

                //日志配置
                string query_logconfigure =
                @"CREATE TABLE IF NOT EXISTS t_logconfigure (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                logname VARCHAR(50),
                logkey VARCHAR(50) NOT NULL,
                strtemplate INTEGER NOT NULL)";

                using (SQLiteCommand command_logconfigure = new SQLiteCommand(query_logconfigure, connection))
                {
                    command_logconfigure.ExecuteNonQuery();
                }

                //产线
                string query_productlines =
                @"CREATE TABLE IF NOT EXISTS t_productlines (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                linename VARCHAR(50),
                linekey VARCHAR(50) NOT NULL,
                scanspeed REAL,
                indexspeed REAL,
                auxspeed REAL,
                scanspeed_empty REAL,
                indexspeed_empty REAL,
                auxspeed_empty REAL,
                idt_layouts INTEGER,
                FOREIGN KEY (idt_layouts) REFERENCES t_layouts(id))";

                using (SQLiteCommand command_productlines = new SQLiteCommand(query_productlines, connection))
                {
                    command_productlines.ExecuteNonQuery();
                }

                //工位布局
                string query_layouts =
                @"CREATE TABLE IF NOT EXISTS t_layouts (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                layoutname VARCHAR(50),
                rows INTEGER NOT NULL,
                cols INTEGER NOT NULL)";

                using (SQLiteCommand command_layouts = new SQLiteCommand(query_layouts, connection))
                {
                    command_layouts.ExecuteNonQuery();
                }

                //布局单元
                string query_cells =
                @"CREATE TABLE IF NOT EXISTS t_cells (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                rowno INTEGER NOT NULL,
                colno INTEGER NOT NULL,
                safypointx REAL NOT NULL,
                zeropointx REAL NOT NULL,
                safypointy REAL NOT NULL,
                zeropointy REAL NOT NULL,
                safypointz REAL,
                zeropointz REAL,
                idt_layouts INTEGER NOT NULL,
                idt_products INTEGER NOT NULL,
                FOREIGN KEY (idt_layouts) REFERENCES t_layouts(id),
                FOREIGN KEY (idt_products) REFERENCES t_products(id))";

                using (SQLiteCommand command_cells = new SQLiteCommand(query_cells, connection))
                {
                    command_cells.ExecuteNonQuery();
                }

                //产品信息
                string query_products =
                @"CREATE TABLE IF NOT EXISTS t_products (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                productname VARCHAT(50) NOT NULL,
                scanorder VARCHAT(50),
                notes VARCHAT(200))";

                using (SQLiteCommand command_products = new SQLiteCommand(query_products, connection))
                {
                    command_products.ExecuteNonQuery();
                }

                //扫查区域
                string query_scanareas =
                @"CREATE TABLE IF NOT EXISTS t_scanareas (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                areano INTEGER NOT NULL,
                offsetx REAL,
                offsety REAL,
                offsetz REAL,
                scanlen REAL,
                indexlen REAL,
                scanres REAL,
                indexres REAL,
                idt_products INTEGER NOT NULL,
                FOREIGN KEY (idt_products) REFERENCES t_products(id))";

                using (SQLiteCommand command_scanareas = new SQLiteCommand(query_scanareas, connection))
                {
                    command_scanareas.ExecuteNonQuery();
                }

                //系统参数
                string query_globalpars =
                @"CREATE TABLE IF NOT EXISTS t_globalpars (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                parname VARCHAR(50),
                parvalue VARCHAR(50),
                dispname VARCHAR(50))";

                using (SQLiteCommand command_globalpars = new SQLiteCommand(query_globalpars, connection))
                {
                    command_globalpars.ExecuteNonQuery();
                }

                connection.Close();
            }

            Console.WriteLine("表创建成功。");
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="connectionString">数据库名称</param>
        /// <param name="num">循环次数</param>
        public static void InsertData(string connectionString, int num)
        {
            DateTime startTime = DateTime.Now;
            DateTime updateTime = startTime.AddDays(7);
            string starttime = startTime.ToString("yyyy-MM-dd");
            string updatetime = updateTime.ToString("yyyy-MM-dd");
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO t_roles (rolename, notes) VALUES (@rolename, @notes);
                INSERT INTO t_users (username, userpwd, realname, idt_role) VALUES (@username, @userpwd, @realname, @idt_role);
                INSERT INTO t_modules (modulename, modulekey) VALUES (@modulename, @modulekey);
                INSERT INTO r_roleandmodule (idt_roles, idt_modules) VALUES (@idt_roles, @idt_modules);
                INSERT INTO t_accessories (accname, starttime, acctype, updatetime, circletime, circleunit) VALUES (@accname, @starttime, @acctype, @updatetime, @circletime, @circleunit);";
                for (int i = 1; i < num + 1; i++)
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@rolename", "工程师" + i);
                        command.Parameters.AddWithValue("@notes", "备注" + i);
                        command.Parameters.AddWithValue("@username", "user" + i);
                        command.Parameters.AddWithValue("@userpwd", "qwertv" + i);
                        command.Parameters.AddWithValue("@realname", "Tom" + i);
                        command.Parameters.AddWithValue("@idt_role", i);
                        command.Parameters.AddWithValue("@modulename", "功能" + i);
                        command.Parameters.AddWithValue("@modulekey", "key" + i);
                        command.Parameters.AddWithValue("@idt_roles", i);
                        command.Parameters.AddWithValue("@idt_modules", i);
                        command.Parameters.AddWithValue("@accname", "配件" + 1);
                        command.Parameters.AddWithValue("@starttime", starttime);
                        command.Parameters.AddWithValue("@acctype", 1);
                        command.Parameters.AddWithValue("@updatetime", updatetime);
                        command.Parameters.AddWithValue("@circletime", 7);
                        command.Parameters.AddWithValue("@circleunit", 1);
                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
            Console.WriteLine("添加成功。");
        }

        /// <summary>
        /// 返回一列数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<string> returnColData(string query)
        {
            List<string> options = new List<string>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        // 逐行读取数据
                        while (reader.Read())
                        {
                            string columnValue = reader.GetString(0);  // 0 是列索引，或者可以使用 reader["columnName"] 的方式获取指定列的值
                            options.Add(columnValue);

                        }
                    }
                }
            }
            return options;
        }
        /// <summary>
        /// 返回一列数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<string> returnRowData(string query,string layoutname)
        {
            List<string> options = new List<string>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@layoutname", layoutname);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                options.Add(Convert.ToString(reader.GetValue(i)));
                            }

                        }

                    }
                }
            }
                 
            return options;
        }

    }
}
