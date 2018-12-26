using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyCompany.MyProject.Controllers;

namespace MyCompany.MyProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
