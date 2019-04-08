using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CUSTOR.OTRLS.Core
{
    public partial class ManagerDTO
    {
        public ManagerDTO()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerId { get; set; }
        public string Tin { get; set; }
        public int? Title { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string FirstNameEng { get; set; }
        public string FatherName { get; set; }
        public string FatherNameEng { get; set; }
        public string GrandName { get; set; }
        public string GrandNameEng { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }
        public int Nationality { get; set; }
        public int Origin { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string PhotoData { get; set; }
        public string RegionId { get; set; }
        public string ZoneId { get; set; }
        public string WoredaId { get; set; }
        public string KebeleId { get; set; }
        public string HouseNo { get; set; }
        public string TeleNo { get; set; }
        public string Pobox { get; set; }
        public string Fax { get; set; }
        public string CellPhoneNo { get; set; }
        public string Email { get; set; }
        public string OtherAddress { get; set; }
        public int AddressId { get; set; }


    }
    public partial class ManagerListDTO
    {
        public ManagerListDTO()
        {
        }
        public int ManagerId { get; set; }
        public string FullName { get; set; }
        public string FullNameEng { get; set; }
    }
}
