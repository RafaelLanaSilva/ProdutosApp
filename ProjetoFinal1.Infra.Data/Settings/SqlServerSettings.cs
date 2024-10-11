using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Data.Settings
{
    public class SqlServerSettings
    {
        public static string ConnectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProjetoFinal1;Integrated Security=True;";
    }
}
