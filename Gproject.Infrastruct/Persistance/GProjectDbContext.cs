using Gproject.Application.Common.Interfaces.Authentication;
using Gproject.Domain.AttachmentAggregate;
using Gproject.Domain.Common.Models;
using Gproject.Domain.MenuAggregate;
using Gproject.Domain.MenuAggregate.Entities;
using Gproject.Infrastruct.Persistance.ExtentionMethods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Persistance
{
    public class GProjectDbContext :DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public GProjectDbContext(DbContextOptions<GProjectDbContext> options,ICurrentUserService currentUserService) :base(options)
        {
            _currentUserService = currentUserService;
        }
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<Attachment> Attachments { get; set; } = null!;
       

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;

            foreach (var entry in ChangeTracker.Entries<AuditableEntity<Guid>>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.IsNullOrEmpty(_currentUserService.UserId) ? "Na" : _currentUserService.UserId;
                        entry.Entity.Created = DateTimeOffset.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = string.IsNullOrEmpty(_currentUserService.UserId) ? "Na" : _currentUserService.UserId;
                        entry.Entity.LastModified = DateTimeOffset.UtcNow;
                        break;
                }

            
            var result =  base.SaveChanges();

            return  result > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(GProjectDbContext).Assembly);
            //modelbuilder.Entity<Menu>().HasQueryFilter(!p=>p.IsDeleted); 
            foreach (var entityType in modelbuilder.Model.GetEntityTypes())
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                    entityType.AddSoftDeleteQueryFilter();

            base.OnModelCreating(modelbuilder);
        }
       


    }
}
