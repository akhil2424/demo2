using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo2.Models;
using demo2.Repository;

namespace demo2.Controllers
{
   
    public class HomeController : Controller
    {
        private UserRepository _userRepository;
        public HomeController()
        {
            _userRepository = new UserRepository();

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {

            try
            {
                if (_userRepository.SignUp(user)) return Json(new { success = true });
                else return Json(new { success = false, errmsg = "Invalid Credentials" });
            }
            catch (Exception)
            {

                throw;
            }


        }
        [HttpPost]
        public JsonResult Login(Models.User user)
        {           

            try
            {
                if (_userRepository.Login(user))
                {
                    return Json(new { success = true });
                }
                else return Json(new { success = false, errmsg = "Email or Password wrong" });
            }

            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public ActionResult Dashboard()
        {
            ViewBag.Message = System.Web.HttpContext.Current.Session["sessionString"];
            var model = new Models.Productindex();
           // model.User = _userRepository.GetUser(UserId);
            model.Products = _userRepository.GetProducts();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
         

            return View();
        }

        [HttpPost]
        public JsonResult AddProducts(Product p)
        {
            try
            {
                if (_userRepository.SaveProduct(p))
                {
                    //int Userid = p.Userid;
                    return Json(new { success = true });
                }

                else return Json(new { success = false, errmsg = "error" });
            }
            catch (Exception e)
            {

                throw;
            }
        }
        
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var model = new Models.Product();
            model = _userRepository.GetProduct(id);
            return View(model);

        }

        [HttpPost]
        public JsonResult UpdateProduct(Product p)
        {
            try
            {
                _userRepository.UpdateProduct(p);
                return Json(new { Success = true });

            }
            catch (Exception e)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult DeleteProduct(int Productid)
        {
            try
            {
                if (_userRepository.DeleteProduct(Productid))
                {
                    return Json(new { Success = true });
                }
                else return Json(new { success = false, errmsg = "error" });

                //if (_userRepository.SignUp(user)) return Json(new { success = true });
                //else return Json(new { success = false, errmsg = "Invalid Credentials" });

            }
            catch (Exception e)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult SearchProduct(string dat)
        {
            var model = new Models.Productindex();
            model.Products = _userRepository.SearchProduct(dat);
            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}