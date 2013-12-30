using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRDemo.Controllers
{
    public class HubChatController : Controller
    {
        //
        // GET: /HubChat/
        public ActionResult Index()
        {
            return View(new SignalRDemo.Models.Chat.ChatModel());
        }
	}
}