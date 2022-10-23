using Dairiten.Models;
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

        [BindProperty]
        public KeiyakuKakunin k_kakunin { get; set; }

        public class InputModel
        {
            [Display(Name = "Œ_–ñƒL[")]
            public int Id { get; set; }                             //Œ_–ñƒL[

            [Required]
            [Display(Name = "‘ã—“XƒL[")]
            public int m_dairiten_id { get; set; }                  //‘ã—“XƒL[

            [Required]
            [Display(Name = "•åWlƒL[")]
            public int employee_key { get; set; }                   //•åWlƒL[

            [Required]
            [MinLength(10, ErrorMessage = "ØŒ””Ô†‚Í‚P‚OŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [StringLength(10, ErrorMessage = "ØŒ””Ô†‚Í‚P‚OŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "”¼Šp‰p”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·B")]
            [Display(Name = "ØŒ””Ô†")]
            public string shoken_no { get; set; }                  //ØŒ””Ô†

            [MinLength(10, ErrorMessage = "ØŒ””Ô†‚Í‚P‚OŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [StringLength(10, ErrorMessage = "ØŒ””Ô†‚Í‚P‚OŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "”¼Šp‰p”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·B")]
            [Display(Name = "‹ŒØŒ””Ô†")]
            public string old_shoken_no { get; set; }              //‹ŒØŒ””Ô†

            [Required]
            [StringLength(10)]
            [Display(Name = "—š—ğ”Ô†")]
            public string rireki_no { get; set; }                  //—š—ğ”Ô†

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "ŒvãŒ")]
            public DateTime keijozuki { get; set; }                 //ŒvãŒ

            [Required]
            [Display(Name = "ó•t‹æ•ª")]
            public int uketsuke_kbn { get; set; }                   //ó•t‹æ•ª

            [Required]
            [Display(Name = "¤•i‹æ•ª")]
            public int shohin_kbn { get; set; }                     //¤•i‹æ•ª

            [Required]
            [Display(Name = "Œ_–ñÒ‹æ•ª")]
            public int keiyakusha_kbn { get; set; }                 //Œ_–ñÒ‹æ•ª

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "\‘ì¬“ú")]
            public DateTime moshikomisho_day { get; set; }          //\‘ì¬“ú

            [Required]
            [Display(Name = "—p–@")]
            public int yoho { get; set; }                           //—p–@

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "•ÛŒ¯nŠú")]
            public DateTime hokenshiki { get; set; }                //•ÛŒ¯nŠú

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "•ÛŒ¯IŠú")]
            public DateTime hokenshuki { get; set; }                //•ÛŒ¯IŠú

            [Required]
            [Display(Name = "•ÛŒ¯ŠúŠÔ")]
            public int hokenkikan { get; set; }                     //•ÛŒ¯ŠúŠÔ

            [Display(Name = "Z‘î“à“ü‹Ò€–S”ï—p“Á–ñ")]
            public bool tokuyaku1 { get; set; }                     //Z‘î“à“ü‹Ò€–S”ï—p“Á–ñ

            [Required]
            [Display(Name = "¤•iƒL[")]
            public int m_shohin_id { get; set; }                    //¤•iƒL[

            [Phone]
            [StringLength(50, ErrorMessage = "Œ_–ñÒ˜A—æ‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ˜A—æ")]
            public string? k_tel { get; set; }                      //Œ_–ñÒ˜A—æ

            [Phone]
            [StringLength(50, ErrorMessage = "Œ_–ñÒŒg‘Ñ‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒŒg‘Ñ")]
            public string? k_mobile { get; set; }                   //Œ_–ñÒŒg‘Ñ

            [Display(Name = "Œ_–ñÒ_ŒËŒš‚Ä")]
            public bool k_kodate { get; set; }                      //Œ_–ñÒ_ŒËŒš‚Ä

            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_•¨Œ”Ô†")]
            public string? k_bukken_no { get; set; }                //Œ_–ñÒ_•¨Œ”Ô†

            [Required]
            [StringLength(7, ErrorMessage = "—X•Ö”Ô†‚ÍƒnƒCƒtƒ“i|j‚È‚µ‚Ì”š‚VŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_—X•Ö”Ô†")]
            public string k_zip { get; set; }                      //Œ_–ñÒ_—X•Ö”Ô†

            [Required]
            [StringLength(55, ErrorMessage = "ZŠi“s“¹•{Œ§s‹æ’¬‘ºj‚Í‚T‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_ZŠi“s“¹•{Œ§s‹æ’¬‘ºj")]
            public string k_address1 { get; set; }                 //Œ_–ñÒ_ZŠi“s“¹•{Œ§s‹æ’¬‘ºj

            [StringLength(25, ErrorMessage = "ZŠi’š–Ú”Ô’nj‚Í‚Q‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_ZŠi’š–Ú”Ô’nj")]
            public string k_address2 { get; set; }                 //Œ_–ñÒ_ZŠi’š–Ú”Ô’nj

            [StringLength(50, ErrorMessage = "ZŠiŒš•¨–¼j‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_ZŠiŒš•¨–¼j")]
            public string? k_address3 { get; set; }                 //Œ_–ñÒ_ZŠiŒš•¨–¼j

            [StringLength(25, ErrorMessage = "ZŠi†ºj‚Í‚Q‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_ZŠi†ºj")]
            public string? k_address4 { get; set; }                 //Œ_–ñÒ_ZŠi†ºj

            [Required]
            [StringLength(50, ErrorMessage = "Œ_–ñÒ–¼_ƒZƒC‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ–¼_ƒZƒC")]
            public string k_sei_kana { get; set; }                 //Œ_–ñÒ–¼_ƒZƒC

            [Required]
            [StringLength(50, ErrorMessage = "Œ_–ñÒ–¼_ƒƒC‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ–¼_ƒƒC")]
            public string k_mei_kana { get; set; }                 //Œ_–ñÒ–¼_ƒƒC

            [Required]
            [StringLength(50, ErrorMessage = "Œ_–ñÒ–¼_©‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ–¼_©")]
            public string k_sei { get; set; }                      //Œ_–ñÒ–¼_©

            [Required]
            [StringLength(50, ErrorMessage = "Œ_–ñÒ–¼_–¼‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ–¼_–¼")]
            public string k_mei { get; set; }                      //Œ_–ñÒ–¼_–¼

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Œ_–ñÒ¶”NŒ“ú")]
            public DateTime k_birth { get; set; }                  //Œ_–ñÒ¶”NŒ“ú

            [EmailAddress]
            [Display(Name = "Œ_–ñÒ_ƒ[ƒ‹ƒAƒhƒŒƒX")]
            public string? k_mail { get; set; }                     //Œ_–ñÒ_ƒ[ƒ‹ƒAƒhƒŒƒX

            [Display(Name = "•ÛØl‹æ•ª")]
            public int hoshonin_kbn { get; set; }                   //•ÛØl‹æ•ª

            [StringLength(100, ErrorMessage = "•ÛØl‹æ•ª‚»‚Ì‘¼‚Í‚P‚O‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "•ÛØl‹æ•ª‚»‚Ì‘¼")]
            public string? hoshonin_kbn_other { get; set; }         //•ÛØl‹æ•ª‚»‚Ì‘¼

            [Display(Name = "•¡”Œ_–ñ“Á–ñ")]
            public bool fukusu_tokuyaku { get; set; }               //•¡”Œ_–ñ“Á–ñ

            [Display(Name = "Œ_–ñÒ‚Æ“¯‚¶")]
            public bool k_onaji { get; set; }                       //Œ_–ñÒ‚Æ“¯‚¶

            [Display(Name = "–Ú“I’n_ŒËŒš‚Ä")]
            public bool h_kodate { get; set; }                      //–Ú“I’n_ŒËŒš‚Ä

            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·")]
            [Display(Name = "–Ú“I’n_•¨Œ”Ô†")]
            public string? h_bukken_no { get; set; }                //–Ú“I’n_•¨Œ”Ô†

            [Required]
            [StringLength(7, ErrorMessage = "—X•Ö”Ô†‚ÍƒnƒCƒtƒ“i|j‚È‚µ‚Ì”š‚VŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”š‚Ì‚İ“ü—Í‚Å‚«‚Ü‚·")]
            [Display(Name = "–Ú“I’n_—X•Ö”Ô†")]
            public string h_zip { get; set; }                      //–Ú“I’n_—X•Ö”Ô†

            [Required]
            [StringLength(55, ErrorMessage = "ZŠi“s“¹•{Œ§s‹æ’¬‘ºj‚Í‚T‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "–Ú“I’n_ZŠi“s“¹•{Œ§s‹æ’¬‘ºj")]
            public string h_address1 { get; set; }                 //–Ú“I’n_ZŠi“s“¹•{Œ§s‹æ’¬‘ºj

            [StringLength(25, ErrorMessage = "ZŠi’š–Ú”Ô’nj‚Í‚Q‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "–Ú“I’n_ZŠi’š–Ú”Ô’nj")]
            public string h_address2 { get; set; }                 //–Ú“I’n_ZŠi’š–Ú”Ô’nj

            [StringLength(50, ErrorMessage = "ZŠiŒš•¨–¼j‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "–Ú“I’n_ZŠiŒš•¨–¼j")]
            public string? h_address3 { get; set; }                 //–Ú“I’n_ZŠiŒš•¨–¼j

            [StringLength(25, ErrorMessage = "ZŠi†ºj‚Í‚Q‚T•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "–Ú“I’n_ZŠi†ºj")]
            public string? h_address4 { get; set; }                 //–Ú“I’n_ZŠi†ºj

            [Required]
            [Display(Name = "”í•ÛŒ¯Ò‹æ•ª")]
            public int hihokensha_kbn { get; set; }                 //”í•ÛŒ¯Ò‹æ•ª

            [Required]
            [StringLength(50, ErrorMessage = "”í•ÛŒ¯Ò–¼_ƒZƒC‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯Ò–¼_ƒZƒC")]
            public string h_sei_kana { get; set; }                 //”í•ÛŒ¯Ò–¼_ƒZƒC

            [Required]
            [StringLength(50, ErrorMessage = "”í•ÛŒ¯Ò–¼_ƒƒC‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯Ò–¼_ƒƒC")]
            public string h_mei_kana { get; set; }                 //”í•ÛŒ¯Ò–¼_ƒƒC

            [Required]
            [StringLength(50, ErrorMessage = "”í•ÛŒ¯Ò–¼_©‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯Ò–¼_©")]
            public string h_sei { get; set; }                      //”í•ÛŒ¯Ò–¼_©

            [Required]
            [StringLength(50, ErrorMessage = "”í•ÛŒ¯Ò–¼_–¼‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯Ò–¼_–¼")]
            public string h_mei { get; set; }                      //”í•ÛŒ¯Ò–¼_–¼

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "”í•ÛŒ¯Ò¶”NŒ“ú")]
            public DateTime h_birth { get; set; }                   //”í•ÛŒ¯Ò¶”NŒ“ú

            [Required]
            [Display(Name = "è‘±ˆË—Š‘”­s‹æ•ª")]
            public int tetsuzukiiraishohakko_kbn { get; set; }      //è‘±ˆË—Š‘”­s‹æ•ª

            [Required]
            [Display(Name = "W‹à•û–@")]
            public int shukinhoho { get; set; }                     //W‹à•û–@

            [Display(Name = "‘¼‚Ì•ÛŒ¯")]
            public bool other_hoken { get; set; }                   //‘¼‚Ì•ÛŒ¯

            [Display(Name = "‘¼‚Ì•ÛŒ¯_“–Ğ—L–³")]
            public bool other_hoken_umu { get; set; }               //‘¼‚Ì•ÛŒ¯_“–Ğ—L–³

            [StringLength(50, ErrorMessage = "‘¼‚Ì•ÛŒ¯_•ÛŒ¯‰ïĞ–¼‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‘¼‚Ì•ÛŒ¯_•ÛŒ¯‰ïĞ–¼")]
            public string? other_hoken_company { get; set; }        //‘¼‚Ì•ÛŒ¯_•ÛŒ¯‰ïĞ–¼

            [StringLength(50, ErrorMessage = "‘¼‚Ì•ÛŒ¯_•ÛŒ¯í—Ş‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‘¼‚Ì•ÛŒ¯_•ÛŒ¯í—Ş")]
            public string? other_hoken_shurui { get; set; }         //‘¼‚Ì•ÛŒ¯_•ÛŒ¯í—Ş

            [DataType(DataType.Date)]
            [Display(Name = "‘¼‚Ì•ÛŒ¯_–Šú“ú")]
            public DateTime other_hoken_manki { get; set; }         //‘¼‚Ì•ÛŒ¯_–Šú“ú

            [Display(Name = "‘¼‚Ì•ÛŒ¯_•ÛŒ¯‹àŠz")]
            public int other_hoken_money { get; set; }              //‘¼‚Ì•ÛŒ¯_•ÛŒ¯‹àŠz

            [Display(Name = "•ÛŒ¯Œ_–ñØ—v")]
            public bool hokenkeiyakusho_kbn { get; set; }           //•ÛŒ¯Œ_–ñØ—v

            [Display(Name = "‚»‚Ì‘¼_ƒR[ƒh1")]
            public int other_code1 { get; set; }                    //‚»‚Ì‘¼_ƒR[ƒh1

            [Display(Name = "‚»‚Ì‘¼_ƒR[ƒh2")]
            public int other_code2 { get; set; }                    //‚»‚Ì‘¼_ƒR[ƒh2

            [Display(Name = "‚»‚Ì‘¼_ƒR[ƒh3")]
            public int other_code3 { get; set; }                    //‚»‚Ì‘¼_ƒR[ƒh3

            [StringLength(100, ErrorMessage = "‚»‚Ì‘¼_“Á‹L–€‚Í‚P‚O‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‚»‚Ì‘¼_“Á‹L–€")]
            public string? other_tokkijiko { get; set; }            //‚»‚Ì‘¼_“Á‹L–€

            [Required]
            [Display(Name = "Œ_–ñÒ_–@lŒ`‘Ô")]
            public int k_hojinkeitai { get; set; }                  //Œ_–ñÒ_–@lŒ`‘Ô

            [StringLength(50, ErrorMessage = "Œ_–ñÒ_–@lŒ`‘Ô‚»‚Ì‘¼‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_–@lŒ`‘Ô‚»‚Ì‘¼")]
            public string? k_hojinkeitai_other { get; set; }        //Œ_–ñÒ_–@lŒ`‘Ô‚»‚Ì‘¼

            [Required]
            [Display(Name = "Œ_–ñÒ_–@lŒ`‘ÔˆÊ’u")]
            public int k_hojinkeitai_ichi { get; set; }             //Œ_–ñÒ_–@lŒ`‘ÔˆÊ’u

            [Required]
            [StringLength(100, ErrorMessage = "Œ_–ñÒ_–@l–¼_ƒJƒi‚Í‚P‚O‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_–@l–¼_ƒJƒi")]
            public string k_hojinmei_kana { get; set; }             //Œ_–ñÒ_–@l–¼_ƒJƒi

            [Required]
            [StringLength(100, ErrorMessage = "Œ_–ñÒ_–@l–¼_Š¿š‚Í‚P‚O‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_–@l–¼_Š¿š")]
            public string k_hojinmei_kanji { get; set; }            //Œ_–ñÒ_–@l–¼_Š¿š

            [StringLength(100, ErrorMessage = "x“XxĞ‰c‹ÆŠ“™‚Í‚P‚O‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "x“XxĞ‰c‹ÆŠ“™")]
            public string? shiten { get; set; }                     //x“XxĞ‰c‹ÆŠ“™

            [Required]
            [StringLength(100, ErrorMessage = "‘ã•\Ò_–ğE‚Í‚P‚O‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‘ã•\Ò_–ğE")]
            public string daihyosha_yakushoku { get; set; }         //‘ã•\Ò_–ğE

            [Required]
            [StringLength(50, ErrorMessage = "‘ã•\Ò_©‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‘ã•\Ò_©")]
            public string daihyosha_sei { get; set; }               //‘ã•\Ò_©

            [Required]
            [StringLength(50, ErrorMessage = "‘ã•\Ò_–¼‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‘ã•\Ò_–¼")]
            public string daihyosha_mei { get; set; }               //‘ã•\Ò_–¼

            [Display(Name = "–@l“Á–ñ")]
            public bool hojin_tokuyaku { get; set; }                //–@l“Á–ñ

            [Required]
            [Display(Name = "”í•ÛŒ¯Ò_–@lŒ`‘Ô")]
            public int h_hojinkeitai { get; set; }                  //”í•ÛŒ¯Ò_–@lŒ`‘Ô

            [StringLength(50, ErrorMessage = "”í•ÛŒ¯Ò_–@lŒ`‘Ô‚»‚Ì‘¼‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯Ò_–@lŒ`‘Ô‚»‚Ì‘¼")]
            public string? h_hojinkeitai_other { get; set; }        //”í•ÛŒ¯Ò_–@lŒ`‘Ô‚»‚Ì‘¼

            [Required]
            [Display(Name = "”í•ÛŒ¯Ò_–@lŒ`‘ÔˆÊ’u")]
            public int h_hojinkeitai_ichi { get; set; }             //”í•ÛŒ¯Ò_–@lŒ`‘ÔˆÊ’u

            [Required]
            [StringLength(100, ErrorMessage = "”í•ÛŒ¯Ò_–@l–¼_ƒJƒi‚Í‚P‚O‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯Ò_–@l–¼_ƒJƒi")]
            public string h_hojinmei_kana { get; set; }             //”í•ÛŒ¯Ò_–@l–¼_ƒJƒi

            [Required]
            [StringLength(100, ErrorMessage = "”í•ÛŒ¯Ò_–@l–¼_Š¿š‚Í‚P‚O‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯Ò_–@l–¼_Š¿š")]
            public string h_hojinmei_kanji { get; set; }            //”í•ÛŒ¯Ò_–@l–¼_Š¿š

            [Required]
            [StringLength(100, ErrorMessage = "‹Æí‚Í‚P‚O‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‹Æí")]
            public string gyoshu { get; set; }                      //‹Æí

            [Display(Name = "‹ÆíŠm”FÏ‚İ")]
            public string? gyoshu_sumi { get; set; }                //‹ÆíŠm”FÏ‚İ

            [Required]
            [Display(Name = "ê—L–ÊÏ")]
            public int senyumenseki { get; set; }                   //ê—L–ÊÏ

            [Display(Name = "Œ_–ñÒ_ƒtƒƒA[Ø‚è")]
            public bool k_floor { get; set; }                       //Œ_–ñÒ_ƒtƒƒA[Ø‚è

            [Display(Name = "–Ú“I’n_ƒtƒƒA[Ø‚è")]
            public bool h_floor { get; set; }                       //–Ú“I’n_ƒtƒƒA[Ø‚è

            [StringLength(50, ErrorMessage = "Œ_–ñÒ_‰®†‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_‰®†")]
            public string? k_yago { get; set; }                       //Œ_–ñÒ_‰®†

            [StringLength(50, ErrorMessage = "Œ_–ñÒ_Œ¨‘‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñÒ_Œ¨‘")]
            public string? k_katagaki { get; set; }                   //Œ_–ñÒ_Œ¨‘

            [StringLength(50, ErrorMessage = "”í•ÛŒ¯Ò_‰®†‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯Ò_‰®†")]
            public string? h_yago { get; set; }                       //”í•ÛŒ¯Ò_‰®†

            [StringLength(50, ErrorMessage = "”í•ÛŒ¯Ò_Œ¨‘‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯Ò_Œ¨‘")]
            public string? h_katagaki { get; set; }                   //”í•ÛŒ¯Ò_Œ¨‘

            [Display(Name = "–¼“æˆó")]
            public bool shomei { get; set; }                        //–¼“æˆó

            [Display(Name = "ˆÓŒüŠm”F")]
            public bool ikokakunin { get; set; }                    //ˆÓŒüŠm”F

            [DataType(DataType.Date)]
            [Display(Name = "•ÛŒ¯—¿—Ìû“ú")]
            public DateTime hokenryo_ryoshubi { get; set; }         //•ÛŒ¯—¿—Ìû“ú

            [Display(Name = "•ÛŒ¯—¿—ÌûŠz")]
            public int hokenryo_ryoshugaku { get; set; }            //•ÛŒ¯—¿—ÌûŠz

            [Required]
            [Display(Name = "—LŒøó‘Ô")]
            public int yukojotai { get; set; }                      //—LŒøó‘Ô

            [Required]
            [Display(Name = "\ó‹µ")]
            public int moshikomijokyo { get; set; }                 //\ó‹µ

            [Display(Name = "‚¨‹q‚³‚Üê—pƒy[ƒW")]
            public bool customer_page { get; set; }                 //‚¨‹q‚³‚Üê—pƒy[ƒW

            [StringLength(50, ErrorMessage = "‚¨‹q‚³‚Üê—pƒy[ƒWID‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‚¨‹q‚³‚Üê—pƒy[ƒWID")]
            public string? customer_id { get; set; }                //‚¨‹q‚³‚Üê—pƒy[ƒWID

            [StringLength(10, ErrorMessage = "‚¨‹q‚³‚ÜƒpƒXƒ[ƒh‚Í‚P‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‚¨‹q‚³‚ÜƒpƒXƒ[ƒh")]
            public string? customer_pass { get; set; }              //‚¨‹q‚³‚ÜƒpƒXƒ[ƒh

            [DataType(DataType.Date)]
            [Display(Name = "‚¨‹q‚³‚ÜƒpƒXƒ[ƒh•ÏX“ú")]
            public DateTime customer_pass_day { get; set; }         //‚¨‹q‚³‚ÜƒpƒXƒ[ƒh•ÏX“ú

            [Required]
            [Display(Name = "“ü—ÍÒ‹æ•ª")]
            public int inputter_kbn { get; set; }                   //“ü—ÍÒ‹æ•ª

            [DataType(DataType.Date)]
            [Display(Name = "Œ_–ñØŒ“—ÌûØ_”­s“ú")]
            public DateTime keiyakusho_hakkobi { get; set; }        //Œ_–ñØŒ“—ÌûØ_”­s“ú

            [Required]
            [Display(Name = "”­Œ”ØŒ”")]
            public int hakkenshoken { get; set; }                   //”­Œ”ØŒ”

            [Required]
            [Display(Name = "•ÛŒ¯—¿æˆø‹æ•ª")]
            public int hokenryotorihiki_kbn { get; set; }           //•ÛŒ¯—¿æˆø‹æ•ª

            [Required]
            [Display(Name = "ˆÙ“®–—R")]
            public int idojiyu { get; set; }                        //ˆÙ“®–—R

            [Required]
            [Display(Name = "Œ_–ñó‹µ")]
            public int keiyakujokyo { get; set; }                   //Œ_–ñó‹µ

            [DataType(DataType.Date)]
            [Display(Name = "Œ_–ñ“ú")]
            public DateTime keiyakubi { get; set; }                 //Œ_–ñ“ú

            [DataType(DataType.Date)]
            [Display(Name = "‰ñû“ú")]
            public DateTime kaishubi { get; set; }                  //‰ñû“ú

            [Display(Name = "‹ŒŒ_–ñƒL[")]
            public int old_keiyaku_key { get; set; }                //‹ŒŒ_–ñƒL[

            [Display(Name = "ÅVƒtƒ‰ƒO")]
            public bool saishin_flg { get; set; }                   //ÅVƒtƒ‰ƒO

            [DataType(DataType.Date)]
            [Display(Name = "–Šú”NŒ")]
            public DateTime manki_nengetsu { get; set; }            //–Šú”NŒ

            [Required]
            [Display(Name = "•¥•[‘—•t‹æ•ª")]
            public int haraikomihyo_kbn { get; set; }               //•¥•[‘—•t‹æ•ª

            [Display(Name = "–ß‚è•Ö")]
            public bool modoribin { get; set; }                     //–ß‚è•Ö

            [Display(Name = "ˆê•Û‘¶")]
            public bool ichijihozon { get; set; }                   //ˆê•Û‘¶

            [DataType(DataType.Date)]
            [Display(Name = "Šm’è“ú")]
            public DateTime kakuteibi { get; set; }                 //Šm’è“ú

            [DataType(DataType.Date)]
            [Display(Name = "¬—§“ú")]
            public DateTime seiritsubi { get; set; }                //¬—§“ú

            [Display(Name = "ŠÇ—ŠOˆÙ“®")]
            public string? kanrigaiido { get; set; }                //ŠÇ—ŠOˆÙ“®

            [Required]
            [Display(Name = "\‘‘—•tƒL[")]
            public int t_moshikomisho_id { get; set; }              //\‘‘—•tƒL[

            [Display(Name = "XVó‘Ô")]
            public int update_kbn { get; set; }                     //XVó‘Ô

            [DataType(DataType.Date)]
            [Display(Name = "XVˆ—“ú")]
            public DateTime update_day { get; set; }                //XVˆ—“ú

            [Required]
            [Display(Name = "•ÛŒ¯—¿")]
            public int hokenryo { get; set; }                       //•ÛŒ¯—¿

            [Required]
            [Display(Name = "‘ã—“Xè”—¿—¦")]
            public float dairiten_ritsu { get; set; }               //‘ã—“Xè”—¿—¦

            [Required]
            [Display(Name = "¬—§ó‹µ")]
            public int seiritsujokyo { get; set; }                  //¬—§ó‹µ

            [Display(Name = "“ü‹àƒL[")]
            public int t_nyukin_id { get; set; }                    //“ü‹àƒL[

            [DataType(DataType.Date)]
            [Display(Name = "\“ú")]
            public DateTime moshikomibi { get; set; }               //\“ú

            [StringLength(50, ErrorMessage = "“Á–ñ‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "“Á–ñ")]
            public string? tokuyaku2 { get; set; }                  //“Á–ñ

            [Display(Name = "•s”õ——R")]
            public string? fubiriyu { get; set; }                   //•s”õ——R

            [Display(Name = "íœƒtƒ‰ƒO")]
            public bool del_flg { get; set; }                       //íœƒtƒ‰ƒO

            [StringLength(50, ErrorMessage = "x•¥æî•ñ‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "x•¥æî•ñ")]
            public string? shiharaisaki { get; set; }               //x•¥æî•ñ

            [StringLength(50, ErrorMessage = "‹à—Z‹@ŠÖ‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‹à—Z‹@ŠÖ")]
            public string? bank { get; set; }                       //‹à—Z‹@ŠÖ

            [StringLength(50, ErrorMessage = "‹à—Z‹@ŠÖ_x“X‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‹à—Z‹@ŠÖ_x“X")]
            public string? bank_shiten { get; set; }                //‹à—Z‹@ŠÖ_x“X

            [StringLength(50, ErrorMessage = "ŒûÀí–Ú‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "ŒûÀí–Ú")]
            public string? bank_account_type { get; set; }          //ŒûÀí–Ú

            [StringLength(50, ErrorMessage = "’Ê’ ‹L†‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "’Ê’ ‹L†")]
            public string? passbook_symbol { get; set; }            //’Ê’ ‹L†

            [StringLength(10, ErrorMessage = "ŒûÀ”Ô†‚Í‚P‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "ŒûÀ”Ô†")]
            public string? bank_account_no { get; set; }            //ŒûÀ”Ô†

            [StringLength(50, ErrorMessage = "ŒûÀ–¼‹`l‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "ŒûÀ–¼‹`l")]
            public string? bank_account_holder { get; set; }        //ŒûÀ–¼‹`l

            [StringLength(50, ErrorMessage = "ŒûÀ–¼‹`ƒJƒi‚Í‚T‚O•¶šˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "ŒûÀ–¼‹`ƒJƒi")]
            public string? bank_account_holder_kana { get; set; }   //ŒûÀ–¼‹`ƒJƒi

            [Display(Name = "•Ô–ß‹à")]
            public int henreikin { get; set; }                      //•Ô–ß‹à

            [DataType(DataType.Date)]
            [Display(Name = "•Ô–ß‹à“o˜^“ú")]
            public DateTime henreikin_day { get; set; }             //•Ô–ß‹à“o˜^“ú

            [DataType(DataType.Date)]
            [Display(Name = "XV”NŒ")]
            public DateTime koshin_nengetsu { get; set; }           //XV”NŒ

            [Required]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM}")]
            [Display(Name = "‘—•t—\’èŒ")]
            public DateTime sofuyoteizuki { get; set; }             //‘—•t—\’èŒ

            [Display(Name = "è”—¿")]
            public int dairiten_tesuryo { get; set; }               //è”—¿

            [Display(Name = "³–¡•ÛŒ¯—¿")]
            public int shomihokenryo { get; set; }                  //³–¡•ÛŒ¯—¿

            [Display(Name = "¿‹ƒL[")]
            public int t_seikyu_id { get; set; }                    //¿‹ƒL[

            [Display(Name = "–í¶ƒtƒ‰ƒO")]
            public bool yayoi_flg { get; set; }                     //–í¶ƒtƒ‰ƒO

            [DataType(DataType.Date)]
            [Display(Name = "“o˜^“ú")]
            public DateTime torokubi { get; set; }                  //“o˜^“ú
        }

        public class KeiyakuKakunin
        {
            public string shohin_name { get; set; }
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            




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
            keiyaku = new t_keiyaku
            {
                m_dairiten_id = Input.m_dairiten_id,
                employee_key = Input.employee_key,
                shoken_no = Input.shoken_no,
                old_shoken_no = Input.old_shoken_no,
                rireki_no = Input.rireki_no,
                keijozuki = Input.keijozuki,
                uketsuke_kbn = Input.uketsuke_kbn,
                shohin_kbn = Input.shohin_kbn,
                keiyakusha_kbn = Input.keiyakusha_kbn,
                moshikomisho_day = Input.moshikomisho_day,
                yoho = Input.yoho,
                hokenshiki = Input.hokenshiki,
                hokenshuki = Input.hokenshuki,
                hokenkikan = Input.hokenkikan,
                tokuyaku1 = Input.tokuyaku1,
                m_shohin_id = shohin_num,
                k_tel = Input.k_tel,
                k_mobile = Input.k_mobile,
                k_kodate = Input.k_kodate,
                k_bukken_no = Input.k_bukken_no,
                k_zip = Input.k_zip,
                k_address1 = Input.k_address1,
                k_address2 = Input.k_address2,
                k_address3 = Input.k_address3,
                k_address4 = Input.k_address4,
                k_sei_kana = Input.k_sei_kana,
                k_mei_kana = Input.k_mei_kana,
                k_sei = Input.k_sei,
                k_mei = Input.k_mei,
                k_birth = Input.k_birth,
                k_mail = Input.k_mail,
                hoshonin_kbn = Input.hoshonin_kbn,
                hoshonin_kbn_other = Input.hoshonin_kbn_other,
                fukusu_tokuyaku = Input.fukusu_tokuyaku,
                k_onaji = Input.k_onaji,
                h_kodate = Input.h_kodate,
                h_bukken_no = Input.h_bukken_no,
                h_zip = Input.h_zip,
                h_address1 = Input.h_address1,
                h_address2 = Input.h_address2,
                h_address3 = Input.h_address3,
                h_address4 = Input.h_address4,
                hihokensha_kbn = Input.hihokensha_kbn,
                h_sei_kana = Input.h_sei_kana,
                h_mei_kana = Input.h_mei_kana,
                h_sei = Input.h_sei,
                h_mei = Input.h_mei,
                h_birth = Input.h_birth,
                tetsuzukiiraishohakko_kbn = Input.tetsuzukiiraishohakko_kbn,
                shukinhoho = Input.shukinhoho,
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
                daihyosha_sei = Input.daihyosha_sei,
                daihyosha_mei = Input.daihyosha_mei,
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

                //‚Ü‚¾“r’†
            };

            k_kakunin = new KeiyakuKakunin
            {
                shohin_name = (string)Request.Form["shohin"]
            };
            
        }
    }
}
