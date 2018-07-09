using Microsoft.AspNetCore.Antiforgery;
using DomainDrivenProject.Controllers;

namespace DomainDrivenProject.Web.Host.Controllers
{
    public class AntiForgeryController : DomainDrivenProjectControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
