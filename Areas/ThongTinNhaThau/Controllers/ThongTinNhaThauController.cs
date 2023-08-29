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

namespace App.Areas.ThongTinNhaThau.Controllers
{
    [Area("ThongTinNhaThau")]
    // [Route("admin/ThongTinNhaThau/ThongTinNhaThau/[action]/{id?}")]
    // [Authorize(Roles = RoleName.Administrator)]
    public class ThongTinNhaThauController : Controller
    {
        private readonly AppDbContext _context;

        public ThongTinNhaThauController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Blog/Category  
        //    [HttpGet("/ThongTinNhaThau/")]
        
      
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.ThongTinNhaThaus.ToListAsync());
        // }

        //  public async Task<IActionResult> Index()
        // {
 
        //     return View(await _context.ThongTinNhaThaus.ToListAsync());
        // }

        [HttpPost("/form2/")]
        [AllowAnonymous]
        public ActionResult form2(ThongTinNhaThauModel sm)
        {
            ViewBag.Ten = sm.Ten;
            ViewBag.TenDA = sm.TenDA;
            ViewBag.Nam = sm.Nam;


           
            ThongTinNhaThauModel thongtinnhathaus = new ThongTinNhaThauModel();
           
            thongtinnhathaus.Ten = sm.Ten;
            thongtinnhathaus.TenDA = sm.TenDA;
            
            Create(thongtinnhathaus);
            return View("Index");
        }
        
       

       

        [HttpGet("/form2/")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var ThongTinNhaThau = _context.ThongTinNhaThaus;
            //var DKThau = _context.DKThaus;
            return View(ThongTinNhaThau);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // [HttpPost]
        public  IActionResult Create(ThongTinNhaThauModel thongtinnhathaus)
        {
            if (ModelState.IsValid)
            {
                _context.ThongTinNhaThaus.Add(thongtinnhathaus);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            // return View(thongtinnhathaus);
            return View("Index");
        } 

        //     // var contact = await _context.ThongTinNhaThaus
        //     //     .FirstOrDefaultAsync(m => m.Id == id);
        //     // if (contact == null)
        //     // {
        //     //     return NotFound();
        //     // }

        //     return View(ThongTinNhaThau);
        // }

        // [TempData]
        // public string StatusMessage {set; get;}

        // [HttpGet("/ThongTinNhaThau/")]
        // [AllowAnonymous]
        // public IActionResult SendContact()
        // {
        //     return View();
        // }

        // [HttpPost("/ThongTinNhaThau/")]
        // [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> SendContact([Bind("ID,Ten,Anh,Ngay,MoTa,TenDA,PhanLoai,DT,NAM,Email,FileMau")] ThongTinNhaThauModel thongTinNhaThau)
        // {
        //     if (ModelState.IsValid)
        //     {

        //         thongTinNhaThau.DateSent = DateTime.Now;    

        //         _context.Add(thongTinNhaThau);
        //         await _context.SaveChangesAsync();

        //         StatusMessage = "Liên hệ của bạn đã được gửi";

        //         return RedirectToAction("Index", "Home");
        //     }

        //     return View(thongTinNhaThau);
        // }


        // [HttpGet("/admin/contact/delete/{id}")]
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var ThongTinNhaThau = await _context.ThongTinNhaThaus
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (contact == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(ThongTinNhaThau);
        // }

        
        // [HttpPost("/admin/contact/delete/{id}"), ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var ThongTinNhaThau = await _context.ThongTinNhaThaus.FindAsync(id);
        //     _context.ThongTinNhaThaus.Remove(ThongTinNhaThau);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

          
    }
}