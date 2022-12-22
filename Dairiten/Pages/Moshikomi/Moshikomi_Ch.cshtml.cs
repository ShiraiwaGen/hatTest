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

        public string kodate = "�ˌ���";

        public string d_no, d_name, bnin_key;

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
            public string shoken_no { get; set; }                  //�،��ԍ�

            [MinLength(10, ErrorMessage = "�،��ԍ��͂P�O���ł��肢���܂�")]
            [StringLength(10, ErrorMessage = "�،��ԍ��͂P�O���ł��肢���܂�")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "���p�p�����̂ݓ��͂ł��܂��B")]
            [Display(Name = "���،��ԍ�")]
            public string old_shoken_no { get; set; }              //���،��ԍ�

            [Required]
            [StringLength(10)]
            [Display(Name = "����ԍ�")]
            public string rireki_no { get; set; }                  //����ԍ�

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "�v�㌎")]
            public DateTime keijozuki { get; set; }                 //�v�㌎

            [Required]
            [Display(Name = "��t�敪")]
            public int uketsuke_kbn { get; set; }                   //��t�敪

            [Required]
            [Display(Name = "���i�敪")]
            public string shohin_kbn { get; set; }                  //���i�敪

            [Required]
            [Display(Name = "�_��ҋ敪")]
            public string keiyakusha_kbn { get; set; }              //�_��ҋ敪

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
            public string hokenkikan { get; set; }                  //�ی�����

            [Display(Name = "�Z��������Ҏ��S��p����")]
            public bool tokuyaku1 { get; set; }                     //�Z��������Ҏ��S��p����

            [Required]
            [Display(Name = "���i�L�[")]
            public string m_shohin_id { get; set; }                    //���i�L�[

            [Phone]
            [StringLength(50, ErrorMessage = "�_��ҘA����͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_��ҘA����")]
            public string? k_tel { get; set; }                      //�_��ҘA����

            [Phone]
            [StringLength(50, ErrorMessage = "�_��Ҍg�т͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_��Ҍg��")]
            public string? k_mobile { get; set; }                   //�_��Ҍg��

            [Display(Name = "�_���_�ˌ���")]
            public string k_kodate { get; set; }                    //�_���_�ˌ���

            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            [Display(Name = "�_���_�����ԍ�")]
            public string? k_bukken_no { get; set; }                //�_���_�����ԍ�

            [Required]
            [StringLength(7, ErrorMessage = "�X�֔ԍ��̓n�C�t���i�|�j�Ȃ��̐����V���ł��肢���܂�")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            [Display(Name = "�_���_�X�֔ԍ�")]
            public string k_zip { get; set; }                      //�_���_�X�֔ԍ�

            [Required]
            [StringLength(55, ErrorMessage = "�Z���i�s���{���s�撬���j�͂T�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�Z���i�s���{���s�撬���j")]
            public string k_address1 { get; set; }                 //�_���_�Z���i�s���{���s�撬���j

            [StringLength(25, ErrorMessage = "�Z���i���ڔԒn�j�͂Q�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�Z���i���ڔԒn�j")]
            public string k_address2 { get; set; }                 //�_���_�Z���i���ڔԒn�j

            [StringLength(50, ErrorMessage = "�Z���i�������j�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�Z���i�������j")]
            public string? k_address3 { get; set; }                 //�_���_�Z���i�������j

            [StringLength(25, ErrorMessage = "�Z���i�����j�͂Q�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�Z���i�����j")]
            public string? k_address4 { get; set; }                 //�_���_�Z���i�����j

            [Required]
            [StringLength(50, ErrorMessage = "�_��Җ��J�i�͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_��Җ��J�i")]
            public string k_kana { get; set; }                      //�_��Җ��J�i

            [Required]
            [StringLength(50, ErrorMessage = "�_��Җ��͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_��Җ�")]
            public string k_name { get; set; }                      //�_��Җ�

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "�_��Ґ��N����")]
            public DateTime k_birth { get; set; }                  //�_��Ґ��N����

            [EmailAddress]
            [Display(Name = "�_���_���[���A�h���X")]
            public string? k_mail { get; set; }                     //�_���_���[���A�h���X

            [Display(Name = "�ۏؐl�敪")]
            public string hoshonin_kbn { get; set; }                //�ۏؐl�敪

            [StringLength(100, ErrorMessage = "�ۏؐl�敪���̑��͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�ۏؐl�敪���̑�")]
            public string? hoshonin_kbn_other { get; set; }         //�ۏؐl�敪���̑�

            [Display(Name = "�����_�����")]
            public bool fukusu_tokuyaku { get; set; }               //�����_�����

            [Display(Name = "�_��҂Ɠ���")]
            public bool k_onaji { get; set; }                       //�_��҂Ɠ���

            [Display(Name = "�ړI�n_�ˌ���")]
            public string h_kodate { get; set; }                      //�ړI�n_�ˌ���

            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            [Display(Name = "�ړI�n_�����ԍ�")]
            public string? h_bukken_no { get; set; }                //�ړI�n_�����ԍ�

            [Required]
            [StringLength(7, ErrorMessage = "�X�֔ԍ��̓n�C�t���i�|�j�Ȃ��̐����V���ł��肢���܂�")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "���p�����̂ݓ��͂ł��܂�")]
            [Display(Name = "�ړI�n_�X�֔ԍ�")]
            public string h_zip { get; set; }                      //�ړI�n_�X�֔ԍ�

            [Required]
            [StringLength(55, ErrorMessage = "�Z���i�s���{���s�撬���j�͂T�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�ړI�n_�Z���i�s���{���s�撬���j")]
            public string h_address1 { get; set; }                 //�ړI�n_�Z���i�s���{���s�撬���j

            [StringLength(25, ErrorMessage = "�Z���i���ڔԒn�j�͂Q�T�����ȓ��ł��肢���܂�")]
            [Display(Name = "�ړI�n_�Z���i���ڔԒn�j")]
            public string h_address2 { get; set; }                 //�ړI�n_�Z���i���ڔԒn�j

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
            public string h_kana { get; set; }                      //��ی��Җ��J�i

            [Required]
            [StringLength(50, ErrorMessage = "��ی��Җ��͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "��ی��Җ�")]
            public string h_name { get; set; }                      //��ی��Җ�

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "��ی��Ґ��N����")]
            public DateTime h_birth { get; set; }                   //��ی��Ґ��N����

            [Required]
            [Display(Name = "�葱�˗������s�敪")]
            public string tetsuzukiiraishohakko_kbn { get; set; }   //�葱�˗������s�敪

            [Required]
            [Display(Name = "�W�����@")]
            public string shukinhoho { get; set; }                  //�W�����@

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
            public string k_hojinmei_kana { get; set; }             //�_���_�@�l��_�J�i

            [Required]
            [StringLength(100, ErrorMessage = "�_���_�@�l��_�����͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�_���_�@�l��_����")]
            public string k_hojinmei_kanji { get; set; }            //�_���_�@�l��_����

            [StringLength(100, ErrorMessage = "�x�X�x�Љc�Ə����͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�x�X�x�Љc�Ə���")]
            public string? shiten { get; set; }                     //�x�X�x�Љc�Ə���

            [Required]
            [StringLength(100, ErrorMessage = @"��\��_��E�͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = @"��\��_��E")]
            public string daihyosha_yakushoku { get; set; }         //��\��_��E

            [Required]
            [StringLength(50, ErrorMessage = @"��\�Җ��͂T�O�����ȓ��ł��肢���܂�")]
            [Display(Name = @"��\�Җ�")]
            public string daihyosha_name { get; set; }               //��\�Җ�

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
            public string h_hojinmei_kana { get; set; }             //��ی���_�@�l��_�J�i

            [Required]
            [StringLength(100, ErrorMessage = "��ی���_�@�l��_�����͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "��ی���_�@�l��_����")]
            public string h_hojinmei_kanji { get; set; }            //��ی���_�@�l��_����

            [Required]
            [StringLength(100, ErrorMessage = "�Ǝ�͂P�O�O�����ȓ��ł��肢���܂�")]
            [Display(Name = "�Ǝ�")]
            public string gyoshu { get; set; }                      //�Ǝ�

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
        }

        //���i�敪
        public string[] shohin_kbns = new string[1];

        //�_��ҋ敪
        public string[] keiyakusha_kbns = new string[1];

        //�ی�����
        public string[] hokenkikans = new[] { "", "�P�N", "�Q�N" };

        //���i�L�[
        public string[] m_shohin_ids = new string[1];

        //�ۏؐl�敪
        public string[] hoshonin_kbns = new string[1];

        //�葱�˗������s
        public string[] tetsuzukiiraishohakko_kbns = new string[1];

        //�W�����@
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

            //���i�敪
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

            //�_��ҋ敪
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

            //���i�L�[
            int m_shohin_ids_cnt = _context.m_shohin.Where(m => m.hokenkikan == 1).Count();//���I�����ꂽ�ی����Ԃŏ��i���i�肽��
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

            //�ۏؐl�敪
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

            //�葱�˗������s
            int tetsuzukiiraishohakko_kbns_cnt = _context.m_master.Where(m => m.m_master_kbn_id == 12).Count();
            Array.Resize(ref tetsuzukiiraishohakko_kbns, tetsuzukiiraishohakko_kbns_cnt);
            var masters4 = _context.m_master.Where(m => m.m_master_kbn_id == 12).ToArray();
            for (int i = 0; i < tetsuzukiiraishohakko_kbns_cnt; i++)
            {
                tetsuzukiiraishohakko_kbns[i] = masters4[i].item_name;
            }

            //�W�����@
            int shukinhohoes_cnt = _context.m_master.Where(m => m.m_master_kbn_id == 13).Count();
            Array.Resize(ref shukinhohoes, shukinhohoes_cnt);
            var masters5 = _context.m_master.Where(m => m.m_master_kbn_id == 13).ToArray();
            for (int i = 0; i < shukinhohoes_cnt; i++)
            {
                shukinhohoes[i] = masters5[i].item_name;
            }

            //�_���_�ˌ���
            Boolean k_kodate = false;
            if (Input.k_kodate == "" || Input.k_kodate == null || Input.k_kodate == "false")
            {
                k_kodate = false;
            }
            else
            {
                k_kodate = true;
            }

            //�ړI�n_�ˌ���
            Boolean h_kodate = false;
            if (Input.h_kodate == "" || Input.h_kodate == null || Input.h_kodate == "false")
            {
                h_kodate = false;
            }
            else
            {
                h_kodate = true;
            }

            // �_��^�C�v�̃v���_�E���őI���������i��ID���擾
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

            // �ۏؐl�敪�̃v���_�E���őI����item_no���擾
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

            // �葱�˗������s�̃v���_�E���őI����item_no���擾
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

            // �W�����@�̃v���_�E���őI����item_no���擾
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
