﻿// Backend - RegisterModel.cs
using BusinessObjects.Enums;
using BusinessObjects.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects.DTOs.User;
using BusinessObjects.Entities;

namespace FindingHealthcareSystem.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public RegisterViewModel Input { get; set; } = new();

        public List<Specialty> Specialties { get; private set; }
        public List<FacilityDepartment> Hospitals { get; private set; }

        public List<Expertise> Expertises { get; private set; }

        public List<CaLamViec> DanhSachCa { get; set; } = new();

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            Specialties = await _userService.GetAllSpecialtiesAsync();

            if (Specialties != null && Specialties.Count > 0)
            {
                ViewData["Specialties"] = Specialties;

            }

            else
            {
                ViewData["Specialties"] = new List<Specialty>(); // Avoid null issues
            }

            if (Specialties == null || Specialties.Count == 0)
            {
                ViewData["SpecialtyMessage"] = "No specialties available.";
            }
            else
            {
                ViewData["SpecialtyMessage"] = Specialties.Count+" specialties available.";


            }

                Expertises = await _userService.GetAllExpertises();

                if (Expertises != null && Expertises.Count > 0)
                {
                    ViewData["Expertises"] = Expertises;
                }


                DanhSachCa = new List<CaLamViec>
        {
            new CaLamViec { MaCa = "Mon-Morning", MoTa = "Sáng (08:00 - 12:00)" },
         
        new CaLamViec { MaCa = "Tue-Afternoon", MoTa = " Chiều (13:00 - 17:00)" },
             new CaLamViec { MaCa = "Tue-Evening", MoTa = "Tối (18:00 - 22:00)" },


        };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();

                var userDto = new RegisterUserDto
                {
                    Fullname = Input.Fullname,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                    Password = HashPassword(Input.Password),
                    Role = Input.Role,
                    Birthday = Input.Birthday,
                    Gender = Input.Gender,
                    Province = Input.Province,
                    City = Input.City,
                    District = Input.District,
                    WorkingHours = Input.WorkingHours,
                    Address = Input.Address,
                    Degree = Input.Degree,
                    Experience = Input.Experience,
                    ExpertiseId = Input.ExpertiseId,
                    SpecialtyIds = Input.SpecialtyIds,
                };

                await _userService.RegisterUserAsync(userDto);

                TempData["SuccessMessage"] = "Đăng ký thành công! Vui lòng đăng nhập.";
                return RedirectToPage("/Auth/Login");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Page(); // Quay lại trang hiện tại và hiển thị thông báo lỗi
            }
        }


          
        

        private string HashPassword(string password)
        {
            // Implement password hashing logic
            return password;
        }
    }

    public class CaLamViec
    {
        public string MaCa { get; set; }  // Mã ca làm việc
        public string MoTa { get; set; }  // Mô tả ca làm việc
    }
    public class RegisterViewModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public DateOnly? Birthday { get; set; }
        public string Gender { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? WorkingHours { get; set; } /// giờ làm vieecjj khoảng thời gian 
        public int? ExpertiseId { get; set; }

        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Degree { get; set; }
        public string? Experience { get; set; }

        public List<int> SpecialtyIds { get; set; } = new();
    }
}

