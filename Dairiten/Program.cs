using Dairiten.Areas.Identity;
using Dairiten.Data;
using Dairiten.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddErrorDescriber<IdentityErrorDescriberJP>();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/Account/Login", "");
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // パスワードに英数以外を含む必要があるか
    options.Password.RequireNonAlphanumeric = true;
    // パスワードに大文字を含む必要があるか
    options.Password.RequireUppercase = true;
    // パスワードに小文字を含む必要があるか
    options.Password.RequireLowercase = true;
    // パスワードに数値を含む必要があるか
    options.Password.RequireDigit = true;
    //// ロックアウト：何回認証に失敗したらロックアウトするか
    //options.Lockout.MaxFailedAccessAttempts = 5;
});

builder.Services.AddDistributedMemoryCache();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Identity/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

namespace Dairiten
{
    public class Program
    {
        private readonly Dairiten.Data.ApplicationDbContext _context;
        public Program(Dairiten.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //代理店名、コード、募集人キー取得
        public string[] Dairiten_Get(string currentUserId)
        {
            //string currentUserId = User.Identity.GetUserId();
            string[] arr = new string[3];

            var nowData = from m in _context.m_dairiten
                          join t in _context.appUsers
                          on m.id equals t.m_dairiten_id
                          where t.Id == currentUserId
                          select new
                          {
                              d_no = m.dairiten_code,
                              d_name = m.dairiten_mei,
                              bnin_no = t.employee_code
                          };
            nowData.ToList();
            if (nowData != null)
            {
                foreach (var item in nowData)
                {
                    arr[0] = item.d_no;
                    arr[1] = item.d_name;
                    arr[2] = item.bnin_no;
                }
            }

            return arr;
        }

        //全角チェック    
        public static bool IsFullWitdh(string chkStr)
        {
            Encoding shiftjisEnc = Encoding.GetEncoding("Shift_JIS");
            int chrByteNum = shiftjisEnc.GetByteCount(chkStr);
            bool isAllFullWidth = (chrByteNum == chkStr.Length * 2);
            return isAllFullWidth;
        }
    }
}