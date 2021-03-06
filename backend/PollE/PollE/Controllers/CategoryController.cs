﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PollE.Controllers.DTOs;

namespace PollE.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }
        
        private readonly List<string> categories = new List<string>()
        {
            "Restaurants",
            "Books",
            "Hotels",
            "Drinks",
            "Sports",
            "Foods",
            "Movies",
            "Girls",
            "Cars"
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categories);
        }
    }
}