using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using DocApp.Models;
using DocApp.Classes;
using DocApp.HelperClasses;


namespace DocApp.Controllers
{
    public class HomeController : Controller
    {
        DoctorSearchEntities db = new DoctorSearchEntities();


        public ActionResult Index()
        {

            var front = (from e in db.FrontPages where e.id == 1 select e).FirstOrDefault();

            if (front != null)
            {

                return View(front);

            }
            
            return View();
        }

        public ActionResult home()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(Userdata collect)
        {
            string username = Request.Form["name"].ToLower();
            string pass1 = Request.Form["password"].ToLower();
            string pass2 = Request.Form["password1"].ToLower();

            if (pass1 != pass2)
            {
                ViewBag.error = "ERROR: PASSWORDS ENTERED NOT THE SAME";

                return View();
            }


            var userdata = (from e in db.Userdatas where e.username == username select e).FirstOrDefault();

            if (userdata != null)
            {
                ViewBag.error = "ERROR: USERNAME ALREADY EXISTS";

                return View();

            }

            else
            {
                collect.username = username;
                collect.password = pass1;

                Session["name"] = username;
                Session["password"] = pass1;


                Allstatic.Userlogin = "REGISTRATION SUCCESSFUL";

                Allstatic.UserDetails = collect;

                db.Userdatas.Add(collect);

                db.SaveChanges();

                return RedirectToAction("UserPage");

            }

            
            return View();
        }



        public ActionResult UserLogin()
        {
            string loginerror = null;
            
            if (Session["showerror"] != null) {

                loginerror = Session["showerror"].ToString();
            }
            
            ViewBag.error1 = loginerror;
            
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(Userdata collect)
        {
            string username = Request.Form["name"].ToLower();
            string pass1 = Request.Form["password"].ToLower();


            if (username == "" || pass1 == "")
            {
                ViewBag.error = "ERROR: ALL DATA MUST BE FILLED";

                return View();
            }


            var userdata = (from e in db.Userdatas where e.username == username && e.password == pass1 select e).FirstOrDefault();

            if (userdata == null)
            {
                ViewBag.error = "ERROR: USERNAME DOSEN'T EXISTS, PLEASE TRY AGAIN";

                return View();

            }

            else if (userdata.role == "admin")
            {

                Session["name"] = username;
                Session["password"] = pass1;

                Allstatic.UserDetails = userdata;

                return RedirectToAction("index", "Admin");

            }

            else
            {
                
                Session["name"] = username;
                Session["password"] = pass1;

                var userinfo = userdata;

                Allstatic.UserDetails = userinfo; 

                return RedirectToAction("UserPage");

            }

            return View();
       
        }

        public ActionResult ShowDoclist(int showdoc, string ailment)
        {

            Session["booktype"] = "GME";
            
            var AllDocs = (from e in db.RemedyTables where e.id == showdoc select e).ToList();

            List<DocRegistraton> ShowDocs = new List<DocRegistraton>();


            foreach (var item in AllDocs)
            {

                var AllDoctors = (from e in db.DocRegistratons where e.cattype == item.cattype && e.approve == 1 select e).FirstOrDefault();

                ShowDocs.Add(AllDoctors);


            }

            Allstatic.Ailment = ailment;

            ViewBag.Alldocs = ShowDocs;

            return View();
        }

         public ActionResult ShowAillment(int showdoc)
         {

             List<string> Allailments = new List<string>();

             var Displaysympt = (from e in db.symptomtables where e.remedy == showdoc select e.symptom).ToList();

             var Showailment = (from e in db.RemedyTables where e.id == showdoc select e).FirstOrDefault();
             
             ViewBag.symptoms = Displaysympt;

             ViewBag.ailment = Showailment;


             
             return View();
        }

        [CusAuth(Roles = "User")]
        public ActionResult UserPage()
        {
            

            if (Session["Remedies"] != null)//retured from post
            {

                List<RemedyTable> remtable = (List<RemedyTable>)Session["Remedies"];

                List<string> symptable = (List<string>)Session["Symptoms"];

                ViewBag.remedies = remtable.ToArray();

                ViewBag.remsymptoms = symptable.ToArray();

                return View();

            }

            return View();
        }

        [HttpPost]
        public ActionResult UserPage(string one)
        {


            string sympone = Request.Form["sympone"];
            string sympone1 = Request.Form["sympone1"];
            string sympone2 = Request.Form["sympone2"];
            string sympone3 = Request.Form["sympone3"];
            string sympone4 = Request.Form["sympone4"];

            List<symptomtable> Allsymptoms = new List<symptomtable>();

            List<symptomtable> Allsymptoms1 = new List<symptomtable>();

            if (sympone == "" || sympone == null)
            {

                ViewBag.data = "Please Enter the First Search Symptom";

                return View();

            }
            else
            {

                var allsymp = (from e in db.symptomtables where e.symptom == sympone select e).ToList();


                if (allsymp.Count() != 0)
                {
                    Allsymptoms = allsymp;


                if (sympone1 != "" || sympone1 != null)
                {
 
                    var allsymp1 = (from e in db.symptomtables where e.symptom == sympone1 select e).ToList();


                    if (allsymp1.Count() != 0)
                    {
                        //Allsymptoms1 = allsymp1;

                        Allsymptoms = Allsymptoms.Union(allsymp1, new DefaultSingerComparer()).ToList();

                    }


                }


                if (sympone2 != "" || sympone2 != null)
                {

                    var symp2 = (from e in db.symptomtables where e.symptom == sympone2 select e).ToList();

                    if (symp2.Count() != 0)
                    {
                        //Allsymptoms1 = allsymp1;

                        Allsymptoms = Allsymptoms.Union(symp2, new DefaultSingerComparer()).ToList();

                    }

                }

                if (sympone3 != "" || sympone3 != null)
                {

                   var  symp3 = (from e in db.symptomtables where e.symptom == sympone3 select e).ToList();

                    if (symp3.Count() != 0)
                    {
                        //Allsymptoms1 = allsymp1;

                        Allsymptoms = Allsymptoms.Union(symp3, new DefaultSingerComparer()).ToList();

                    }

                }

                if (sympone4 != "" || sympone4 != null)
                {

                    var symp4 = (from e in db.symptomtables where e.symptom == sympone4 select e).ToList();


                    if (symp4.Count() != 0)
                    {
                        //Allsymptoms1 = allsymp1;

                        Allsymptoms = Allsymptoms.Union(symp4, new DefaultSingerComparer()).ToList();

                    }

                }


                List<RemedyTable> Allrem = new List<RemedyTable>();


                List<string> Allresymp = new List<string>();

                string Allsymp = "";



                foreach (var item in Allsymptoms)
                {

                   var dsymtoms = (from e in db.symptomtables where e.remedy == item.remedy select e.symptom).ToArray();



                   for (int i = 0; i < dsymtoms.Count(); i++)
                   {
                       int dlast = dsymtoms.Count() - i;
                       
                       if (dlast == 1)
                       {

                           Allsymp = Allsymp + dsymtoms[i];

                       }
                       else{

                           Allsymp = Allsymp + dsymtoms[i] + ",";

                       }
                       

                   }



                   Allresymp.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Allsymp));

                    Allsymp = "";
                  

                    var remedies = (from e in db.RemedyTables where e.id == item.remedy select e).FirstOrDefault();


                    Allrem.Add(remedies);
               
                }

              

                 Session["Remedies"] = Allrem;

                 Session["Symptoms"] = Allresymp;

                 ViewBag.remedies = Allrem.ToArray();

                 ViewBag.remsymptoms = Allresymp.ToArray();

                                    
                 return View();


                }//end first if
                else
                {

                     ViewBag.data = "Please Refine First Search Symptom";

                     return View();


                }

         }//end else



