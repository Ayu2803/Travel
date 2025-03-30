using Gamers_Arena.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_travLin.Controllers

{

    //[CheckSession]

    public class AdminController : Controller
    {


        db database = new db();

        // GET: Admin
        public ActionResult Index()
        {
            string cu = "SELECT COUNT(*) FROM AUser;";

            DataTable uc = database.SelectStatment(cu);
            ViewBag.ac = uc;



            string cmd = "SELECT COUNT(*) FROM PLACE;";

            DataTable pc = database.SelectStatment(cmd);
            ViewBag.bc = pc;




            string cm = "SELECT COUNT(*) FROM state;";

            DataTable cs = database.SelectStatment(cm);
            ViewBag.cc = cs;



            string cd = "SELECT COUNT(*) FROM category;";

            DataTable cc = database.SelectStatment(cd);
            ViewBag.dc = cc;



            string command = "select * from AUser";

            DataTable dt = database.SelectStatment(command);
            ViewBag.data = dt;






            return View();
        }

        public ActionResult Contact()
        {
            string command = "select * from contact";

            DataTable dt = database.SelectStatment(command);
            ViewBag.data = dt;



            return View();


        }


        public ActionResult AddUser()
        
        {

            string command = "select * from AUser";

            DataTable dt = database.SelectStatment(command);
            ViewBag.data=dt;



            return View();
        }



       



        public ActionResult edit (int? sr)
        {

            string command = "select * from AUser where sr='" + sr + "'";

            DataTable dr = database.SelectStatment(command);
            ViewBag.val = dr;

            return View();


        }

        [HttpPost]

        public ActionResult edit(string name, string mail, string mob, string uc, string city, string state, string pass)
        {

            string command = "UPDATE AUser SET name = '" + name + "', mail='" + mail + "' ,  mobile= '" + mob + "' , city='" + city + "' , state='" + state + "' , password='" + pass + "' WHERE sr='" + uc + "'";

            int d = database.InserUpdateDelete(command);


            if (d > 0)
            {



                return Content("<script>alert('successfully edited profile ); location.href='/admin/AddUser/';</script>");

            }


            else
            {

                return Content("<script>alert('failed'); location.href='/admin/AddUser/';</script>");


            }





        }



        public ActionResult AddPlace()
        {

            string command = "select * from state";

            string cmd = "select * from category";

            DataTable dr = database.SelectStatment(command);
            ViewBag.data= dr;

            DataTable dt = database.SelectStatment(cmd);
            ViewBag.cat=dt;




            string cd = "select * from PLACE";

            DataTable dp = database.SelectStatment(cd);
            ViewBag.place = dp;

            return View();
        }

        [HttpPost]

        public ActionResult AddPlace(string name,string state,string cat, string phrase, string p1_b ,string p1_l, string tp, string tp1_h, string tp1_p, string tp2_h, string tp2_p, string tp2_p1, string tp2_p2, string tp2_p3, string tp3_h, string tp3_p, string tp3_p1, string tp3_p2, string tp3_p3, string tp4_h, string tp4_p, HttpPostedFileBase landscape, HttpPostedFileBase sp_1, HttpPostedFileBase sp_2, HttpPostedFileBase sp_3, HttpPostedFileBase g1, HttpPostedFileBase g2, HttpPostedFileBase g3, HttpPostedFileBase g4, HttpPostedFileBase g5, HttpPostedFileBase g6, HttpPostedFileBase g7, HttpPostedFileBase g8, HttpPostedFileBase g9)
        {


            string command ="INSERT INTO PLACE (name,phrase,para1,para1b,tp_para,tp1_head,tp1_para,tp2_head,tp2_para,tp2_point1,tp2_point2,tp2_point3,tp3_head,tp3_para,tp3_point1,tp3_point2,tp3_point3,tp4_head,tp4_para,landscape,some_photo1,some_photo2,some_photo3,g1,g2,g3,g4,g5,g6,g7,g8,g9,state,cat) VALUES('"+name+"' ,'"+phrase+"' ,'"+p1_b+"' ,'"+p1_l+"' ,'"+tp+"' ,'"+tp1_h+"' ,'"+tp1_p+"' ,'"+tp2_h+"' ,'"+tp2_p+"' ,'"+tp2_p1+"' ,'"+tp2_p2+"' ,'"+tp2_p3+"' ,'"+tp3_h+"' ,'"+tp3_p+"' ,'"+tp3_p1+"' ,'"+tp3_p2+"' ,'"+tp3_p3+"', '"+tp4_h+"', '"+tp4_p+"', '"+landscape.FileName+"', '"+sp_1.FileName+"', '"+sp_2.FileName + "', '"+sp_3.FileName +"', '"+g1.FileName + "', '"+g2.FileName +"', '"+g3.FileName + "', '"+g4.FileName +"', '"+g5.FileName + "', '"+g6.FileName +"', '"+g7.FileName + "', '"+g8.FileName +"', '"+g9.FileName + "' , '"+state+"' , '"+cat+"')";


            int d = database.InserUpdateDelete(command);

            if (d > 0)
            {
                landscape.SaveAs(Server.MapPath("/Content/landscape/") +landscape.FileName);





                sp_1.SaveAs(Server.MapPath("/Content/some/") +sp_1.FileName);

                sp_2.SaveAs(Server.MapPath("/Content/some/") +sp_2.FileName);

                sp_3.SaveAs(Server.MapPath("/Content/some/") +sp_3.FileName);





                g1.SaveAs(Server.MapPath("/Content/gallery/") +g1.FileName);

                g2.SaveAs(Server.MapPath("/Content/gallery/") +g2.FileName);

                g3.SaveAs(Server.MapPath("/Content/gallery/") +g3.FileName);

                g4.SaveAs(Server.MapPath("/Content/gallery/") +g4.FileName);

                g5.SaveAs(Server.MapPath("/Content/gallery/") +g5.FileName);

                g6.SaveAs(Server.MapPath("/Content/gallery/") +g6.FileName);

                g7.SaveAs(Server.MapPath("/Content/gallery/") +g7.FileName);

                g8.SaveAs(Server.MapPath("/Content/gallery/") +g8.FileName);

                g9.SaveAs(Server.MapPath("/Content/gallery/") +g9.FileName);





                return Content("<script>alert('place successfully registered!'); location.href='/admin/AddPlace/';</script>");

            }


            else
            {

                return Content("<script>alert('place registration failed'); location.href='/admin/AddPlace/';</script>");


            }


        }



        public ActionResult AddState()
        {

            string command = "select * from state";

            DataTable dt = database.SelectStatment(command);
            ViewBag.data = dt;



            return View();
        }


        [HttpPost]

        public ActionResult AddState(string state_name, HttpPostedFileBase s_image)
        {

            string command = "insert into state values('"+state_name+"','"+s_image.FileName+"')";

            int d = database.InserUpdateDelete(command);

            if (d > 0)
            {
                s_image.SaveAs(Server.MapPath("/Content/state/") + s_image.FileName);

                return Content("<script>alert('state successfully registered!'); location.href='/admin/AddState/';</script>");

            }

            else
            {

                return Content("<script>alert('state registration failed'); location.href='/admin/AddState/';</script>");


            }


            return View();
        }


        public ActionResult Categories()
        {

            string command = "select * from category";

            DataTable dt = database.SelectStatment(command);
            ViewBag.data = dt;



            return View();
        }



        [HttpPost]

        public ActionResult Categories(string categorie_name, HttpPostedFileBase icon_cat)
        {

            string command = "insert into category values('" + categorie_name + "','" + icon_cat.FileName + "')";

            int d = database.InserUpdateDelete(command);

            if (d > 0)
            {
                icon_cat.SaveAs(Server.MapPath("/Content/state/") + icon_cat.FileName);

                return Content("<script>alert('state successfully registered!'); location.href='/admin/Categories/';</script>");

            }

            else
            {

                return Content("<script>alert('state registration failed'); location.href='/home/';</script>");


            }


            
        }

        public ActionResult Comment()
        {
            return View();
        }

    }
}