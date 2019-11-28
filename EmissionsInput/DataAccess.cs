using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace EmissionsInput
{
    public class DataAccess
    {
        public List<MySource> GetMySensors()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionStringValue("emissionsDBtest")))
            {
                return connection.Query<MySource>("select * from MySources;").ToList();
            }
        }

        internal void InsertMySource(string uuid, int _pniv)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionStringValue("emissionsDBtest")))
            {
                MySource newSource = new MySource()
                {
                    SourceUuid = uuid,
                    pniv = _pniv
                };

                List<MySource> sources = new List<MySource>();
                sources.Add(newSource);

                connection.Execute("insert into MySources (SourceUuid, pniv) values (@SourceUuid, @pniv);", sources);
            }
        }
    }
}
