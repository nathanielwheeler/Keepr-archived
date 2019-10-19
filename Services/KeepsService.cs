using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
	public class KeepsService : BaseApiService<Keep, string>
	{
		private readonly KeepsRepository _repo;
		public KeepsService(KeepsRepository repo) : base(repo)
		{
			_repo = repo;
		}

		internal object Create(Keep newKeep)
		{
			newKeep.Id = Guid.NewGuid().ToString();
			_repo.Create(newKeep);
			return newKeep;
		}

		internal object Edit(Keep newKeep)
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

		internal object Delete(string id)
		{
			Keep keep = _repo.Get(id);
			if (keep == null) { throw new Exception("Invalid Id"); }
			_repo.Delete(id);
			return "Successfully delorted";
		}
	}
}