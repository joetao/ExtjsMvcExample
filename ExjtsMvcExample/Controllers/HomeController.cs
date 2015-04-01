using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExjtsMvcExample.Models;
using wqt_bs_kp.Common;

namespace ExjtsMvcExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //获取用户模型数据
        [HttpPost]
        public JsonResult GetUserList()
        {
            UserContext userContext = new UserContext();
            List<User> userList = userContext.GetUserList();

            //此处获取的Json字符串Name名第一个字母大写，页面上的相应Name名也应该做大写匹配
            var data = Json(userList, JsonRequestBehavior.AllowGet);
            return data;
        }

        [HttpPost]
        public void UpdateUser(User user)
        {
            //var user= Request.Form.ToModel<User>();
            //string s = "ssssss";
            int i = 0;
        }
      
    }
}
