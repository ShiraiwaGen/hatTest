using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Text;
using System;
using Dairiten.Models;

namespace Dairiten.Pages.Bukken
{
    public class Bukken_InModel : PageModel
    {
        public class Person
        {
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string? Age { get; set; }
        }
        public List<Person> mylist = new List<Person>();
        public int so_kensu = 0;
        public int err_kensu = 0;

        [BindProperty]
        public string file_name { get; set; }

        public void OnGet()
        {
        }

        public void OnPost() {
            // Shift-JISで出力されるので合わせる
 //           var path = @"C:\Users\a.hasegawa\source\repos\csv_get\csv\person1.csv";

            //if (File.Exists(filePath))
            //{
            //    // filePathのファイルは存在する
            //}
            //else
            //{
            //    // filePathのファイルは存在しない
            //}

            if(file_name == null)       
            {
                return;
            }

            // 初期化
            string line;

            // ファイルを開く
            using (StreamReader sr = new StreamReader(file_name))
            {                
                // 1行目(項目名)読み捨てる
                sr.ReadLine();
                string e_color = " class= 'error_color'";

                // ファイルの内容を1行づ読み込み
                while ((line = sr.ReadLine()) != null)
                {
                    so_kensu++;

                    // カンマで分割
                    var values = line.Split(',');
                    if (values.Length != 3)
                    {
                        // throw new Exception("CSV format error");
                        err_kensu++;
                    }
                    else
                    {
                        try
                        {
                            // オブジェクト作成
                            string id;
                            string name;
                            string age;
                            Boolean e_cellflg;
                            Boolean e_rowflg = false;
                            var result = 0;

                            //id
                            e_cellflg = false;
                            if (int.TryParse(values[0], out result) != true)
                            {
                                id = "<span title = '数値以外が入力されています。'>" + values[0] + "</span>";
                                e_cellflg = true;
                            }
                            else
                            {
                                id = values[0];
                            }
                            if (e_cellflg == true)
                            {
                                id = "<td" + e_color + ">" + id + "</td>";
                                e_rowflg = true;
                            }
                            else
                            {
                                id = "<td>" + id + "</td>";
                            }
                            //Name
                            e_cellflg = false;
                            if (values[1].Length > 10)
                            {
                                name = "<span title = '文字数が大きいです。'>" + values[1] + "</span>";
                                e_cellflg = true;
                            }
                            else
                            {
                                name = values[1];
                            }
                            if (e_cellflg == true)
                            {
                                name = "<td" + e_color + ">" + name + "</td>";
                                e_rowflg = true;
                            }
                            else
                            {
                                name = "<td>" + name + "</td>";
                            }
                            //Age
                            result = 0;
                            e_cellflg = false;
                            if (int.TryParse(values[2], out result) != true)
                            {
                                age = "<span title = '数値以外が入力されています。'>" + values[2] + "</span>";
                                e_cellflg = true;
                            }
                            else
                            {
                                age = values[2];
                            }
                            if (e_cellflg == true)
                            {
                                age = "<td" + e_color + ">" + age + "</td>";
                                e_rowflg = true;
                            }
                            else
                            {
                                age = "<td>" + age + "</td>";
                            }

                            if(e_rowflg == true)
                            {
                                err_kensu++;
                            }

                            mylist.Add(new Person { Id = id, Name = name, Age = age });
                        }
                        catch (Exception)
                        {
                            //              throw new Exception("CSV format error");
                        }
                    }
                }
            }
        }
    }
}