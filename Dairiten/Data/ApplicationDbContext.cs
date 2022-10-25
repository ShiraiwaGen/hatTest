using Dairiten.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Dairiten.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Dairiten.Models.m_company> m_company { get; set; }
        public DbSet<Dairiten.Models.m_shohin> m_shohin { get; set; }
        public DbSet<Dairiten.Models.m_dairiten> m_dairiten { get; set; }
        public DbSet<Dairiten.Models.m_master> m_master { get; set; }
        public DbSet<Dairiten.Models.m_master_kbn> m_master_kbn { get; set; }
        public DbSet<Dairiten.Models.m_tax> m_tax { get; set; }
        public DbSet<Dairiten.Models.m_yubin> m_yubin { get; set; }
        public DbSet<Dairiten.Models.t_keiyaku> t_keiyaku { get; set; }
        public DbSet<Dairiten.Models.t_bukken> t_bukken { get; set; }
        public DbSet<Dairiten.Models.t_karibukken> t_karibukken { get; set; }
        public DbSet<Dairiten.Models.t_company_employee> t_company_employee { get; set; }
        public DbSet<Dairiten.Models.t_dairiten_employee> t_dairiten_employee { get; set; }
        public DbSet<Dairiten.Models.t_seikyu> t_seikyu { get; set; }
        public DbSet<Dairiten.Models.t_moshikomisho> t_moshikomisho { get; set; }
        public DbSet<Dairiten.Models.t_nayose> t_nayose { get; set; }
        public DbSet<Dairiten.Models.t_kaiyaku> t_kaiyaku { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<m_company>().ToTable("m_company");
            modelBuilder.Entity<m_shohin>().ToTable("m_shohin");
            modelBuilder.Entity<m_dairiten>().ToTable("m_dairiten");
            modelBuilder.Entity<m_master>(e =>
            {
                e.HasKey(m => new { m.m_master_kbn_id, m.item_no });
                e.ToTable("m_master");
            });
            modelBuilder.Entity<m_master_kbn>().ToTable("m_master_kbn");
            modelBuilder.Entity<m_tax>().ToTable("m_tax");
            modelBuilder.Entity<m_yubin>().ToTable("m_yubin");
            modelBuilder.Entity<t_keiyaku>().ToTable("t_keiyaku");
            modelBuilder.Entity<t_bukken>().ToTable("t_bukken");
            modelBuilder.Entity<t_karibukken>().ToTable("t_karibukken");
            modelBuilder.Entity<t_company_employee>().ToTable("t_company_employee");
            modelBuilder.Entity<t_dairiten_employee>().ToTable("t_dairiten_employee");
            modelBuilder.Entity<t_seikyu>().ToTable("t_seikyu");
            modelBuilder.Entity<t_moshikomisho>().ToTable("t_moshikomisho");
            modelBuilder.Entity<t_nayose>().ToTable("t_nayose");
            modelBuilder.Entity<t_kaiyaku>().ToTable("t_kaiyaku");

            ////マスター区分　初期値
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 1, master_kbn_name = "事故内容" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 2, master_kbn_name = "担保種目" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 3, master_kbn_name = "テナント区分・用途" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 4, master_kbn_name = "テナント区分_略称" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 5, master_kbn_name = "業種" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 6, master_kbn_name = "契約者区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 7, master_kbn_name = "商品区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 8, master_kbn_name = "用法" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 9, master_kbn_name = "受付区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 10, master_kbn_name = "保証人区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 11, master_kbn_name = "被保険者区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 12, master_kbn_name = "手続依頼書発行" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 13, master_kbn_name = "集金方法" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 14, master_kbn_name = "法人形態" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 15, master_kbn_name = "法人形態位置" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 16, master_kbn_name = "有効状態" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 17, master_kbn_name = "申込状況" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 18, master_kbn_name = "入力者区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 19, master_kbn_name = "発券証券" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 20, master_kbn_name = "保険料取引区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 21, master_kbn_name = "異動事由" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 22, master_kbn_name = "契約状況" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 23, master_kbn_name = "名寄せ状況" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 24, master_kbn_name = "名寄せエラー区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 25, master_kbn_name = "明細種別" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 26, master_kbn_name = "送付区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 27, master_kbn_name = "払込票送付区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 28, master_kbn_name = "払込手続状況" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 29, master_kbn_name = "更新状態" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 30, master_kbn_name = "成立状況" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 31, master_kbn_name = "代理店区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 32, master_kbn_name = "特約" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 33, master_kbn_name = "コード" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 34, master_kbn_name = "弥生レコード区分" });
            //modelBuilder.Entity<m_master_kbn>().HasData(new m_master_kbn { master_kbn = 35, master_kbn_name = "戸建区分" });
            ////マスター　初期値　
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 1, item_name = "火災" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 2, item_name = "落雷" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 3, item_name = "破裂・爆発" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 4, item_name = "飛来・落下" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 5, item_name = "水濡れ" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 6, item_name = "盗難" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 7, item_name = "台風" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 8, item_name = "集中豪雨" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 9, item_name = "竜巻・旋風" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 10, item_name = "漏水（加害）" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 11, item_name = "漏水（被害）" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 12, item_name = "失火・破裂・爆発" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 13, item_name = "施設瑕疵" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 1, item_no = 14, item_name = "従業員過失" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 1, item_name = "設備・什器等" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 2, item_name = "設備・什器等（盗難）" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 3, item_name = "設備・什器等（水災）" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 4, item_name = "臨時費用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 5, item_name = "残存物取片付け費用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 6, item_name = "地震火災費用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 7, item_name = "修理費用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 8, item_name = "借家人賠償責任" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 9, item_name = "施設賠償責任" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 10, item_name = "損害防止費用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 11, item_name = "弁護士費用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 12, item_name = "鑑定費用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 2, item_no = 13, item_name = "調査費用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 3, item_no = 1, item_name = "店舗" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 3, item_no = 2, item_name = "事務所" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 3, item_no = 3, item_name = "文化教育" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 3, item_no = 4, item_name = "飲食" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 3, item_no = 5, item_name = "サービス" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 4, item_no = 1, item_name = "T" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 4, item_no = 2, item_name = "J" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 4, item_no = 3, item_name = "C" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 4, item_no = 4, item_name = "R" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 4, item_no = 5, item_name = "S" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 1, item_name = "農林水産" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 2, item_name = "建設・不動産" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 3, item_name = "製造" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 4, item_name = "通信・運輸" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 5, item_name = "教育" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 6, item_name = "卸売小売" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 7, item_name = "飲食" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 8, item_name = "金融・保険" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 9, item_name = "サービス" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 5, item_no = 10, item_name = "その他" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 6, item_no = 1, item_name = "法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 6, item_no = 2, item_name = "個人事業主" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 6, item_no = 3, item_name = "個人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 7, item_no = 1, item_name = "住宅用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 7, item_no = 2, item_name = "事業用" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 8, item_no = 1, item_name = "事務所・店舗" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 8, item_no = 2, item_name = "飲食店" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 9, item_no = 1, item_name = "新規" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 9, item_no = 2, item_name = "更改" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 10, item_no = 1, item_name = "親権者" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 10, item_no = 2, item_name = "保証会社" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 10, item_no = 3, item_name = "その他" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 11, item_no = 1, item_name = "個人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 11, item_no = 2, item_name = "法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 12, item_no = 1, item_name = "申込書作成" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 13, item_no = 1, item_name = "現金" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 1, item_name = "株式会社" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 2, item_name = "有限会社" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 3, item_name = "合同会社" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 4, item_name = "合資会社" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 5, item_name = "社会福祉法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 6, item_name = "一般財団法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 7, item_name = "公益財団法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 8, item_name = "特定非営利活動法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 9, item_name = "ＮＰＯ法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 10, item_name = "医療法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 11, item_name = "医療法人社団" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 12, item_name = "医療法人財団" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 13, item_name = "社会医療法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 14, item_name = "協同組合" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 15, item_name = "学校法人" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 14, item_no = 16, item_name = "なし" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 15, item_no = 1, item_name = "前" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 15, item_no = 2, item_name = "後" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 16, item_no = 1, item_name = "有効" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 16, item_no = 2, item_name = "無効" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 16, item_no = 3, item_name = "無効(削除)" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 16, item_no = 4, item_name = "無効(名寄せエラー確定)" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 16, item_no = 5, item_name = "無効(当日取消)" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 17, item_no = 1, item_name = "未署名・未入金" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 17, item_no = 2, item_name = "途中保存" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 18, item_no = 1, item_name = "代理店" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 18, item_no = 2, item_name = "BPO" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 18, item_no = 3, item_name = "本部" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 18, item_no = 4, item_name = "契約者直入金" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 18, item_no = 5, item_name = "自動作成" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 18, item_no = 6, item_name = "FAXシステム" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 19, item_no = 1, item_name = "確認書" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 19, item_no = 2, item_name = "契約証" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 19, item_no = 3, item_name = "更新証" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 20, item_no = 1, item_name = "金銭取引" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 21, item_no = 1, item_name = "解約" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 21, item_no = 2, item_name = "取消" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 21, item_no = 3, item_name = "クーリングオフ" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 21, item_no = 4, item_name = "契約者欄の変更" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 21, item_no = 5, item_name = "被保険者欄の変更" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 21, item_no = 6, item_name = "被保険者住所の変更" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 21, item_no = 7, item_name = "支払無取消" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 21, item_no = 8, item_name = "解約削除" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 21, item_no = 9, item_name = "その他異動" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 22, item_no = 1, item_name = "新規" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 22, item_no = 2, item_name = "異動" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 22, item_no = 3, item_name = "解約取消" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 22, item_no = 4, item_name = "更改" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 22, item_no = 5, item_name = "契約移管" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 22, item_no = 6, item_name = "メモ更新" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 23, item_no = 1, item_name = "エラー" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 23, item_no = 2, item_name = "解除" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 23, item_no = 3, item_name = "確定" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 23, item_no = 4, item_name = "対応中" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 23, item_no = 5, item_name = "本社対応" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 25, item_no = 1, item_name = "名寄せ元" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 25, item_no = 2, item_name = "名寄せ対象" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 26, item_no = 1, item_name = "未送付" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 26, item_no = 2, item_name = "送付済" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 26, item_no = 3, item_name = "回収済" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 26, item_no = 4, item_name = "不備" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 26, item_no = 5, item_name = "送付不要" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 27, item_no = 1, item_name = "戻り便" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 27, item_no = 2, item_name = "事務C不備" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 28, item_no = 1, item_name = "未手続き" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 28, item_no = 2, item_name = "手続き済み" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 29, item_no = 1, item_name = "未更新" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 29, item_no = 2, item_name = "更新済" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 29, item_no = 3, item_name = "更新辞退" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 29, item_no = 4, item_name = "更新完了" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 29, item_no = 5, item_name = "代理店手続中" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 29, item_no = 6, item_name = "更新手続中" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 30, item_no = 1, item_name = "途中保存" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 30, item_no = 2, item_name = "名寄せエラー" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 30, item_no = 3, item_name = "未署名・未入金" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 30, item_no = 4, item_name = "未署名" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 30, item_no = 5, item_name = "未入金" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 30, item_no = 6, item_name = "署名済・入金済" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 30, item_no = 7, item_name = "成立" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 31, item_no = 1, item_name = "保険会社" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 31, item_no = 2, item_name = "代理店" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 34, item_no = 1, item_name = "契約" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 34, item_no = 2, item_name = "入金" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 34, item_no = 3, item_name = "解約" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 34, item_no = 4, item_name = "事故支払" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 35, item_no = 1, item_name = "集合住宅" });
            //modelBuilder.Entity<m_master>().HasData(new m_master { m_master_kbn_id = 35, item_no = 2, item_name = "戸建" });
            ////消費税
            //modelBuilder.Entity<m_tax>().HasData(new m_tax { id = 1, kaisibi = "1989/4/1", shuryobi = "1997/3/31", tax = float.Parse("0.03") });
            //modelBuilder.Entity<m_tax>().HasData(new m_tax { id = 2, kaisibi = "1997/4/1", shuryobi = "2014/3/31", tax = float.Parse("0.05") });
            //modelBuilder.Entity<m_tax>().HasData(new m_tax { id = 3, kaisibi = "2014/4/1", shuryobi = "2019/9/30", tax = float.Parse("0.08") });
            //modelBuilder.Entity<m_tax>().HasData(new m_tax { id = 4, kaisibi = "2019/10/1", shuryobi = null, tax = float.Parse("0.1") });

        }
    }
}

