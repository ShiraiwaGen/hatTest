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

        public string kodate = "ŒËŒš‚Ä";

        public string d_no, d_name, bnin_key;

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
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "”¼Šp‰p”Žš‚Ì‚Ý“ü—Í‚Å‚«‚Ü‚·B")]
            [Display(Name = "ØŒ””Ô†")]
            public string shoken_no { get; set; }                  //ØŒ””Ô†

            [MinLength(10, ErrorMessage = "ØŒ””Ô†‚Í‚P‚OŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [StringLength(10, ErrorMessage = "ØŒ””Ô†‚Í‚P‚OŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "”¼Šp‰p”Žš‚Ì‚Ý“ü—Í‚Å‚«‚Ü‚·B")]
            [Display(Name = "‹ŒØŒ””Ô†")]
            public string old_shoken_no { get; set; }              //‹ŒØŒ””Ô†

            [Required]
            [StringLength(10)]
            [Display(Name = "—š—ð”Ô†")]
            public string rireki_no { get; set; }                  //—š—ð”Ô†

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "ŒvãŒŽ")]
            public DateTime keijozuki { get; set; }                 //ŒvãŒŽ

            [Required]
            [Display(Name = "Žó•t‹æ•ª")]
            public int uketsuke_kbn { get; set; }                   //Žó•t‹æ•ª

            [Required]
            [Display(Name = "¤•i‹æ•ª")]
            public string shohin_kbn { get; set; }                  //¤•i‹æ•ª

            [Required]
            [Display(Name = "Œ_–ñŽÒ‹æ•ª")]
            public string keiyakusha_kbn { get; set; }              //Œ_–ñŽÒ‹æ•ª

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = @"\ž‘ì¬“ú")]
            public DateTime moshikomisho_day { get; set; }          //\ž‘ì¬“ú

            [Required]
            [Display(Name = "—p–@")]
            public int yoho { get; set; }                           //—p–@

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "•ÛŒ¯ŽnŠú")]
            public DateTime hokenshiki { get; set; }                //•ÛŒ¯ŽnŠú

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "•ÛŒ¯IŠú")]
            public DateTime hokenshuki { get; set; }                //•ÛŒ¯IŠú

            [Required]
            [Display(Name = "•ÛŒ¯ŠúŠÔ")]
            public string hokenkikan { get; set; }                  //•ÛŒ¯ŠúŠÔ

            [Display(Name = "Z‘î“à“ü‹ŽÒŽ€–S”ï—p“Á–ñ")]
            public bool tokuyaku1 { get; set; }                     //Z‘î“à“ü‹ŽÒŽ€–S”ï—p“Á–ñ

            [Required]
            [Display(Name = "¤•iƒL[")]
            public string m_shohin_id { get; set; }                    //¤•iƒL[

            [Phone]
            [StringLength(50, ErrorMessage = "Œ_–ñŽÒ˜A—æ‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ˜A—æ")]
            public string? k_tel { get; set; }                      //Œ_–ñŽÒ˜A—æ

            [Phone]
            [StringLength(50, ErrorMessage = "Œ_–ñŽÒŒg‘Ñ‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒŒg‘Ñ")]
            public string? k_mobile { get; set; }                   //Œ_–ñŽÒŒg‘Ñ

            [Display(Name = "Œ_–ñŽÒ_ŒËŒš‚Ä")]
            public string k_kodate { get; set; }                    //Œ_–ñŽÒ_ŒËŒš‚Ä

            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”Žš‚Ì‚Ý“ü—Í‚Å‚«‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_•¨Œ”Ô†")]
            public string? k_bukken_no { get; set; }                //Œ_–ñŽÒ_•¨Œ”Ô†

            [Required]
            [StringLength(7, ErrorMessage = "—X•Ö”Ô†‚ÍƒnƒCƒtƒ“i|j‚È‚µ‚Ì”Žš‚VŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”Žš‚Ì‚Ý“ü—Í‚Å‚«‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_—X•Ö”Ô†")]
            public string k_zip { get; set; }                      //Œ_–ñŽÒ_—X•Ö”Ô†

            [Required]
            [StringLength(55, ErrorMessage = "ZŠi“s“¹•{Œ§Žs‹æ’¬‘ºj‚Í‚T‚T•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_ZŠi“s“¹•{Œ§Žs‹æ’¬‘ºj")]
            public string k_address1 { get; set; }                 //Œ_–ñŽÒ_ZŠi“s“¹•{Œ§Žs‹æ’¬‘ºj

            [StringLength(25, ErrorMessage = "ZŠi’š–Ú”Ô’nj‚Í‚Q‚T•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_ZŠi’š–Ú”Ô’nj")]
            public string k_address2 { get; set; }                 //Œ_–ñŽÒ_ZŠi’š–Ú”Ô’nj

            [StringLength(50, ErrorMessage = "ZŠiŒš•¨–¼j‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_ZŠiŒš•¨–¼j")]
            public string? k_address3 { get; set; }                 //Œ_–ñŽÒ_ZŠiŒš•¨–¼j

            [StringLength(25, ErrorMessage = "ZŠi†Žºj‚Í‚Q‚T•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_ZŠi†Žºj")]
            public string? k_address4 { get; set; }                 //Œ_–ñŽÒ_ZŠi†Žºj

            [Required]
            [StringLength(50, ErrorMessage = "Œ_–ñŽÒ–¼ƒJƒi‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ–¼ƒJƒi")]
            public string k_kana { get; set; }                      //Œ_–ñŽÒ–¼ƒJƒi

            [Required]
            [StringLength(50, ErrorMessage = "Œ_–ñŽÒ–¼‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ–¼")]
            public string k_name { get; set; }                      //Œ_–ñŽÒ–¼

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Œ_–ñŽÒ¶”NŒŽ“ú")]
            public DateTime k_birth { get; set; }                  //Œ_–ñŽÒ¶”NŒŽ“ú

            [EmailAddress]
            [Display(Name = "Œ_–ñŽÒ_ƒ[ƒ‹ƒAƒhƒŒƒX")]
            public string? k_mail { get; set; }                     //Œ_–ñŽÒ_ƒ[ƒ‹ƒAƒhƒŒƒX

            [Display(Name = "•ÛØl‹æ•ª")]
            public string hoshonin_kbn { get; set; }                //•ÛØl‹æ•ª

            [StringLength(100, ErrorMessage = "•ÛØl‹æ•ª‚»‚Ì‘¼‚Í‚P‚O‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "•ÛØl‹æ•ª‚»‚Ì‘¼")]
            public string? hoshonin_kbn_other { get; set; }         //•ÛØl‹æ•ª‚»‚Ì‘¼

            [Display(Name = "•¡”Œ_–ñ“Á–ñ")]
            public bool fukusu_tokuyaku { get; set; }               //•¡”Œ_–ñ“Á–ñ

            [Display(Name = "Œ_–ñŽÒ‚Æ“¯‚¶")]
            public bool k_onaji { get; set; }                       //Œ_–ñŽÒ‚Æ“¯‚¶

            [Display(Name = "–Ú“I’n_ŒËŒš‚Ä")]
            public string h_kodate { get; set; }                      //–Ú“I’n_ŒËŒš‚Ä

            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”Žš‚Ì‚Ý“ü—Í‚Å‚«‚Ü‚·")]
            [Display(Name = "–Ú“I’n_•¨Œ”Ô†")]
            public string? h_bukken_no { get; set; }                //–Ú“I’n_•¨Œ”Ô†

            [Required]
            [StringLength(7, ErrorMessage = "—X•Ö”Ô†‚ÍƒnƒCƒtƒ“i|j‚È‚µ‚Ì”Žš‚VŒ…‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "”¼Šp”Žš‚Ì‚Ý“ü—Í‚Å‚«‚Ü‚·")]
            [Display(Name = "–Ú“I’n_—X•Ö”Ô†")]
            public string h_zip { get; set; }                      //–Ú“I’n_—X•Ö”Ô†

            [Required]
            [StringLength(55, ErrorMessage = "ZŠi“s“¹•{Œ§Žs‹æ’¬‘ºj‚Í‚T‚T•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "–Ú“I’n_ZŠi“s“¹•{Œ§Žs‹æ’¬‘ºj")]
            public string h_address1 { get; set; }                 //–Ú“I’n_ZŠi“s“¹•{Œ§Žs‹æ’¬‘ºj

            [StringLength(25, ErrorMessage = "ZŠi’š–Ú”Ô’nj‚Í‚Q‚T•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "–Ú“I’n_ZŠi’š–Ú”Ô’nj")]
            public string h_address2 { get; set; }                 //–Ú“I’n_ZŠi’š–Ú”Ô’nj

            [StringLength(50, ErrorMessage = "ZŠiŒš•¨–¼j‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "–Ú“I’n_ZŠiŒš•¨–¼j")]
            public string? h_address3 { get; set; }                 //–Ú“I’n_ZŠiŒš•¨–¼j

            [StringLength(25, ErrorMessage = "ZŠi†Žºj‚Í‚Q‚T•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "–Ú“I’n_ZŠi†Žºj")]
            public string? h_address4 { get; set; }                 //–Ú“I’n_ZŠi†Žºj

            [Required]
            [Display(Name = "”í•ÛŒ¯ŽÒ‹æ•ª")]
            public int hihokensha_kbn { get; set; }                 //”í•ÛŒ¯ŽÒ‹æ•ª

            [Required]
            [StringLength(50, ErrorMessage = "”í•ÛŒ¯ŽÒ–¼ƒJƒi‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯ŽÒ–¼ƒJƒi")]
            public string h_kana { get; set; }                      //”í•ÛŒ¯ŽÒ–¼ƒJƒi

            [Required]
            [StringLength(50, ErrorMessage = "”í•ÛŒ¯ŽÒ–¼‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯ŽÒ–¼")]
            public string h_name { get; set; }                      //”í•ÛŒ¯ŽÒ–¼

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "”í•ÛŒ¯ŽÒ¶”NŒŽ“ú")]
            public DateTime h_birth { get; set; }                   //”í•ÛŒ¯ŽÒ¶”NŒŽ“ú

            [Required]
            [Display(Name = "Žè‘±ˆË—Š‘”­s‹æ•ª")]
            public string tetsuzukiiraishohakko_kbn { get; set; }   //Žè‘±ˆË—Š‘”­s‹æ•ª

            [Required]
            [Display(Name = "W‹à•û–@")]
            public string shukinhoho { get; set; }                  //W‹à•û–@

            [Display(Name = "‘¼‚Ì•ÛŒ¯")]
            public bool other_hoken { get; set; }                   //‘¼‚Ì•ÛŒ¯

            [Display(Name = "‘¼‚Ì•ÛŒ¯_“–ŽÐ—L–³")]
            public bool other_hoken_umu { get; set; }               //‘¼‚Ì•ÛŒ¯_“–ŽÐ—L–³

            [StringLength(50, ErrorMessage = "‘¼‚Ì•ÛŒ¯_•ÛŒ¯‰ïŽÐ–¼‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‘¼‚Ì•ÛŒ¯_•ÛŒ¯‰ïŽÐ–¼")]
            public string? other_hoken_company { get; set; }        //‘¼‚Ì•ÛŒ¯_•ÛŒ¯‰ïŽÐ–¼

            [StringLength(50, ErrorMessage = "‘¼‚Ì•ÛŒ¯_•ÛŒ¯Ží—Þ‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‘¼‚Ì•ÛŒ¯_•ÛŒ¯Ží—Þ")]
            public string? other_hoken_shurui { get; set; }         //‘¼‚Ì•ÛŒ¯_•ÛŒ¯Ží—Þ

            [DataType(DataType.Date)]
            [Display(Name = "‘¼‚Ì•ÛŒ¯_–žŠú“ú")]
            public DateTime other_hoken_manki { get; set; }         //‘¼‚Ì•ÛŒ¯_–žŠú“ú

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

            [StringLength(100, ErrorMessage = "‚»‚Ì‘¼_“Á‹LŽ–€‚Í‚P‚O‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‚»‚Ì‘¼_“Á‹LŽ–€")]
            public string? other_tokkijiko { get; set; }            //‚»‚Ì‘¼_“Á‹LŽ–€

            [Required]
            [Display(Name = "Œ_–ñŽÒ_–@lŒ`‘Ô")]
            public int k_hojinkeitai { get; set; }                  //Œ_–ñŽÒ_–@lŒ`‘Ô

            [StringLength(50, ErrorMessage = "Œ_–ñŽÒ_–@lŒ`‘Ô‚»‚Ì‘¼‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_–@lŒ`‘Ô‚»‚Ì‘¼")]
            public string? k_hojinkeitai_other { get; set; }        //Œ_–ñŽÒ_–@lŒ`‘Ô‚»‚Ì‘¼

            [Required]
            [Display(Name = "Œ_–ñŽÒ_–@lŒ`‘ÔˆÊ’u")]
            public int k_hojinkeitai_ichi { get; set; }             //Œ_–ñŽÒ_–@lŒ`‘ÔˆÊ’u

            [Required]
            [StringLength(100, ErrorMessage = "Œ_–ñŽÒ_–@l–¼_ƒJƒi‚Í‚P‚O‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_–@l–¼_ƒJƒi")]
            public string k_hojinmei_kana { get; set; }             //Œ_–ñŽÒ_–@l–¼_ƒJƒi

            [Required]
            [StringLength(100, ErrorMessage = "Œ_–ñŽÒ_–@l–¼_Š¿Žš‚Í‚P‚O‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_–@l–¼_Š¿Žš")]
            public string k_hojinmei_kanji { get; set; }            //Œ_–ñŽÒ_–@l–¼_Š¿Žš

            [StringLength(100, ErrorMessage = "Žx“XŽxŽÐ‰c‹ÆŠ“™‚Í‚P‚O‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Žx“XŽxŽÐ‰c‹ÆŠ“™")]
            public string? shiten { get; set; }                     //Žx“XŽxŽÐ‰c‹ÆŠ“™

            [Required]
            [StringLength(100, ErrorMessage = @"‘ã•\ŽÒ_–ðE‚Í‚P‚O‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = @"‘ã•\ŽÒ_–ðE")]
            public string daihyosha_yakushoku { get; set; }         //‘ã•\ŽÒ_–ðE

            [Required]
            [StringLength(50, ErrorMessage = @"‘ã•\ŽÒ–¼‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = @"‘ã•\ŽÒ–¼")]
            public string daihyosha_name { get; set; }               //‘ã•\ŽÒ–¼

            [Display(Name = "–@l“Á–ñ")]
            public bool hojin_tokuyaku { get; set; }                //–@l“Á–ñ

            [Required]
            [Display(Name = "”í•ÛŒ¯ŽÒ_–@lŒ`‘Ô")]
            public int h_hojinkeitai { get; set; }                  //”í•ÛŒ¯ŽÒ_–@lŒ`‘Ô

            [StringLength(50, ErrorMessage = "”í•ÛŒ¯ŽÒ_–@lŒ`‘Ô‚»‚Ì‘¼‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯ŽÒ_–@lŒ`‘Ô‚»‚Ì‘¼")]
            public string? h_hojinkeitai_other { get; set; }        //”í•ÛŒ¯ŽÒ_–@lŒ`‘Ô‚»‚Ì‘¼

            [Required]
            [Display(Name = "”í•ÛŒ¯ŽÒ_–@lŒ`‘ÔˆÊ’u")]
            public int h_hojinkeitai_ichi { get; set; }             //”í•ÛŒ¯ŽÒ_–@lŒ`‘ÔˆÊ’u

            [Required]
            [StringLength(100, ErrorMessage = "”í•ÛŒ¯ŽÒ_–@l–¼_ƒJƒi‚Í‚P‚O‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯ŽÒ_–@l–¼_ƒJƒi")]
            public string h_hojinmei_kana { get; set; }             //”í•ÛŒ¯ŽÒ_–@l–¼_ƒJƒi

            [Required]
            [StringLength(100, ErrorMessage = "”í•ÛŒ¯ŽÒ_–@l–¼_Š¿Žš‚Í‚P‚O‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯ŽÒ_–@l–¼_Š¿Žš")]
            public string h_hojinmei_kanji { get; set; }            //”í•ÛŒ¯ŽÒ_–@l–¼_Š¿Žš

            [Required]
            [StringLength(100, ErrorMessage = "‹ÆŽí‚Í‚P‚O‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‹ÆŽí")]
            public string gyoshu { get; set; }                      //‹ÆŽí

            [Display(Name = "‹ÆŽíŠm”FÏ‚Ý")]
            public string? gyoshu_sumi { get; set; }                //‹ÆŽíŠm”FÏ‚Ý

            [Required]
            [Display(Name = "ê—L–ÊÏ")]
            public int senyumenseki { get; set; }                   //ê—L–ÊÏ

            [Display(Name = "Œ_–ñŽÒ_ƒtƒƒA[ŽØ‚è")]
            public bool k_floor { get; set; }                       //Œ_–ñŽÒ_ƒtƒƒA[ŽØ‚è

            [Display(Name = "–Ú“I’n_ƒtƒƒA[ŽØ‚è")]
            public bool h_floor { get; set; }                       //–Ú“I’n_ƒtƒƒA[ŽØ‚è

            [StringLength(50, ErrorMessage = "Œ_–ñŽÒ_‰®†‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_‰®†")]
            public string? k_yago { get; set; }                       //Œ_–ñŽÒ_‰®†

            [StringLength(50, ErrorMessage = "Œ_–ñŽÒ_Œ¨‘‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Œ_–ñŽÒ_Œ¨‘")]
            public string? k_katagaki { get; set; }                   //Œ_–ñŽÒ_Œ¨‘

            [StringLength(50, ErrorMessage = "”í•ÛŒ¯ŽÒ_‰®†‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯ŽÒ_‰®†")]
            public string? h_yago { get; set; }                       //”í•ÛŒ¯ŽÒ_‰®†

            [StringLength(50, ErrorMessage = "”í•ÛŒ¯ŽÒ_Œ¨‘‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "”í•ÛŒ¯ŽÒ_Œ¨‘")]
            public string? h_katagaki { get; set; }                   //”í•ÛŒ¯ŽÒ_Œ¨‘

            [Display(Name = "–¼“æˆó")]
            public bool shomei { get; set; }                        //–¼“æˆó

            [Display(Name = "ˆÓŒüŠm”F")]
            public bool ikokakunin { get; set; }                    //ˆÓŒüŠm”F

            [DataType(DataType.Date)]
            [Display(Name = "•ÛŒ¯—¿—ÌŽû“ú")]
            public DateTime hokenryo_ryoshubi { get; set; }         //•ÛŒ¯—¿—ÌŽû“ú

            [Display(Name = "•ÛŒ¯—¿—ÌŽûŠz")]
            public int hokenryo_ryoshugaku { get; set; }            //•ÛŒ¯—¿—ÌŽûŠz

            [Required]
            [Display(Name = "—LŒøó‘Ô")]
            public int yukojotai { get; set; }                      //—LŒøó‘Ô

            [Required]
            [Display(Name = @"\žó‹µ")]
            public int moshikomijokyo { get; set; }                 //\žó‹µ

            [Display(Name = "‚¨‹q‚³‚Üê—pƒy[ƒW")]
            public bool customer_page { get; set; }                 //‚¨‹q‚³‚Üê—pƒy[ƒW

            [StringLength(50, ErrorMessage = "‚¨‹q‚³‚Üê—pƒy[ƒWID‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‚¨‹q‚³‚Üê—pƒy[ƒWID")]
            public string? customer_id { get; set; }                //‚¨‹q‚³‚Üê—pƒy[ƒWID

            [StringLength(10, ErrorMessage = "‚¨‹q‚³‚ÜƒpƒXƒ[ƒh‚Í‚P‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‚¨‹q‚³‚ÜƒpƒXƒ[ƒh")]
            public string? customer_pass { get; set; }              //‚¨‹q‚³‚ÜƒpƒXƒ[ƒh

            [DataType(DataType.Date)]
            [Display(Name = "‚¨‹q‚³‚ÜƒpƒXƒ[ƒh•ÏX“ú")]
            public DateTime customer_pass_day { get; set; }         //‚¨‹q‚³‚ÜƒpƒXƒ[ƒh•ÏX“ú

            [Required]
            [Display(Name = "“ü—ÍŽÒ‹æ•ª")]
            public int inputter_kbn { get; set; }                   //“ü—ÍŽÒ‹æ•ª

            [DataType(DataType.Date)]
            [Display(Name = "Œ_–ñØŒ“—ÌŽûØ_”­s“ú")]
            public DateTime keiyakusho_hakkobi { get; set; }        //Œ_–ñØŒ“—ÌŽûØ_”­s“ú

            [Required]
            [Display(Name = "”­Œ”ØŒ”")]
            public int hakkenshoken { get; set; }                   //”­Œ”ØŒ”

            [Required]
            [Display(Name = "•ÛŒ¯—¿Žæˆø‹æ•ª")]
            public int hokenryotorihiki_kbn { get; set; }           //•ÛŒ¯—¿Žæˆø‹æ•ª

            [Required]
            [Display(Name = "ˆÙ“®Ž–—R")]
            public int idojiyu { get; set; }                        //ˆÙ“®Ž–—R

            [Required]
            [Display(Name = "Œ_–ñó‹µ")]
            public int keiyakujokyo { get; set; }                   //Œ_–ñó‹µ

            [DataType(DataType.Date)]
            [Display(Name = "Œ_–ñ“ú")]
            public DateTime keiyakubi { get; set; }                 //Œ_–ñ“ú

            [DataType(DataType.Date)]
            [Display(Name = "‰ñŽû“ú")]
            public DateTime kaishubi { get; set; }                  //‰ñŽû“ú

            [Display(Name = "‹ŒŒ_–ñƒL[")]
            public int old_keiyaku_key { get; set; }                //‹ŒŒ_–ñƒL[

            [Display(Name = "ÅVƒtƒ‰ƒO")]
            public bool saishin_flg { get; set; }                   //ÅVƒtƒ‰ƒO

            [DataType(DataType.Date)]
            [Display(Name = "–žŠú”NŒŽ")]
            public DateTime manki_nengetsu { get; set; }            //–žŠú”NŒŽ

            [Required]
            [Display(Name = "•¥ž•[‘—•t‹æ•ª")]
            public int haraikomihyo_kbn { get; set; }               //•¥ž•[‘—•t‹æ•ª

            [Display(Name = "–ß‚è•Ö")]
            public bool modoribin { get; set; }                     //–ß‚è•Ö

            [Display(Name = "ˆêŽž•Û‘¶")]
            public bool ichijihozon { get; set; }                   //ˆêŽž•Û‘¶

            [DataType(DataType.Date)]
            [Display(Name = "Šm’è“ú")]
            public DateTime kakuteibi { get; set; }                 //Šm’è“ú

            [DataType(DataType.Date)]
            [Display(Name = "¬—§“ú")]
            public DateTime seiritsubi { get; set; }                //¬—§“ú

            [Display(Name = "ŠÇ—ŠOˆÙ“®")]
            public string? kanrigaiido { get; set; }                //ŠÇ—ŠOˆÙ“®

            [Required]
            [Display(Name = @"\ž‘‘—•tƒL[")]
            public int t_moshikomisho_id { get; set; }              //\ž‘‘—•tƒL[

            [Display(Name = "XVó‘Ô")]
            public int update_kbn { get; set; }                     //XVó‘Ô

            [DataType(DataType.Date)]
            [Display(Name = "XVˆ—“ú")]
            public DateTime update_day { get; set; }                //XVˆ—“ú

            [Required]
            [Display(Name = "•ÛŒ¯—¿")]
            public int hokenryo { get; set; }                       //•ÛŒ¯—¿

            [Required]
            [Display(Name = "‘ã—“XŽè”—¿—¦")]
            public float dairiten_ritsu { get; set; }               //‘ã—“XŽè”—¿—¦

            [Required]
            [Display(Name = "¬—§ó‹µ")]
            public int seiritsujokyo { get; set; }                  //¬—§ó‹µ

            [Display(Name = "“ü‹àƒL[")]
            public int t_nyukin_id { get; set; }                    //“ü‹àƒL[

            [DataType(DataType.Date)]
            [Display(Name = @"\ž“ú")]
            public DateTime moshikomibi { get; set; }               //\ž“ú

            [StringLength(50, ErrorMessage = "“Á–ñ‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "“Á–ñ")]
            public string? tokuyaku2 { get; set; }                  //“Á–ñ

            [Display(Name = "•s”õ——R")]
            public string? fubiriyu { get; set; }                   //•s”õ——R

            [Display(Name = "íœƒtƒ‰ƒO")]
            public bool del_flg { get; set; }                       //íœƒtƒ‰ƒO

            [StringLength(50, ErrorMessage = "Žx•¥æî•ñ‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "Žx•¥æî•ñ")]
            public string? shiharaisaki { get; set; }               //Žx•¥æî•ñ

            [StringLength(50, ErrorMessage = "‹à—Z‹@ŠÖ‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‹à—Z‹@ŠÖ")]
            public string? bank { get; set; }                       //‹à—Z‹@ŠÖ

            [StringLength(50, ErrorMessage = "‹à—Z‹@ŠÖ_Žx“X‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "‹à—Z‹@ŠÖ_Žx“X")]
            public string? bank_shiten { get; set; }                //‹à—Z‹@ŠÖ_Žx“X

            [StringLength(50, ErrorMessage = "ŒûÀŽí–Ú‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "ŒûÀŽí–Ú")]
            public string? bank_account_type { get; set; }          //ŒûÀŽí–Ú

            [StringLength(50, ErrorMessage = "’Ê’ ‹L†‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "’Ê’ ‹L†")]
            public string? passbook_symbol { get; set; }            //’Ê’ ‹L†

            [StringLength(10, ErrorMessage = "ŒûÀ”Ô†‚Í‚P‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "ŒûÀ”Ô†")]
            public string? bank_account_no { get; set; }            //ŒûÀ”Ô†

            [StringLength(50, ErrorMessage = "ŒûÀ–¼‹`l‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "ŒûÀ–¼‹`l")]
            public string? bank_account_holder { get; set; }        //ŒûÀ–¼‹`l

            [StringLength(50, ErrorMessage = "ŒûÀ–¼‹`ƒJƒi‚Í‚T‚O•¶ŽšˆÈ“à‚Å‚¨Šè‚¢‚µ‚Ü‚·")]
            [Display(Name = "ŒûÀ–¼‹`ƒJƒi")]
            public string? bank_account_holder_kana { get; set; }   //ŒûÀ–¼‹`ƒJƒi

            [Display(Name = "•Ô–ß‹à")]
            public int henreikin { get; set; }                      //•Ô–ß‹à

            [DataType(DataType.Date)]
            [Display(Name = "•Ô–ß‹à“o˜^“ú")]
            public DateTime henreikin_day { get; set; }             //•Ô–ß‹à“o˜^“ú

            [DataType(DataType.Date)]
            [Display(Name = "XV”NŒŽ")]
            public DateTime koshin_nengetsu { get; set; }           //XV”NŒŽ

            [Required]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM}")]
            [Display(Name = @"‘—•t—\’èŒŽ")]
            public DateTime sofuyoteizuki { get; set; }             //‘—•t—\’èŒŽ

            [Display(Name = "Žè”—¿")]
            public int dairiten_tesuryo { get; set; }               //Žè”—¿

            [Display(Name = "³–¡•ÛŒ¯—¿")]
            public int shomihokenryo { get; set; }                  //³–¡•ÛŒ¯—¿

            [Display(Name = "¿‹ƒL[")]
            public int t_seikyu_id { get; set; }                    //¿‹ƒL[

            [Display(Name = "–í¶ƒtƒ‰ƒO")]
            public bool yayoi_flg { get; set; }                     //–í¶ƒtƒ‰ƒO

            [DataType(DataType.Date)]
            [Display(Name = "“o˜^“ú")]
            public DateTime torokubi { get; set; }                  //“o˜^“ú

            [Required]
            [Display(Name = "‘—•t‹æ•ª")]
            public int sofu_kbn { get; set; }                      //‘—•t‹æ•ª
        }

        //¤•i‹æ•ª
        public string[] shohin_kbns = new string[1];

        //Œ_–ñŽÒ‹æ•ª
        public string[] keiyakusha_kbns = new string[1];

        //•ÛŒ¯ŠúŠÔ
        public string[] hokenkikans = new[] { "", "‚P”N", "‚Q”N" };

        //¤•iƒL[
        public string[] m_shohin_ids = new string[1];

        //•ÛØl‹æ•ª
        public string[] hoshonin_kbns = new string[1];

        //Žè‘±ˆË—Š‘”­s
        public string[] tetsuzukiiraishohakko_kbns = new string[1];

        //W‹à•û–@
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

            //¤•i‹æ•ª
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

            //Œ_–ñŽÒ‹æ•ª
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

            //¤•iƒL[
            int m_shohin_ids_cnt = _context.m_shohin.Where(m => m.hokenkikan == 1).Count();//¦‘I‘ð‚³‚ê‚½•ÛŒ¯ŠúŠÔ‚Å¤•i‚ði‚è‚½‚¢
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

            //•ÛØl‹æ•ª
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

            //Žè‘±ˆË—Š‘”­s
            int tetsuzukiiraishohakko_kbns_cnt = _context.m_master.Where(m => m.m_master_kbn_id == 12).Count();
            Array.Resize(ref tetsuzukiiraishohakko_kbns, tetsuzukiiraishohakko_kbns_cnt);
            var masters4 = _context.m_master.Where(m => m.m_master_kbn_id == 12).ToArray();
            for (int i = 0; i < tetsuzukiiraishohakko_kbns_cnt; i++)
            {
                tetsuzukiiraishohakko_kbns[i] = masters4[i].item_name;
            }

            //W‹à•û–@
            int shukinhohoes_cnt = _context.m_master.Where(m => m.m_master_kbn_id == 13).Count();
            Array.Resize(ref shukinhohoes, shukinhohoes_cnt);
            var masters5 = _context.m_master.Where(m => m.m_master_kbn_id == 13).ToArray();
            for (int i = 0; i < shukinhohoes_cnt; i++)
            {
                shukinhohoes[i] = masters5[i].item_name;
            }

            //Œ_–ñŽÒ_ŒËŒš‚Ä
            Boolean k_kodate = false;
            if (Input.k_kodate == "" || Input.k_kodate == null || Input.k_kodate == "false")
            {
                k_kodate = false;
            }
            else
            {
                k_kodate = true;
            }

            //–Ú“I’n_ŒËŒš‚Ä
            Boolean h_kodate = false;
            if (Input.h_kodate == "" || Input.h_kodate == null || Input.h_kodate == "false")
            {
                h_kodate = false;
            }
            else
            {
                h_kodate = true;
            }

            // Œ_–ñƒ^ƒCƒv‚Ìƒvƒ‹ƒ_ƒEƒ“‚Å‘I‘ð‚µ‚½¤•i‚ÌID‚ðŽæ“¾
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

            // •ÛØl‹æ•ª‚Ìƒvƒ‹ƒ_ƒEƒ“‚Å‘I‘ð‚Ìitem_no‚ðŽæ“¾
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

            // Žè‘±ˆË—Š‘”­s‚Ìƒvƒ‹ƒ_ƒEƒ“‚Å‘I‘ð‚Ìitem_no‚ðŽæ“¾
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

            // W‹à•û–@‚Ìƒvƒ‹ƒ_ƒEƒ“‚Å‘I‘ð‚Ìitem_no‚ðŽæ“¾
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
