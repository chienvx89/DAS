﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAS.Web.Models;
using DAS.Application.Interfaces;
using DAS.Application.Models.ViewModels;
using DAS.Domain.Models.DAS;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAS.Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryServices _categoryServices;
        private readonly ICategoryTypeServices _categoryTypeServices;

        public CategoryController(ICategoryServices categoryServices, ICategoryTypeServices categoryTypeServices)
        {
            _categoryServices = categoryServices;
            _categoryTypeServices = categoryTypeServices;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryServices.Gets();
            var model = categories.Select(s => new VMCategory
            {
                ID = s.ID,
                Name = s.Name,
                Code = s.Code,
                Status = s.Status
            });

            return PartialView(model);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();

            var user = await _categoryServices.Get(id.Value);
            if (user == null)
                return NotFound();

            return PartialView(user);
        }

        // GET: Users/Create
        public async Task<IActionResult> Create()
        {
            var categoryType = await _categoryTypeServices.Gets();
            if (categoryType == null || categoryType.Count() == 0)
            {
                ViewBag.CategoryType = new SelectListItem();
            }
            else
            {
                ViewBag.CategoryType = categoryType.Select(s => new SelectListItem()
                {
                    Value = s.ID.ToString(),
                    Text = s.Name
                });
            }

            return PartialView();
        }

        //POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Code,IdCategoryType")] VMCreateCategory vmCreateCategory)
        {
            if (!ModelState.IsValid)
            {
                return JSErrorModelState();
            }

            var now = DateTime.Now;
            var user = new Category
            {
                Name = vmCreateCategory.Name,
                Code = vmCreateCategory.Code,
                IdCategoryType = vmCreateCategory.IdCategoryType,
                CreateDate = now,
                CreatedBy = GetCurrUser(),
                UpdatedBy = null,
                UpdatedDate = null
            };

            //var user = _mapper.Map<User>(vmUser);
            //user.CreateDate = now;
            //user.CreatedBy = GetCurrUser();
            var rs = await _categoryServices.Create(user);
            return CustJSonResult(rs);
        }

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