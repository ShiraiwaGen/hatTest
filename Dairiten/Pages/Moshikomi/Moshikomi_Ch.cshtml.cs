using Dairiten.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Dairiten.Pages.Moshikomi
{
    public class Moshikomi_ChModel : PageModel
    {
        private readonly Dairiten.Data.ApplicationDbContext _context;

        public Moshikomi_ChModel(Dairiten.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public t_keiyaku keiyaku { get; set; }

        public string kodate = "戸建て";

        public string d_no, d_name, bnin_key;

        public class InputModel
        {
            [Display(Name = "契約キー")]
            public int Id { get; set; }                             //契約キー

            [Required]
            [Display(Name = "代理店キー")]
            public int m_dairiten_id { get; set; }                  //代理店キー

            [Required]
            [Display(Name = "募集人キー")]
            public int employee_key { get; set; }                   //募集人キー

            [Required]
            [MinLength(10, ErrorMessage = "証券番号は１０桁でお願いします")]
            [StringLength(10, ErrorMessage = "証券番号は１０桁でお願いします")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "半角英数字のみ入力できます。")]
            [Display(Name = "証券番号")]
            public string shoken_no { get; set; }                  //証券番号

            [MinLength(10, ErrorMessage = "証券番号は１０桁でお願いします")]
            [StringLength(10, ErrorMessage = "証券番号は１０桁でお願いします")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "半角英数字のみ入力できます。")]
            [Display(Name = "旧証券番号")]
            public string old_shoken_no { get; set; }              //旧証券番号

            [Required]
            [StringLength(10)]
            [Display(Name = "履歴番号")]
            public string rireki_no { get; set; }                  //履歴番号

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "計上月")]
            public DateTime keijozuki { get; set; }                 //計上月

            [Required]
            [Display(Name = "受付区分")]
            public int uketsuke_kbn { get; set; }                   //受付区分

            [Required]
            [Display(Name = "商品区分")]
            public string shohin_kbn { get; set; }                  //商品区分

            [Required]
            [Display(Name = "契約者区分")]
            public string keiyakusha_kbn { get; set; }              //契約者区分

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = @"申込書作成日")]
            public DateTime moshikomisho_day { get; set; }          //申込書作成日

            [Required]
            [Display(Name = "用法")]
            public int yoho { get; set; }                           //用法

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "保険始期")]
            public DateTime hokenshiki { get; set; }                //保険始期

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "保険終期")]
            public DateTime hokenshuki { get; set; }                //保険終期

            [Required]
            [Display(Name = "保険期間")]
            public string hokenkikan { get; set; }                  //保険期間

            [Display(Name = "住宅内入居者死亡費用特約")]
            public bool tokuyaku1 { get; set; }                     //住宅内入居者死亡費用特約

            [Required]
            [Display(Name = "商品キー")]
            public string m_shohin_id { get; set; }                    //商品キー

            [Phone]
            [StringLength(50, ErrorMessage = "契約者連絡先は５０文字以内でお願いします")]
            [Display(Name = "契約者連絡先")]
            public string? k_tel { get; set; }                      //契約者連絡先

            [Phone]
            [StringLength(50, ErrorMessage = "契約者携帯は５０文字以内でお願いします")]
            [Display(Name = "契約者携帯")]
            public string? k_mobile { get; set; }                   //契約者携帯

            [Display(Name = "契約者_戸建て")]
            public string k_kodate { get; set; }                    //契約者_戸建て

            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            [Display(Name = "契約者_物件番号")]
            public string? k_bukken_no { get; set; }                //契約者_物件番号

            [Required]
            [StringLength(7, ErrorMessage = "郵便番号はハイフン（−）なしの数字７桁でお願いします")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            [Display(Name = "契約者_郵便番号")]
            public string k_zip { get; set; }                      //契約者_郵便番号

            [Required]
            [StringLength(55, ErrorMessage = "住所（都道府県市区町村）は５５文字以内でお願いします")]
            [Display(Name = "契約者_住所（都道府県市区町村）")]
            public string k_address1 { get; set; }                 //契約者_住所（都道府県市区町村）

            [StringLength(25, ErrorMessage = "住所（丁目番地）は２５文字以内でお願いします")]
            [Display(Name = "契約者_住所（丁目番地）")]
            public string k_address2 { get; set; }                 //契約者_住所（丁目番地）

            [StringLength(50, ErrorMessage = "住所（建物名）は５０文字以内でお願いします")]
            [Display(Name = "契約者_住所（建物名）")]
            public string? k_address3 { get; set; }                 //契約者_住所（建物名）

            [StringLength(25, ErrorMessage = "住所（号室）は２５文字以内でお願いします")]
            [Display(Name = "契約者_住所（号室）")]
            public string? k_address4 { get; set; }                 //契約者_住所（号室）

            [Required]
            [StringLength(50, ErrorMessage = "契約者名カナは５０文字以内でお願いします")]
            [Display(Name = "契約者名カナ")]
            public string k_kana { get; set; }                      //契約者名カナ

            [Required]
            [StringLength(50, ErrorMessage = "契約者名は５０文字以内でお願いします")]
            [Display(Name = "契約者名")]
            public string k_name { get; set; }                      //契約者名

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "契約者生年月日")]
            public DateTime k_birth { get; set; }                  //契約者生年月日

            [EmailAddress]
            [Display(Name = "契約者_メールアドレス")]
            public string? k_mail { get; set; }                     //契約者_メールアドレス

            [Display(Name = "保証人区分")]
            public string hoshonin_kbn { get; set; }                //保証人区分

            [StringLength(100, ErrorMessage = "保証人区分その他は１００文字以内でお願いします")]
            [Display(Name = "保証人区分その他")]
            public string? hoshonin_kbn_other { get; set; }         //保証人区分その他

            [Display(Name = "複数契約特約")]
            public bool fukusu_tokuyaku { get; set; }               //複数契約特約

            [Display(Name = "契約者と同じ")]
            public bool k_onaji { get; set; }                       //契約者と同じ

            [Display(Name = "目的地_戸建て")]
            public string h_kodate { get; set; }                      //目的地_戸建て

            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            [Display(Name = "目的地_物件番号")]
            public string? h_bukken_no { get; set; }                //目的地_物件番号

            [Required]
            [StringLength(7, ErrorMessage = "郵便番号はハイフン（−）なしの数字７桁でお願いします")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
            [Display(Name = "目的地_郵便番号")]
            public string h_zip { get; set; }                      //目的地_郵便番号

            [Required]
            [StringLength(55, ErrorMessage = "住所（都道府県市区町村）は５５文字以内でお願いします")]
            [Display(Name = "目的地_住所（都道府県市区町村）")]
            public string h_address1 { get; set; }                 //目的地_住所（都道府県市区町村）

            [StringLength(25, ErrorMessage = "住所（丁目番地）は２５文字以内でお願いします")]
            [Display(Name = "目的地_住所（丁目番地）")]
            public string h_address2 { get; set; }                 //目的地_住所（丁目番地）

            [StringLength(50, ErrorMessage = "住所（建物名）は５０文字以内でお願いします")]
            [Display(Name = "目的地_住所（建物名）")]
            public string? h_address3 { get; set; }                 //目的地_住所（建物名）

            [StringLength(25, ErrorMessage = "住所（号室）は２５文字以内でお願いします")]
            [Display(Name = "目的地_住所（号室）")]
            public string? h_address4 { get; set; }                 //目的地_住所（号室）

            [Required]
            [Display(Name = "被保険者区分")]
            public int hihokensha_kbn { get; set; }                 //被保険者区分

            [Required]
            [StringLength(50, ErrorMessage = "被保険者名カナは５０文字以内でお願いします")]
            [Display(Name = "被保険者名カナ")]
            public string h_kana { get; set; }                      //被保険者名カナ

            [Required]
            [StringLength(50, ErrorMessage = "被保険者名は５０文字以内でお願いします")]
            [Display(Name = "被保険者名")]
            public string h_name { get; set; }                      //被保険者名

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "被保険者生年月日")]
            public DateTime h_birth { get; set; }                   //被保険者生年月日

            [Required]
            [Display(Name = "手続依頼書発行区分")]
            public string tetsuzukiiraishohakko_kbn { get; set; }   //手続依頼書発行区分

            [Required]
            [Display(Name = "集金方法")]
            public string shukinhoho { get; set; }                  //集金方法

            [Display(Name = "他の保険")]
            public bool other_hoken { get; set; }                   //他の保険

            [Display(Name = "他の保険_当社有無")]
            public bool other_hoken_umu { get; set; }               //他の保険_当社有無

            [StringLength(50, ErrorMessage = "他の保険_保険会社名は５０文字以内でお願いします")]
            [Display(Name = "他の保険_保険会社名")]
            public string? other_hoken_company { get; set; }        //他の保険_保険会社名

            [StringLength(50, ErrorMessage = "他の保険_保険種類は５０文字以内でお願いします")]
            [Display(Name = "他の保険_保険種類")]
            public string? other_hoken_shurui { get; set; }         //他の保険_保険種類

            [DataType(DataType.Date)]
            [Display(Name = "他の保険_満期日")]
            public DateTime other_hoken_manki { get; set; }         //他の保険_満期日

            [Display(Name = "他の保険_保険金額")]
            public int other_hoken_money { get; set; }              //他の保険_保険金額

            [Display(Name = "保険契約証要")]
            public bool hokenkeiyakusho_kbn { get; set; }           //保険契約証要

            [Display(Name = "その他_コード1")]
            public int other_code1 { get; set; }                    //その他_コード1

            [Display(Name = "その他_コード2")]
            public int other_code2 { get; set; }                    //その他_コード2

            [Display(Name = "その他_コード3")]
            public int other_code3 { get; set; }                    //その他_コード3

            [StringLength(100, ErrorMessage = "その他_特記事項は１００文字以内でお願いします")]
            [Display(Name = "その他_特記事項")]
            public string? other_tokkijiko { get; set; }            //その他_特記事項

            [Required]
            [Display(Name = "契約者_法人形態")]
            public int k_hojinkeitai { get; set; }                  //契約者_法人形態

            [StringLength(50, ErrorMessage = "契約者_法人形態その他は５０文字以内でお願いします")]
            [Display(Name = "契約者_法人形態その他")]
            public string? k_hojinkeitai_other { get; set; }        //契約者_法人形態その他

            [Required]
            [Display(Name = "契約者_法人形態位置")]
            public int k_hojinkeitai_ichi { get; set; }             //契約者_法人形態位置

            [Required]
            [StringLength(100, ErrorMessage = "契約者_法人名_カナは１００文字以内でお願いします")]
            [Display(Name = "契約者_法人名_カナ")]
            public string k_hojinmei_kana { get; set; }             //契約者_法人名_カナ

            [Required]
            [StringLength(100, ErrorMessage = "契約者_法人名_漢字は１００文字以内でお願いします")]
            [Display(Name = "契約者_法人名_漢字")]
            public string k_hojinmei_kanji { get; set; }            //契約者_法人名_漢字

            [StringLength(100, ErrorMessage = "支店支社営業所等は１００文字以内でお願いします")]
            [Display(Name = "支店支社営業所等")]
            public string? shiten { get; set; }                     //支店支社営業所等

            [Required]
            [StringLength(100, ErrorMessage = @"代表者_役職は１００文字以内でお願いします")]
            [Display(Name = @"代表者_役職")]
            public string daihyosha_yakushoku { get; set; }         //代表者_役職

            [Required]
            [StringLength(50, ErrorMessage = @"代表者名は５０文字以内でお願いします")]
            [Display(Name = @"代表者名")]
            public string daihyosha_name { get; set; }               //代表者名

            [Display(Name = "法人特約")]
            public bool hojin_tokuyaku { get; set; }                //法人特約

            [Required]
            [Display(Name = "被保険者_法人形態")]
            public int h_hojinkeitai { get; set; }                  //被保険者_法人形態

            [StringLength(50, ErrorMessage = "被保険者_法人形態その他は５０文字以内でお願いします")]
            [Display(Name = "被保険者_法人形態その他")]
            public string? h_hojinkeitai_other { get; set; }        //被保険者_法人形態その他

            [Required]
            [Display(Name = "被保険者_法人形態位置")]
            public int h_hojinkeitai_ichi { get; set; }             //被保険者_法人形態位置

            [Required]
            [StringLength(100, ErrorMessage = "被保険者_法人名_カナは１００文字以内でお願いします")]
            [Display(Name = "被保険者_法人名_カナ")]
            public string h_hojinmei_kana { get; set; }             //被保険者_法人名_カナ

            [Required]
            [StringLength(100, ErrorMessage = "被保険者_法人名_漢字は１００文字以内でお願いします")]
            [Display(Name = "被保険者_法人名_漢字")]
            public string h_hojinmei_kanji { get; set; }            //被保険者_法人名_漢字

            [Required]
            [StringLength(100, ErrorMessage = "業種は１００文字以内でお願いします")]
            [Display(Name = "業種")]
            public string gyoshu { get; set; }                      //業種

            [Display(Name = "業種確認済み")]
            public string? gyoshu_sumi { get; set; }                //業種確認済み

            [Required]
            [Display(Name = "専有面積")]
            public int senyumenseki { get; set; }                   //専有面積

            [Display(Name = "契約者_フロアー借り")]
            public bool k_floor { get; set; }                       //契約者_フロアー借り

            [Display(Name = "目的地_フロアー借り")]
            public bool h_floor { get; set; }                       //目的地_フロアー借り

            [StringLength(50, ErrorMessage = "契約者_屋号は５０文字以内でお願いします")]
            [Display(Name = "契約者_屋号")]
            public string? k_yago { get; set; }                       //契約者_屋号

            [StringLength(50, ErrorMessage = "契約者_肩書は５０文字以内でお願いします")]
            [Display(Name = "契約者_肩書")]
            public string? k_katagaki { get; set; }                   //契約者_肩書

            [StringLength(50, ErrorMessage = "被保険者_屋号は５０文字以内でお願いします")]
            [Display(Name = "被保険者_屋号")]
            public string? h_yago { get; set; }                       //被保険者_屋号

            [StringLength(50, ErrorMessage = "被保険者_肩書は５０文字以内でお願いします")]
            [Display(Name = "被保険者_肩書")]
            public string? h_katagaki { get; set; }                   //被保険者_肩書

            [Display(Name = "署名捺印")]
            public bool shomei { get; set; }                        //署名捺印

            [Display(Name = "意向確認")]
            public bool ikokakunin { get; set; }                    //意向確認

            [DataType(DataType.Date)]
            [Display(Name = "保険料領収日")]
            public DateTime hokenryo_ryoshubi { get; set; }         //保険料領収日

            [Display(Name = "保険料領収額")]
            public int hokenryo_ryoshugaku { get; set; }            //保険料領収額

            [Required]
            [Display(Name = "有効状態")]
            public int yukojotai { get; set; }                      //有効状態

            [Required]
            [Display(Name = @"申込状況")]
            public int moshikomijokyo { get; set; }                 //申込状況

            [Display(Name = "お客さま専用ページ")]
            public bool customer_page { get; set; }                 //お客さま専用ページ

            [StringLength(50, ErrorMessage = "お客さま専用ページIDは５０文字以内でお願いします")]
            [Display(Name = "お客さま専用ページID")]
            public string? customer_id { get; set; }                //お客さま専用ページID

            [StringLength(10, ErrorMessage = "お客さまパスワードは１０文字以内でお願いします")]
            [Display(Name = "お客さまパスワード")]
            public string? customer_pass { get; set; }              //お客さまパスワード

            [DataType(DataType.Date)]
            [Display(Name = "お客さまパスワード変更日")]
            public DateTime customer_pass_day { get; set; }         //お客さまパスワード変更日

            [Required]
            [Display(Name = "入力者区分")]
            public int inputter_kbn { get; set; }                   //入力者区分

            [DataType(DataType.Date)]
            [Display(Name = "契約証兼領収証_発行日")]
            public DateTime keiyakusho_hakkobi { get; set; }        //契約証兼領収証_発行日

            [Required]
            [Display(Name = "発券証券")]
            public int hakkenshoken { get; set; }                   //発券証券

            [Required]
            [Display(Name = "保険料取引区分")]
            public int hokenryotorihiki_kbn { get; set; }           //保険料取引区分

            [Required]
            [Display(Name = "異動事由")]
            public int idojiyu { get; set; }                        //異動事由

            [Required]
            [Display(Name = "契約状況")]
            public int keiyakujokyo { get; set; }                   //契約状況

            [DataType(DataType.Date)]
            [Display(Name = "契約日")]
            public DateTime keiyakubi { get; set; }                 //契約日

            [DataType(DataType.Date)]
            [Display(Name = "回収日")]
            public DateTime kaishubi { get; set; }                  //回収日

            [Display(Name = "旧契約キー")]
            public int old_keiyaku_key { get; set; }                //旧契約キー

            [Display(Name = "最新フラグ")]
            public bool saishin_flg { get; set; }                   //最新フラグ

            [DataType(DataType.Date)]
            [Display(Name = "満期年月")]
            public DateTime manki_nengetsu { get; set; }            //満期年月

            [Required]
            [Display(Name = "払込票送付区分")]
            public int haraikomihyo_kbn { get; set; }               //払込票送付区分

            [Display(Name = "戻り便")]
            public bool modoribin { get; set; }                     //戻り便

            [Display(Name = "一時保存")]
            public bool ichijihozon { get; set; }                   //一時保存

            [DataType(DataType.Date)]
            [Display(Name = "確定日")]
            public DateTime kakuteibi { get; set; }                 //確定日

            [DataType(DataType.Date)]
            [Display(Name = "成立日")]
            public DateTime seiritsubi { get; set; }                //成立日

            [Display(Name = "管理外異動")]
            public string? kanrigaiido { get; set; }                //管理外異動

            [Required]
            [Display(Name = @"申込書送付キー")]
            public int t_moshikomisho_id { get; set; }              //申込書送付キー

            [Display(Name = "更新状態")]
            public int update_kbn { get; set; }                     //更新状態

            [DataType(DataType.Date)]
            [Display(Name = "更新処理日")]
            public DateTime update_day { get; set; }                //更新処理日

            [Required]
            [Display(Name = "保険料")]
            public int hokenryo { get; set; }                       //保険料

            [Required]
            [Display(Name = "代理店手数料率")]
            public float dairiten_ritsu { get; set; }               //代理店手数料率

            [Required]
            [Display(Name = "成立状況")]
            public int seiritsujokyo { get; set; }                  //成立状況

            [Display(Name = "入金キー")]
            public int t_nyukin_id { get; set; }                    //入金キー

            [DataType(DataType.Date)]
            [Display(Name = @"申込日")]
            public DateTime moshikomibi { get; set; }               //申込日

            [StringLength(50, ErrorMessage = "特約は５０文字以内でお願いします")]
            [Display(Name = "特約")]
            public string? tokuyaku2 { get; set; }                  //特約

            [Display(Name = "不備理由")]
            public string? fubiriyu { get; set; }                   //不備理由

            [Display(Name = "削除フラグ")]
            public bool del_flg { get; set; }                       //削除フラグ

            [StringLength(50, ErrorMessage = "支払先情報は５０文字以内でお願いします")]
            [Display(Name = "支払先情報")]
            public string? shiharaisaki { get; set; }               //支払先情報

            [StringLength(50, ErrorMessage = "金融機関は５０文字以内でお願いします")]
            [Display(Name = "金融機関")]
            public string? bank { get; set; }                       //金融機関

            [StringLength(50, ErrorMessage = "金融機関_支店は５０文字以内でお願いします")]
            [Display(Name = "金融機関_支店")]
            public string? bank_shiten { get; set; }                //金融機関_支店

            [StringLength(50, ErrorMessage = "口座種目は５０文字以内でお願いします")]
            [Display(Name = "口座種目")]
            public string? bank_account_type { get; set; }          //口座種目

            [StringLength(50, ErrorMessage = "通帳記号は５０文字以内でお願いします")]
            [Display(Name = "通帳記号")]
            public string? passbook_symbol { get; set; }            //通帳記号

            [StringLength(10, ErrorMessage = "口座番号は１０文字以内でお願いします")]
            [Display(Name = "口座番号")]
            public string? bank_account_no { get; set; }            //口座番号

            [StringLength(50, ErrorMessage = "口座名義人は５０文字以内でお願いします")]
            [Display(Name = "口座名義人")]
            public string? bank_account_holder { get; set; }        //口座名義人

            [StringLength(50, ErrorMessage = "口座名義カナは５０文字以内でお願いします")]
            [Display(Name = "口座名義カナ")]
            public string? bank_account_holder_kana { get; set; }   //口座名義カナ

            [Display(Name = "返戻金")]
            public int henreikin { get; set; }                      //返戻金

            [DataType(DataType.Date)]
            [Display(Name = "返戻金登録日")]
            public DateTime henreikin_day { get; set; }             //返戻金登録日

            [DataType(DataType.Date)]
            [Display(Name = "更新年月")]
            public DateTime koshin_nengetsu { get; set; }           //更新年月

            [Required]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM}")]
            [Display(Name = @"送付予定月")]
            public DateTime sofuyoteizuki { get; set; }             //送付予定月

            [Display(Name = "手数料")]
            public int dairiten_tesuryo { get; set; }               //手数料

            [Display(Name = "正味保険料")]
            public int shomihokenryo { get; set; }                  //正味保険料

            [Display(Name = "請求キー")]
            public int t_seikyu_id { get; set; }                    //請求キー

            [Display(Name = "弥生フラグ")]
            public bool yayoi_flg { get; set; }                     //弥生フラグ

            [DataType(DataType.Date)]
            [Display(Name = "登録日")]
            public DateTime torokubi { get; set; }                  //登録日

            [Required]
            [Display(Name = "送付区分")]
            public int sofu_kbn { get; set; }                      //送付区分
        }

        //商品区分
        public string[] shohin_kbns = new string[1];

        //契約者区分
        public string[] keiyakusha_kbns = new string[1];

        //保険期間
        public string[] hokenkikans = new[] { "", "１年", "２年" };

        //商品キー
        public string[] m_shohin_ids = new string[1];

        //保証人区分
        public string[] hoshonin_kbns = new string[1];

        //手続依頼書発行
        public string[] tetsuzukiiraishohakko_kbns = new string[1];

        //集金方法
        public string[] shukinhohoes = new string[1];

        public async Task OnGetAsync()
        {
        }

        public void OnPost()
        {
            var pm = new Program(_context);
            string[] arr = pm.Dairiten_Get(User.Identity.GetUserId());
            d_no = arr[0];
            d_name = arr[1];
            bnin_key = arr[2];

            //商品区分
            int shohin_kbns_cnt = _context.m_master.Where(m => m.m_master_kbn_id == 7).Count();
            Array.Resize(ref shohin_kbns, shohin_kbns_cnt + 1);
            var masters1 = _context.m_master.Where(m => m.m_master_kbn_id == 7).ToArray();
            for (int i = 0; i < shohin_kbns_cnt + 1; i++)
            {
                if (i == 0)
                {
                    shohin_kbns[i] = "";
                }
                else
                {
                    shohin_kbns[i] = masters1[i - 1].item_name;
                }
            }

            //契約者区分
            int keiyakusha_kbns_cnt = _context.m_master.Where(m => m.m_master_kbn_id == 6).Count();
            Array.Resize(ref keiyakusha_kbns, keiyakusha_kbns_cnt + 1);
            var masters2 = _context.m_master.Where(m => m.m_master_kbn_id == 6).ToArray();
            for (int i = 0; i < keiyakusha_kbns_cnt + 1; i++)
            {
                if (i == 0)
                {
                    keiyakusha_kbns[i] = "";
                }
                else
                {
                    keiyakusha_kbns[i] = masters2[i - 1].item_name;
                }
            }

            //商品キー
            int m_shohin_ids_cnt = _context.m_shohin.Where(m => m.hokenkikan == 1).Count();//※選択された保険期間で商品を絞りたい
            Array.Resize(ref m_shohin_ids, m_shohin_ids_cnt + 1);
            var shohins = _context.m_shohin.Where(m => m.hokenkikan == 1).ToArray();
            for (int i = 0; i < m_shohin_ids_cnt + 1; i++)
            {
                if (i == 0)
                {
                    m_shohin_ids[i] = "";
                }
                else
                {
                    m_shohin_ids[i] = shohins[i - 1].shohin_name;
                }
            }

            //保証人区分
            int hoshonin_kbns_cnt = _context.m_master.Where(m => m.m_master_kbn_id == 10).Count();
            Array.Resize(ref hoshonin_kbns, hoshonin_kbns_cnt + 1);
            var masters3 = _context.m_master.Where(m => m.m_master_kbn_id == 10).ToArray();
            for (int i = 0; i < hoshonin_kbns_cnt + 1; i++)
            {
                if (i == 0)
                {
                    hoshonin_kbns[i] = "";
                }
                else
                {
                    hoshonin_kbns[i] = masters3[i - 1].item_name;
                }
            }

            //手続依頼書発行
            int tetsuzukiiraishohakko_kbns_cnt = _context.m_master.Where(m => m.m_master_kbn_id == 12).Count();
            Array.Resize(ref tetsuzukiiraishohakko_kbns, tetsuzukiiraishohakko_kbns_cnt);
            var masters4 = _context.m_master.Where(m => m.m_master_kbn_id == 12).ToArray();
            for (int i = 0; i < tetsuzukiiraishohakko_kbns_cnt; i++)
            {
                tetsuzukiiraishohakko_kbns[i] = masters4[i].item_name;
            }

            //集金方法
            int shukinhohoes_cnt = _context.m_master.Where(m => m.m_master_kbn_id == 13).Count();
            Array.Resize(ref shukinhohoes, shukinhohoes_cnt);
            var masters5 = _context.m_master.Where(m => m.m_master_kbn_id == 13).ToArray();
            for (int i = 0; i < shukinhohoes_cnt; i++)
            {
                shukinhohoes[i] = masters5[i].item_name;
            }

            //契約者_戸建て
            Boolean k_kodate = false;
            if (Input.k_kodate == "" || Input.k_kodate == null || Input.k_kodate == "false")
            {
                k_kodate = false;
            }
            else
            {
                k_kodate = true;
            }

            //目的地_戸建て
            Boolean h_kodate = false;
            if (Input.h_kodate == "" || Input.h_kodate == null || Input.h_kodate == "false")
            {
                h_kodate = false;
            }
            else
            {
                h_kodate = true;
            }

            // 契約タイプのプルダウンで選択した商品のIDを取得
            string shohin_selected = (string)Request.Form["shohin"];
            int shohin_num = -1;
            if (!string.IsNullOrEmpty(shohin_selected))
            {
                foreach (var shohin in _context.m_shohin)
                {
                    if (shohin_selected.Equals(shohin.shohin_name))
                    {
                        shohin_num = shohin.id;
                        break;
                    }
                }
            }

            // 保証人区分のプルダウンで選択のitem_noを取得
            string hoshonin_selected = (string)Request.Form["hoshonin_kbn"];
            int hoshonin_num = -1;
            if (!string.IsNullOrEmpty(hoshonin_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 10))
                {
                    if (hoshonin_selected.Equals(master.item_name))
                    {
                        hoshonin_num = master.item_no;
                        break;
                    }
                }
            }

            // 手続依頼書発行のプルダウンで選択のitem_noを取得
            string tetsuzukiiraishohakko_selected = (string)Request.Form["tetsuzukiiraishohakko_kbn"];
            int tetsuzukiiraishohakko_num = -1;
            if (!string.IsNullOrEmpty(tetsuzukiiraishohakko_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 12))
                {
                    if (tetsuzukiiraishohakko_selected.Equals(master.item_name))
                    {
                        tetsuzukiiraishohakko_num = master.item_no;
                        break;
                    }
                }
            }

            // 集金方法のプルダウンで選択のitem_noを取得
            string shukinhoho_selected = (string)Request.Form["shukinhoho"];
            int shukinhoho_num = -1;
            if (!string.IsNullOrEmpty(shukinhoho_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 13))
                {
                    if (shukinhoho_selected.Equals(master.item_name))
                    {
                        shukinhoho_num = master.item_no;
                        break;
                    }
                }
            }

            keiyaku = new t_keiyaku
            {
                m_dairiten_id = Input.m_dairiten_id,
                employee_key = Input.employee_key,
                shoken_no = Input.shoken_no,
                old_shoken_no = Input.old_shoken_no,
                rireki_no = Input.rireki_no,
                keijozuki = Input.keijozuki,
                uketsuke_kbn = Input.uketsuke_kbn,
                shohin_kbn = Array.IndexOf(shohin_kbns, Input.shohin_kbn),
                keiyakusha_kbn = Array.IndexOf(keiyakusha_kbns, Input.keiyakusha_kbn),
                moshikomisho_day = Input.moshikomisho_day,
                yoho = Input.yoho,
                hokenshiki = Input.hokenshiki,
                hokenshuki = Input.hokenshuki,
                hokenkikan = Array.IndexOf(hokenkikans, Input.hokenkikan),
                tokuyaku1 = Input.tokuyaku1,
                m_shohin_id = Array.IndexOf(m_shohin_ids, Input.m_shohin_id),
                k_tel = Input.k_tel,
                k_mobile = Input.k_mobile,
                k_kodate = k_kodate,
                k_zip = Input.k_zip,
                k_address1 = Input.k_address1,
                k_address2 = Input.k_address2,
                k_address3 = Input.k_address3,
                k_address4 = Input.k_address4,
                k_kana = Input.k_kana,
                k_name = Input.k_name,
                k_birth = Input.k_birth,
                k_mail = Input.k_mail,
                hoshonin_kbn = Array.IndexOf(hoshonin_kbns, Input.hoshonin_kbn),
                hoshonin_kbn_other = Input.hoshonin_kbn_other,
                fukusu_tokuyaku = Input.fukusu_tokuyaku,
                k_onaji = Input.k_onaji,
                h_kodate = h_kodate,
                h_zip = Input.h_zip,
                h_address1 = Input.h_address1,
                h_address2 = Input.h_address2,
                h_address3 = Input.h_address3,
                h_address4 = Input.h_address4,
                hihokensha_kbn = Input.hihokensha_kbn,
                h_kana = Input.h_kana,
                h_name = Input.h_name,
                h_birth = Input.h_birth,
                tetsuzukiiraishohakko_kbn = Array.IndexOf(tetsuzukiiraishohakko_kbns, Input.tetsuzukiiraishohakko_kbn),
                shukinhoho = Array.IndexOf(shukinhohoes, Input.shukinhoho),
                other_hoken = Input.other_hoken,
                other_hoken_umu = Input.other_hoken_umu,
                other_hoken_company = Input.other_hoken_company,
                other_hoken_shurui = Input.other_hoken_shurui,
                other_hoken_manki = Input.other_hoken_manki,
                other_hoken_money = Input.other_hoken_money,
                hokenkeiyakusho_kbn = Input.hokenkeiyakusho_kbn,
                other_code1 = Input.other_code1,
                other_code2 = Input.other_code2,
                other_code3 = Input.other_code3,
                other_tokkijiko = Input.other_tokkijiko,
                k_hojinkeitai = Input.k_hojinkeitai,
                k_hojinkeitai_other = Input.k_hojinkeitai_other,
                k_hojinkeitai_ichi = Input.k_hojinkeitai_ichi,
                k_hojinmei_kana = Input.k_hojinmei_kana,
                k_hojinmei_kanji = Input.k_hojinmei_kanji,
                shiten = Input.shiten,
                daihyosha_yakushoku = Input.daihyosha_yakushoku,
                daihyosha_name = Input.daihyosha_name,
                hojin_tokuyaku = Input.hojin_tokuyaku,
                h_hojinkeitai = Input.h_hojinkeitai,
                h_hojinkeitai_other = Input.h_hojinkeitai_other,
                h_hojinkeitai_ichi = Input.h_hojinkeitai_ichi,
                h_hojinmei_kana = Input.h_hojinmei_kana,
                h_hojinmei_kanji = Input.h_hojinmei_kanji,
                gyoshu = Input.gyoshu,
                gyoshu_sumi = Input.gyoshu_sumi,
                senyumenseki = Input.senyumenseki,
                k_floor = Input.k_floor,
                h_floor = Input.h_floor,
                k_yago = Input.k_yago,
                k_katagaki = Input.k_katagaki,
                h_yago = Input.h_yago,
                h_katagaki = Input.h_katagaki,
                shomei = Input.shomei,
                ikokakunin = Input.ikokakunin,
                hokenryo_ryoshubi = Input.hokenryo_ryoshubi,
                hokenryo_ryoshugaku = Input.hokenryo_ryoshugaku,
                yukojotai = Input.yukojotai,
                moshikomijokyo = Input.moshikomijokyo,
                customer_page = Input.customer_page,
                customer_id = Input.customer_id,
                customer_pass = Input.customer_pass,
                customer_pass_day = Input.customer_pass_day,
                inputter_kbn = Input.inputter_kbn,
                keiyakusho_hakkobi = Input.keiyakusho_hakkobi,
                hakkenshoken = Input.hakkenshoken,
                hokenryotorihiki_kbn = Input.hokenryotorihiki_kbn,
                idojiyu = Input.idojiyu,
                keiyakujokyo = Input.keiyakujokyo,
                keiyakubi = Input.keiyakubi,
                kaishubi = Input.kaishubi,
                old_keiyaku_key = Input.old_keiyaku_key,
                saishin_flg = Input.saishin_flg,
                manki_nengetsu = Input.manki_nengetsu,
                haraikomihyo_kbn = Input.haraikomihyo_kbn,
                modoribin = Input.modoribin,
                ichijihozon = Input.ichijihozon,
                kakuteibi = Input.kakuteibi,
                seiritsubi = Input.seiritsubi,
                kanrigaiido = Input.kanrigaiido,
                t_moshikomisho_id = Input.t_moshikomisho_id,
                update_kbn = Input.update_kbn,
                update_day = Input.update_day,
                hokenryo = Input.hokenryo,
                dairiten_ritsu = Input.dairiten_ritsu,
                seiritsujokyo = Input.seiritsujokyo,
                t_nyukin_id = Input.t_nyukin_id,
                moshikomibi = Input.moshikomibi,
                tokuyaku2 = Input.tokuyaku2,
                fubiriyu = Input.fubiriyu,
                del_flg = Input.del_flg,
                shiharaisaki = Input.shiharaisaki,
                bank = Input.bank,
                bank_shiten = Input.bank_shiten,
                bank_account_type = Input.bank_account_type,
                passbook_symbol = Input.passbook_symbol,
                bank_account_no = Input.bank_account_no,
                bank_account_holder = Input.bank_account_holder,
                bank_account_holder_kana = Input.bank_account_holder_kana,
                henreikin = Input.henreikin,
                henreikin_day = Input.henreikin_day,
                koshin_nengetsu = Input.koshin_nengetsu,
                sofuyoteizuki = Input.sofuyoteizuki,
                dairiten_tesuryo = Input.dairiten_tesuryo,
                shomihokenryo = Input.shomihokenryo,
                t_seikyu_id = Input.t_seikyu_id,
                yayoi_flg = Input.yayoi_flg,
                torokubi = Input.torokubi,
            };
        }
    }
}
