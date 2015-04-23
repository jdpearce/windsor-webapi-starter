using System;
using System.Web.Security;

using Castle.Core.Logging;

namespace WindsorWebApi.Services
{
    public class CustomRoleProvider : RoleProvider, ICustomRoleProvider
    {
        private readonly ILogger _logger;
        private readonly string _connectionString;

        public CustomRoleProvider(string connectionString, ILogger logger)
        {
            _logger = logger;
            _connectionString = connectionString; //an illustration of how the AppSettingsConvention allows this to be automatically injected
        }

        public override bool IsUserInRole(string username, string featureCode)
        {
            return true;
        }

        public override string[] GetRolesForUser(string username)
        {
            return new[] {"Admin"};
        }

        public override void CreateRole(string rolename)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string rolename)
        {
            return rolename == "Admin";
        }

        public override void AddUsersToRoles(string[] usernames, string[] featureCodes)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string featureCode)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return new[] { "Admin" };
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}