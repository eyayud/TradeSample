using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CUSTOR.OTRLS.Core
{
    public class RegistrationCatagory
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int RegistrationCatagoryId { get; set; }
        public Guid MainGuid { get; set; }
        public string Tin { get; set; }
        public string MajorCatagoryCode { get; set; }

    }
}
