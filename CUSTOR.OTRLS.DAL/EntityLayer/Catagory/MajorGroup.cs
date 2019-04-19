using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CUSTOR.OTRLS.Core
{
   public class MajorGroup
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public int Parent { get; set; }

        public string Description { get; set; }

        public string EnglishDescription { get; set; }

        public string MajorGroupTigrigna { get; set; }

        public string MajorGroupAfanOromo { get; set; }

        public string MajorGroupAfar { get; set; }

        public string MajorGroupSomali { get; set; }

        public string MajorGroupArabic { get; set; }

        public string DescriptionSort { get; set; }

        public string DescriptionSoundX { get; set; }
    }

    public partial class MajorGroupModel
    {
        public MajorGroupModel()
        {
        }

        [Key]
        public int Code { get; set; }

        public string Description { get; set; }
    }
}
