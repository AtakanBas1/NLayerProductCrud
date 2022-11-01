using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        BaseUserManager bum = new BaseUserManager(new EfBaseUserRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(BaseUser user)
        {
            Context c = new Context();
            var loginvalue  = c.BaseUsers.FirstOrDefault(x => x.EMail == user.EMail && x.Password == user.Password);
            if(loginvalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.EMail)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }


            //Context c = new Context();
            //var loginvalue = c.BaseUsers.FirstOrDefault(x => x.EMail == user.EMail && x.Password == user.Password);
            //if(loginvalue != null)
            //{
            //    HttpContext.Session.SetString("username", user.EMail);
            //    return RedirectToAction("Index", "Product");
            //}
            //else
            //{
            //    return View();
            //}   
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(BaseUser user)
        {
            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(user);
            if(results.IsValid)
            {
                user.Status = true;
                bum.TAdd(user);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }

        }
}
