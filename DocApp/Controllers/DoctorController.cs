using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocApp.Classes;
using DocApp.Models;
using System.IO;
using System.Web.Script.Serialization;

namespace DocApp.Controllers
{
    public class DoctorController : Controller
    {
        DoctorSearchEntities db = new DoctorSearchEntities();

        public ActionResult Doclogin()
        {
             
            return View();
        }


        [HttpPost]
        public ActionResult Doclogin(DocRegistraton collect)
        {
            string username = Request.Form["name"].ToLower();
            string pass1 = Request.Form["password"].ToLower();


            if (username == "" || pass1 == "")
            {
                ViewBag.error = "ERROR: ALL DATA MUST BE FILLED";

                return View();
            }


            var userdata = (from e in db.DocRegistratons where e.docusername == username && e.docpassword == pass1 select e).FirstOrDefault();

            if (userdata == null)
            {
                ViewBag.error = "ERROR: USERNAME DOSEN'T EXISTS, PLEASE TRY AGAIN";

                return View();

            }

            else
            {

                Session["name"] = username;
                Session["password"] = pass1;

                var userinfo = userdata;

                Allstatic.DocRegister = userinfo;

                return RedirectToAction("DocProfile");

            }

            return View();

        }


        public ActionResult DocRegister()
        {

            return View();
        }


        [HttpPost]
        public ActionResult DocRegister(DocRegistraton collect)
        {
            string username = Request.Form["name"].ToLower();
            string pass1 = Request.Form["password"].ToLower();
            string pass2 = Request.Form["password1"].ToLower();

            if (pass1 != pass2)
            {
                ViewBag.error = "ERROR: PASSWORDS ENTERED NOT THE SAME";

                return View();
            }


            var userdata = (from e in db.DocRegistratons where e.docusername == username select e).FirstOrDefault();

            if (userdata != null)
            {
                ViewBag.error = "ERROR: USERNAME ALREADY EXISTS";

                return View();

            }

            else
            {
                collect.docusername = username;
                collect.docpassword = pass1;

                Session["name"] = username;
                Session["password"] = pass1;


                Allstatic.Userlogin = "REGISTRATION SUCCESSFUL";

                Allstatic.DocRegister = collect;

                db.DocRegistratons.Add(collect);

                db.SaveChanges();

                return RedirectToAction("DocProfile");

            }


            return View();
        }


        public ActionResult DocProfile()
        {
            if (Allstatic.DocRegister.docname != null)
            {

                return RedirectToAction("DocPending");

            }
           
            
            
            string file = Server.MapPath("~/Images/states.json");
            //deserialize JSON from file  
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var personlist = ser.Deserialize<List<string>>(Json);

            
            
            
            var allcat = (from e in db.DocCategories orderby e.CatName  select e).ToList();

            ViewBag.states = personlist;
            
            ViewBag.category = allcat;
           
            return View();
        }

        [HttpPost]
        public ActionResult DocProfile(HttpPostedFileBase dfile)
        {
            string docfilename = "";
            
            
            
            if ((dfile == null))
            {

                ViewBag.error = "Please upload  your credentials";

                return RedirectToAction("DocProfile");
            }
            else
            {

                        int fileSize = dfile.ContentLength;
                        var fileType = dfile.FileName.Split(new char[] { '.' })[1].ToLower();
                        if (fileSize > (1024 * 1024 * 5))
                        {
                            ViewBag.error = "ERROR: Please file size should not be more than 5MB";

                            return RedirectToAction("DocProfile");


                        }
                        else if (fileType != "pdf" && fileType != "jpg" && fileType != "jpeg" && fileType != "png")
                        {
                            ViewBag.error = "ERROR: Only PDF or jpg files allowed";

                            return RedirectToAction("DocProfile");


                        }
                        else
                        {
                            try
                            {
                                // get stream
                                var stream = dfile.InputStream;

                                string FileName = System.IO.Path.GetFileName(dfile.FileName);

                                Random random = new Random();
                                int newnum =  random.Next(245, 2555555);  


                                string filename_server = newnum.ToString() + FileName;

                                string path = Path.Combine(Server.MapPath("~/Uploads"), filename_server);

                                using (var fileStream = System.IO.File.Create(path))
                                {
                                    stream.CopyTo(fileStream);
                                }

                                docfilename = filename_server;
                            }
                            catch (Exception e)
                            {
                                ViewBag.error = "ERROR: while uploading file to server, please try again";

                                return RedirectToAction("DocProfile");

                            }
                        }
            }

            string doctitle = Request.Form["doctitle"];
            string fullname = Request.Form["fullname"];
            string hospital = Request.Form["hospital"];
            string specialty = Request.Form["specialty"];
            string category = Request.Form["category"];
            string otherinfo = Request.Form["otherinfo"];
            string address = Request.Form["address"];
            string state = Request.Form["state"];

            if (doctitle == "" || hospital == "")
            {
                ViewBag.error = "ERROR: Name and Hospital field must be filled";

                return RedirectToAction("DocProfile");


            }
            else
            {
                var docdetails = db.DocRegistratons.FirstOrDefault(p => p.id == Allstatic.DocRegister.id);

                docdetails.docname = doctitle + " " + fullname;
                docdetails.hospital = hospital;
                docdetails.Specialty = specialty;
                docdetails.cattype = Convert.ToInt32(category);
                docdetails.OtherInfo = otherinfo;
                docdetails.uploadfile = docfilename;
                docdetails.approve = 0;
                docdetails.regdate = DateTime.Now;
                docdetails.address = address;
                docdetails.state = state;

                Allstatic.DocRegister = docdetails;
                
                db.SaveChanges();
            }




            return RedirectToAction("DocProfile");
        }

