using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using NuGet.Protocol.Plugins;
using App.Models.DKThaus;
using App.Models.ThongTinNhaThaus;


namespace App.Models.ThongTinKhachHangs
{
    public class ThongTinKhachHang
    {  

        public int? ThongTinKhachHangID {get; set;}
        public DKThau DKThauModel { get; set; }
        public ThongTinNhaThau ThongTinNhaThauModel { get; set; }

      
    }
    
}       