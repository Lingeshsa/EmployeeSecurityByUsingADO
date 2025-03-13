    namespace EmployeeSecurityByUsingADO.Service
{
    public interface IAuthService
    {
        bool ValidateAdmin(string userName, string password);
        int InsertAdmin(string userName, string password);
        int UpdateAdmin(int adminId, string newUserName, string newPassword);
        int DeleteAdmin(int adminId);
    }
}
