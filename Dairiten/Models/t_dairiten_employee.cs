﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dairiten.Models
{
    public class t_dairiten_employee
    {
        public int id { get; set; }

        [DisplayName("代理店キー")]
        [Required]
        public int m_dairiten_id { get; set; }

        [DisplayName("募集人コード")]
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "半角英数字のみ入力できます")]
        [StringLength(50, ErrorMessage = "募集人コードは５０文字以内でお願いします")]
        public string employee_code { get; set; }

        [DisplayName("社員_姓")]
        [Required]
        [StringLength(50, ErrorMessage = "社員_姓は５０文字以内でお願いします")]
        public string employee_sei { get; set; }

        [DisplayName("社員_名")]
        [Required]
        [StringLength(50, ErrorMessage = "社員_名は５０文字以内でお願いします")]
        public string employee_mei { get; set; }

        [DisplayName("パスワード")]
        [Required]
        [RegularExpression(@"[a-zA-Z0-9 -/:-@\[-\`\{-\~]+", ErrorMessage = "半角英数字記号のみ入力できます")]
        [StringLength(10, ErrorMessage = "パスワードは１０文字以内でお願いします")]
        public string employee_pass { get; set; }

        public DateTime pass_day { get; set; }
        public bool employee_del { get; set; }
    }
}