        public ActionResult DocPending()
        {

            if (Allstatic.DocRegister.docname == null)
            {

                return RedirectToAction("DocProfile");

            }
            
            var allpending = (from e in db.UserAppoints where e.docid == Allstatic.DocRegister.id && e.approve == 0 && e.treatapprove == 0  orderby e.id  descending select e).ToList();

            if (allpending != null)
            {

                return View(allpending);

            }

            ViewBag.error = "No Pending Treatment Avaiable";

            return View();
        }


        public ActionResult DocBooked()
        {

            if (Allstatic.DocRegister.docname == null)
            {

                return RedirectToAction("DocProfile");

            }

            var allpending = (from e in db.UserAppoints where e.docid == Allstatic.DocRegister.id && e.approve == 0 && e.treatapprove == 1 orderby e.id descending select e).ToList();

            if (allpending != null)
            {

                return View(allpending);

            }

            ViewBag.error = "No Pending Appointments";

            return View();
        }

        public ActionResult AllPending(int? id)
        {
            if (Allstatic.DocRegister.docname == null)
            {

                return RedirectToAction("DocProfile");

            }

           

            var userpending = (from e in db.UserAppoints where e.id == id select e).FirstOrDefault();

            var userdetail = (from e in db.Userdatas where e.id == userpending.userid select e).FirstOrDefault();

            ///var medrecord = (from e in db.UserMedHistories where e.userid == userpending.userid select e).ToList();

            var medrecord1 = (from s in db.UserMedHistories where s.userid == userdetail.id
                             join st in db.DocRegistratons
                             on s.docid equals st.id
                             select new Medhistory
                             {   ailment = s.ailment,
                                 treatment = s.treatment_prescribe,
                                 testresult = s.testresult,
                                 test =  s.test_done,
                                 recommendation = s.recommendation,
                                 date = s.date,
                                 docname = st.docname,
                                 hospital = st.hospital
                             }).ToList();



            TempData["userid"] = userdetail.id;

            TempData["appointid"] = id;

            ViewBag.medrecord = medrecord1;

            ViewBag.pending = userpending;

            ViewBag.userdata = userdetail;

            

            return View();
        }

        [HttpPost]
        public ActionResult AllPending(UserMedHistory med)
        {
            string ailment = Request.Form["ailment"];
            string dprescribe = Request.Form["dprescribe"];
            string test = Request.Form["test"];
            string testresult = Request.Form["testresult"];
            string recommend = Request.Form["recommend"];

            int approveid = Convert.ToInt32(TempData["appointid"]);

            med.ailment = ailment;
            med.treatment_prescribe = dprescribe;
            med.test_done = test;
            med.testresult = testresult;
            med.recommendation = recommend;
            med.docid = Allstatic.DocRegister.id;
            med.userid = Convert.ToInt32(TempData["userid"]);
            med.date = DateTime.Now;
            med.appointid = approveid;

            db.UserMedHistories.Add(med);

            

            var userappoint = (from e in db.UserAppoints where e.id == approveid select e).FirstOrDefault();

            userappoint.approve = 1;

            db.SaveChanges();


            return RedirectToAction("DocPending");
        
        }

        public ActionResult DocEdit()
        {
            if (Allstatic.DocRegister.docname == null)
            {

                return RedirectToAction("DocProfile");

            }



            string file = Server.MapPath("~/Images/states.json");
            //deserialize JSON from file  
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var personlist = ser.Deserialize<List<string>>(Json);


            var allcat = (from e in db.DocCategories orderby e.CatName select e).ToList();

            var editdoc = (from e in db.DocRegistratons where e.id == Allstatic.DocRegister.id select e).FirstOrDefault();

            ViewBag.editdoc = editdoc;
            
            ViewBag.states = personlist;

            ViewBag.category = allcat;

            return View();
        }

        [HttpPost]
        public ActionResult DocEdit(string one)
        {
           
            string doctitle = Request.Form["doctitle"];
            string fullname = Request.Form["fullname"];
            string hospital = Request.Form["hospital"];
            string specialty = Request.Form["specialty"];
            string category = Request.Form["category"];
            string otherinfo = Request.Form["otherinfo"];
            string address = Request.Form["address"];
            string state = Request.Form["state"];

            if (doctitle == "" || hospital == "")
            {
                ViewBag.error = "ERROR: Name and Hospital field must be filled";

                return RedirectToAction("DocEdit");


            }
            else
            {
                var docdetails = db.DocRegistratons.FirstOrDefault(p => p.id == Allstatic.DocRegister.id);

                docdetails.docname = doctitle + " " + fullname;
                docdetails.hospital = hospital;
                docdetails.Specialty = specialty;
                docdetails.cattype = Convert.ToInt32(category);
                docdetails.OtherInfo = otherinfo;
                docdetails.approve = 0;
                docdetails.regdate = DateTime.Now;
                docdetails.address = address;
                docdetails.state = state;

                Allstatic.DocRegister = docdetails;

                db.SaveChanges();
            }




            return RedirectToAction("DocPending");
        }



    }
}