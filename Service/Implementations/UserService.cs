using Entity.Models;
using Entity.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Service.Interfaces;


namespace Service.Implementations;

public class UserService : IUserService
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepo;
    private readonly IFileService _fileService;
    private readonly IAuthService _authService;
    public UserService(IUserRepository userRepo, IConfiguration config, IAuthService authService, IFileService fileService)
    {
        _authService = authService;
        _userRepo = userRepo;
        _config = config;
        _fileService = fileService;
    }
    public (List<UserTable> Users, int TotalItems) GetUsers(string SearchTerm, int page, int PageSize)
    {
        var query = _userRepo.GetUsers(SearchTerm, page, PageSize);
        return query;
    }
    public MyProfile GetProfileForUpdate(int userId){
        var userDetail = _userRepo.GetUserById(userId);
        return new MyProfile
        {
            UserId = userDetail.Userid,
            Firstname = userDetail.Firstname,
            Lastname = userDetail.Lastname,
            Username = userDetail.Username,
            Email = userDetail.User.Email,
            Roleid = userDetail.Roleid,
            Countryid = userDetail.Countryid,
            Stateid = userDetail.Stateid,
            Cityid = userDetail.Cityid,
            Address = userDetail.Address,
            Zipcode = userDetail.Zipcode,
            Status= (userDetail.Status == true)? "1":"2",
            Phonenumber = userDetail.Phonenumber,
            ExistingProfileImage = userDetail.Profileimage
        };
    }
    public void UpdateUserProfile(MyProfile model, string profileImagePath)
    {
        var user = _userRepo.GetUserById(model.UserId);
        var userLogin = _userRepo.GetUserloginDetails(model.UserId);
        user.Firstname = model.Firstname;
        user.Lastname = model.Lastname;
        user.Username = model.Username;
        user.Address = model.Address;
        user.Countryid = model.Countryid;
        user.Stateid = model.Stateid;
        user.Cityid = model.Cityid;
        user.Zipcode = model.Zipcode;
        user.Phonenumber = model.Phonenumber;
        user.Profileimage = profileImagePath ?? user.Profileimage;
        user.Status=(model.Status=="1")?true: false;
        user.Modifieddate=DateTime.Now;
        _userRepo.UpdateUser(userLogin, user);
    }
    public void AddNewUser(AddUserDetail user)
    {
        var imagePath = _fileService.SaveProfileImage(user.ProfileImageFile).Result;
        user.ProfileimagePath = imagePath;
        user.Password = _authService.EncryptPassword(user.Password);
        _userRepo.AddNewUser(user);
    }
    public EditUserDetail GetUserForEdit(int userId)
    {
        var userDetail = _userRepo.GetUserById(userId);
        return new EditUserDetail
        {
            UserId = userDetail.Userid,
            Firstname = userDetail.Firstname,
            Lastname = userDetail.Lastname,
            Username = userDetail.Username,
            Email = userDetail.User.Email,
            Roleid = userDetail.Roleid,
            Countryid = userDetail.Countryid,
            Stateid = userDetail.Stateid,
            Cityid = userDetail.Cityid,
            Address = userDetail.Address,
            Zipcode = userDetail.Zipcode,
            Status= (userDetail.Status == true)? "1":"2",
            Phonenumber = userDetail.Phonenumber,
            ExistingProfileImage = userDetail.Profileimage
        };
    }


    public void UpdateUser(EditUserDetail model, string profileImagePath)
    {
        var user = _userRepo.GetUserById(model.UserId);
        var userLogin = _userRepo.GetUserloginDetails(model.UserId);

        userLogin.Email = model.Email;
        userLogin.Roleid = model.Roleid;

        user.Firstname = model.Firstname;
        user.Lastname = model.Lastname;
        user.Username = model.Username;
        user.Address = model.Address;
        user.Countryid = model.Countryid;
        user.Stateid = model.Stateid;
        user.Cityid = model.Cityid;
        user.Zipcode = model.Zipcode;
        user.Phonenumber = model.Phonenumber;
        user.Profileimage = profileImagePath ?? user.Profileimage;
        user.Status= model.Status=="1";
        _userRepo.UpdateUser(userLogin, user);
    }
    public bool DeleteUser(int id)
    {
        return _userRepo.DeleteUserById(id);
    }
    public Task<IEnumerable<Country>> GetCountriesAsync()
    {
        return _userRepo.GetCountriesAsync();
    }

    public Task<IEnumerable<State>> GetStatesByCountryAsync(int countryId)
    {
        return _userRepo.GetStatesByCountryAsync(countryId);
    }

    public Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId)
    {
        return _userRepo.GetCitiesByStateAsync(stateId);
    }
    public List<Userrole> GetRoles()
    {
        return _userRepo.GetRoles();
    }
}

