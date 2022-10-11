using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dairiten.Models
{
    public class t_kaiyaku
    {
        [DisplayName("解約キー")]
        public int id { get; set; }

        [ForeignKey("t_kaiyaku")]
        [DisplayName("契約キー")]
        [Required]
        public int t_keiyaku_id { get; set; }

        [DisplayName("解約日")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime kaiyakubi { get; set; }

        [DisplayName("支払日")]
        [DataType(DataType.Date)]
        public DateTime shiharaibi { get; set; }

        [DisplayName("解約返戻金")]
        [Required]
        public int kaiyakuhenreikin { get; set; }

        [DisplayName("既経過保険料")]
        public int kikeikahokenryo { get; set; }

        [DisplayName("未経過保険料")]
        public int mikeikahokenryo { get; set; }

        [DisplayName("振込手数料")]
        public int hurikomitesuryo { get; set; }

        [DisplayName("弥生出力フラグ")]
        public int yayoi_flg { get; set; }

        [DisplayName("残月数")]
        [Required]
        public int zangetsusu { get; set; }

        [ForeignKey("t_seikyu")]
        [DisplayName("請求キー")]
        public int t_seikyu_id { get; set; }

    }
}
