using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMSTech.Models;

namespace SMSTech.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult UserView()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/user";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                User Usr = new User();

                dt.Columns.Add("RoleID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Phone  ");
                dt.Columns.Add("Address");
                dt.Columns.Add("Status  ");
                dt.Columns.Add("Username");
                dt.Columns.Add("Password");
                dt.Columns.Add("RankID  ");
                dt.Columns.Add("NationalityID");
                dt.Columns.Add("EducationID  ");
                dt.Columns.Add("ExperienceID ");
                dt.Columns.Add("ReligionID   ");
                dt.Columns.Add("AppointmentDate");
                dt.Columns.Add("TerminationDate");
                dt.Columns.Add("DateOfBirth");
                dt.Columns.Add("Phone2     ");
                dt.Columns.Add("Email      ");
                dt.Columns.Add("Comments   ");

                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    Usr.Rid = data.RoleID;
                    Usr.Name = data.Name;
                    Usr.Phone = data.Phone;
                    Usr.Addr = data.NAddress;
                    Usr.Status = data.Status;
                    Usr.Username = data.Username;
                    Usr.Pass = data.Password;
                    Usr.Rankid = data.RankID;
                    Usr.Nid = data.NationalityID;
                    Usr.Eduid = data.EducationID;
                    Usr.Expid = data.ExperienceID;
                    Usr.Relid = data.ReligionID;
                    Usr.AppDate = data.AppointmentDate;
                    Usr.TermDate = data.TerminationDate;
                    Usr.DOB = data.DateOfBirth;
                    Usr.Phone2 = data.Phone2;
                    Usr.Email = data.Email;
                    Usr.comments = data.Comments;


                    dt.Rows.Add();
                    dt.Rows[i]["RoleID"] = Usr.Rid;
                    dt.Rows[i]["Name"] = Usr.Name;
                    dt.Rows[i]["Phone"] = Usr.Phone;
                    dt.Rows[i]["Address"] = Usr.Addr;
                    dt.Rows[i]["Status"] = Usr.Status;
                    dt.Rows[i]["Username"] = Usr.Username;
                    dt.Rows[i]["Password"] = Usr.Pass;
                    dt.Rows[i]["RankID"] = Usr.Rankid;
                    dt.Rows[i]["NationalityID"] = Usr.Nid;
                    dt.Rows[i]["EducationID"] = Usr.Eduid;
                    dt.Rows[i]["ExperienceID"] = Usr.Expid;
                    dt.Rows[i]["ReligionID"] = Usr.Relid;
                    dt.Rows[i]["AppointmentDate"] = Usr.AppDate;
                    dt.Rows[i]["TerminationDate"] = Usr.TermDate;
                    dt.Rows[i]["DateOfBirth"] = Usr.DOB;
                    dt.Rows[i]["Phone2"] = Usr.Phone2;
                    dt.Rows[i]["Email"] = Usr.Email;
                    dt.Rows[i]["Comments"] = Usr.comments;

                }
            }
            return View(dt);



            //RoleID
            //Name
            //Phone
            //Address
            //Status
            //Username
            //Password
            //RankID
            //NationalityID
            //EducationID
            //ExperienceID
            //ReligionID
            //AppointmentDate
            //TerminationDate
            //DateOfBirth
            //Phone2
            //Email
            //Comments


        }
    }
}