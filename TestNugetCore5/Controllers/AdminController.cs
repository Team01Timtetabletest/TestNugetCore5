﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNugetCore5.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult UserList()
        {
            return View();
        }
    }
}
