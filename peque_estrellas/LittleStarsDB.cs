using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Data;

namespace peque_estrellas
{
    class LittleStarsDB
    {
        public static OdbcConnection connectionnResult()
        {
            OdbcConnection cnx = new OdbcConnection(Properties.Settings.Default.ruta);
            cnx.Open();
            return cnx;
        }
        
     }
}
