﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ConsulClient.Controllers
{
    [Produces("application/json")]
    [Route("api/Health")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Index() => Ok("ok");
    }
}