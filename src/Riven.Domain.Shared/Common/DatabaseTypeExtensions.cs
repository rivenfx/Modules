using System;
using System.Collections.Generic;
using System.Text;

namespace Riven.Common
{
    public static class DatabaseTypeExtensions
    {
        /// <summary>
        /// 将字符串转换为数据库类型，若匹配不上默认返回：<see cref="DatabaseType.SqlServer"/>
        /// </summary>
        /// <param name="databaseType"></param>
        /// <returns></returns>
        public static DatabaseType ToDatabaseType(this string databaseType)
        {
            switch (databaseType?.Trim().ToLower())
            {
                case "mysql":
                    return DatabaseType.MySql;
                case "postgresql":
                    return DatabaseType.PostgreSQL;
                case "oracle":
                    return DatabaseType.Oracle;
                case "sqlserver":
                default:
                    return DatabaseType.SqlServer;
            }
        }
    }
}

