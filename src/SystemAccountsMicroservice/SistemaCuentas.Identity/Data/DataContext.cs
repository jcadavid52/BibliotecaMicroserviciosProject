using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SistemaCuentas.Identity.Data
{
    public class DataContext(DbContextOptions options):IdentityDbContext(options)
    {
        public DbSet<ApplicationIdentity> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable("AccountUsers");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("AccountRoles");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("AccountUserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("AccountUserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("AccountUserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("AccountRoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("AccountUserTokens");
            });

            string idRoleAdmin = Guid.NewGuid().ToString();
            string idUserAdmin = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = idRoleAdmin, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Usuario", NormalizedName = "USUARIO" }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            var adminUser = new ApplicationIdentity
            {
                FullName = "Admin",
                DocumentType = "CC",
                Document = "123456789",
                Address = "Calle Admin",
                Id = idUserAdmin,
                UserName = "admin@system.com",
                NormalizedUserName = "ADMIN@SYSTEM.COM",
                Email = "admin@system.com",
                NormalizedEmail = "ADMIN@SYSTEM.COM",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Admin123*"),
                SecurityStamp = Guid.NewGuid().ToString().ToUpper()
            };

            builder.Entity<ApplicationIdentity>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = idUserAdmin,
                RoleId = idRoleAdmin
            });

            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
