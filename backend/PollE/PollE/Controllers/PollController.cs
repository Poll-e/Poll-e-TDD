﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PollE.Controllers.DTOs;
using PollE.DataAccess.DataService;

namespace PollE.Controllers
{
    [ApiController]
    [Route("polls")]
    public class PollController : ControllerBase
    {
        
        private readonly ILogger<PollController> _logger;
        private readonly IPollService _pollService;

        public PollController(ILogger<PollController> logger, IPollService pollService)
        {
            _logger = logger;
            _pollService = pollService ?? throw new ArgumentNullException(nameof(pollService));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PollCreate create)
        {
            return Ok(await _pollService.CreatePoll(create));
        }

        [HttpGet]
        [Route("{Code?}")]
        public async Task<IActionResult> Get([FromRoute] string Code)
        {
            return Ok( await _pollService.GetPollByCode(Code));
        }
    }
}