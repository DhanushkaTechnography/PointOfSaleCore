using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.AuthenticationDto;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.CrustPrices;
using PizzaCore.Entity.Customer;
using PizzaCore.Entity.CustomerMembership;
using PizzaCore.Entity.DeliveryOptions;
using PizzaCore.Entity.Ingredients;
using PizzaCore.Entity.Item;
using PizzaCore.Entity.Membership;
using PizzaCore.Entity.Order;
using PizzaCore.Entity.OrderDetails;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.PizzaOrderDetails;
using PizzaCore.Entity.PizzaSizes;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.SubCategory;
using PizzaCore.Entity.ToppingPrices;
using PizzaCore.Entity.Toppings;
using PizzaCore.Entity.Types;

namespace PizzaPos.DataAccess.AuthRepository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));

            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<SubCategoryDto> SubCategories { get; set; }
        public DbSet<SizesDto> Sizes { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<ToppingsDto> Toppings { get; set; }
        public DbSet<ToppingPricesDto> ToppingPrices { get; set; }
        public DbSet<CrustDto> Crust { get; set; }
        public DbSet<CrustPricesDto> CrustPrices { get; set; }
        public DbSet<PizzaDto> PizzaDto { get; set; }
        public DbSet<PizzaSizesDto> PizzaPrice { get; set; }
        public DbSet<IngredientsDto> Ingredients { get; set; }
        public DbSet<MemberShipDto> MemberShip { get; set; }
        public DbSet<CustomerDto> CustomerDto { get; set; }
        public DbSet<CustomerMembership> CustomerMemberShip { get; set; }
        public DbSet<DeliveryOptionDto> DeliveryOption { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<OrderStatusDto> OrderStatus { get; set; }
        public DbSet<PizzaOrderDetailsDto> OrderDetailsPizza { get; set; }
        public DbSet<ExtraToppings> ExtraTopping { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemDetails> ItemPrices { get; set; }
        public DbSet<OrderDetailsDto> OrderDetails { get; set; }
    }
}