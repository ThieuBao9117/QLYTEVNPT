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
using ThongTinKhachHangModel = App.Models.ThongTinKhachHangs.ThongTinKhachHang;
using App.Models.DKThaus;
using Microsoft.AspNetCore.Http;
using App.Models.ThongTinKhachHangs;


namespace App.Areas.ThongTinKhachHangController.Controllers
{
    public class ThongTinKhachHangController : Controller
    {
        private readonly AppDbContext _context; // DbContext của bạn
        
        public ThongTinKhachHangController(AppDbContext context)
        {
            _context = context;
        }
       public ActionResult MyView()
        {
            var viewModel = new ThongTinKhachHang
            {
                DKThauModel = _context.DKThaus.FirstOrDefault(), // Lấy một bản ghi từ bảng DKThaus (hoặc thay thế bằng cách khác nếu cần)
                ThongTinNhaThauModel = _context.ThongTinNhaThaus.FirstOrDefault() // Lấy một bản ghi từ bảng ThongTinNhaThaus (hoặc thay thế bằng cách khác nếu cần)
            };
            return View(viewModel);
        }
    }
}