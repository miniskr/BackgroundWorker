using System;
using System.Collections.Generic;
using System.Text;
using HCVisionWorker.Entities;
using Microsoft.EntityFrameworkCore;

namespace HCVisionWorker.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        #region DbSet
        public DbSet<ExperimentTaskEntity> ExperimentTask { get; set; }
        #endregion
    }
}
