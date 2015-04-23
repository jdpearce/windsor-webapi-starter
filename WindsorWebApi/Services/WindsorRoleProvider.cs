using System;
using System.Web.Security;
using Castle.Windsor;

namespace WindsorWebApi.Services
{
    public class WindsorRoleProvider : RoleProvider
    {
        public IWindsorContainer GetContainer()
        {
            if (WindsorConfig.Container == null)
                throw new Exception("WindsorConfig.Container has not been initialised.");
            return WindsorConfig.Container;
        }

        private ICustomRoleProvider GetProvider()
        {
            try
            {
                var provider = GetContainer().Resolve<ICustomRoleProvider>();
                if (provider == null)
                    throw new Exception("ICustomRoleProvider not configured.");
                return provider;
            }
            catch (Exception e)
            {
                throw new Exception("Error resolving ICustomRoleProvider", e);
            }
        }

        private T WithProvider<T>(Func<ICustomRoleProvider, T> f)
        {
            var provider = GetProvider();
            try
            {
                return f(provider);
            }
            finally
            {
                GetContainer().Release(provider);
            }
        }


        private void WithProvider(Action<ICustomRoleProvider> f)
        {
            var provider = GetProvider();
            try
            {
                f(provider);
            }
            finally
            {
                GetContainer().Release(provider);
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return WithProvider(x => x.IsUserInRole(username, roleName));
        }

        public override string[] GetRolesForUser(string username)
        {
            return WithProvider(x => x.GetRolesForUser(username));
        }

        public override void CreateRole(string roleName)
        {
            WithProvider(x => x.CreateRole(roleName));
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return WithProvider(x => x.DeleteRole(roleName, throwOnPopulatedRole));
        }

        public override bool RoleExists(string roleName)
        {
            return WithProvider(x => x.RoleExists(roleName));
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            WithProvider(x => x.AddUsersToRoles(usernames, roleNames));
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            WithProvider(x => x.RemoveUsersFromRoles(usernames, roleNames));
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return WithProvider(x => x.GetUsersInRole(roleName));
        }

        public override string[] GetAllRoles()
        {
            return WithProvider(x => x.GetAllRoles());
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return WithProvider(x => x.FindUsersInRole(roleName, usernameToMatch));
        }

        public override string ApplicationName { get; set; }
    }
}