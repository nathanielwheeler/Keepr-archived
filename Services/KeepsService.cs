using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
	public class KeepsService
	{
		private readonly KeepsRepository _repo;
		public KeepsService(KeepsRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<Keep> Get()
		{
			return _repo.Get();
		}

		public Keep Get(string id)
		{
			Keep exists = _repo.Get(id);
			if (exists == null)
			{
				throw new Exception("Invalid Id");
			}
			return exists;
		}

		public Keep Create(Keep newKeep)
		{
			newKeep.Id = Guid.NewGuid().ToString();
			_repo.Create(newKeep);
			return newKeep;
		}

		public Keep Edit(Keep newKeep)
		{
			Keep keep = _repo.Get(newKeep.Id);
			if (keep == null) { throw new Exception("Invalid Id"); }
			keep.Name = newKeep.Name;
			keep.Description = newKeep.Description;
			keep.Img = newKeep.Img;
			keep.IsPrivate = newKeep.IsPrivate;
			keep.Views = newKeep.Views;
			keep.Shares = newKeep.Shares;
			keep.Keeps = newKeep.Keeps;
			_repo.Edit(keep);
			return keep;
		}

		public string Delete(string id)
		{
			Keep keep = _repo.Get(id);
			if (keep == null) { throw new Exception("Invalid Id"); }
			_repo.Delete(id);
			return "Successfully delorted";
		}
	}
}