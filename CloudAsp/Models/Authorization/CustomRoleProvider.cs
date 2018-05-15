using System;
using System.Web.Security;
using CloudAspData;

namespace CloudAsp.Models.Authorization
{
    public class CustomRoleProvider: RoleProvider
    {
        private readonly IDataCloud _data;

        public CustomRoleProvider()
        {
            _data = new DataCloud();
        }
        public CustomRoleProvider(IDataCloud data)
        {
            _data = data;
        }
        public override string[] GetRolesForUser(string email)
        {
            var role = _data.RoleByUserEmail(email)?.Name;
            if(role == null)
                return new string[0];
            return new[] {role};
        }
        public override void CreateRole(string roleName)
        {
            //DataBase.AddRule(new Rule {Id = Guid.NewGuid(), Name = roleName});
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            return _data.RoleByUserEmail(username)?.Name == roleName;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}