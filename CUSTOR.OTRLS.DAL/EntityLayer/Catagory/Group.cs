using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CUSTOR.OTRLS.Core
{
   public class Group
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public int Parent { get; set; }

        public string Description { get; set; }

        public string EnglishDescription { get; set; }

        public string GroupTigrigna { get; set; }

        public string GroupAfanOromo { get; set; }

        public string GroupAfar { get; set; }

        public string GroupSomali { get; set; }

        public string GroupArabic { get; set; }

        public string DescriptionSort { get; set; }

        public string DescriptionSoundX { get; set; }

    }
    public partial class GroupViewModel
    {
        public GroupViewModel()
        {
        }

        [Key]
        public int Code { get; set; }

        public string Description { get; set; }
    }
}
