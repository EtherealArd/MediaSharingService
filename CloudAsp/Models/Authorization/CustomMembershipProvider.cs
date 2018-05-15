using System;
using System.Web.Security;
using CloudAspData;
using CloudAspData.Entity;

namespace CloudAsp.Models.Authorization
{
    public class CustomMembershipProvider: MembershipProvider
    {
        IDataCloud DataBase { get; set; } = new DataCloud();
        public override bool ValidateUser(string username, string password)
        {
            Client user = DataBase.Authorisation(username, password);
            return user != null;
        }

        public MembershipUser CreateUser(string email, string password)
        {
            //MembershipUser membershipUser = GetUser(email, false);

            //if (membershipUser == null)
            //{
            //    try
            //    {
            //        using (UserContext _db = new UserContext())
            //        {
            //            User user = new User();
            //            user.Email = email;
            //            user.Password = Crypto.HashPassword(password);
            //            user.CreationDate = DateTime.Now;

            //            if (_db.Roles.Find(2) != null)
            //            {
            //                user.RoleId = 2;
            //            }

            //            _db.Users.Add(user);
            //            _db.SaveChanges();
            //            membershipUser = GetUser(email, false);
            //            return membershipUser;
            //        }
            //    }
            //    catch
            //    {
            //        return null;
            //    }
            //}
            return null;
        }

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            try
            {
                var user = DataBase.GetClient(email);
                if (user == null)
                    return null;
                MembershipUser membershipUser = new MembershipUser("MyMembershipProvider", user.Email, null, null, null, null, false, false, DateTime.Now, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                return membershipUser;
                //using (UserContext _db = new UserContext())
                //{
                //    var users = from u in _db.Users
                //                where u.Email == email
                //                select u;
                //    if (users.Count() > 0)
                //    {
                //        User user = users.First();
                //        MembershipUser memberUser = new MembershipUser("MyMembershipProvider", user.Email, null, null, null, null,
                //            false, false, user.CreationDate, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                //        return memberUser;
                //    }
                //}
            }
            catch
            {
                return null;
            }
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

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }
        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }
        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }
        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }
        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }
        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }
        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }
        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }
        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }
        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }
        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
}