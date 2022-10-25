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
    // �p�X���[�h�ɉp���ȊO���܂ޕK�v�����邩
    options.Password.RequireNonAlphanumeric = true;
    // �p�X���[�h�ɑ啶�����܂ޕK�v�����邩
    options.Password.RequireUppercase = true;
    // �p�X���[�h�ɏ��������܂ޕK�v�����邩
    options.Password.RequireLowercase = true;
    // �p�X���[�h�ɐ��l���܂ޕK�v�����邩
    options.Password.RequireDigit = true;
    //// ���b�N�A�E�g�F����F�؂Ɏ��s�����烍�b�N�A�E�g���邩
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

        //�㗝�X���A�R�[�h�A��W�l�L�[�擾
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

        //�S�p�`�F�b�N    
        public static bool IsFullWitdh(string chkStr)
        {
            Encoding shiftjisEnc = Encoding.GetEncoding("Shift_JIS");
            int chrByteNum = shiftjisEnc.GetByteCount(chkStr);
            bool isAllFullWidth = (chrByteNum == chkStr.Length * 2);
            return isAllFullWidth;
        }
    }
}