using NNR.UIEntity.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNR.WEB.Controllers
{
    public class TemplateController : BaseController
    {

        public ActionResult Template()
        {
            return PartialView("_Template",new TemplateVM());
        }
    }
}