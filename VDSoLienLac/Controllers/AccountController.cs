using Newtonsoft.Json;
using ServiceCore.DataAccess;
using ServiceCore.Models;
using ServiceCore.Models.Base;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using VDSoLienLac.Filters;
using VDSoLienLac.Principal;

namespace VDSoLienLac.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInModel model)
        {
            AccountDAO dao = new AccountDAO();
            BaseResponseModel<object> resp = dao.ValidateSignIn(model);

            if (ModelState.IsValid)
            {
                if (model != null && resp.Result > 0)
                {
                    var mModel = (List<SignInModel>)resp.ResponseData;
                    var token = JwtManager.GenerateToken(mModel[0].UserName, mModel[0].ID);
                    mModel[0].SignInSession = token;
                    var mClaims = AddClaim(mModel[0], resp.ResponseMessage);
                    VDPrincipalModel prinModel = new VDPrincipalModel(mModel[0].UserName, mClaims);
                    resp.ResponseMessage = "OK";
                    Thread.CurrentPrincipal = prinModel;
                    Session["CurrentThread"] = prinModel;
                    return RedirectToAction("UserProfile", "Home");
                }
                else
                {
                    ViewBag.SignInStatus = "Tên tài khoản hoặc mật khẩu không chính xác.";
                }
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            Session.Contents.Remove("CurrentThread");
            return RedirectToAction("SignIn", "Account");
        }

        public List<Claim> AddClaim(SignInModel model, string classcode = "")
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.PrimarySid, model.ID));
            claims.Add(new Claim("Token", model.SignInSession));
            claims.Add(new Claim(ClaimTypes.Name, model.UserName));
            claims.Add(new Claim(ClaimTypes.Role, model.RoleID.ToString()));
            claims.Add(new Claim("ClassCode", classcode));
            return claims;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult DownloadForMobile()
        {
            return View();
        }
    }
}