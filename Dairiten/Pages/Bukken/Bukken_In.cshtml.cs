using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Text;
using System;
using Dairiten.Models;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Dairiten.Data;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis.Scripting;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Dairiten.Pages.Bukken
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class Bukken_InModel : PageModel
    {
        private readonly Dairiten.Data.ApplicationDbContext _context;
        public Bukken_InModel(Dairiten.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //��ʕ\���p(html�^�O����)
        public class Bukken1
        {
            public string? b_count2 { get; set; }
            public string? bukken_no { get; set; }
            public string? b_zip { get; set; }
            public string? b_address1 { get; set; }
            public string? b_address2 { get; set; }
            public string? b_address3 { get; set; }
            public string? b_address4 { get; set; }
            public string? b_address5 { get; set; }
            public string? b_kodate { get; set; }
            public string? d_code { get; set; }
        }
        public List<Bukken1> mylist = new List<Bukken1>();

        //���e�[�u���o�^�p
        //public class t_karibukken
        //{
        //    public string bukken_no { get; set; }
        //    public int b_zip { get; set; }
        //    public string b_address1 { get; set; }
        //    public string b_address2 { get; set; }
        //    public string? b_address3 { get; set; }
        //    public string? b_address4 { get; set; }
        //    public string? b_address5 { get; set; }
        //    public int b_kodate { get; set; }
        //    public int m_dairiten_id { get; set; }
        //    public int employee_key { get; set; }
        //}
        public t_karibukken t_karibukken;

        public int so_kensu = 0;
        public int err_kensu = 0;

        [BindProperty(SupportsGet = true)]
        public IFormFile? formfile { get; set; }
        public Boolean eflg { get; set; } = true;
        public String error_msg { get; set; } = "";
        public String kanryo_msg { get; set; } = "";

        public string d_no, d_name;
        public int d_id, bnin_id;
        public void main_data()
        {
            var pm = new Program(_context);
            string[] arr = pm.Dairiten_Get(User.Identity.GetUserId());
            d_no = arr[0];
            d_name = arr[1];
            //bnin_no = arr[2];
            d_id = Int32.Parse(arr[3]);
            bnin_id = Int32.Parse(arr[4]);
        }

        public void OnGet()
        {
            //string[] arr = Index1Model_Model.Dairiten_Get();
            main_data();

            //if ( Program_Model.IsFullWitdh1("������e��") == true)
            //{
            //    Console.Write("true");
            //}
            //else
            //{
            //    Console.Write("false");
            //}
        }

        //public async Task OnGetAsync()
        //{
        //    m_Dairiten = await _context.m_dairiten.ToListAsync();
        //}

        public void OnPostClearBtn()
        {
            main_data();
        }

        public void OnPostHandle1()
        {
            main_data();

            //�t�@�C���`�F�b�N
            //if (File.Exists(filePath))
            //{
            //    // filePath�̃t�@�C���͑��݂���
            //}
            //else
            //{
            //    // filePath�̃t�@�C���͑��݂��Ȃ�
            //}

            if (formfile == null)
            {
                error_msg = "�t�@�C�����w�肳��Ă��܂���B";
                return;
            }

            //��W�l�L�[����v�����S�폜
            if (bnin_id == 0)
            {
                error_msg = "��W�l�L�[�̎擾�Ɏ��s���܂����B";
                return;
            }
            //var del_person = _context.Person.Find(p => p.d_key == in_d_key, p => p.b_key == in_b_key);
            var del_karibukken = from p in _context.t_karibukken
                                 where p.employee_key == bnin_id
                                 select p;
            _context.t_karibukken.RemoveRange(del_karibukken);
            _context.SaveChanges();

            // ������
            string line;

            var ms = new MemoryStream();
            formfile.CopyTo(ms);
            // ���ꂵ�Ȃ��ƃ}�b�s���O���Ȃ�����
            ms.Position = 0;
            // �N���X�Ƀ}�b�s���O (Shift-JIS)
            using (var sr = new StreamReader(ms, System.Text.Encoding.GetEncoding("shift_jis")))
            {
                List<t_karibukken> mylist1 = new List<t_karibukken>();

                // 1�s��(���ږ�)�ǂݎ̂Ă�
                sr.ReadLine();

                string e_color = " style = 'background-color:#ff0000;'";
                eflg = false;
                int b_count = 1;

                // �t�@�C���̓��e��1�s�Óǂݍ���
                while ((line = sr.ReadLine()) != null)
                {
                    so_kensu++;

                    // �J���}�ŕ���
                    var values = line.Split(',');
                    if (values.Length != 9)
                    {
                        // throw new Exception("CSV format error");
                        //err_kensu++;  �J���}�̎��s�͌����Ɋ܂߂Ȃ��H
                    }
                    else
                    {
                        try
                        {
                            // �I�u�W�F�N�g�쐬
                            string? b_count2;
                            string? bukken_no;
                            string? b_zip;
                            string? b_address1;
                            string? b_address2;
                            string? b_address3;
                            string? b_address4;
                            string? b_address5;
                            string? b_kodate;
                            string? d_code;
                            int d_key = 0;

                            Boolean e_rowflg = false;
                            string emsg;
                            var result = 0;

                            //�����ԍ�
                            emsg = "";
                            bukken_no = values[0];
                            if (bukken_no == null || bukken_no == "")
                            {
                                //before.PadLeft(10, '0');�@0����
                                //s.TrimStart('0');�͂��߂�0�폜
                            }
                            else
                            {
                                if (int.TryParse(bukken_no, out result) != true)
                                {
                                    emsg = "���l����͂��Ă��������B";
                                    eflg = true;
                                }
                                else
                                {
                                    if (bukken_no.Length > 10)
                                    {
                                        emsg = "�P�O�����ȓ��œ��͂��Ă��������B";
                                    }
                                }
                                if (emsg != "")
                                {
                                    bukken_no = "<td rowspan=2" + e_color + " title='" + emsg + "' >" + bukken_no + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    bukken_no = "<td rowspan=2>" + bukken_no + "</td>";
                                }

                                //�X�֔ԍ�
                                emsg = "";
                                b_zip = values[1];
                                if (b_zip == null || b_zip == "")
                                {
                                    emsg = "���͂��Ă��������B";
                                }
                                else
                                {
                                    if (b_zip.Length != 7)
                                    {
                                        emsg = "�V���œ��͂��Ă��������B";
                                    }
                                    else
                                    {
                                        result = 0;
                                        if (int.TryParse(b_zip, out result) != true)
                                        {
                                            emsg = "���l�݂̂���͂��Ă��������B";
                                            eflg = true;
                                        }
                                    }
                                }
                                if (emsg != "")
                                {
                                    b_zip = "<td rowspan=2" + e_color + " title='" + emsg + "' >" + b_zip + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    b_zip = "<td rowspan=2>" + b_zip + "</td>";
                                }

                                //�Z���i�s���{���s�撬���j
                                emsg = "";
                                b_address1 = values[2];
                                if (b_address1 == null || b_address1 == "")
                                {
                                    emsg = "���͂��Ă��������B";
                                }
                                else
                                {
                                    if (b_address1.Length > 55)
                                    {
                                        emsg = "�T�T�����ȓ��œ��͂��Ă��������B";
                                    }
                                    else
                                    {
                                        if (Program.IsFullWitdh(b_address1) != true)
                                        {
                                            emsg = "�S�p�œ��͂��Ă��������B";
                                        }
                                    }
                                }
                                if (emsg != "")
                                {
                                    b_address1 = "<td" + e_color + " title='" + emsg + "' >" + b_address1 + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    b_address1 = "<td>" + b_address1 + "</td>";
                                }

                                //�Z���i���ڔԒn�j
                                emsg = "";
                                b_address2 = values[3];
                                if (b_address2 == null || b_address2 == "")
                                {
                                    emsg = "���͂��Ă��������B";
                                }
                                else
                                {
                                    if (b_address2.Length > 25)
                                    {
                                        emsg = "�Q�T�����ȓ��œ��͂��Ă��������B";
                                    }
                                    else
                                    {
                                        if (Program.IsFullWitdh(b_address2) != true)
                                        {
                                            emsg = "�S�p�œ��͂��Ă��������B";
                                        }
                                    }
                                }
                                if (emsg != "")
                                {
                                    b_address2 = "<td" + e_color + " title='" + emsg + "' >" + b_address2 + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    b_address2 = "<td>" + b_address2 + "</td>";
                                }

                                //�Z���i�������j
                                emsg = "";
                                b_address3 = values[4];
                                if (b_address3 == null || b_address3 == "")
                                {
                                    // emsg = "���͂��Ă��������B";
                                }
                                else
                                {
                                    if (b_address3.Length > 50)
                                    {
                                        emsg = "�T�O�����ȓ��œ��͂��Ă��������B";
                                    }
                                    else
                                    {
                                        if (Program.IsFullWitdh(b_address3) != true)
                                        {
                                            emsg = "�S�p�œ��͂��Ă��������B";
                                        }
                                    }
                                }
                                if (emsg != "")
                                {
                                    b_address3 = "<td rowspan=2" + e_color + " title='" + emsg + "' >" + b_address3 + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    b_address3 = "<td rowspan=2>" + b_address3 + "</td>";
                                }

                                //�Z���i���ԍ��j
                                emsg = "";
                                b_address4 = values[5];
                                if (b_address4 == null || b_address4 == "")
                                {
                                    // emsg = "���͂��Ă��������B";
                                }
                                else
                                {
                                    if (b_address4.Length > 25)
                                    {
                                        emsg = "�Q�T�����ȓ��œ��͂��Ă��������B";
                                    }
                                    else
                                    {
                                        if (Program.IsFullWitdh(b_address4) != true)
                                        {
                                            emsg = "�S�p�œ��͂��Ă��������B";
                                        }
                                    }
                                }
                                if (emsg != "")
                                {
                                    b_address4 = "<td rowspan=2" + e_color + " title='" + emsg + "' >" + b_address4 + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    b_address4 = "<td rowspan=2>" + b_address4 + "</td>";
                                }

                                //�Z���i�Z���i�����j�j
                                emsg = "";
                                b_address5 = values[6];
                                if (b_address5 == null || b_address5 == "")
                                {
                                    // emsg = "���͂��Ă��������B";
                                }
                                else
                                {
                                    if (b_address5.Length > 25)
                                    {
                                        emsg = "�Q�T�����ȓ��œ��͂��Ă��������B";
                                    }
                                    else
                                    {
                                        if (Program.IsFullWitdh(b_address5) != true)
                                        {
                                            emsg = "�S�p�œ��͂��Ă��������B";
                                        }
                                    }
                                }
                                if (emsg != "")
                                {
                                    b_address5 = "<td rowspan=2" + e_color + " title='" + emsg + "' >" + b_address5 + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    b_address5 = "<td rowspan=2>" + b_address5 + "</td>";
                                }

                                //�ˌ��敪
                                emsg = "";
                                b_kodate = values[7];
                                if (b_kodate == null || b_kodate == "")
                                {
                                    emsg = "���p�� 0 �܂��� 1 ����͂��Ă��������B";
                                }
                                else
                                {
                                    result = 0;
                                    if (int.TryParse(b_kodate, out result) != true)
                                    {
                                        emsg = "���l����͂��Ă��������B";
                                        eflg = true;
                                    }
                                    else
                                    {
                                        if (b_kodate == "0" || b_kodate == "1")
                                        {

                                        }
                                        else
                                        {
                                            emsg = "���p�� 0 �܂��� 1 ����͂��Ă��������B";
                                        }
                                    }
                                }
                                if (emsg != "")
                                {
                                    b_kodate = "<td rowspan=2" + e_color + " title='" + emsg + "' >" + b_kodate + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    if (b_kodate == "1")
                                    {
                                        b_kodate = "<td rowspan=2>�ˌ���</td>";
                                    }
                                    else
                                    {
                                        b_kodate = "<td rowspan=2></td>";
                                    }
                                }

                                //�㗝�X�R�[�h
                                emsg = "";
                                d_code = values[8];
                                if (d_code == null || d_code == "")
                                {
                                    emsg = "���͂��Ă��������B";
                                }
                                else
                                {
                                    var nowData = _context.m_dairiten.SingleOrDefault(p => p.dairiten_code == d_code);
                                    if (nowData == null)
                                    {
                                        emsg = "�o�^����Ă��Ȃ��㗝�X�R�[�h�ł��B";
                                    }
                                    else
                                    {
                                        if (d_no != d_code)
                                        {
                                            emsg = "���O�C�����Ă���㗝�X�ƈႤ�R�[�h�ł��B";
                                        }
                                        else
                                        {
                                            d_code = nowData.dairiten_code + " " + nowData.dairiten_mei;
                                            d_key = nowData.id;
                                        }
                                    }
                                }
                                if (emsg != "")
                                {
                                    d_code = "<td rowspan=2" + e_color + " title='" + emsg + "' >" + d_code + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    d_code = "<td rowspan=2>" + d_code + "</td>";
                                }

                                //�d���`�F�b�N
                                emsg = "";
                                var work_bukken = _context.t_bukken                                    
                                    .Where(x => x.b_zip == values[1])
                                    .Where(x => x.b_address1 == values[2])
                                    .Where(x => x.b_address2 == values[3])
                                    .Where(x => x.b_address3 == values[4])
                                    .Where(x => x.b_address4 == values[5])
                                    .Where(x => x.b_address5 == values[6])
                                    .Where(x => x.m_dairiten_id == d_id)
                                    .Select(x => x.id)
                                    .Count();                                 
                                if (work_bukken != 0)
                                {
                                    emsg = "���ɓo�^�ς݂̏Z���ł��B";
                                }
                                if (emsg != "")
                                {
                                    b_count2 = "<td rowspan=2" + e_color + " title='" + emsg + "' >" + b_count + "</td>";
                                    e_rowflg = true;
                                }
                                else
                                {
                                    b_count2 = "<td rowspan=2>" + b_count + "</td>";
                                }

                                //��`�F�b�N
                                if (e_rowflg == true)
                                {
                                    eflg = true;
                                    err_kensu++;
                                }

                                mylist.Add(new Bukken1 { b_count2 = b_count2, bukken_no = bukken_no, b_zip = b_zip, b_address1 = b_address1, b_address2 = b_address2, b_address3 = b_address3, b_address4 = b_address4, b_address5 = b_address5, b_kodate = b_kodate, d_code = d_code });
                                b_count++;

                                if (eflg == false)
                                {
                                    mylist1.Add(new t_karibukken { bukken_no = values[0], b_zip = values[1], b_address1 = values[2], b_address2 = values[3], b_address3 = values[4], b_address4 = values[5], b_address5 = values[6], b_kodate = Int32.Parse(values[7]), m_dairiten_id = d_key, employee_key = bnin_id });
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //              throw new Exception("CSV format error");
                            eflg = true;
                        }
                    }
                }
                if (eflg == false)
                {
                    //foreach (var item in mylist1)
                    //{
                    //    _context.t_karibukken.Add(item);
                    //}
                    //_context.SaveChanges();
                    foreach (var item in mylist1)
                    {
                        Dairiten.Models.t_karibukken k_bukken = new Dairiten.Models.t_karibukken();

                        k_bukken.bukken_no = item.bukken_no;
                        k_bukken.b_zip = item.b_zip;
                        k_bukken.b_address1 = item.b_address1;
                        k_bukken.b_address2 = item.b_address2;
                        k_bukken.b_address3 = item.b_address3;
                        k_bukken.b_address4 = item.b_address4;
                        k_bukken.b_address5 = item.b_address5;
                        k_bukken.b_kodate = item.b_kodate;
                        k_bukken.m_dairiten_id = item.m_dairiten_id;
                        k_bukken.employee_key = item.employee_key;

                        _context.t_karibukken.Add(k_bukken);
                        _context.SaveChanges();
                    }
                }
            }
        }

        public void OnPostHandle2()
        {
            main_data();
            if (bnin_id == 0)
            {
                error_msg = "��W�l�R�[�h������܂���B";
                return;
            }

            try
            {
                var t_karibukken = _context.t_karibukken
                    .Where(x => x.employee_key == bnin_id)
                    .ToArray();

                foreach (var item in t_karibukken)
                {
                    Dairiten.Models.t_bukken person1 = new Dairiten.Models.t_bukken();

                    person1.bukken_no = item.bukken_no;
                    person1.b_zip = item.b_zip;
                    person1.b_address1 = item.b_address1;
                    person1.b_address2 = item.b_address2;
                    person1.b_address3 = item.b_address3;
                    person1.b_address4 = item.b_address4;
                    person1.b_address5 = item.b_address5;
                    person1.b_kodate = item.b_kodate;
                    person1.m_dairiten_id = item.m_dairiten_id;

                    _context.t_bukken.Add(person1);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                //              throw new Exception("CSV format error");
                return;
            }

            //Response.Write("<script language=JavaScript> alert('�N���C�A���g') </script>");
            //Response.WriteAsync("<script> alert('�捞�݂܂����B') </script>");
            kanryo_msg = "�捞�݂��������܂����B";

        }
    }
}