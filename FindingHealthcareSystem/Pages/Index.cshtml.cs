using BusinessObjects.Commons;
using BusinessObjects.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        public PaginatedList<GeneralUserDto> Users { get; set; } = new(new List<GeneralUserDto>(), 0, 1, 10);

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string Role { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string Status { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; } = "fullname";

        [BindProperty(SupportsGet = true)]
        public bool IsDescending { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        private const int PageSize = 10;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            Users = await _userService.GetUsersAsync(Search, Role, Status, SortBy, IsDescending, PageIndex, PageSize);
        }
    }
}
