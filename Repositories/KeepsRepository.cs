using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
	public class KeepsRepository : BaseApiRepository<Keep, string>
	{
		private readonly IDbConnection _db;
		public KeepsRepository(IDbConnection db) : base(db, "keeps")
		{
			_db = db;
		}

		public void Create(Keep newKeep)
		{
			string sql = @"
                INSERT INTO keeps
                (id, name, description, img, isPrivate, views, shares, keeps, userId)
                VALUES
                (@Id, @Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps, @UserId);";
			_db.Execute(sql, newKeep);
		}

		public void Edit(Keep keep)
		{
			string sql = @"
                UPDATE keeps
                SET
                    name = @Name,
                    description = @Description,
                    img = @Img,
                    isPrivate = @IsPrivate,
                    views = @Views,
                    shares = @Shares,
                    keeps = @Keeps
                WHERE id = @Id";
			_db.Execute(sql, keep);
		}

		public void Delete(string id)
		{
			string sql = "DELETE FROM keeps WHERE id = @id";
			_db.Execute(sql, new { id });
		}
	}
}