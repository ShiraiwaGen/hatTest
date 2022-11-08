using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dairiten.Models
{
    [Keyless]
    public class m_yubin
    {
        public int id { get; set; }

        [DisplayName("全国地方公共団体コード")]
        public string kokyodantai_code { get; set; }

        [DisplayName("旧郵便番号")]
        public string old_zipcode { get; set; }

        [DisplayName("郵便番号")]
        public string zipcode { get; set; }

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

        public int data1 { get; set; }
        public int data2 { get; set; }
        public int data3 { get; set; }
        public int data4 { get; set; }
        public int data5 { get; set; }
        public int data6 { get; set; }
    }
}
