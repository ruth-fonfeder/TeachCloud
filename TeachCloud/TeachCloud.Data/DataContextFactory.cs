using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TeachCloud.Data;

namespace TeachCloud.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            var connectionString = "server=bo6hzsr19hbskira47bj-mysql.services.clever-cloud.com;port=3306;database=bo6hzsr19hbskira47bj;user=umgcxnkvtzd1utst;password=q5whm0mxlIzqjGRjzURC;SslMode=None"
;

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new DataContext(optionsBuilder.Options);
        }
    }
}

