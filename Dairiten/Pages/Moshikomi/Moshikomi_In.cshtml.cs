using Dairiten.Models;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
//using System.Security.Claims;

namespace Dairiten.Pages
{
    public class Moshikomi_InModel : PageModel
    {
        private readonly Dairiten.Data.ApplicationDbContext _context;

        public Moshikomi_InModel(Dairiten.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public InputModel Input { get; set; } = null!;
        public IList<m_shohin> m_Shohin { get; set; } = null!;
        public IList<m_master> m_Master { get; set; } = null!;

        public string d_no = null!;
        public string d_name = null!;
        public string bnin_key = null!;

        public class InputModel
        {
            [Display(Name = "�_��L�[")]
            public int Id { get; set; }                             //�_��L�[

            [Required]
            [Display(Name = "�㗝�X�L�[")]
            public int m_dairiten_id { get; set; }                  //�㗝�X�L�[

            [Required]
            [Display(Name = "��W�l�L�[")]
            public int employee_key { get; set; }                   //��W�l�L�[

            [Required]
            [MinLength(10, ErrorMessage = "�،��ԍ��͂P�O���ł��肢���܂�")]
            [StringLength(10, ErrorMessage = "�،��ԍ��͂P�O���ł��肢���܂�")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "���p�p�����̂ݓ��͂ł��܂��B")]
            [Display(Name = "�،��ԍ�")]
            public string shoken_no { get; set; } = null!;                  //�،��ԍ�

            [MinLength(10, ErrorMessage = "�،��ԍ��͂P�O���ł��肢���܂�")]
            [StringLength(10, ErrorMessage = "�،��ԍ��͂P�O���ł��肢���܂�")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "���p�p�����̂ݓ��͂ł��܂��B")]
            [Display(Name = "���،��ԍ�")]
            public string old_shoken_no { get; set; } = null!;             //���،��ԍ�

