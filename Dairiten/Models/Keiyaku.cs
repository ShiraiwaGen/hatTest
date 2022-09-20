using System.ComponentModel.DataAnnotations;

namespace Dairiten.Models
{
    public class Keiyaku
    {
        [Display(Name = "契約キー")]
        public int Id { get; set; }                      //契約キー

        [Required]
        [Display(Name = "代理店キー")]
        public int m_dairiten_id { get; set; }           //代理店キー

        [Required]
        [StringLength(50)]
        [Display(Name = "募集人キー")]
        public string? employee_key { get; set; }        //募集人キー

        [Required]
        [StringLength(10)]
        [Display(Name = "証券番号")]
        public string? shoken_no { get; set; }           //証券番号

        [StringLength(10)]
        [Display(Name = "旧証券番号")]
        public string? old_shoken_no { get; set; }       //旧証券番号

        [Required]
        [StringLength(10)]
        [Display(Name = "履歴番号")]
        public string? rireki_no { get; set; }           //履歴番号

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "計上月")]
        public DateTime keijozuki { get; set; }          //計上月

        [Required]
        [Display(Name = "受付区分")]
        public int uketsuke_kbn { get; set; }            //受付区分

        [Required]
        [Display(Name = "商品区分")]
        public int shohin_kbn { get; set; }              //商品区分

        [Required]
        [Display(Name = "契約者区分")]
        public int keiyakusha_kbn { get; set; }          //契約者区分

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "申込書作成日")]
        public DateTime moshikomisho_day { get; set; }   //申込書作成日

        [Required]
        [Display(Name = "用法")]
        public int yoho { get; set; }                    //用法

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "保険始期")]
        public DateTime hokenshiki { get; set; }         //保険始期

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "保険終期")]
        public DateTime hokenshuki { get; set; }         //保険終期

        [Required]
        [Display(Name = "保険期間")]
        public int hokenkikan { get; set; }              //保険期間

        [Display(Name = "住宅内入居者死亡費用特約")]
        public bool tokuyaku1 { get; set; }              //住宅内入居者死亡費用特約

        [Required]
        [Display(Name = "商品キー")]
        public int m_shohin_id { get; set; }             //商品キー

        [StringLength(50)]
        [Display(Name = "契約者連絡先")]
        public string? k_tel { get; set; }               //契約者連絡先

        [StringLength(50)]
        [Display(Name = "契約者携帯")]
        public string? k_mobile { get; set; }            //契約者携帯

        [Display(Name = "契約者_戸建て")]
        public bool k_kodate { get; set; }               //契約者_戸建て

        [Display(Name = "契約者_物件番号")]
        public string? k_bukken_no { get; set; }         //契約者_物件番号

        [Required]
        [StringLength(10)]
        [Display(Name = "契約者_郵便番号")]
        public string? k_zip { get; set; }               //契約者_郵便番号

        [Required]
        [StringLength(200)]
        [Display(Name = "契約者_住所")]
        public string? k_address1 { get; set; }          //契約者_住所

        [StringLength(200)]
        [Display(Name = "契約者_丁目番地")]
        public string? k_address2 { get; set; }          //契約者_丁目番地

        [StringLength(100)]
        [Display(Name = "契約者_建物名")]
        public string? k_address3 { get; set; }          //契約者_建物名

        [StringLength(50)]
        [Display(Name = "契約者_号室")]
        public string? k_address4 { get; set; }          //契約者_号室

        [Required]
        [StringLength(50)]
        [Display(Name = "契約者名_セイ")]
        public string? k_sei_kana { get; set; }          //契約者名_セイ

        [Required]
        [StringLength(50)]
        [Display(Name = "契約者名_メイ")]
        public string? k_mei_kana { get; set; }          //契約者名_メイ

        [Required]
        [StringLength(50)]
        [Display(Name = "契約者名_姓")]
        public string? k_sei { get; set; }               //契約者名_姓

        [Required]
        [StringLength(50)]
        [Display(Name = "契約者名_名")]
        public string? k_mei { get; set; }               //契約者名_名

        [Required]
        [Display(Name = "契約者生年月日")]
        public DateTime k_birth { get; set; }            //契約者生年月日

        [EmailAddress]
        [Display(Name = "契約者_メールアドレス")]
        public string? k_mail { get; set; }              //契約者_メールアドレス
    }
}
