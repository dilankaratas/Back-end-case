using BackEndCase.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCase.Models
{
    public class DirectoryContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserContact> UsersContacts { get; set; }

        public DirectoryContext(DbContextOptions<DirectoryContext> options) : base(options)
        {

        }
    }
}
