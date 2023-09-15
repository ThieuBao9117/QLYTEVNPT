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
using App.Models.ThongTinNhaThaus;
using App.Models.DKThaus;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace App.Areas.ThongTinNhaThau.Controllers
{
    [Area("ThongTinNhaThau")]
    public class ThongTinNhaThauController : Controller
    {
        private readonly AppDbContext _context;

        public ThongTinNhaThauController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("/dsNhaThau/")]
        [AllowAnonymous]
        public IActionResult dsNhaThau()
        {   
            //var ThongTinNhaThau = _context.ThongTinNhaThaus;
            var DKThau = _context.DKThaus;
            //if(DKThau == null || DKThau.ToList().Count == 0)
            return View(DKThau);
            
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
            var ThongTinNhaThau = _context.ThongTinNhaThaus;
            var DKThaus = _context.DKThaus;
            var model = await ThongTinNhaThau.FirstOrDefaultAsync(m => m.ID == ID);
            if (model == null)
            {
                return NotFound();
            }
            var dsach_thau = await DKThaus.Where(m => m.IDNhaThau == ID).ToListAsync();
            ViewBag.dsach_thau = dsach_thau;
            Console.WriteLine(dsach_thau.Count);
            return View(model);
        }
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
        [HttpPost("/trangthongtin/")]
        [AllowAnonymous]
        public ActionResult trangthongtin(ThongTinNhaThauModel sm, DKThauModel qm, IFormFile file)
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
                Nam = sm.Nam
            };
            _context.ThongTinNhaThaus.Add(thongtinnhathaus);
            _context.SaveChanges();

            DKThauModel dkthaus = new DKThauModel 
            {
                MaST = qm.MaST,
                TenNhaThau = qm.TenNhaThau,
                FileBaoGia = qm.FileBaoGia,
                HSKhac = qm.HSKhac,
                Email = qm.Email,
                DT = qm.DT,
                IDNhaThau = thongtinnhathaus.ID
            };
             if (file != null && file.Length > 0)
            {
        // Lưu trữ tệp trên máy chủ hoặc hệ thống lưu trữ
                var filePath = System.IO.Path.Combine("/Uploads/Products", file.FileName);
                using (var stream = new System.IO.FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
             }
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
            var ThongTinNhaThau = _context.ThongTinNhaThaus;
            var DKThau = _context.DKThaus;
            return View(ThongTinNhaThau);
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
