using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using App.Data;
using ThongTinNhaThauModel = App.Models.ThongTinNhaThaus.ThongTinNhaThau;
using DKThauModel = App.Models.DKThaus.DKThau;
using ThongTinKhachHangModel= App.Models.ThongTinKhachHangs.ThongTinKhachHang;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.AspNetCore.Identity;
using App.Models.Product;

namespace App.Areas.ThongTinNhaThau.Controllers
{
    [Area("ThongTinNhaThau")]
    public class ThongTinNhaThauController : Controller
    {
        private readonly AppDbContext _context;
        
        private readonly UserManager<AppUser> _userManager;

        public ThongTinNhaThauController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
           Initialize();
            
        }
              private async void Initialize()
        {
             if (User != null)
                {
                    var user = await _userManager.GetUserAsync(User);

                    if (user != null)
                    {
                        var userId = user.Id;
                        var userName =user.UserName;
                        
                        ViewBag.UserName = user.UserName;
                        Console.WriteLine(userId);
                        Console.WriteLine(userName);
                    }
                }
            
        }

        [HttpGet("/dsNhaThau/")]
        [AllowAnonymous]
        public IActionResult dsNhaThau()
        {   
            //var ThongTinNhaThau = _context.ThongTinNhaThaus;
            var DKThauList = _context.DKThaus.ToList();
            //if(DKThau == null || DKThau.ToList().Count == 0)
            return View(DKThauList);
            
        }
     // thông tin nhà thầu detail
        [HttpGet("dsNhaThau/detail/{ID}")]
        public async Task<IActionResult> Details1(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var DKThau = await _context.DKThaus
                .FirstOrDefaultAsync(m => m.ID == ID);
            if (DKThau == null)
            {
                return NotFound();
            }
            // var ThongTinNhaThau = _context.ThongTinNhaThaus;
           
            var DKThaus = _context.DKThaus;
            var ThongTinNhaThauData = await _context.ThongTinNhaThaus.FirstOrDefaultAsync(m => m.ID == ID);
            if (ThongTinNhaThauData == null)
            {
                return NotFound();
            } 
            var product = _context.Products;
            var dsach_thau = await DKThaus.Where(m => m.IDNhaThau == ID).ToListAsync();
            if(dsach_thau.Count > 0) {
                ViewBag.dsach_thau = dsach_thau[0];
                ViewBag.ThongTinNhaThauData = ThongTinNhaThauData;
                ViewBag.User = User;
                
            }
            // var dataNguoiDKDuAn = await TableNguoiDkyDuAn.Where(m => m.IDNhaThau == ID).ToListAsync();
            // ViewBag.dataNguoiDKDuAn = dataNguoiDKDuAn;
            // Console.WriteLine(ViewBag.dsach_thau.TenNhaThau);
            Console.WriteLine(ViewBag.ThongTinNhaThauData.ID);
            // Console.WriteLine(ViewBag.ThongTinNhaThauData.TenDA.ToString());
            Console.WriteLine(ViewBag.ThongTinNhaThauData.Ten);
            // Console.WriteLine(ViewBag.ThongTinNhaThauData.MoTa);
            return View();
        }
      
    //     [HttpGet("dsNhaThau/detail/{ID}")]
    // public async Task<IActionResult> Details1(int? ID)
    // {
        
    //     if (ID == null)
    //     {
    //         return NotFound();
    //     }

    //     var thongTinNhaThau = await _context.ThongTinNhaThaus
    //         .FirstOrDefaultAsync(ttnh => ttnh.ID == ID);

    //     if (thongTinNhaThau == null)
    //     {
    //         return NotFound();
    //     }

    //     var dsach_thau = await _context.DKThaus
    //         .Where(dkt => dkt.IDNhaThau == ID)
    //         .ToListAsync();

    //     var viewModel = new ThongTinKhachHangModel
    //     {
            
    //         DKThaus = dsach_thau
    //     };

    //     ViewBag.thongTinNhaThau = thongTinNhaThau;
    //     ViewBag.dsach_thau = dsach_thau;

