using CovidReader.Models.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlInspectionRepository : SqlApiDailyRepositoryBase<Inspection>, IInspectionRepository
    {
        public SqlInspectionRepository(ApiDbContext db) : base(db, db.Inspections) { }
    }
}
