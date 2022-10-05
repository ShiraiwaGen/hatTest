using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dairiten.Models
{
    
    public class m_tax
    {
        [Key]        
        public int id { get; set; }

        [DisplayName("開始日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime kaisibi { get; set; }
        public String kaisibi { get; set; }

        [DisplayName("終了日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime shuryobi { get; set; }
        public String? shuryobi { get; set; }

        [DisplayName("消費税")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "少数以下２桁以上は入力できません")]
        public float tax { get; set; }
    }
}
