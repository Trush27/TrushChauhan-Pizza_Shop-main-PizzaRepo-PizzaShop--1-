using Microsoft.AspNetCore.Http;

namespace Service.Interfaces;

public interface IFileService
{
    Task<string> SaveProfileImage(IFormFile file);
}
