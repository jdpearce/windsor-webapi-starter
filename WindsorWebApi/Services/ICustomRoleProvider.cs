namespace WindsorWebApi.Services
{
    public interface ICustomRoleProvider
    {
        bool IsUserInRole(string username, string featureCode);
        string[] GetRolesForUser(string username);
        void CreateRole(string featureCode);
        bool DeleteRole(string featureCode, bool throwOnPopulatedRole);
        bool RoleExists(string featureCode);
        void AddUsersToRoles(string[] usernames, string[] featureCodes);
        void RemoveUsersFromRoles(string[] usernames, string[] roleNames);
        string[] GetUsersInRole(string featureCode);
        string[] GetAllRoles();
        string[] FindUsersInRole(string roleName, string usernameToMatch);
    }
}