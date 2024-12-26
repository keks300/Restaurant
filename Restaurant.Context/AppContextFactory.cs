using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Context
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppContext>();
            optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Restaurant;Trusted_Connection=True;");
            //optionBuilder.UseSqlServer(@"Data Source=172.20.10.3;User ID=sa;Password=VeryStr0ngP@ssw0rd;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Database=AppTestApi01;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new AppContext(optionBuilder.Options);
        }
    }
}
