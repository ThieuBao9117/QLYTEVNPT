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
       
        [HttpPost("/form2/")]
        [AllowAnonymous]
        public ActionResult form2(ThongTinNhaThauModel sm, DKThauModel qm, IFormFile file)
        {
            ViewBag.Ten = sm.Ten;
            ViewBag.TenDA = sm.TenDA;
            ViewBag.Nam = sm.Nam;

            ThongTinNhaThauModel thongtinnhathaus = new ThongTinNhaThauModel
            {
                Ten = sm.Ten,
                TenDA = sm.TenDA,
                Nam = sm.Nam
            };

            DKThauModel dkthaus = new DKThauModel 
            {
                MaST = qm.MaST,
                TenNhaThau = qm.TenNhaThau,
            };
             if (file != null && file.Length > 0)
    {
        // Lưu trữ tệp trên máy chủ hoặc hệ thống lưu trữ
            var filePath = System.IO.Path.Combine("Uploads/FileThau", file.FileName);
            using (var stream = new System.IO.FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
    }

            _context.ThongTinNhaThaus.Add(thongtinnhathaus);
            _context.DKThaus.Add(dkthaus);
            _context.SaveChanges();

            //return View("Index");
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet("/form2/")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var ThongTinNhaThau = _context.ThongTinNhaThaus;
            var DKThau = _context.DKThaus;
            return View(ThongTinNhaThau);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
