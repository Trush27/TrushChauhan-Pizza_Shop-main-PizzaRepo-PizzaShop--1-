using Entity.Models;
using Entity.ViewModel;
namespace Repository.Interfaces;

public interface IUserRepository
{
   public Userlogin GetUserByEmail(string email);
   void UpdateUser(Userlogin user);
   bool IsUserExists(string email);

   int GetRoleIdByEmail(string email);
   bool IsCorrectPassword(string email,string Password);
   (List<UserTable> Users, int TotalItems) GetUsers(string searchTerm, int page, int pageSize);
    Userdetail GetUserById(int userId);
    void AddNewUser(AddUserDetail userDetail);
    void UpdateUser(Userlogin user, Userdetail detail);
    Userlogin GetUserloginDetails(int UserId);
    Task<IEnumerable<Country>> GetCountriesAsync();
    Task<IEnumerable<State>> GetStatesByCountryAsync(int countryId);
    Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId);
    List<Userrole> GetRoles();
    bool DeleteUserById(int id);
    string GetUserNameByEmail(string email);
    int GetUserIdByEmail(string email);
}

