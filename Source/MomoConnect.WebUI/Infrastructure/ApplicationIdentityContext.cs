using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MomoConnect.WebUI.Models;
using MongoDB.Driver;

namespace MomoConnect.WebUI.Infrastructure
{
    public class ApplicationIdentityContext: IDisposable
    {
        public static ApplicationIdentityContext Create()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["DatabaseName"]);
            var users = database.GetCollection<ApplicationUser>("users");
            var roles = database.GetCollection<IdentityRole>("roles");
            return new ApplicationIdentityContext(users, roles);
        }

        private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<IdentityRole> Roles { get; set; }

        public IMongoCollection<ApplicationUser> Users { get; set; }

        public Task<List<IdentityRole>> AllRolesAsync()
        {
            return Roles.Find(r => true).ToListAsync();
        }

        public void Dispose()
        {
        }
    }
}
