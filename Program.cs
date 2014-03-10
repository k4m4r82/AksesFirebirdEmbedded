using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FirebirdSql.Data.FirebirdClient;

namespace AksesFirebirdEmbedded
{
    class Program
    {
        static void Main(string[] args)
        {
            var appPath = System.IO.Directory.GetCurrentDirectory();

            appPath = @"192.168.1.2:E:\fb\TEST.FDB";
            appPath = @"I:\TEST.FDB";
            var strConn = "ServerType=1;User=SYSDBA;Password=masterkey;Dialect=3;Database=" + appPath;

            using (var conn = new FbConnection(strConn))
            {
                conn.Open();

                var strSql = "SELECT idagama, deskripsi FROM agama";
                using (var cmd = new FbCommand(strSql, conn))
                {
                    using (var dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Console.WriteLine(dtr.GetString(0) + ", " + dtr.GetString(1));
                        }
                    }
                }
            }
        
            Console.ReadKey();
        }
    }
}
