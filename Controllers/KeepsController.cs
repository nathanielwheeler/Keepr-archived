using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
	[Route("/api/[controller]")]
	public class KeepsController : ControllerBase
	{
		private readonly KeepsService _ks;
		private readonly AccountService _as;
		public KeepsController(KeepsService ks, AccountService aServ)
		{
			_ks = ks;
			_as = aServ;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Keep>> Get()
		{
			try
			{
				return Ok(_ks.Get());

			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		[HttpGet("{id}")]
		public ActionResult<Keep> Get(string id)
		{
			try
			{
				return Ok(_ks.Get(id));
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}

		[Authorize]
		[HttpPost]
		public ActionResult<Keep> Create([FromBody] Keep newKeep)
		{

			try
			{
				return Ok(_ks.Create(newKeep));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		[Authorize]
		[HttpPut("{id")]
		public ActionResult<Keep> Edit([FromBody] Keep newKeep, string id)
		{
			try
			{
				var userIdClaim = HttpContext.User.FindFirstValue("Id");
				var user = _as.GetUserById(userIdClaim);
				newKeep.Id = id;
				newKeep.UserId = user.Id;
				return Ok(_ks.Edit(newKeep));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		[Authorize]
		[HttpDelete("{id}")]
		public ActionResult<string> Delete(string id)
		{
			try
			{
				return Ok(_ks.Delete(id));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}
	}
}