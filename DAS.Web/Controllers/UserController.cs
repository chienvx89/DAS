using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAS.Web.Models;
using DAS.Application.Interfaces;
using DAS.Application.Models.ViewModels;

namespace DAS.Web.Controllers
{
    public class UserController : BaseController
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _userService.Gets();
            var model = users.Select(s => new VMUser
            {
                ID = s.ID,
                Name = s.Name,
                Email = s.Email,
                Description = s.Description
            });

            return PartialView(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();

            var user = await _userService.Get(id.Value);
            if (user == null)
                return NotFound();

            return PartialView(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Users/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name,Email,Description")] VMCreateUser vmUser)
        //{
        //    if (vmUser != null && !string.IsNullOrEmpty(vmUser.Email) && await _userService.IsEmailExist(vmUser.Email))
        //    {
        //        ModelState.AddModelError("", "Email đã tồn tại");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return JSErrorModelState();
        //    }
        //    var now = DateTime.Now;
        //    //var user = new User
        //    //{
        //    //    Name = vmUser.Name,
        //    //    Description = vmUser.Description,
        //    //    Email = vmUser.Email,
        //    //    CreateDate = now,
        //    //    CreatedBy = GetCurrUser(),
        //    //    UpdatedBy = null,
        //    //    UpdatedDate = null
        //    //};

        //    var user = _mapper.Map<User>(vmUser);
        //    user.CreateDate = now;
        //    user.CreatedBy = GetCurrUser();
        //    var rs = await _userService.Create(user);

        //    return CustJSonResult(rs);
        //}

        //// GET: Users/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //        return NotFound();
        //    var user = await _userService.Get(id.Value);
        //    if (user == null)
        //        return NotFound();

        //    return View(user);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit([Bind("ID,Name,Email,Description")] VMEditUser vmUser)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (vmUser != null
        //             && !string.IsNullOrEmpty(vmUser.Email)
        //             && await _userService.IsEmailExist(vmUser.Email))
        //        {
        //            ModelState.AddModelError("", "Email đã tồn tại");
        //        }
        //        return JSErrorModelState();
        //    }

        //    var user = await _userService.Get(vmUser.ID);
        //    if (user == null)
        //    {
        //        return JSErrorResult("Không tìm thấy User");
        //    }
        //    var now = DateTime.Now;
        //    user.Name = vmUser.Name;
        //    user.Description = vmUser.Description;
        //    user.Email = vmUser.Email;
        //    user.UpdatedBy = GetCurrUser();
        //    user.UpdatedDate = now;
        //    await _userService.Update(user);

        //    return JSSuccessResult("Cập nhật thành công");
        //}

        //// POST: Users/Delete/5
        //[HttpPost]
        //public async Task<IActionResult> Delete(long id)
        //{
        //    var rs = await _userService.Delete(id);
        //    return CustJSonResult(rs);
        //}
    }
}