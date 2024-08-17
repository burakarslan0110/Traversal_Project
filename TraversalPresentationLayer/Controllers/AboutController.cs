﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly IAbout1Service _about1Service;

        public AboutController(IAbout1Service about1Service)
        {
            _about1Service = about1Service;
        }

     
        public IActionResult Index()
        {
           var values = _about1Service.TGetList();
           return View(values);
        }
    }
}
