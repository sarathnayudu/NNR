using NNR.UIEntity.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNR.WEB.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Default/
        [Route("Login")]
        public ActionResult Login()
        {
            return PartialView("_Login", new LoginVM());
        }

        //
        // GET: /Default/
        [Route("CreateUser")]
        [HttpGet]
        public ActionResult CreateUser()
        {
            return PartialView("../Partial/_CreateUser", new CreateUserVM());
        }
        //
        // GET: /Default/
        [Route("CreateUser")]
        [HttpGet]
        public ActionResult CreateUser(CreateUserVM cUserUM)
        {
            return PartialView("../Partial/_CreateUser", new CreateUserVM());
        }

	}
}