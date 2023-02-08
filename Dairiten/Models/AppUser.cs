using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dairiten.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "代理店キー")]
        [Required]
        public int m_dairiten_id { get; set; }

        [Display(Name = "募集人キー")]
        [Required]
        public int employee_id { get; set; }

        [Display(Name = "募集人コード")]
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "半角英数字のみ入力できます")]
        [StringLength(50, ErrorMessage = "募集人コードは５０文字以内でお願いします")]
        public string employee_code { get; set; } = null!;

        [Display(Name = "社員_姓")]
        [Required]
        [StringLength(50, ErrorMessage = "社員_姓は５０文字以内でお願いします")]
        public string employee_sei { get; set; } = null!;

        [Display(Name = "社員_名")]
        [Required]
        [StringLength(50, ErrorMessage = "社員_名は５０文字以内でお願いします")]
        public string employee_mei { get; set; } = null!;

        [Display(Name = "パスワード変更日")]
        public DateTime pass_day { get; set; }

        [Display(Name = "ユーザー削除")]
        public bool employee_del { get; set; }
    }
}
