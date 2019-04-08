
using System;
using System.Collections.Generic;
using System.Text;

namespace CUSTOR.OTRLS.Core
{
    public static class ManagerHelper
    {
        public static Manager GetManager(this ManagerDTO managerDTO)
        {
            try
            {
                return new Manager
                {
                    //ManagerId = (managerDTO.ManagerId > 0) ? 0 : managerDTO.ManagerId,
                    //DateOfBirth = managerDTO.DateOfBirth,
                    FatherName = managerDTO.FatherName,
                    FatherNameEng = managerDTO.FatherNameEng,
                    FatherNameSort = string.Empty,
                    FatherNameSoundx = string.Empty,
                    FirstName = managerDTO.FirstName,
                    FirstNameEng = managerDTO.FirstNameEng,
                    FirstNameSort = string.Empty,
                    FirstNameSoundx = string.Empty,
                    Gender = managerDTO.Gender,
                    GrandName = managerDTO.GrandName,
                    GrandNameEng = managerDTO.GrandNameEng,
                    GrandNameSort = string.Empty,
                    GrandNameSoundx = string.Empty,
                    IsActive = managerDTO.IsActive,
                    IsDeleted = managerDTO.IsDeleted,
                    Nationality = managerDTO.Nationality,
                    Origin = managerDTO.Origin,
                    Remark = string.Empty,
                    Title = managerDTO.Title,
                    Tin = managerDTO.Tin,
                    CustomerId = managerDTO.CustomerId


                };
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return null;
            }
            
        }
        public static Address GetAddress(this ManagerDTO ManagerDTO)
        {
            return new Address
            {
                CellPhoneNo = ManagerDTO.CellPhoneNo,
                AddressType = (int)AddressType.eManager,
                Email = ManagerDTO.Email,
                Fax = ManagerDTO.Fax,
                HouseNo = ManagerDTO.HouseNo,
                IsActive = ManagerDTO.IsActive,
                IsDeleted = ManagerDTO.IsDeleted,
                IsMainOffice = true,
                KebeleId = ManagerDTO.KebeleId,
                OtherAddress = ManagerDTO.OtherAddress,
                ParentId = ManagerDTO.ManagerId,
                RegionId = ManagerDTO.RegionId,
                Pobox = ManagerDTO.Pobox,
                Remark = "",
                SpecificAreaName = "",
                TeleNo = ManagerDTO.TeleNo,
                TownId = "-1",
                WoredaId = ManagerDTO.WoredaId,
                ZoneId = ManagerDTO.ZoneId,
                AddressId = ManagerDTO.AddressId

            };
        }
        public static ManagerDTO GetManagerDTO(Manager mgr, Address add)
        {
            return new ManagerDTO
            {
                FatherName = mgr.FatherName,
                FatherNameEng = mgr.FatherNameEng,
                //FatherNameSort = string.Empty,
                //FatherNameSoundx = string.Empty,
                FirstName = mgr.FirstName,
                FirstNameEng = mgr.FirstNameEng,
                //FirstNameSort = string.Empty,
                //FirstNameSoundx = string.Empty,
                Gender = mgr.Gender,
                GrandName = mgr.GrandName,
                GrandNameEng = mgr.GrandNameEng,
                //GrandNameSort = string.Empty,
                //GrandNameSoundx = string.Empty,
                ManagerId = mgr.ManagerId,
                IsActive = mgr.IsActive,
                IsDeleted = mgr.IsDeleted,
                Nationality = mgr.Nationality,
                Origin = mgr.Origin,
                Title = mgr.Title,
                Tin = mgr.Tin,
                CellPhoneNo = add.CellPhoneNo,
                Email = add.Email,
                Fax = add.Fax,
                HouseNo = add.HouseNo,
                KebeleId = add.KebeleId,
                OtherAddress = add.OtherAddress,
                RegionId = add.RegionId,
                Pobox = add.Pobox,
                TeleNo = add.TeleNo,
                WoredaId = add.WoredaId,
                ZoneId = add.ZoneId,
                AddressId = add.AddressId
            };
        }

    }
}
