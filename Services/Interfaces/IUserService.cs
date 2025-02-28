using BusinessObjects.Commons;
using BusinessObjects.Dtos.User;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<PaginatedList<GeneralUserDto>> GetUsersAsync(
        string? search,
        string? role,
        string? status,
        string? sortBy,
        bool isDescending,
        int pageIndex,
        int pageSize);

        Task<GeneralUserDto?> GetUserByIdAsync(int userId);

    }
}
