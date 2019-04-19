using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CUSTOR.OTRLS.Core
{
    public class LegalStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Code { get; set; }
        public string LegalStatusNameAmhSource { get; set; }
        public string LegalStatusNameAmh { get; set; }
        public string LegalStatusNameEng { get; set; }
        public string LegalStatusNameTigrigna { get; set; }
        public string LegalStatusNameAfanOromo { get; set; }
        public string LegalStatusNameAfar { get; set; }
        public string LegalStatusNameSomali { get; set; }
        public string LegalStatusNameArabic { get; set; }
        public string UserName { get; set; }
        public DateTime EventDate { get; set; }
        public string UpdatedUserName { get; set; }
        public DateTime UpdatedEventDate { get; set; }
    }


    public partial class LegalStatusDTO
    {
        public LegalStatusDTO()
        {
        }

        [Key]
        public int Code { get; set; }
        public string Description { get; set; }
    }
}
