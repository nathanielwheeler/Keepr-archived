using System;
using System.Collections.Generic;
using Keepr.Repositories;

namespace Keepr.Services
{
	public abstract class BaseApiService<T, Tid>
	{
		private readonly BaseApiRepository<T, Tid> _repo;
		public BaseApiService(BaseApiRepository<T, Tid> repo)
		{
			_repo = repo;
		}

		internal virtual IEnumerable<T> Get()
		{
			return _repo.Get();
		}

		internal virtual T Get<Tid>(Tid id)
		{
			T exists = _repo.Get(id);
			if (exists == null)
			{
				throw new Exception("Invalid Id");
			}
			return exists;
		}
	}
}