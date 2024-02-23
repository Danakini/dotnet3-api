using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using idc.version.Libs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace idc.version.Controllers
{
    public class BaseController : Controller
    {
        private lDbConn dbconn = new lDbConn();

        public string execExtAPIPost(string api, string path, string json)
        {
            var WebAPIURL = dbconn.domainGetApi(api);
            string requestStr = WebAPIURL + path;

            var client = new HttpClient();
            var contentData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(requestStr, contentData).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string execExtAPIPostWithToken(string api, string path, string json, string credential)
        {
            var WebAPIURL = dbconn.domainGetApi(api);
            string requestStr = WebAPIURL + path;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", credential);
            var contentData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //contentData.Headers.Add("Authorization", credential);

            HttpResponseMessage response = client.PostAsync(requestStr, contentData).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string execExtAPIGetWithToken(string api, string path, string json, string credential)
        {
            var WebAPIURL = dbconn.domainGetApi(api);
            string requestStr = WebAPIURL + path;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", credential);
            HttpResponseMessage response = client.GetAsync(requestStr).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string postConnection(string spname, params string[] list)
        {
            //var retObject = new List<dynamic>();
            string retObject = "";
            var parameter = spname;
            if (list != null && list.Count() > 0)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    parameter += ";" + list[i];
                }
            }
            retObject = postDataFromApi(parameter);
            return retObject;
        }

        public string postDataFromApi(string parameter)
        {
            var conn = dbconn.domainPostApi();
            WebRequest request = WebRequest.Create(conn + parameter);
            WebResponse response = request.GetResponseAsync().Result;
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            return responseFromServer;
        }

        public void execSqlWithExecption(string spname, params string[] list)
        {
            var conn = dbconn.conString();
            string message = "";
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            nconn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var pars = item.Split(',');

                    if (pars.Count() > 2)
                    {
                        if (pars[2] == "i")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToInt32(pars[1]));
                        }
                        else if (pars[2] == "s")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToString(pars[1]));
                        }
                        else if (pars[2] == "d")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToDecimal(pars[1]));
                        }
                        else if (pars[2] == "b")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToBoolean(pars[1]));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(pars[0], pars[1]);
                        }
                    }
                    else if (pars.Count() > 1)
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[1]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[0]);
                    }
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                message = "success";
            }
            catch (NpgsqlException e)
            {
                message = e.Message;
            }
            finally
            {
                nconn.Close();
            }
            //return message;
        }

        public void execSqlWithExecptionSplitSemicolon(string spname, params string[] list)
        {
            var conn = dbconn.conString();
            string message = "";
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            nconn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var pars = item.Split(';');

                    if (pars.Count() > 2)
                    {
                        if (pars[2] == "i")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToInt32(pars[1]));
                        }
                        else if (pars[2] == "s")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToString(pars[1]));
                        }
                        else if (pars[2] == "d")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToDecimal(pars[1]));
                        }
                        else if (pars[2] == "b")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToBoolean(pars[1]));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(pars[0], pars[1]);
                        }
                    }
                    else if (pars.Count() > 1)
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[1]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[0]);
                    }
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                message = "success";
            }
            catch (NpgsqlException e)
            {
                message = e.Message;
            }
            finally
            {
                nconn.Close();
            }
            //return message;
        }


        public void execSqlWithExecptionCaret(string spname, params string[] list)
        {
            var conn = dbconn.conString();
            string message = "";
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            nconn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var pars = item.Split('^');

                    if (pars.Count() > 2)
                    {
                        if (pars[2] == "i")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToInt32(pars[1]));
                        }
                        else if (pars[2] == "s")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToString(pars[1]));
                        }
                        else if (pars[2] == "d")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToDecimal(pars[1]));
                        }
                        else if (pars[2] == "b")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToBoolean(pars[1]));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(pars[0], pars[1]);
                        }
                    }
                    else if (pars.Count() > 1)
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[1]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[0]);
                    }
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                message = "success";
            }
            catch (NpgsqlException e)
            {
                message = e.Message;
            }
            finally
            {
                nconn.Close();
            }
            //return message;
        }


        public List<dynamic> getDataToObject(string spname, params string[] list)
        {
            var conn = dbconn.conString();
            StringBuilder sb = new StringBuilder();
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            var retObject = new List<dynamic>();

            nconn.Open();
            //NpgsqlTransaction tran = nconn.BeginTransaction();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var pars = item.Split(',');

                    if (pars.Count() > 2)
                    {
                        if (pars[2] == "i")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToInt32(pars[1]));
                        }
                        else if (pars[2] == "s")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToString(pars[1]));
                        }
                        else if (pars[2] == "d")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToDecimal(pars[1]));
                        }
                        else if (pars[2] == "dt")
                        {
                            cmd.Parameters.AddWithValue(pars[0], DateTime.ParseExact(pars[1], "yyyy-MM-dd", CultureInfo.InvariantCulture));
                        }
                        else if (pars[2] == "b")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToBoolean(pars[1]));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(pars[0], pars[1]);
                        }
                    }
                    else if (pars.Count() > 1)
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[1]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[0]);
                    }
                }
            }

            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr == null || dr.FieldCount == 0)
            {
                return retObject;
            }

            retObject = GetDataObj(dr);

            nconn.Close();
            return retObject;
        }

        public List<dynamic> getDataToObjectFromEtlData(string spname, params string[] list)
        {
            var conn = dbconn.conStringEtlData();
            StringBuilder sb = new StringBuilder();
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            var retObject = new List<dynamic>();

            nconn.Open();
            //NpgsqlTransaction tran = nconn.BeginTransaction();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var pars = item.Split(',');

                    if (pars.Count() > 2)
                    {
                        if (pars[2] == "i")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToInt32(pars[1]));
                        }
                        else if (pars[2] == "s")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToString(pars[1]));
                        }
                        else if (pars[2] == "d")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToDecimal(pars[1]));
                        }
                        else if (pars[2] == "dt")
                        {
                            cmd.Parameters.AddWithValue(pars[0], DateTime.ParseExact(pars[1], "yyyy-MM-dd", CultureInfo.InvariantCulture));
                        }
                        else if (pars[2] == "b")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToBoolean(pars[1]));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(pars[0], pars[1]);
                        }
                    }
                    else if (pars.Count() > 1)
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[1]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[0]);
                    }
                }
            }

            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr == null || dr.FieldCount == 0)
            {
                return retObject;
            }

            retObject = GetDataObj(dr);

            nconn.Close();
            return retObject;
        }

        public List<dynamic> getDataToObjectFromCustData(string spname, params string[] list)
        {
            var conn = dbconn.conStringCust();
            StringBuilder sb = new StringBuilder();
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            var retObject = new List<dynamic>();

            nconn.Open();
            //NpgsqlTransaction tran = nconn.BeginTransaction();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var pars = item.Split(',');

                    if (pars.Count() > 2)
                    {
                        if (pars[2] == "i")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToInt32(pars[1]));
                        }
                        else if (pars[2] == "s")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToString(pars[1]));
                        }
                        else if (pars[2] == "d")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToDecimal(pars[1]));
                        }
                        else if (pars[2] == "dt")
                        {
                            cmd.Parameters.AddWithValue(pars[0], DateTime.ParseExact(pars[1], "yyyy-MM-dd", CultureInfo.InvariantCulture));
                        }
                        else if (pars[2] == "b")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToBoolean(pars[1]));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(pars[0], pars[1]);
                        }
                    }
                    else if (pars.Count() > 1)
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[1]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[0]);
                    }
                }
            }

            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr == null || dr.FieldCount == 0)
            {
                return retObject;
            }

            retObject = GetDataObj(dr);

            nconn.Close();
            return retObject;
        }

        public List<dynamic> GetDataObj(NpgsqlDataReader dr)
        {
            var retObject = new List<dynamic>();
            while (dr.Read())
            {
                var dataRow = new ExpandoObject() as IDictionary<string, object>;
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dataRow.Add(
                           dr.GetName(i),
                           dr.IsDBNull(i) ? null : dr[i] // use null instead of {}
                   );
                }
                retObject.Add((ExpandoObject)dataRow);
            }

            return retObject;
        }

        public void execSqlWithSplitSemicolon(string spname, params string[] list)
        {
            var conn = dbconn.conStringLog();
            string message = "";
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            nconn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var pars = item.Split(';');

                    if (pars.Count() > 2)
                    {
                        if (pars[2] == "i")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToInt32(pars[1]));
                        }
                        else if (pars[2] == "s")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToString(pars[1]));
                        }
                        else if (pars[2] == "d")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToDecimal(pars[1]));
                        }
                        else if (pars[2] == "b")
                        {
                            cmd.Parameters.AddWithValue(pars[0], Convert.ToBoolean(pars[1]));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(pars[0], pars[1]);
                        }
                    }
                    else if (pars.Count() > 1)
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[1]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(pars[0], pars[0]);
                    }
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                message = "success";
            }
            catch (NpgsqlException e)
            {
                message = e.Message;
            }
            finally
            {
                nconn.Close();
            }
            //return message;
        }

        public string CheckValueData(JObject json, string prop)
        {
            var strReturn = "";
            if (json.Property(prop) != null)
            {
                strReturn = json.GetValue(prop).ToString();
            }
            return strReturn;
        }

        public void execSqlWithJSON(string spname, JObject json)
        {
            var conn = dbconn.conString();
            string message = "";
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            nconn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;
            string p_json = json.ToString();
            cmd.Parameters.AddWithValue("p_json", p_json);
            try
            {
                cmd.ExecuteNonQuery();
                message = "success";
            }
            catch (NpgsqlException e)
            {
                message = e.Message;
            }
            finally
            {
                nconn.Close();
            }
        }

        public string execSqlWithJSONwthMsg(string spname, JObject json)
        {
            var conn = dbconn.conString();
            string message = "";
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            nconn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;
            string p_json = json.ToString();
            cmd.Parameters.AddWithValue("p_json", p_json);
            try
            {
                cmd.ExecuteNonQuery();
                message = "success";
            }
            catch (NpgsqlException e)
            {
                message = e.Message;
            }
            finally
            {
                nconn.Close();
            }
            return message;
        }


        public List<dynamic> getDataToObjectJSONParam(string spname, JObject json)
        {
            var conn = dbconn.conString();
            StringBuilder sb = new StringBuilder();
            NpgsqlConnection nconn = new NpgsqlConnection(conn);
            var retObject = new List<dynamic>();

            nconn.Open();
            //NpgsqlTransaction tran = nconn.BeginTransaction();
            NpgsqlCommand cmd = new NpgsqlCommand(spname, nconn);
            cmd.CommandType = CommandType.StoredProcedure;
            string p_json = json.ToString();
            cmd.Parameters.AddWithValue("p_json", p_json);


            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr == null || dr.FieldCount == 0)
            {
                return retObject;
            }

            retObject = GetDataObj(dr);

            nconn.Close();
            return retObject;
        }
    }
}
