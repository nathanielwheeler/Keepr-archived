using System;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
	[Route("/api/[controller]")]
	public class KeepController : BaseApiController<Keep, string>
	{
		private readonly KeepService _ks;
		public KeepController(KeepService ks) : base(ks)
		{
			_ks = ks;
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
				newKeep.Id = id;
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