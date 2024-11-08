namespace StaticFactoryDp.Common.Constants;

public static class MessageConstant
{
    public const string Success = "Success";
    public const string Failed = "Failed";
    
    public static class User
    {
        public const string Created = "User created successfully";
        public const string Updated = "User updated successfully";
        public const string Deleted = "User deleted successfully";
        
        public const string NotFound = "User not found";

        public const string CreatedError = "User creation failed";
        public const string UpdatedError = "User update failed";
        public const string DeletedError = "User deletion failed";
    }
}