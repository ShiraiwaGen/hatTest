using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Dairiten.Models
{
    public class t_karibukken
    {
        public int id { get; set; }

        [DisplayName("物件番号")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        public string bukken_no { get; set; }

        [DisplayName("郵便番号")]
        [Required]
        [StringLength(7, ErrorMessage = "郵便番号はハイフン（－）なしの数字７桁でお願いします")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        public string b_zip { get; set; }

        [DisplayName("住所（都道府県市区町村）")]
        [Required]
        [StringLength(55, ErrorMessage = "住所（都道府県市区町村）は５５文字以内でお願いします")]
        public string b_address1 { get; set; }

        [DisplayName("住所（丁目番地）")]
        [Required]
        [StringLength(25, ErrorMessage = "住所（丁目番地）は２５文字以内でお願いします")]
        public string b_address2 { get; set; }

        [DisplayName("住所（建物名）")]
        [StringLength(50, ErrorMessage = "住所（建物名）は５０文字以内でお願いします")]
        public string? b_address3 { get; set; }

        [DisplayName("住所（棟番号）")]
        [StringLength(25, ErrorMessage = "棟番号は２５文字以内でお願いします")]
        public string? b_address4 { get; set; }

        [DisplayName("住所（号室）")]
        [StringLength(25, ErrorMessage = "住所（号室）は２５文字以内でお願いします")]
        public string? b_address5 { get; set; }

        [DisplayName("戸建区分")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        [Range(0, 1, ErrorMessage = "戸建区分は０か１でお願いします")]        
        public int b_kodate { get; set; }

        [DisplayName("代理店コード")]
        [Required]
        [MinLength(12, ErrorMessage = "代理店コードは１２桁でお願いします")]
        [StringLength(12, ErrorMessage = "代理店コードは１２桁でお願いします")]
        public int m_dairiten_id { get; set; }

        [DisplayName("募集人キー")]
        [Required]
        public int employee_key { get; set; }
    }
}