            return View();
        }




        [HttpPost]
        public JsonResult Allsymptoms(string prefix)
        {
            var Sympget = (from e in db.symptomtables where e.symptom.ToLower().StartsWith(prefix.ToLower()) select new { 
                       e.symptom
                         }).ToList().Distinct();


            return Json(Sympget);  

        }

        [HttpPost]
        public JsonResult Appointconfirm(string id)
        {
            int getid = Convert.ToInt32(id);


            var  confirmappoint = (from e in db.UserAppoints  where e.id == getid  select e).FirstOrDefault();

            confirmappoint.docdate = confirmappoint.dateofappoint;
            confirmappoint.doctime = confirmappoint.timeofvisit;
            confirmappoint.treatapprove = 1;

            db.SaveChanges();


            return Json("Appointment Confirmed");

        }
         
        [HttpPost]
        public JsonResult Patientconfirmed(string id)
        {
            int getid = Convert.ToInt32(id);


            var confirmappoint = (from e in db.UserAppoints where e.id == getid select e).FirstOrDefault();

            confirmappoint.dateofappoint = confirmappoint.docdate;
            confirmappoint.timeofvisit = confirmappoint.doctime;
            confirmappoint.treatapprove = 1;

            db.SaveChanges();


            return Json("Appointment Confirmed");

        }

        [HttpPost]  
        public JsonResult Reschedule(Allinfo alldata)
        {
            int getid = Convert.ToInt32(alldata.id);

            var result = Convert.ToDateTime(alldata.time);
          


            var confirmappoint = (from e in db.UserAppoints where e.id == getid select e).FirstOrDefault();

            confirmappoint.docdate = Convert.ToDateTime(alldata.date);
            confirmappoint.doctime = result.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
            confirmappoint.treatapprove = 2;

            db.SaveChanges();


            return Json("Appointment Rescheduled");

        }


        [HttpPost]
        public JsonResult PatientRescheduled(Allinfo alldata)
        {
            int getid = Convert.ToInt32(alldata.id);

            var result = Convert.ToDateTime(alldata.time);



            var confirmappoint = (from e in db.UserAppoints where e.id == getid select e).FirstOrDefault();

            confirmappoint.dateofappoint = Convert.ToDateTime(alldata.date);
            confirmappoint.timeofvisit = result.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
            confirmappoint.treatapprove = 0;

            db.SaveChanges();


            return Json("Appointment Rescheduled");

        }


        [HttpPost]
        public JsonResult Fees(Allinfo alldata)
        {
            int getid = Convert.ToInt32(alldata.id);

            var result = HttpUtility.HtmlEncode(alldata.fee);



            var confirmappoint = (from e in db.UserAppoints where e.id == getid select e).FirstOrDefault();

           
            confirmappoint.otherfee = result;
            confirmappoint.treatapprove = 1;

            db.SaveChanges();


            return Json("Appointment Confirmed");

        }

        


        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

           

            return View("index");
        }


        public ActionResult Testjava()
        {
           

            return View();
        }

        
    }



    
    public class DefaultSingerComparer : IEqualityComparer<symptomtable>
    {
        public bool Equals(symptomtable x, symptomtable y)
        {

            if (x.remedy == y.remedy || x.symptom.ToLower() == y.symptom.ToLower())
            {
                return true;

            }

            return false;
            
            // return x.remedy == y.remedy;


        }

        public int GetHashCode(symptomtable obj)
        {
            return obj.remedy.GetHashCode();
        }
    }



    public class Dsymtoms
    {
       public  List<string> Allsymtoms { get; set; }
    }

    public class Allinfo
    {
        public string id { get; set; }

        public DateTime date { get; set; }

        public string time { get; set; }

        public string fee { get; set; }


    }
}