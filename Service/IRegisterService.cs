using EmployeeSecurityByUsingADO.Models;

namespace EmployeeSecurityByUsingADO.Service
{
    public interface IRegisterService
    {
        public bool RegisterUser(RegisterModel user);
        public List<RegisterModel> GetAllUsers();

        public RegisterModel GetUserById(int id);

        public bool UpdateUser(RegisterModel user);

        bool DeleteUser(int id);



    }

}