    //     return View();
    // }

        
        //xóa 1 nhà thầu
         [HttpGet("dsNhaThau/delete/{ID}")]
        public async Task<IActionResult> Delete1(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var DKThau = await _context.DKThaus
                .FirstOrDefaultAsync(m => m.ID == ID);
            if (DKThau == null)
            {
                return NotFound();
            }
            
            

            return View(DKThau);
        }
        
        [HttpPost("dsNhaThau/delete/{ID}"), ActionName("Delete1")]
        public async Task<IActionResult> DeleteConfirmed(int ID)
        {
            Console.WriteLine("delete test ====");
            var DKThaus = await _context.DKThaus.FindAsync(ID);
            _context.DKThaus.Remove(DKThaus);
            await _context.SaveChangesAsync();
            // return RedirectToAction("/dsNhaThau");
            return RedirectToAction(nameof(dsNhaThau));
        }


        [HttpPost("/trangthongtin/")]
        [AllowAnonymous]
        public ActionResult trangthongtin(ThongTinNhaThauModel sm, DKThauModel _DKThau, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                // Nếu thông tin không hợp lệ, quay lại trang nhập
                 return View("ThongTinNhaThau", sm); // Create là tên view hiển thị biểu mẫu nhập thông tin
            }
            ViewBag.Ten = sm.Ten;
            ViewBag.TenDA = sm.TenDA;
            ViewBag.Nam = sm.Nam;
            

            ThongTinNhaThauModel thongtinnhathaus = new ThongTinNhaThauModel
            {
                Ten = sm.Ten,
                TenDA = sm.TenDA,
                Nam = sm.Nam,
                NguoiLienHe = sm.NguoiLienHe,
                Email =sm.Email,
                DThoai= sm.DThoai
            };
            _context.ThongTinNhaThaus.Add(thongtinnhathaus);
            _context.SaveChanges();

            DKThauModel dkthaus = new DKThauModel 
            {
                MaST = _DKThau.MaST,
                TenNhaThau = _DKThau.TenNhaThau,
                EmailLH = _DKThau.EmailLH,
                DT = _DKThau.DT,
                NguoiLH = _DKThau.NguoiLH,
                Ngay =_DKThau.Ngay,
                IDNhaThau = thongtinnhathaus.ID,

                BangBaoGia = _DKThau.BangBaoGia,
                FileBaoGia = _DKThau.FileBaoGia,
                HSKhac = _DKThau.HSKhac
            };

            _context.DKThaus.Add(dkthaus);
            _context.SaveChanges();
            TempData["ConfirmationMessage"] = "Thông Tin Đã Được Gửi Về";
            //return View("Index");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        // xuất file excel
        
        
        [HttpGet("/trangthongtin/")]
        [AllowAnonymous]
        public IActionResult Index()
        {
           
            if (HttpContext.Request.Query.TryGetValue("productid", out var productIdString) && int.TryParse(productIdString, out var productId))
            {
                var product = _context.Products
                .Where (p => p.ProductID == productId)
                .FirstOrDefault ();
                if (product == null)
                    return NotFound ("Không có sản phẩm");
                Console.WriteLine(product.AuthorId);
                App.Models.AppUser User = _context.Users.FirstOrDefault(p=> p.Id == product.AuthorId);
                if( User == null) return NotFound("Khong ton tai user");
                ViewBag.User = User;
                ViewBag.Product = product;
            }
            else
            {
                return NotFound();
            }
            var Categories = _context.CategoryProducts.Select( i=> new SelectListItem {
                      Value=i.Id.ToString(),
                      Text=i.Title 
                    }).ToList();

            Console.WriteLine(Categories.Count);
            
            ViewBag.Categories = Categories;

            var ThongTinNhaThau = _context.ThongTinNhaThaus;
            var DKThau = _context.DKThaus;

            return View(ThongTinNhaThau);
        }
       
        [HttpGet("/sort/")]
        [AllowAnonymous]
        public IActionResult DanhSachNhaThau()
            {
                var DKThauList = _context.DKThaus.ToList();
                // Lấy danh sách nhà thầu từ cơ sở dữ liệu và sắp xếp theo thời gian giảm dần
                var danhSachNhaThau = _context.DKThaus.OrderByDescending(item => item.Ngay).ToList();
                
                return View(danhSachNhaThau);
            }
       
        [TempData]
        public string StatusMessage {set; get;}  
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}