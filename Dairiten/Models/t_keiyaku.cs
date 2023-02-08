using System.ComponentModel.DataAnnotations;

namespace Dairiten.Models
{
    public class t_keiyaku
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
        public string shoken_no { get; set; } = null!;                  //証券番号

        [MinLength(10, ErrorMessage = "証券番号は１０桁でお願いします")]
        [StringLength(10, ErrorMessage = "証券番号は１０桁でお願いします")]
        [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "半角英数字のみ入力できます。")]
        [Display(Name = "旧証券番号")]
        public string old_shoken_no { get; set; } = null!;              //旧証券番号

        [Required]
        [StringLength(10)]
        [Display(Name = "履歴番号")]
        public string rireki_no { get; set; } = null!;                  //履歴番号

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "計上月")]
        public DateTime keijozuki { get; set; }                 //計上月

        [Required]
        [Display(Name = "受付区分")]
        public int uketsuke_kbn { get; set; }                   //受付区分

        [Required]
        [Display(Name = "商品区分")]
        public int shohin_kbn { get; set; }                     //商品区分

        [Required]
        [Display(Name = "契約者区分")]
        public int keiyakusha_kbn { get; set; }                 //契約者区分

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "申込書作成日")]
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
        public int hokenkikan { get; set; }                     //保険期間

        [Display(Name = "住宅内入居者死亡費用特約")]
        public bool tokuyaku1 { get; set; }                     //住宅内入居者死亡費用特約

        [Required]
        [Display(Name = "商品キー")]
        public int m_shohin_id { get; set; }                    //商品キー

        [Phone]
        [StringLength(50, ErrorMessage = "契約者連絡先は５０文字以内でお願いします")]
        [Display(Name = "契約者連絡先")]
        public string? k_tel { get; set; }                      //契約者連絡先

        [Phone]
        [StringLength(50, ErrorMessage = "契約者携帯は５０文字以内でお願いします")]
        [Display(Name = "契約者携帯")]
        public string? k_mobile { get; set; }                   //契約者携帯

        [Display(Name = "契約者_戸建て")]
        public bool k_kodate { get; set; }                      //契約者_戸建て

        [Required]
        [StringLength(7, ErrorMessage = "郵便番号はハイフン（－）なしの数字７桁でお願いします")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        [Display(Name = "契約者_郵便番号")]
        public string k_zip { get; set; } = null!;                      //契約者_郵便番号

        [Required]
        [StringLength(55, ErrorMessage = "住所（都道府県市区町村）は５５文字以内でお願いします")]
        [Display(Name = "契約者_住所（都道府県市区町村）")]
        public string k_address1 { get; set; } = null!;                 //契約者_住所（都道府県市区町村）

        [StringLength(25, ErrorMessage = "住所（丁目番地）は２５文字以内でお願いします")]
        [Display(Name = "契約者_住所（丁目番地）")]
        public string k_address2 { get; set; } = null!;                 //契約者_住所（丁目番地）

        [StringLength(50, ErrorMessage = "住所（建物名）は５０文字以内でお願いします")]
        [Display(Name = "契約者_住所（建物名）")]
        public string? k_address3 { get; set; }                 //契約者_住所（建物名）

        [StringLength(25, ErrorMessage = "住所（号室）は２５文字以内でお願いします")]
        [Display(Name = "契約者_住所（号室）")]
        public string? k_address4 { get; set; }                 //契約者_住所（号室）

        [Required]
        [StringLength(50, ErrorMessage = "契約者名カナは５０文字以内でお願いします")]
        [Display(Name = "契約者名カナ")]
        public string k_kana { get; set; } = null!;                      //契約者名カナ

        [Required]
        [StringLength(50, ErrorMessage = "契約者名は５０文字以内でお願いします")]
        [Display(Name = "契約者名")]
        public string k_name { get; set; } = null!;                      //契約者名

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "契約者生年月日")]
        public DateTime k_birth { get; set; }                  //契約者生年月日

        [EmailAddress]
        [Display(Name = "契約者_メールアドレス")]
        public string? k_mail { get; set; }                     //契約者_メールアドレス

        [Display(Name = "保証人区分")]
        public int hoshonin_kbn { get; set; }                   //保証人区分

        [StringLength(100, ErrorMessage = "保証人区分その他は１００文字以内でお願いします")]
        [Display(Name = "保証人区分その他")]
        public string? hoshonin_kbn_other { get; set; }         //保証人区分その他

        [Display(Name = "複数契約特約")]
        public bool fukusu_tokuyaku { get; set; }               //複数契約特約

        [Display(Name = "契約者と同じ")]
        public bool k_onaji { get; set; }                       //契約者と同じ

        [Display(Name = "目的地_戸建て")]
        public bool h_kodate { get; set; }                      //目的地_戸建て

        [Required]
        [StringLength(7, ErrorMessage = "郵便番号はハイフン（－）なしの数字７桁でお願いします")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        [Display(Name = "目的地_郵便番号")]
        public string h_zip { get; set; } = null!;                      //目的地_郵便番号

        [Required]
        [StringLength(55, ErrorMessage = "住所（都道府県市区町村）は５５文字以内でお願いします")]
        [Display(Name = "目的地_住所（都道府県市区町村）")]
        public string h_address1 { get; set; } = null!;                 //目的地_住所（都道府県市区町村）

        [StringLength(25, ErrorMessage = "住所（丁目番地）は２５文字以内でお願いします")]
        [Display(Name = "目的地_住所（丁目番地）")]
        public string h_address2 { get; set; } = null!;                //目的地_住所（丁目番地）

        [StringLength(50, ErrorMessage = "住所（建物名）は５０文字以内でお願いします")]
        [Display(Name = "目的地_住所（建物名）")]
        public string? h_address3 { get; set; }                //目的地_住所（建物名）

        [StringLength(25, ErrorMessage = "住所（号室）は２５文字以内でお願いします")]
        [Display(Name = "目的地_住所（号室）")]
        public string? h_address4 { get; set; }                 //目的地_住所（号室）

        [Required]
        [Display(Name = "被保険者区分")]
        public int hihokensha_kbn { get; set; }                 //被保険者区分

        [Required]
        [StringLength(50, ErrorMessage = "被保険者名カナは５０文字以内でお願いします")]
        [Display(Name = "被保険者名カナ")]
        public string h_kana { get; set; } = null!;                      //被保険者名カナ

        [Required]
        [StringLength(50, ErrorMessage = "被保険者名は５０文字以内でお願いします")]
        [Display(Name = "被保険者名")]
        public string h_name { get; set; } = null!;                      //被保険者名

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "被保険者生年月日")]
        public DateTime h_birth { get; set; }                   //被保険者生年月日

        [Required]
        [Display(Name = "手続依頼書発行区分")]
        public int tetsuzukiiraishohakko_kbn { get; set; }      //手続依頼書発行区分

        [Required]
        [Display(Name = "集金方法")]
        public int shukinhoho { get; set; }                     //集金方法

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
        public string k_hojinmei_kana { get; set; } = null!;             //契約者_法人名_カナ

        [Required]
        [StringLength(100, ErrorMessage = "契約者_法人名_漢字は１００文字以内でお願いします")]
        [Display(Name = "契約者_法人名_漢字")]
        public string k_hojinmei_kanji { get; set; } = null!;            //契約者_法人名_漢字

        [StringLength(100, ErrorMessage = "支店支社営業所等は１００文字以内でお願いします")]
        [Display(Name = "支店支社営業所等")]
        public string? shiten { get; set; }                     //支店支社営業所等

        [Required]
        [StringLength(100, ErrorMessage = "代表者_役職は１００文字以内でお願いします")]
        [Display(Name = "代表者_役職")]
        public string daihyosha_yakushoku { get; set; } = null!;         //代表者_役職

        [Required]
        [StringLength(50, ErrorMessage = "代表者名は５０文字以内でお願いします")]
        [Display(Name = "代表者名")]
        public string daihyosha_name { get; set; } = null!;               //代表者名

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
        public string h_hojinmei_kana { get; set; } = null!;             //被保険者_法人名_カナ

        [Required]
        [StringLength(100, ErrorMessage = "被保険者_法人名_漢字は１００文字以内でお願いします")]
        [Display(Name = "被保険者_法人名_漢字")]
        public string h_hojinmei_kanji { get; set; } = null!;            //被保険者_法人名_漢字

        [Required]
        [StringLength(100, ErrorMessage = "業種は１００文字以内でお願いします")]
        [Display(Name = "業種")]
        public string gyoshu { get; set; } = null!;                      //業種

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
        [Display(Name = "申込状況")]
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
        [Display(Name = "申込書送付キー")]
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
        [Display(Name = "申込日")]
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
        [Display(Name = "送付予定月")]
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
}
