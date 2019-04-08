using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CUSTOR.OTRLS.Core
{
    public partial class Manager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerId { get; set; }
        public int CustomerId { get; set; }
        public string Tin { get; set; }
        public int? Title { get; set; }
        public string FirstName { get; set; }
        public string FirstNameSort { get; set; }
        public string FirstNameSoundx { get; set; }
        public string FirstNameEng { get; set; }
        public string FatherName { get; set; }
        public string FatherNameSort { get; set; }
        public string FatherNameSoundx { get; set; }
        public string FatherNameEng { get; set; }
        public string GrandName { get; set; }
        public string GrandNameSort { get; set; }
        public string GrandNameSoundx { get; set; }
        public string GrandNameEng { get; set; }
        //public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public int Nationality { get; set; }
        public int Origin { get; set; }
        public string Remark { get; set; }
        public int? AddressId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
