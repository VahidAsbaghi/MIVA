using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Registration.EventFeed;
using Registration.Models;
using Registration.Persistent;
using Registration.Services;

namespace Registration.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;

        private readonly IEventStore _eventStore;
        // GET: RegisterController

        public RegisterController(IUserService userService,IEventStore eventStore)
        {
            _userService = userService;
            _eventStore = eventStore;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(IFormCollection collection)
        {
            var email=collection["Username"];
            var password=collection["password"];

            var user= new User() { Email = email, UserName = email };
            
            var passwordHash = 
                new PasswordHasher<User>().HashPassword(
                    user, password);
            
            user.PasswordHash = passwordHash;
            
            user = await _userService.AddUser(user);
            await _eventStore.Raise("UserRegistered", user);

            return Ok();
        }
        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
