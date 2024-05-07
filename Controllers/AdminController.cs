﻿using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApplication.DAL.Contracts;
using BlogApplication.ViewModels.BlogViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication;
[Authorize]

public class AdminController : Controller
{
    private readonly IAdmin _admin;
            private readonly INotyfService _notyfService;

    public AdminController(IAdmin admin,INotyfService notyfService)
    {
        this._admin = admin;
        this._notyfService = notyfService;
    }

[HttpGet]
public IActionResult Create(){
    return View();
}
[HttpPost]
public async Task<IActionResult> Create(CreateBlogViewModel model){
    await _admin.Create(model);
    return RedirectToAction("Index","home");
}
[HttpGet]
public IActionResult Edit(){
    return View();
}
[HttpPost]
public async Task<IActionResult> Edit(EditBlogViewModel model){
    var result = await _admin.Update(model);
    if(result == true){
_notyfService.Success("Edited Succesfully");
    }
    else{
        _notyfService.Warning("An error Occured");

    }
    return View();
}
}
