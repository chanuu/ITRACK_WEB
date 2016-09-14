using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Collections;
using Abp.Configuration.Startup;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Runtime.Session;
using Abp.TestBase;
using ITRACK.EntityFramework;
using ITRACK.Migrations.SeedData;
using ITRACK.MultiTenancy;
using ITRACK.Users;
using Castle.MicroKernel.Registration;
using EntityFramework.DynamicFilters;
using ITRACK.Domain.Events;
using ITRACK.Tests.Data;

namespace ITRACK.Tests.Sessions
{
    public abstract class ITRACKTestBase : AbpIntegratedTestBase
    {
        static ITRACKTestBase()
        {
            //Disable global event bus for unit tests
            DomainEvents.EventBus = NullEventBus.Instance;
        }

        protected ITRACKTestBase()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );

            //Seed initial data
            UsingDbContext(context => new InitialDataBuilder(context).Build());
            UsingDbContext(context => new TestDataBuilder(context).Build());

            LoginAsDefaultTenantAdmin();
        }

        protected override void AddModules(ITypeList<AbpModule> modules)
        {
            base.AddModules(modules);

            //Adding testing modules. Depended modules of these modules are automatically added.
            modules.Add<ITRACKApplicationModule>();
            modules.Add<ITRACKDataModule>();
        }

        public void UsingDbContext(Action<ITRACKDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<ITRACKDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                context.SaveChanges();
            }
        }


        public async Task UsingDbContext(Func<ITRACKDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<ITRACKDbContext>())
            {
                context.DisableAllFilters();
                await action(context);
                await context.SaveChangesAsync();
            }
        }

        public T UsingDbContext<T>(Func<ITRACKDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ITRACKDbContext>())
            {
                context.DisableAllFilters();
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected void LoginAsHostAdmin()
        {
            LoginAsHost(User.AdminUserName);
        }

        protected void LoginAsDefaultTenantAdmin()
        {
            LoginAsTenant(Tenant.DefaultTenantName, User.AdminUserName);
        }

        protected void LoginAsHost(string userName)
        {
            Resolve<IMultiTenancyConfig>().IsEnabled = true;

            AbpSession.TenantId = null;

            var user = UsingDbContext(context => context.Users.FirstOrDefault(u => u.TenantId == AbpSession.TenantId && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for host.");
            }

            AbpSession.UserId = user.Id;
        }

        protected void LoginAsTenant(string tenancyName, string userName)
        {
            var tenant = UsingDbContext(context => context.Tenants.FirstOrDefault(t => t.TenancyName == tenancyName));
            if (tenant == null)
            {
                throw new Exception("There is no tenant: " + tenancyName);
            }

            AbpSession.TenantId = tenant.Id;

            var user = UsingDbContext(context => context.Users.FirstOrDefault(u => u.TenantId == AbpSession.TenantId && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for tenant: " + tenancyName);
            }

            AbpSession.UserId = user.Id;
        }

        /// <summary>
        /// Gets current user if <see cref="IAbpSession.UserId"/> is not null.
        /// Throws exception if it's null.
        /// </summary>
        protected async Task<User> GetCurrentUserAsync()
        {
            var userId = AbpSession.GetUserId();
            return await UsingDbContext(context => context.Users.SingleAsync(u => u.Id == userId));
        }

        /// <summary>
        /// Gets current tenant if <see cref="IAbpSession.TenantId"/> is not null.
        /// Throws exception if there is no current tenant.
        /// </summary>
        protected async Task<Tenant> GetCurrentTenantAsync()
        {
            var tenantId = AbpSession.GetTenantId();
            return await UsingDbContext(context => context.Tenants.SingleAsync(t => t.Id == tenantId));
        }
    }
}