using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dairiten.Models
{
    [Keyless]
    public class m_yubin
    {
        [DisplayName("郵便番号")]
        public int zipcode { get; set; }

        [DisplayName("都道府県カナ")]
        public string prefectures_kana { get; set; }

        [DisplayName("市区町村名カナ")]
        public string municipality_kana { get; set; }

        [DisplayName("町域名カナ")]
        public string? town_kana { get; set; }

        [DisplayName("都道府県")]
        public string prefectures { get; set; }

        [DisplayName("市区町村名")]
        public string municipality { get; set; }

        [DisplayName("町域名")]
        public string? town { get; set; }
    }
}
