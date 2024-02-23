using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using idc.version.Libs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json.Linq;

namespace idc.version.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("idcversion/[controller]")]
    public class VersionController : Controller
    {

        private BaseController bc = new BaseController();
        private MessageController mc = new MessageController();
        private lConvert lc = new lConvert();
        private lServiceLogs lsl = new lServiceLogs();


        [HttpGet("GetAppList")]
        public JObject GetAppList()
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_app_list";
                retObject = bc.getDataToObject(spname);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }

        [HttpGet("GetAppStatus")]
        public JObject GetAppStatus()
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_app_status";
                retObject = bc.getDataToObject(spname);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        [HttpGet("GetLastVersionApp/{id}")]
        public JObject GetLastVersionApp(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_last_version";
                string p1 = "p_app_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }

        /*
        [HttpGet("GetAppDetailById/{id}")]
        public JObject GetAppDetailById(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_app_detail_byid";
                string p1 = "p_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }
        */

        [HttpGet("GetAppDetail/{id}")]
        public JObject GetAppDetail(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_app_detail";
                string p1 = "p_app_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        [HttpGet("GetAppType")]
        public JObject String()
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_app_type";
                retObject = bc.getDataToObject(spname);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        [HttpGet("GetApp/{id}")]
        public JObject GetApp(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_app_list_id";
                string p1 = "p_app_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        //API New 2/2/2022
        //New untuk website admin page Version Back end & Front End

        //API Version Back End


        //API untuk pilihan checkboxes App Back End
        [HttpGet("GetAppTypeBE")]
        public JObject StringBE()
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_app_typeBE";
                retObject = bc.getDataToObject(spname);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }

        //API untuk generate list versi App Back End
        [HttpGet("GetBEAppDetail/{id}")]
        public JObject GetBEAppDetail(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_be_app_detail";
                string p1 = "p_app_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        //API untuk lihat detail versi backend dari id versi
        [HttpGet("GetBEAppDetailById/{id}")]
        public JObject GetBEAppDetailById(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_be_app_detail_byid";
                string p1 = "p_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }

        //API untuk menambah versi baru beserta detailnya, modified untuk kolom baru
        [HttpPost("AddBEVersionDetail")]
        public JObject AddBEVersionDetail([FromBody] JObject json)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();

            try
            {
                string spname = "version.get_be_last_version_det";
                retObject = bc.getDataToObjectJSONParam(spname, json);

                var jaReturn = lc.convertDynamicToJArray(retObject);
                var joReturn = new JObject();
                String newVersion = "";
                if (jaReturn.Count > 0)
                {
                    joReturn = JObject.Parse(jaReturn[0].ToString());

                    String version = joReturn.GetValue("vers_text").ToString();
                    String[] verSplit = version.Split(".");
                    if (verSplit.Length == 4)
                    {

                        int stat = Int32.Parse("" + json.GetValue("p_status"));
                        if (stat == 0)
                        {

                            //newVersion = (Int32.Parse(verSplit[0]) + 1) + "." + verSplit[1] + "." + verSplit[2] + "." + verSplit[3];
                            newVersion = (Int32.Parse(verSplit[0]) + 1) + ".0.0.0";
                        }
                        else if (stat == 1)
                        {
                            //newVersion = verSplit[0] + "." + (Int32.Parse(verSplit[1]) + 1) + "." + verSplit[2] + "." + verSplit[3];
                            newVersion = verSplit[0] + "." + (Int32.Parse(verSplit[1]) + 1) + ".0.0";
                        }
                        else if (stat == 2)
                        { //1.1.1.1
                            //newVersion = verSplit[0] + "." + verSplit[1] + "." + (Int32.Parse(verSplit[2]) + 1) + "." + verSplit[3];
                            newVersion = verSplit[0] + "." + verSplit[1] + "." + (Int32.Parse(verSplit[2]) + 1) + ".0";

                        }
                        else
                        {
                            newVersion = verSplit[0] + "." + verSplit[1] + "." + verSplit[2] + "." + (Int32.Parse(verSplit[3]) + 1);

                        }
                    }
                }
                else
                {
                    newVersion = "1.0.0.0";
                }
                json.Add("p_app_version", newVersion);
                string spname1 = "version.insert_be_version_detail";
                bc.execSqlWithJSON(spname1, json);
                data = new JObject();
                data.Add("status", mc.GetMessage("process_success"));
                data.Add("message", mc.GetMessage("save_success"));
            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            return data;
        }

        //API untuk edit detail version back end, modified untuk kolom baru
        [HttpPost("EditBEVersionDetail")]
        public JObject EditBEVersionDetail([FromBody] JObject json)
        {
            var data = new JObject();
            try
            {
                string spname1 = "version.update_be_version_detail";
                string msg = bc.execSqlWithJSONwthMsg(spname1, json);
                data = new JObject();

                if (msg == "success")
                {
                    data.Add("status", mc.GetMessage("process_success"));
                    data.Add("message", mc.GetMessage("update_success"));
                }
                else
                {
                    data.Add("status", mc.GetMessage("process_not_success"));
                    data.Add("message", msg);
                }

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }

            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), json.ToString(), data.ToString());
            return data;

        }


        //API untuk menghapus detail versi back end  dari id
        [HttpPost("DeleteBEAppDetail")]
        public JObject DeleteBEAppDetail([FromBody] JObject json)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.delete_be_version_detail";
                bc.execSqlWithJSON(spname, json);
                data = new JObject();
                data.Add("status", mc.GetMessage("process_success"));
                data.Add("message", mc.GetMessage("delete_success"));
            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }

        //API untuk mengeluarkan droplist tahun version Back End
        [HttpGet("GetYearListBE/{id}")]
        public JObject YearBE(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_be_year_list";
                string p1 = "p_app_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            return data;
        }

        //API untuk mengeluarkan daftar versi back end dari tahun yang dipilih untuk di export
        [HttpGet("GetBEVersionByYear/{id}")]
        public JObject GetBEYearlyDetail(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.export_be_version";
                string p1 = "p_year," + id + ",s";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        //API Version Front End

        //API untuk mengeluarkan data checkboxes version Front End
        [HttpGet("GetAppTypeFE")]
        public JObject StringFE()
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_app_typeFE";
                retObject = bc.getDataToObject(spname);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        //API untuk generate list versi App front End
        [HttpGet("GetFEAppDetail/{id}")]
        public JObject GetFEAppDetail(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_fe_app_detail";
                string p1 = "p_app_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        //API untuk lihat detail versi front end dari id versi
        [HttpGet("GetFEAppDetailById/{id}")]
        public JObject GetFEAppDetailById(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_fe_app_detail_byid";
                string p1 = "p_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);

                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        //API untuk menambah versi baru beserta detailnya, modified untuk tabel baru
        [HttpPost("AddFEVersionDetail")]
        public JObject AddFEVersionDetail([FromBody] JObject json)
        {
            var data = new JObject();
            try
            {
                string spname1 = "version.insert_fe2_version_detail";
                string msg = bc.execSqlWithJSONwthMsg(spname1, json);
                data = new JObject();

                if (msg == "success")
                {
                    data.Add("status", mc.GetMessage("process_success"));
                    data.Add("message", mc.GetMessage("save_success"));
                }
                else
                {
                    data.Add("status", mc.GetMessage("process_not_success"));
                    data.Add("message", msg);
                }
            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            return data;
        }


        //API untuk edit detail version front end, modified untuk tabel baru
        [HttpPost("EditFEVersionDetail")]
        public JObject EditFEVersionDetail([FromBody] JObject json)
        {
            var data = new JObject();
            try
            {
                string spname1 = "version.update_fe2_version_detail"; //1 android 19//2 android 19
                string msg = bc.execSqlWithJSONwthMsg(spname1, json);
                data = new JObject();

                if (msg == "success")
                {
                    data.Add("status", mc.GetMessage("process_success"));
                    data.Add("message", mc.GetMessage("update_success"));
                }
                else
                {
                    data.Add("status", mc.GetMessage("process_not_success"));
                    data.Add("message", msg);
                }

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }

            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), json.ToString(), data.ToString());
            return data;
        }


        //API untuk menghapus detail versi back end  dari id
        [HttpPost("DeleteFEAppDetail")]
        public JObject DeleteFEAppDetail([FromBody] JObject json)
        {
            var data = new JObject();
            try
            {
                string spname = "version.delete_fe_version_detail";
                bc.execSqlWithJSON(spname, json);
                data = new JObject();
                data.Add("status", mc.GetMessage("process_success"));
                data.Add("message", mc.GetMessage("delete_success"));


            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }

        //API untuk mengeluarkan droplist tahun version Front End
        [HttpGet("GetYearListFE/{id}")]
        public JObject YearFE(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_fe_year_list";
                string p1 = "p_app_id," + id + ",i";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            return data;
        }

        //API untuk mengeluarkan daftar versi back end dari tahun yang dipilih untuk di export
        [HttpGet("GetFEVersionByYear/{id}")]
        public JObject GetFEYearlyDetail(string id)
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.export_fe_version";
                string p1 = "p_year," + id + ",s";
                retObject = bc.getDataToObject(spname, p1);
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));

            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        //Mengeluarkan versi ios terbaru dari versi front end
        [HttpGet("GetIosLatestVersion")]

        public JObject GetIosLatestVersion()
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_ios_last_version";
                retObject = bc.getDataToObject(spname);

                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));
            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }


        //Mengeluarkan versi android terbaru dari versi front end
        [HttpGet("GetAndroidLatestVersion")]

        public JObject GetAndroidLatestVersion()
        {
            var retObject = new List<dynamic>();
            var data = new JObject();
            try
            {
                string spname = "version.get_android_last_version";
                retObject = bc.getDataToObject(spname);

                data.Add("status", mc.GetMessage("api_output_ok"));
                data.Add("message", mc.GetMessage("process_success"));
                data.Add("data", lc.convertDynamicToJArray(retObject));
            }
            catch (Exception ex)
            {
                data = new JObject();
                data.Add("status", mc.GetMessage("api_output_not_ok"));
                data.Add("message", ex.Message);
            }
            //lsl.ServiceRecordLogs(HttpContext.Request.Method.ToString(), HttpContext.Request.Path.Value.ToString(), "", data.ToString());
            return data;
        }
    }
}
