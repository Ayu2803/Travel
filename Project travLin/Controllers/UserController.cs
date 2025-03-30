using Gamers_Arena.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_travLin.Controllers

{

    

    public class UserController : Controller
    {

        db database = new db();
        // GET: User

       

        public ActionResult profile()
        {


            if (Session["User"] != null)
            {

                //string command = "select * from profile_sec where us='" + Session["User"] + "'";

                //DataTable dt = database.SelectStatment(command);

                //ViewBag.profile = dt;

                //string comman = "select * from edit where gamer='" + Session["User"] + "'";

                //DataTable d = database.SelectStatment(comman);
                //ViewBag.edit = d;



                string comm = "select * from AUser where mail='" + Session["User"] + "'";

                DataTable jt = database.SelectStatment(comm);

                ViewBag.user = jt;

                return View();


                //return RedirectToAction("profile");

            }

            else
            {
                return View();
            }

        }


        [HttpPost]
        public ActionResult profile(string name,string mail,string message)
        {


            string command = "insert into contact values('" + name + "' , '" + mail + "' , '" + message + "');";

            int d = database.InserUpdateDelete(command);

            if (d > 0)
            {

                return Content("<script>alert('user successfully registered! please log in to continue'); location.href='/user/profile';</script>");

            }


            else
            {

                return Content("<script>alert('user registration failed'); location.href='/home/login';</script>");


            }





        }



        public ActionResult cat(string name)
        {

            string comm = "select * from PLACE where cat='" + name + "'";

            DataTable jt = database.SelectStatment(comm);

            ViewBag.user = jt;

            return View();

         
        
        }





            public ActionResult Index()
        {

            string command = "SELECT TOP(9) * FROM PLACE Order By p_id DESC;";

            DataTable dt = database.SelectStatment(command);
            ViewBag.data = dt;





            string comm = "SELECT TOP(4) serNo,name,icon FROM category Order By serNo DESC;";

            DataTable dc = database.SelectStatment(comm);
            ViewBag.cat = dc;





            string cd = "SELECT TOP(3) * FROM PLACE Order By p_id DESC";

            DataTable ds = database.SelectStatment(cd);
            ViewBag.suggest = ds;


            return View();
        }

        [HttpPost]

        public ActionResult searchhome(string search)
        {
            string cmd = "SELECT * FROM PLACE WHERE para1 LIKE '%" + search + "%' OR name LIKE '%" + search + "%' OR phrase LIKE '%" + search + "%' OR para1b LIKE '%" + search + "%'  OR tp_para LIKE '%" + search + "%' OR tp1_head LIKE '%" + search + "%'  OR tp1_para LIKE '%" + search + "%'   OR tp2_head LIKE '%" + search + "%'   OR tp2_para LIKE '%" + search + "%'   OR tp2_point1 LIKE '%" + search + "%'   OR tp2_point2 LIKE '%" + search + "%'   OR tp2_point3 LIKE '%" + search + "%'     OR tp3_head LIKE '%" + search + "%'   OR tp3_para LIKE '%" + search + "%'   OR tp3_point1 LIKE '%" + search + "%'   OR tp3_point2 LIKE '%" + search + "%'   OR tp3_point3 LIKE '%" + search + "%'  OR tp4_head LIKE '%" + search + "%'   OR tp4_para LIKE '%" + search + "%'";



            DataTable dt = database.SelectStatment(cmd);
            ViewBag.Data = dt;

            return View();


            //if (dt.Rows.Count > 0)
            //{


            //    return RedirectToAction("searchhome", "home");


            //}

            //else
            //{

            //    return Content("<script>alert('bhag yaha se') location.href='/home/admin';</script>");


            //}




        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }




        public ActionResult search()
        {

            string command = "select * from PLACE";

            DataTable dt = database.SelectStatment(command);
            ViewBag.data = dt;


            return View();

        }



        public ActionResult admin()
        {
            return View();
        }

        [HttpPost]

        public ActionResult admin(string user_id, string pass)
        {
            string command = "select * from admin where user_id='" + user_id + "'and password='" + pass + "'";


            DataTable dt = database.SelectStatment(command);

            if (dt.Rows.Count > 0)
            {

                Session["admin"] = user_id;

                return RedirectToAction("index", "admin");


            }

            else
            {

                return Content("<script>alert('bhag yaha se') location.href='/home/admin';</script>");


            }




        }

        public ActionResult login()
        {

            return View();
        }



        public ActionResult sinup()
        {

            return View();
        }



        [HttpPost]

        public ActionResult Contact(string name, string mail, string mob, string city, string state, string pass, HttpPostedFileBase icon)
        {
            string command = "insert into AUser values('" + name + "' , '" + mail + "' , '" + mob + "' , '" + city + "' , '" + state + "' , '" + pass + "' , '" + icon.FileName + "');";

            int d = database.InserUpdateDelete(command);

            if (d > 0)
            {


                icon.SaveAs(Server.MapPath("/Content/profile/") + icon.FileName);

                return Content("<script>alert('user successfully registered! please log in to continue'); location.href='/home/login';</script>");

            }


            else
            {

                return Content("<script>alert('user registration failed'); location.href='/home/login';</script>");


            }





        }


        public ActionResult content(int? p_id)
        {


            string command = "Select * from PLACE where p_id='" + p_id + "' ";

            DataTable jt = database.SelectStatment(command);
            ViewBag.Data = jt;




            return View();

        }








    }
}