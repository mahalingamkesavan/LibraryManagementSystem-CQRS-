using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBAL
{
    public class Constants
    {
        public const string Inserted = "Successfully Inserted";
        public const string Updated = "Successfully Updated";
        public const string Deleted = "Successfully Deleted";
        public static class Messages
        {
            public const string Admin = "Admin";
            public const string Active = "Active";
            public const string Processing = "Processing";
            public const string User = "User";
            public const string Address = "94G";
            public const string City = "Tirunelveli";
            public const string State = "Tamil Nadu";
            public const string InActive = "InActive";

        }
        public static class UserRegistration
        {
            public const string UserDeleted = "User data is deleted successfully";
            public const string RemoveUserMessage = "Successfully Remove the Message";
            public const string UpdateUser = "User data is Updated Successfully";
            public const string ErrorMessage = "Something  Wrong";
            public const string Address = "94G";
            public const string City = "Tirunelveli";
            public const string State = "Tamil Nadu";
            public const string InActive = "InActive";
        }

            public static class BookIssued
        {
            public const string Issued = "Book Is Issued Successfully";
            public const string ReturnBook = "Successfully Return the Book";
        }
        public static class UserApprovel
        {
            public const string Approved = "User Registration is Approved Successfully";
            public const string Rejected = "User Registration is Rejected";
        }

    }
}
