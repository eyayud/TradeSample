using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CUSTOR.OTRLS.Core
{
   public class Division
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public int Parent { get; set; }

        public string Description { get; set; }

        public string EnglishDescription { get; set; }

        public string DivisionTigrigna { get; set; }

        public string DivisionAfanOromo { get; set; }

        public string DivisionAfar { get; set; }

        public string DivisionSomali { get; set; }

        public string DivisionArabic { get; set; }

        public string DescriptionSort { get; set; }

        public string DescriptionSoundX { get; set; }
    }

    public partial class DivisionViewModel
    {
        public DivisionViewModel()
        {
        }

        [Key]
        public int Code { get; set; }

        public string Description { get; set; }
    }
}
