namespace Repository.Implementations;
using Entity.Models;
using Entity.ViewModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Userlogin GetUserByEmail(string email)
    {
        return _context.Userlogins
            .Include(u => u.Role)
            .FirstOrDefault(u => u.Email == email);
    }
    public bool IsCorrectPassword(string email, string Password)
    {
        var user = _context.Userlogins.FirstOrDefault(u => u.Email == email);

        if (Password == user.Password)
        {
            return true;
        }
        return false;
    }
    public int GetUserIdByEmail(string email){
         var user = _context.Userlogins
                .FirstOrDefault(u => u.Email == email);
        return user.Userid;
    }
    public string GetUserNameByEmail(string email){
        var user = GetUserByEmail(email);
        var userdetail=_context.Userdetails.FirstOrDefault(u=>u.Userid == user.Userid);
        return userdetail.Username;
    }
    public int GetRoleIdByEmail(string email)
    {
        var user = _context.Userlogins
                .FirstOrDefault(u => u.Email == email);
        return user.Roleid;
    }
    public void UpdateUser(Userlogin user)
    {
        _context.Userlogins.Update(user);
        _context.SaveChanges();
    }
    public (List<UserTable> Users, int TotalItems) GetUsers(string searchTerm, int page, int pageSize)
    {
        var query = _context.Userdetails
            .Include(ud => ud.User)
            .Include(ud => ud.Role)
            .Where(ud => !ud.Isdeleted);

        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = searchTerm.ToLower();
            searchTerm = RemoveWhitespace(searchTerm);
            query = query.Where(ud =>
                (ud.Firstname + " " + ud.Lastname).ToLower().Contains(searchTerm) ||
                ud.User.Email.ToLower().Contains(searchTerm) ||
                ud.Phonenumber.Contains(searchTerm) ||
                ud.Role.Rolename.ToLower().Contains(searchTerm)
            );
        }

        var totalItems = query.Count();
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        var users = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(ud => new UserTable
            {
                UserId = ud.Userid,
                Name = $"{ud.Firstname} {ud.Lastname}",
                Email = ud.User.Email,
                Phone = ud.Phonenumber,
                Role = ud.Role.Rolename,
                Status = ud.Status ? "active" : "inactive",
                ProfileImage = ud.Profileimage
            })
            .ToList();
        return (users, totalItems);
    }
    public bool IsUserExists(string email)
    {
        return _context.Userlogins.Any(u => u.Email == email);
    }
    public void AddNewUser(AddUserDetail model)
    {
        var nextUserId = _context.Userdetails.Count() + 1;
        DateTime now = DateTime.Now;

        Userlogin userlogin = new Userlogin
        {
            Userid = nextUserId,
            Email = model.Email,
            Password = model.Password,
            Roleid = model.Roleid
        };

        Userdetail userdetail = new Userdetail
        {
            Userid = nextUserId,
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Username = model.Username,
            Address = model.Address,
            Cityid = model.Cityid,
            Countryid = model.Countryid,
            Stateid = model.Stateid,
            Roleid = model.Roleid,
            Zipcode = model.Zipcode,
            Profileimage = model.ProfileimagePath,
            Phonenumber = model.Phonenumber,
            Status = true,
            Createddate = now,
            Isdeleted = false
        };

        _context.Userlogins.Add(userlogin);
        _context.Userdetails.Add(userdetail);
        _context.SaveChanges();
    }
    public Userdetail GetUserById(int userId)
    {
        return _context.Userdetails
            .Include(ud => ud.User)
            .Include(ud => ud.Role)
            .FirstOrDefault(ud => ud.Userid == userId);
    }
    public Userlogin GetUserloginDetails(int UserId){
        return _context.Userlogins.Find(UserId);
    }

    public void UpdateUser(Userlogin user, Userdetail detail)
    {
        _context.Userlogins.Update(user);
        _context.Userdetails.Update(detail);
        _context.SaveChanges();
    }
    public bool DeleteUserById(int id)
    {
        var userDetail = _context.Userdetails.FirstOrDefault(u => u.Userid == id);
        var userLogin = _context.Userlogins.FirstOrDefault(u => u.Userid == id);

        if (userDetail != null && userLogin != null)
        {
            userDetail.Isdeleted = true;
            userLogin.Isdeleted = true;

            _context.SaveChanges();
            return true;
        }
        return false;
    }
    public async Task<IEnumerable<Country>> GetCountriesAsync()
    {
        return await _context.Countries
            .Where(c => !c.Isdeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<State>> GetStatesByCountryAsync(int countryId)
    {
        return await _context.States
            .Where(s => s.Countryid == countryId && !s.Isdeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId)
    {
        return await _context.Cities
            .Where(c => c.Stateid == stateId && !c.Isdeleted)
            .ToListAsync();
    }
    public List<Userrole> GetRoles()
    {
        return _context.Userroles
            .Where(r => !r.Isdeleted)
            .ToList();
    }
    public string RemoveWhitespace(string input)
 {
    return new string(input
        .Where(c => !Char.IsWhiteSpace(c))
        .ToArray());
 }
}

