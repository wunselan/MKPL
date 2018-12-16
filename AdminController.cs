using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Apdex.Models;

namespace Apdex.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult HomepageAdmin()
        {
            return View();
        }

        public ActionResult ProfileAdmin()
        {

            return View();
        }

        public ActionResult GetMember()
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var profiles = dc.profiles.OrderBy(a => a.nama).ToList();
                return Json(new { data = profiles }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetProfile(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var profiles = dc.profiles.Where(a => a.member_id == id).ToList();
                return Json(new { data = profiles }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetBehaviour(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var behaviours = dc.behaviours.Where(a => a.member_id == id).ToList();
                return Json(new { data = behaviours }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetHav(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var havs = dc.havs.Where(a => a.member_id == id).ToList();
                return Json(new { data = havs }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetPerformance(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var performances = dc.performances.Where(a => a.member_id == id).ToList();
                return Json(new { data = performances }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetTraining(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var trainings = dc.trainings.Where(a => a.member_id == id).ToList();
                return Json(new { data = trainings }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCareer(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var careers = dc.careers.Where(a => a.member_id == id).ToList();
                return Json(new { data = careers }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.profiles.Where(a => a.member_id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(profile emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ApdexDBEntities dc = new ApdexDBEntities())
                {

                    if (emp.member_id > 0)
                    {
                        //edit
                        var v = dc.profiles.Where(a => a.member_id == emp.member_id).FirstOrDefault();
                        if (v != null)
                        {
                            v.company = emp.company;
                            v.nama = emp.nama;
                            v.jabatan = emp.jabatan;
                            v.tgl_lahir = emp.tgl_lahir;
                            v.usia = emp.usia;
                            v.tgl_masuk = emp.tgl_masuk;
                            v.masa_kerja = emp.masa_kerja;
                            v.gol = emp.gol;
                            v.tgl_gol = emp.tgl_gol;
                            v.strength = emp.strength;
                            v.aod = emp.aod;

                        }
                    }
                    else
                    {
                        //save
                        dc.profiles.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            new JsonResult { Data = new { status = status } };
            return View("HomepageAdmin");
        }

        [HttpGet]
        public ActionResult SaveBehaviour(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.behaviours.Where(a => a.member_id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult SaveBehaviour(behaviour emp)
        {
            bool status = false;
            var id = 0;
          //  if (ModelState.IsValid)
           // {
                using (ApdexDBEntities dc = new ApdexDBEntities())
                {

                    if (emp.behaviour_id > 0)
                    {
                        //edit
                        var v = dc.behaviours.Where(a => a.behaviour_id == emp.behaviour_id).FirstOrDefault();
                        if (v != null)
                        {
                           // v.member_id = emp.member_id;
                            v.vis_bis_sens = emp.vis_bis_sens;
                            v.cust_focus = emp.cust_focus;
                            v.interp_skills = emp.interp_skills;
                            v.analysis_and_judge = emp.analysis_and_judge;
                            v.plan_drive_action = emp.plan_drive_action;
                            v.lead_motivating = emp.lead_motivating;
                            v.teamwork = emp.teamwork;
                            v.drive_cour_integrity = emp.drive_cour_integrity;
                            // System.Diagnostics.Debug.WriteLine(v.member_id);
                            id = v.member_id;

                        }
                    }
                    else
                    {
                        //save
                        dc.behaviours.Add(emp);
                        id = emp.member_id;

                }
                   
                    dc.SaveChanges();
                    status = true;
                }
           // }
            new JsonResult { Data = new { status = status } };
            string newUrl = Url.Action("ProfileAdmin?id="+ id);
           
            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
            
        }

        [HttpGet]
        public ActionResult SaveHav(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.havs.Where(a => a.member_id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult SaveHav(hav emp)
        {
            bool status = false;
            var id = 0;
            //  if (ModelState.IsValid)
            // {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {

                if (emp.hav_id > 0)
                {
                    //edit
                    var v = dc.havs.Where(a => a.hav_id == emp.hav_id).FirstOrDefault();
                    if (v != null)
                    {
                        // v.member_id = emp.member_id;
                        v.tahun1 = emp.tahun1;
                        v.nhav1 = emp.nhav1;
                        v.tahun2 = emp.tahun2;
                        v.nhav2 = emp.nhav2;
                        v.tahun3 = emp.tahun3;
                        v.nhav3 = emp.nhav3;
                        v.tahun4 = emp.tahun4;
                        v.nhav4 = emp.nhav4;
                        v.tahun5 = emp.tahun5;
                        v.nhav5 = emp.nhav5;
                        id = v.member_id;
                    }
                }
                else
                {
                    //save
                    id = emp.member_id;
                    dc.havs.Add(emp);

                }
                dc.SaveChanges();
                status = true;
            }
            // }
            new JsonResult { Data = new { status = status } };
            string newUrl = Url.Action("ProfileAdmin?id=" + id);
            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
        }

        [HttpGet]
        public ActionResult SavePerformance(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.performances.Where(a => a.member_id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult SavePerformance(performance emp)
        {
            bool status = false;
            var id = 0;
            //  if (ModelState.IsValid)
            // {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {

                if (emp.perf_id > 0)
                {
                    //edit
                    var v = dc.performances.Where(a => a.perf_id == emp.perf_id).FirstOrDefault();
                    if (v != null)
                    {
                        // v.member_id = emp.member_id;
                        v.ptahun1 = emp.ptahun1;
                        v.nperf1 = emp.nperf1;
                        v.ptahun2 = emp.ptahun2;
                        v.nperf2 = emp.nperf2;
                        v.ptahun3 = emp.ptahun3;
                        v.nperf3 = emp.nperf3;
                        v.ptahun4 = emp.ptahun4;
                        v.nperf4 = emp.nperf4;
                        v.ptahun5 = emp.ptahun5;
                        v.nperf5 = emp.nperf5;
                        id = v.member_id;

                    }
                }
                else
                {
                    //save
                    id = emp.member_id;
                    dc.performances.Add(emp);

                }
                dc.SaveChanges();
                status = true;
            }
            // }
            new JsonResult { Data = new { status = status } };
            string newUrl = Url.Action("ProfileAdmin?id=" + id);

            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
        }

        [HttpGet]
        public ActionResult SaveTraining(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.trainings.Where(a => a.member_id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult SaveTraining(training emp)
        {
            bool status = false;
            var id = 0;
            //  if (ModelState.IsValid)
            // {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {

                if (emp.training_id > 0)
                {
                    //edit
                    var v = dc.trainings.Where(a => a.training_id == emp.training_id).FirstOrDefault();
                    if (v != null)
                    {
                        // v.member_id = emp.member_id;
                        v.ammp = emp.ammp;
                        v.agmp = emp.agmp;
                        v.aep = emp.aep;
                        v.others = emp.others;
                        v.others1 = emp.others1;
                        id = v.member_id;
                    }
                }
                else
                {
                    //save
                    dc.trainings.Add(emp);
                    id = emp.member_id;

                }
                dc.SaveChanges();
                status = true;
            }
            // }
            new JsonResult { Data = new { status = status } };
            string newUrl = Url.Action("ProfileAdmin?id=" + id);

            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
        }

        [HttpGet]
        public ActionResult SaveCareer(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.careers.Where(a => a.member_id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult SaveCareer(career emp)
        {
            bool status = false;
            var id = 0;
            //  if (ModelState.IsValid)
            // {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {

                if (emp.career_id > 0)
                {
                    //edit
                    var v = dc.careers.Where(a => a.career_id == emp.career_id).FirstOrDefault();
                    if (v != null)
                    {
                        // v.member_id = emp.member_id;
                        v.career1 = emp.career1;
                        v.career2 = emp.career2;
                        v.career3 = emp.career3;
                        id = v.member_id;
                    }
                }
                else
                {
                    //save
                    dc.careers.Add(emp);
                    id = emp.member_id;

                }
                dc.SaveChanges();
                status = true;
            }
            // }
            new JsonResult { Data = new { status = status } };
            string newUrl = Url.Action("ProfileAdmin?id=" + id);

            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.profiles.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("delete")]

        public ActionResult DeleteProfile(int id)
        {
            bool status = false;
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.profiles.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.profiles.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            new JsonResult { Data = new { status = status } };
            return View("HomepageAdmin");
        }

        [HttpGet]
        public ActionResult DeleteBehaviour(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.behaviours.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("DeleteBehaviour")]

        public ActionResult DeleteBehaviour1(int id)
        {
            bool status = false;
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.behaviours.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.behaviours.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            new JsonResult { Data = new { status = status } };
            string newUrl = Url.Action("ProfileAdmin?id=" + id);
            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
        }

        [HttpGet]
        public ActionResult DeleteHav(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.havs.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("DeleteHav")]

        public ActionResult DeleteHav1(int id)
        {
            bool status = false;
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.havs.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.havs.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            string newUrl = Url.Action("ProfileAdmin?id=" + id);
            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
        }

        [HttpGet]
        public ActionResult DeletePerformance(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.performances.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("DeletePerformance")]

        public ActionResult DeletePerformance1(int id)
        {
            bool status = false;
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.performances.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.performances.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            string newUrl = Url.Action("ProfileAdmin?id=" + id);
            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
        }

        [HttpGet]
        public ActionResult DeleteTraining(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.trainings.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("DeleteTraining")]

        public ActionResult DeleteTraining1(int id)
        {
            bool status = false;
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.trainings.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.trainings.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            string newUrl = Url.Action("ProfileAdmin?id=" + id);
            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
        }

        [HttpGet]
        public ActionResult DeleteCareer(int id)
        {
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.careers.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("DeleteCareer")]

        public ActionResult DeleteCareer1(int id)
        {
            bool status = false;
            using (ApdexDBEntities dc = new ApdexDBEntities())
            {
                var v = dc.careers.Where(a => a.member_id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.careers.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            string newUrl = Url.Action("ProfileAdmin?id=" + id);
            string plussedUrl = newUrl.Replace("%3fid%3d", "?id=");
            return new RedirectResult(plussedUrl);
        }

        ApdexDBEntities dc = new ApdexDBEntities();
        public ActionResult Chart()
        {

            return View();
        }
        
    }
}