            [Required]
            [StringLength(10)]
            [Display(Name = "����ԍ�")]
            public string rireki_no { get; set; } = null!;                  //����ԍ�

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "�v�㌎")]
            public DateTime keijozuki { get; set; }                 //�v�㌎

            [Required]
            [Display(Name = "��t�敪")]
            public int uketsuke_kbn { get; set; }                   //��t�敪

            [Required]
            [Display(Name = "���i�敪")]
            public string shohin_kbn { get; set; } = null!;                  //���i�敪

            [Required]
            [Display(Name = "�_��ҋ敪")]
            public string keiyakusha_kbn { get; set; } = null!;              //�_��ҋ敪

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = @"�\�����쐬��")]
            public DateTime moshikomisho_day { get; set; }          //�\�����쐬��

            [Required]
            [Display(Name = "�p�@")]
            public int yoho { get; set; }                           //�p�@

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "�ی��n��")]
            public DateTime hokenshiki { get; set; }                //�ی��n��

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "�ی��I��")]
            public DateTime hokenshuki { get; set; }                //�ی��I��

            [Required]
            [Display(Name = "�ی�����")]
            public string hokenkikan { get; set; } = null!;                  //�ی�����

            [Display(Name = "�Z��������Ҏ��S��p����")]
            public bool tokuyaku1 { get; set; }                     //�Z��������Ҏ��S��p����

            [Required]
            [Display(Name = "���i�L�[")]
            public string m_shohin_id { get; set; } = null!;                    //���i�L�[

            [Phone]
            [StringLength(50, ErrorMessage = "�_��ҘA����͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_��ҘA����")]
            public string? k_tel { get; set; }                      //�_��ҘA����

            [Phone]
            [StringLength(50, ErrorMessage = "�_��Ҍg�т͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_��Ҍg��")]
            public string? k_mobile { get; set; }                   //�_��Ҍg��

            [Display(Name = "�_���_�ˌ���")]
            public string k_kodate { get; set; } = null!;                   //�_���_�ˌ���

            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            [Display(Name = "�_���_�����ԍ�")]
            public string? k_bukken_no { get; set; }                //�_���_�����ԍ�

            [Required]
            [StringLength(7, ErrorMessage = "�X�֔ԍ��̓n�C�t���i�|�j�Ȃ��̐����V���ł��肢���܂�")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            [Display(Name = "�_���_�X�֔ԍ�")]
            public string k_zip { get; set; } = null!;                     //�_���_�X�֔ԍ�

            [Required]
            [StringLength(55, ErrorMessage = "�Z���i�s���{���s�撬���j�͂T�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�Z���i�s���{���s�撬���j")]
            public string k_address1 { get; set; } = null!;                 //�_���_�Z���i�s���{���s�撬���j

            [StringLength(25, ErrorMessage = "�Z���i���ڔԒn�j�͂Q�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�Z���i���ڔԒn�j")]
            public string k_address2 { get; set; } = null!;                 //�_���_�Z���i���ڔԒn�j

            [StringLength(50, ErrorMessage = "�Z���i�������j�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�Z���i�������j")]
            public string? k_address3 { get; set; }                 //�_���_�Z���i�������j

            [StringLength(25, ErrorMessage = "�Z���i�����j�͂Q�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�Z���i�����j")]
            public string? k_address4 { get; set; }                 //�_���_�Z���i�����j

            [Required]
            [StringLength(50, ErrorMessage = "�_��Җ��J�i�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_��Җ��J�i")]
            public string k_kana { get; set; } = null!;                      //�_��Җ��J�i

            [Required]
            [StringLength(50, ErrorMessage = "�_��Җ��͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_��Җ�")]
            public string k_name { get; set; } = null!;                      //�_��Җ�

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "�_��Ґ��N����")]
            public DateTime k_birth { get; set; }                  //�_��Ґ��N����

            [EmailAddress]
            [Display(Name = "�_���_���[���A�h���X")]
            public string? k_mail { get; set; }                     //�_���_���[���A�h���X

            [Display(Name = "�ۏؐl�敪")]
            public string hoshonin_kbn { get; set; } = null!;               //�ۏؐl�敪

            [StringLength(100, ErrorMessage = "�ۏؐl�敪���̑��͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�ۏؐl�敪���̑�")]
            public string? hoshonin_kbn_other { get; set; }         //�ۏؐl�敪���̑�

            [Display(Name = "�����_�����")]
            public bool fukusu_tokuyaku { get; set; }               //�����_�����

            [Display(Name = "�_��҂Ɠ���")]
            public bool k_onaji { get; set; }                       //�_��҂Ɠ���

            [Display(Name = "�ړI�n_�ˌ���")]
            public string h_kodate { get; set; } = null!;                   //�ړI�n_�ˌ���

            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            [Display(Name = "�ړI�n_�����ԍ�")]
            public string? h_bukken_no { get; set; }                //�ړI�n_�����ԍ�

            [Required]
            [StringLength(7, ErrorMessage = "�X�֔ԍ��̓n�C�t���i�|�j�Ȃ��̐����V���ł��肢���܂�")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            [Display(Name = "�ړI�n_�X�֔ԍ�")]
            public string h_zip { get; set; } = null!;                     //�ړI�n_�X�֔ԍ�

            [Required]
            [StringLength(55, ErrorMessage = "�Z���i�s���{���s�撬���j�͂T�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�ړI�n_�Z���i�s���{���s�撬���j")]
            public string h_address1 { get; set; } = null!;                //�ړI�n_�Z���i�s���{���s�撬���j

            [StringLength(25, ErrorMessage = "�Z���i���ڔԒn�j�͂Q�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�ړI�n_�Z���i���ڔԒn�j")]
            public string h_address2 { get; set; } = null!;                 //�ړI�n_�Z���i���ڔԒn�j

            [StringLength(50, ErrorMessage = "�Z���i�������j�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�ړI�n_�Z���i�������j")]
            public string? h_address3 { get; set; }                 //�ړI�n_�Z���i�������j

            [StringLength(25, ErrorMessage = "�Z���i�����j�͂Q�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�ړI�n_�Z���i�����j")]
            public string? h_address4 { get; set; }                 //�ړI�n_�Z���i�����j

            [Required]
            [Display(Name = "��ی��ҋ敪")]
            public int hihokensha_kbn { get; set; }                 //��ی��ҋ敪

            [Required]
            [StringLength(50, ErrorMessage = "��ی��Җ��J�i�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "��ی��Җ��J�i")]
            public string h_kana { get; set; } = null!;                     //��ی��Җ��J�i

            [Required]
            [StringLength(50, ErrorMessage = "��ی��Җ��͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "��ی��Җ�")]
            public string h_name { get; set; } = null!;                      //��ی��Җ�

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "��ی��Ґ��N����")]
            public DateTime h_birth { get; set; }                   //��ی��Ґ��N����

            [Required]
            [Display(Name = "�葱�˗������s�敪")]
            public string tetsuzukiiraishohakko_kbn { get; set; } = null!;   //�葱�˗������s�敪

            [Required]
            [Display(Name = "�W�����@")]
            public string shukinhoho { get; set; } = null!;                  //�W�����@

            [Display(Name = "���̕ی�")]
            public bool other_hoken { get; set; }                   //���̕ی�

            [Display(Name = "���̕ی�_���ЗL��")]
            public bool other_hoken_umu { get; set; }               //���̕ی�_���ЗL��

            [StringLength(50, ErrorMessage = "���̕ی�_�ی���Ж��͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "���̕ی�_�ی���Ж�")]
            public string? other_hoken_company { get; set; }        //���̕ی�_�ی���Ж�

            [StringLength(50, ErrorMessage = "���̕ی�_�ی���ނ͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "���̕ی�_�ی����")]
            public string? other_hoken_shurui { get; set; }         //���̕ی�_�ی����

            [DataType(DataType.Date)]
            [Display(Name = "���̕ی�_������")]
            public DateTime other_hoken_manki { get; set; }         //���̕ی�_������

            [Display(Name = "���̕ی�_�ی����z")]
            public int other_hoken_money { get; set; }              //���̕ی�_�ی����z

            [Display(Name = "�ی��_��ؗv")]
            public bool hokenkeiyakusho_kbn { get; set; }           //�ی��_��ؗv

            [Display(Name = "���̑�_�R�[�h1")]
            public int other_code1 { get; set; }                    //���̑�_�R�[�h1

            [Display(Name = "���̑�_�R�[�h2")]
            public int other_code2 { get; set; }                    //���̑�_�R�[�h2

            [Display(Name = "���̑�_�R�[�h3")]
            public int other_code3 { get; set; }                    //���̑�_�R�[�h3

            [StringLength(100, ErrorMessage = "���̑�_���L�����͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "���̑�_���L����")]
            public string? other_tokkijiko { get; set; }            //���̑�_���L����

            [Required]
            [Display(Name = "�_���_�@�l�`��")]
            public int k_hojinkeitai { get; set; }                  //�_���_�@�l�`��

            [StringLength(50, ErrorMessage = "�_���_�@�l�`�Ԃ��̑��͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�@�l�`�Ԃ��̑�")]
            public string? k_hojinkeitai_other { get; set; }        //�_���_�@�l�`�Ԃ��̑�

            [Required]
            [Display(Name = "�_���_�@�l�`�Ԉʒu")]
            public int k_hojinkeitai_ichi { get; set; }             //�_���_�@�l�`�Ԉʒu

            [Required]
            [StringLength(100, ErrorMessage = "�_���_�@�l��_�J�i�͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�@�l��_�J�i")]
            public string k_hojinmei_kana { get; set; } = null!;             //�_���_�@�l��_�J�i

            [Required]
            [StringLength(100, ErrorMessage = "�_���_�@�l��_�����͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�@�l��_����")]
            public string k_hojinmei_kanji { get; set; } = null!;            //�_���_�@�l��_����

            [StringLength(100, ErrorMessage = "�x�X�x�Љc�Ə����͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�x�X�x�Љc�Ə���")]
            public string? shiten { get; set; }                     //�x�X�x�Љc�Ə���

            [Required]
            [StringLength(100, ErrorMessage = @"��\��_��E�͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = @"��\��_��E")]
            public string daihyosha_yakushoku { get; set; } = null!;         //��\��_��E

            [Required]
            [StringLength(50, ErrorMessage = @"��\�Җ��͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = @"��\�Җ�")]
            public string daihyosha_name { get; set; } = null!;               //��\�Җ�

            [Display(Name = "�@�l����")]
            public bool hojin_tokuyaku { get; set; }                //�@�l����

            [Required]
            [Display(Name = "��ی���_�@�l�`��")]
            public int h_hojinkeitai { get; set; }                  //��ی���_�@�l�`��

            [StringLength(50, ErrorMessage = "��ی���_�@�l�`�Ԃ��̑��͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "��ی���_�@�l�`�Ԃ��̑�")]
            public string? h_hojinkeitai_other { get; set; }        //��ی���_�@�l�`�Ԃ��̑�

            [Required]
            [Display(Name = "��ی���_�@�l�`�Ԉʒu")]
            public int h_hojinkeitai_ichi { get; set; }             //��ی���_�@�l�`�Ԉʒu

            [Required]
            [StringLength(100, ErrorMessage = "��ی���_�@�l��_�J�i�͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "��ی���_�@�l��_�J�i")]
            public string h_hojinmei_kana { get; set; } = null!;            //��ی���_�@�l��_�J�i

            [Required]
            [StringLength(100, ErrorMessage = "��ی���_�@�l��_�����͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "��ی���_�@�l��_����")]
            public string h_hojinmei_kanji { get; set; } = null!;           //��ی���_�@�l��_����

            [Required]
            [StringLength(100, ErrorMessage = "�Ǝ�͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�Ǝ�")]
            public string gyoshu { get; set; } = null!;                      //�Ǝ�

            [Display(Name = "�Ǝ�m�F�ς�")]
            public string? gyoshu_sumi { get; set; }                //�Ǝ�m�F�ς�

            [Required]
            [Display(Name = "��L�ʐ�")]
            public int senyumenseki { get; set; }                   //��L�ʐ�

            [Display(Name = "�_���_�t���A�[�؂�")]
            public bool k_floor { get; set; }                       //�_���_�t���A�[�؂�

            [Display(Name = "�ړI�n_�t���A�[�؂�")]
            public bool h_floor { get; set; }                       //�ړI�n_�t���A�[�؂�

            [StringLength(50, ErrorMessage = "�_���_�����͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_����")]
            public string? k_yago { get; set; }                       //�_���_����

            [StringLength(50, ErrorMessage = "�_���_�����͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_����")]
            public string? k_katagaki { get; set; }                   //�_���_����

            [StringLength(50, ErrorMessage = "��ی���_�����͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "��ی���_����")]
            public string? h_yago { get; set; }                       //��ی���_����

            [StringLength(50, ErrorMessage = "��ی���_�����͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "��ی���_����")]
            public string? h_katagaki { get; set; }                   //��ی���_����

            [Display(Name = "�������")]
            public bool shomei { get; set; }                        //�������

            [Display(Name = "�ӌ��m�F")]
            public bool ikokakunin { get; set; }                    //�ӌ��m�F

            [DataType(DataType.Date)]
            [Display(Name = "�ی����̎���")]
            public DateTime hokenryo_ryoshubi { get; set; }         //�ی����̎���

            [Display(Name = "�ی����̎��z")]
            public int hokenryo_ryoshugaku { get; set; }            //�ی����̎��z

            [Required]
            [Display(Name = "�L�����")]
            public int yukojotai { get; set; }                      //�L�����

            [Required]
            [Display(Name = @"�\����")]
            public int moshikomijokyo { get; set; }                 //�\����

            [Display(Name = "���q���ܐ�p�y�[�W")]
            public bool customer_page { get; set; }                 //���q���ܐ�p�y�[�W

            [StringLength(50, ErrorMessage = "���q���ܐ�p�y�[�WID�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "���q���ܐ�p�y�[�WID")]
            public string? customer_id { get; set; }                //���q���ܐ�p�y�[�WID

            [StringLength(10, ErrorMessage = "���q���܃p�X���[�h�͂P�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "���q���܃p�X���[�h")]
            public string? customer_pass { get; set; }              //���q���܃p�X���[�h

            [DataType(DataType.Date)]
            [Display(Name = "���q���܃p�X���[�h�ύX��")]
            public DateTime customer_pass_day { get; set; }         //���q���܃p�X���[�h�ύX��

            [Required]
            [Display(Name = "���͎ҋ敪")]
            public int inputter_kbn { get; set; }                   //���͎ҋ敪

            [DataType(DataType.Date)]
            [Display(Name = "�_��،��̎���_���s��")]
            public DateTime keiyakusho_hakkobi { get; set; }        //�_��،��̎���_���s��

            [Required]
            [Display(Name = "�����،�")]
            public int hakkenshoken { get; set; }                   //�����،�

            [Required]
            [Display(Name = "�ی�������敪")]
            public int hokenryotorihiki_kbn { get; set; }           //�ی�������敪

            [Required]
            [Display(Name = "�ٓ����R")]
            public int idojiyu { get; set; }                        //�ٓ����R

            [Required]
            [Display(Name = "�_���")]
            public int keiyakujokyo { get; set; }                   //�_���

            [DataType(DataType.Date)]
            [Display(Name = "�_���")]
            public DateTime keiyakubi { get; set; }                 //�_���

            [DataType(DataType.Date)]
            [Display(Name = "�����")]
            public DateTime kaishubi { get; set; }                  //�����

            [Display(Name = "���_��L�[")]
            public int old_keiyaku_key { get; set; }                //���_��L�[

            [Display(Name = "�ŐV�t���O")]
            public bool saishin_flg { get; set; }                   //�ŐV�t���O

            [DataType(DataType.Date)]
            [Display(Name = "�����N��")]
            public DateTime manki_nengetsu { get; set; }            //�����N��

            [Required]
            [Display(Name = "�����[���t�敪")]
            public int haraikomihyo_kbn { get; set; }               //�����[���t�敪

            [Display(Name = "�߂��")]
            public bool modoribin { get; set; }                     //�߂��

            [Display(Name = "�ꎞ�ۑ�")]
            public bool ichijihozon { get; set; }                   //�ꎞ�ۑ�

            [DataType(DataType.Date)]
            [Display(Name = "�m���")]
            public DateTime kakuteibi { get; set; }                 //�m���

            [DataType(DataType.Date)]
            [Display(Name = "������")]
            public DateTime seiritsubi { get; set; }                //������

            [Display(Name = "�Ǘ��O�ٓ�")]
            public string? kanrigaiido { get; set; }                //�Ǘ��O�ٓ�

            [Required]
            [Display(Name = @"�\�������t�L�[")]
            public int t_moshikomisho_id { get; set; }              //�\�������t�L�[

            [Display(Name = "�X�V���")]
            public int update_kbn { get; set; }                     //�X�V���

            [DataType(DataType.Date)]
            [Display(Name = "�X�V������")]
            public DateTime update_day { get; set; }                //�X�V������

            [Required]
            [Display(Name = "�ی���")]
            public int hokenryo { get; set; }                       //�ی���

            [Required]
            [Display(Name = "�㗝�X�萔����")]
            public float dairiten_ritsu { get; set; }               //�㗝�X�萔����

            [Required]
            [Display(Name = "������")]
            public int seiritsujokyo { get; set; }                  //������

            [Display(Name = "�����L�[")]
            public int t_nyukin_id { get; set; }                    //�����L�[

            [DataType(DataType.Date)]
            [Display(Name = @"�\����")]
            public DateTime moshikomibi { get; set; }               //�\����

            [StringLength(50, ErrorMessage = "����͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "����")]
            public string? tokuyaku2 { get; set; }                  //����

            [Display(Name = "�s�����R")]
            public string? fubiriyu { get; set; }                   //�s�����R

            [Display(Name = "�폜�t���O")]
            public bool del_flg { get; set; }                       //�폜�t���O

            [StringLength(50, ErrorMessage = "�x������͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�x������")]
            public string? shiharaisaki { get; set; }               //�x������

            [StringLength(50, ErrorMessage = "���Z�@�ւ͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "���Z�@��")]
            public string? bank { get; set; }                       //���Z�@��

            [StringLength(50, ErrorMessage = "���Z�@��_�x�X�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "���Z�@��_�x�X")]
            public string? bank_shiten { get; set; }                //���Z�@��_�x�X

            [StringLength(50, ErrorMessage = "������ڂ͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�������")]
            public string? bank_account_type { get; set; }          //�������

            [StringLength(50, ErrorMessage = "�ʒ��L���͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�ʒ��L��")]
            public string? passbook_symbol { get; set; }            //�ʒ��L��

            [StringLength(10, ErrorMessage = "�����ԍ��͂P�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�����ԍ�")]
            public string? bank_account_no { get; set; }            //�����ԍ�

            [StringLength(50, ErrorMessage = "�������`�l�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�������`�l")]
            public string? bank_account_holder { get; set; }        //�������`�l

            [StringLength(50, ErrorMessage = "�������`�J�i�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�������`�J�i")]
            public string? bank_account_holder_kana { get; set; }   //�������`�J�i

            [Display(Name = "�Ԗߋ�")]
            public int henreikin { get; set; }                      //�Ԗߋ�

            [DataType(DataType.Date)]
            [Display(Name = "�Ԗߋ��o�^��")]
            public DateTime henreikin_day { get; set; }             //�Ԗߋ��o�^��

            [DataType(DataType.Date)]
            [Display(Name = "�X�V�N��")]
            public DateTime koshin_nengetsu { get; set; }           //�X�V�N��

            [Required]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM}")]
            [Display(Name = @"���t�\�茎")]
            public DateTime sofuyoteizuki { get; set; }             //���t�\�茎

            [Display(Name = "�萔��")]
            public int dairiten_tesuryo { get; set; }               //�萔��

            [Display(Name = "�����ی���")]
            public int shomihokenryo { get; set; }                  //�����ی���

            [Display(Name = "�����L�[")]
            public int t_seikyu_id { get; set; }                    //�����L�[

            [Display(Name = "�퐶�t���O")]
            public bool yayoi_flg { get; set; }                     //�퐶�t���O

            [DataType(DataType.Date)]
            [Display(Name = "�o�^��")]
            public DateTime torokubi { get; set; }                  //�o�^��

            [Required]
            [Display(Name = "���t�敪")]
            public int sofu_kbn { get; set; }                      //���t�敪

            public string ji_k_kodate { get; set; } = null!;                //���Ɨp�_���_�ˌ���
            public string ji_h_kodate { get; set; } = null!;               //���Ɨp�ړI�n_�ˌ���
            public string ji_tetsuzukiiraishohakko_kbn { get; set; } = null!;   //���Ɨp�葱�˗������s�敪
        }





        public async Task OnGetAsync()
        {
            m_Shohin = await _context.m_shohin.ToListAsync();
            m_Master = await _context.m_master.ToListAsync();

            var pm = new Program(_context);

            //string[] arr = pm.Dairiten_Get(User.Identity.GetUserId());
            //var employeeCode = HttpContext.Session.GetString("employee_code");

            var ap = new AppUser();
            //var employeeCode = ap.Id;


            var employeeCode = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (employeeCode != null)
            {
                string[] arr = pm.Dairiten_Get(employeeCode);
                d_no = arr[0];
                d_name = arr[1];
                bnin_key = arr[2];
            }
        }
        public void OnPost()
        {
            int hojinkeitai_num = -1;      //�@�l�`��

            //�@�l�`�Ԃ��擾
            string hojinkeitai_selected = (string)Request.Form["hojinkeitai"];
            if (!string.IsNullOrEmpty(hojinkeitai_selected))
            {
                foreach (var master in _context.m_master.Where(m => m.m_master_kbn_id == 14))
                {
                    if (hojinkeitai_selected.Equals(master.item_name))
                    {
                        hojinkeitai_num = master.item_no;
                        break;
                    }
                }
            }
        }
    }
}
