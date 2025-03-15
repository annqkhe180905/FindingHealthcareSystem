﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using BusinessObjects.DTOs.Facility;
using BusinessObjects.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.DTOs.Department;
using Services.Interfaces;

namespace Services.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacilityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FacilityDto>> GetAllFacilities()
        {
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facilities = await facRepo.GetAllAsync();
            if (facilities == null || !facilities.Any())
            {
                return new List<FacilityDto>();
            }
            return _mapper.Map<List<FacilityDto>>(facilities);
        }

        public async Task<IEnumerable<FacilityDto>> SearchFacilities(string? name, string? province, string? operationDay, string? district, string? city, bool isAdmin, int? typeId)
        {
            var filters = new Dictionary<string, object?>();

            if (!string.IsNullOrEmpty(name)) filters["Name"] = name;
            if (!string.IsNullOrEmpty(province)) filters["Province"] = province;
            if (!string.IsNullOrEmpty(operationDay)) filters["OperationDay"] = operationDay;
            if (!string.IsNullOrEmpty(district)) filters["District"] = district;
            if (!string.IsNullOrEmpty(city)) filters["City"] = city;
            if (isAdmin == false) filters["Status"] = FacilityStatus.Active;
            if (typeId.HasValue) filters["TypeId"] = typeId;

            var includes = new List<string> { "FacilityType" };

            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facilities = await facRepo.SearchAsync(filters);
            return _mapper.Map<List<FacilityDto>>(facilities);
        }

        public async Task<FacilityDto> Create(FacilityDto facilityDto)
        {
            //validation
            ValidateFacilityDto(facilityDto);

            //set value and save for Facility
            facilityDto.Status = FacilityStatus.Inactive;
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facility = _mapper.Map<Facility>(facilityDto);
            facility.CreatedAt = DateTime.UtcNow.AddHours(7);
            facility.IsDeleted = false;
            await facRepo.AddAsync(facility);
            await _unitOfWork.SaveChangesAsync();

            //set value and save for FacilityDepartment
            var facRepo2 = _unitOfWork.FacilityRepository;
            var facdepRepo = _unitOfWork.GetRepository<FacilityDepartment>();
            if (facilityDto.DepartmentIds.Count > 0)
            {
                var facilityDepartments = facilityDto.DepartmentIds.Select(deptId => new FacilityDepartment
                {
                    FacilityId = facility.Id,
                    DepartmentId = deptId,
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    IsDeleted = false
                }).ToList();

                await facRepo2.CreateFacilityDepartmentsAsync(facilityDepartments);
                await _unitOfWork.SaveChangesAsync();
            }

            //get and response for Facility
            var facilityWithRelations = await facRepo2.GetByIdWithRelationsAsync(facility.Id);

            return MapToFacilityResponseDto(facilityWithRelations);
        }

        public async Task<FacilityDto> Update(int id, FacilityDto facilityDto)
        {
            //validation
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facility = await facRepo.GetByIdAsync(id);
            if (facility == null)
            {
                throw new Exception("Facility not found");
            }
            ValidateFacilityDto(facilityDto);

            //set value and save for Facility
            _mapper.Map<Facility>(facilityDto);
            facility.UpdatedAt = DateTime.UtcNow.AddHours(7);
            facRepo.Update(facility);
            await _unitOfWork.SaveChangesAsync();

            //set value and save for FacilityDepartment
            var facRepo2 = _unitOfWork.FacilityRepository;
            if (facilityDto.DepartmentIds.Count > 0)
            {
                await facRepo2.UpdateFacilityDepartmentsAsync(facility.Id, facilityDto.DepartmentIds);
                await _unitOfWork.SaveChangesAsync();
            }

            //get and response for Facility
            var facilityWithRelations = await facRepo2.GetByIdWithRelationsAsync(facility.Id);

            return MapToFacilityResponseDto(facilityWithRelations);
        }

        public async Task<FacilityDto> GetById(int id)
        {
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facility = await facRepo.GetByIdAsync(id);
            if (facility == null)
            {
                throw new Exception("Facility not found");
            }
            return _mapper.Map<FacilityDto>(facility);
        }

        public async Task<FacilityDto> DeleteAsync(int id)
        {
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facility = await facRepo.GetByIdAsync(id);
            if (facility == null)
            {
                throw new Exception("Facility not found");
            }
            facility.Status = FacilityStatus.Inactive;
            facility.UpdatedAt = DateTime.UtcNow.AddHours(7);
            facility.IsDeleted = true;
            facRepo.Update(facility);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<FacilityDto>(facility);
        }

        private void ValidateFacilityDto(FacilityDto facilityDto)
        {
            var requiredFields = new Dictionary<string, object>
            {
                { "Facility type", facilityDto.TypeId },
                { "Facility name", facilityDto.Name },
                { "Facility operation day", facilityDto.OperationDay },
                { "Facility province", facilityDto.Province },
                { "Facility district", facilityDto.District },
                { "Facility city", facilityDto.City },
                { "Facility address", facilityDto.Address }
            };

            foreach (var field in requiredFields)
            {
                if (field.Value == null || (field.Value is string str && string.IsNullOrEmpty(str)))
                {
                    throw new Exception($"{field.Key} is required");
                }
            }

            if (facilityDto.OperationDay > DateOnly.FromDateTime(DateTime.UtcNow))
            {
                throw new Exception("Operation day must be less than or equal to the current date");
            }
        }

        private FacilityDto MapToFacilityResponseDto(Facility facility)
        {
            return new FacilityDto
            {
                Id = facility.Id,
                TypeId = facility.TypeId,
                Name = facility.Name,
                OperationDay = facility.OperationDay,
                Province = facility.Province,
                District = facility.District,
                City = facility.City,
                Address = facility.Address,
                Description = facility.Description,
                Status = facility.Status,
                Type = facility.Type != null ? new FacilityTypeDto
                {
                    Id = facility.Type.Id,
                    Name = facility.Type.Name,
                    Description = facility.Type.Description
                } : null,
                FacilityDepartments = facility.FacilityDepartments.Select(fd => new FacilityDepartmentDto
                {
                    Id = fd.Id,
                    FacilityId = fd.FacilityId,
                    DepartmentId = fd.DepartmentId,
                    Department = fd.Department != null ? new DepartmentDto
                    {
                        Id = fd.Department.Id,
                        Name = fd.Department.Name,
                        Description = fd.Department.Description
                    } : null
                }).ToList()
            };
        }
    }
}
