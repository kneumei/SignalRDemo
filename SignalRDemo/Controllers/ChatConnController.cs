using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalRDemo.Models.Chat;

namespace SignalRDemo.Controllers
{
    public class ChatConnController : Controller
    {
        //
        // GET: /ChatUsingConnection/
        public ActionResult Index()
        {
            return View(new ChatModel());
        }
	}
}