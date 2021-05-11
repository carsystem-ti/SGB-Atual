using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGB
{
    public class Fury
    {
        public static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cns"].ToString();

        public System.Data.DataTable getTable(System.Data.CommandType pTipo, string pComando, object[] pParametros)
        {
            return (System.Data.DataTable)executeSQL(pTipo, pComando, pParametros, true);
        }

        public int setTable(System.Data.CommandType pTipo, string pComando, object[] pParametros)
        {
            return (int)executeSQL(pTipo, pComando, pParametros, false);
        }

        private object executeSQL(System.Data.CommandType pTipo, string pComando, object[] pParametros, bool pRetornaDados)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connection))
                {
                    conn.Open();

                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(pComando, conn);

                    cmd.CommandTimeout = 160;
                    cmd.CommandType = pTipo;

                    if (pParametros != null)
                    {
                        foreach (object[] objeto in pParametros)
                            cmd.Parameters.AddWithValue(objeto[0].ToString(), objeto[1]);
                    }

                    if (pRetornaDados)
                    {

                        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                        System.Data.DataTable iTabela = new System.Data.DataTable();
                        da.Fill(iTabela);

                        return iTabela;
                    }
                    else
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
