using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Users_App.Models;
using Users_DataModels.DataModels;
using Users_Repos.Repos;

namespace Users_App.Controllers
{
    public class UsersController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public UsersController()
        {
            unitOfWork = new UnitOfWork();
        }

        [NonAction]
        public static IEnumerable<SelectListItem> MembershipList()
        {
            var membershipList = new List<SelectListItem>();
            foreach (var u in new UnitOfWork().Memberships.GetAll())
            {
                membershipList.Add(new SelectListItem()
                {
                    Value = u.MembershipId.ToString(),
                    Text = u.Membership
                });
            }
            membershipList.Sort((x, y) => x.Value.CompareTo(y.Value));

            return membershipList;
        }

        public ViewResult Index()
        {
            var userList = unitOfWork.Users.GetAll();
            var userViewList = new List<UsersViewModel>();

            foreach (var u in userList)
            {
                userViewList.Add(new UsersViewModel()
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Email = u.Email,
                    Password = u.Password,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    GenderId = u.GenderId,
                    MembershipId = u.MembershipId,
                    DateCreated = u.DateCreated,
                    Genders = u.Genders,
                    Memberships = u.Memberships
                });
            }

            return View(userViewList);
        }

        [Route("register")]
        public ViewResult Register()
        {
            var userView = new UsersViewModel();

            return View(userView);
        }

        [Route("register")] [HttpPost]
        public ActionResult Register(UsersViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var newUser = new Users()
                {
                    Username = entity.Username,
                    Email = entity.Email,
                    Password = entity.Password,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    GenderId = (int)entity.GenderId,
                    MembershipId = (int)entity.MembershipId,
                    DateCreated = DateTime.Now
                };

                unitOfWork.Users.Add(newUser);
                unitOfWork.Commit();

                return RedirectToAction("Index");
            }
            else
                return View(entity);
        }

        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var user = unitOfWork.Users.GetById(id);

            if (user != null)
            {
                var userView = new UsersViewModel()
                {
                    UserId = user.UserId,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    GenderId = user.GenderId,
                    MembershipId = user.MembershipId,
                };

                return View(userView);
            }
            else
                return HttpNotFound();
        }

        [Route("edit/{id:int}")] [HttpPost]
        public ActionResult Edit(UsersViewModel entity)
        {
            if (ModelState.IsValidField("Password")
                && ModelState.IsValidField("ConfirmPassword")
                && ModelState.IsValidField("FirstName")
                && ModelState.IsValidField("LastName")
                && ModelState.IsValidField("GenderId")
                && ModelState.IsValidField("MembershipId"))
            {
                var user = unitOfWork.Users.GetById(entity.UserId);
                user.Password = entity.Password;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.GenderId = (int)entity.GenderId;
                user.MembershipId = (int)entity.MembershipId;

                unitOfWork.Users.Update(user);
                unitOfWork.Commit();

                return RedirectToAction("Index");
            }
            else
                return View(entity);
        }

        [Route("remove/{id:int}")]
        public ActionResult Remove(int id)
        {
            var user = unitOfWork.Users.GetById(id);

            if (user != null)
            {
                unitOfWork.Users.Remove(user);
                unitOfWork.Commit();

                return RedirectToAction("Index");
            }
            else
                return HttpNotFound();
        }

        public JsonResult UsernameRemoteCheck(string Username)
        {
            var userList = unitOfWork.Users.GetAll();
            bool check = true;

            foreach (var user in userList)
            {
                if (user.Username == Username)
                {
                    check = false;
                    break;
                }
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EmailRemoteCheck(string Email)
        {
            var userList = unitOfWork.Users.GetAll();
            bool check = true;

            foreach (var user in userList)
            {
                if (user.Email == Email)
                {
                    check = false;
                    break;
                }
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }
    }
}
