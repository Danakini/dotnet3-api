using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using idc.version.Libs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace idc.version.Controllers
{
    public class BasetrxController : Controller
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();

        public string InsertversionPriority(JObject json)
        {
            string strout = "";
            JObject jo = new JObject();
            var conn = dbconn.conString();
            NpgsqlTransaction trans;
            NpgsqlConnection connection = new NpgsqlConnection(conn);
            connection.Open();
            trans = connection.BeginTransaction();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("remove_version_priorities", connection, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                for (int i = 0; i < json.GetValue("data").Count(); i++)
                {
                    cmd = new NpgsqlCommand("insert_version_priorities", connection, trans);
                    jo = new JObject();
                    jo = JObject.Parse(json.GetValue("data")[i].ToString());
                    cmd.Transaction = trans;
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_rule1", jo.GetValue("rule1").ToString());
                    cmd.Parameters.AddWithValue("p_rule2", jo.GetValue("rule2").ToString());
                    cmd.Parameters.AddWithValue("p_rule3", jo.GetValue("rule3").ToString());
                    cmd.Parameters.AddWithValue("p_state", jo.GetValue("state").ToString());
                    cmd.Parameters.AddWithValue("p_order", (i + 1));
                    cmd.Parameters.AddWithValue("p_user", json.GetValue("username").ToString());
                    cmd.ExecuteNonQuery();
                }

                trans.Commit();
                strout = "success";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                strout = ex.Message;
            }
            connection.Close();
            return strout;
        }
    }
}
