using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Record.Entities;
using Record.Business;
using Record.Util;
using Record.Web;

namespace AngualarCrudeOperation.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        // View for Display record
        public ActionResult ShowUsers()
        {
            return View();
        }
        // View for Update record
        public ActionResult UpdateUsers(int id)
        {
            return View();
        }
        //Save User
        public JsonResult SaveUser(UserEntity user)
        {
            string message = string.Empty;

            try
            {
                UserBusiness.SaveUser(user);
                message = RecordInternal.InsertRegister;
            }
            catch (Exception)
            {
                message = RecordInternal.InsertRegisterFailed;
            }
            return Json(message, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetUsers()
        {

            return Json(UserBusiness.GetAllUsers(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserById(int id)
        {
            var t = UserBusiness.GetUserById(id);
            return Json(t, JsonRequestBehavior.AllowGet);

        }


        public JsonResult UpdateUser(UserEntity user)
        {
            string message = string.Empty;
            try
            {
                UserBusiness.UpdateUser(user);
                message = RecordInternal.Update;
            }
            catch (Exception)
            {
                message = RecordInternal.UpdateFailed;

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }



        public JsonResult Delete(int id)
        {
            string message = string.Empty;
            try
            {
                UserBusiness.DeleteUser(id);
                message = RecordInternal.DataDeleted;
            }
            catch (Exception)
            {
                message = RecordInternal.DataDeletedFailed;
            }
            return Json(message, JsonRequestBehavior.AllowGet);

        }

    }

}

