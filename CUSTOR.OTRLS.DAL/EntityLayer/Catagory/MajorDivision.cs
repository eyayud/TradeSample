﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CUSTOR.OTRLS.Core
{
  public class MajorDivision
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string EnglishDescription { get; set; }
        public string MajorDivTigrigna { get; set; }
        public string MajorDivAfanOromo { get; set; }
        public string MajorDivAfar { get; set; }
        public string MajorDivSomali { get; set; }
        public string MajorDivArabic { get; set; }
        public string DescriptionSort { get; set; }
        public string DescriptionSoundX { get; set; }
        public int Code { get; set; }
    }

    public partial class MajorDivisionDTO
    {
        public MajorDivisionDTO()
        {
        }

        [Key]
        public int Code { get; set; }
        public string Description { get; set; }
    }

}
