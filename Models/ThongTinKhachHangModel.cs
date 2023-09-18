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
        public List <ThongTinNhaThau> ThongTinNhaThau {get;set;} 
        
        
            public int ID { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(500)]
            public string Ten { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(150)]
            public string Anh { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(250)]
            public string Ngay { get; set; }

            [Column(TypeName = "text")]
            public string MoTa { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(550)]
            public string TenDA { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(150)]
            public string PhanLoai { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(150)]
            public string DThoai { get; set; }

            public int? Nam { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(150)]
            [EmailAddress(ErrorMessage = "Phải là địa chỉ email")]
            public string Email { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(150)]
            public string NguoiLienHe { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(250)]
            public string FilMau { get; set; }
           

            
    
    
    public List <DKThau>  DKThaus {get;set;}
        


            [Column(TypeName = "nvarchar")]
            [StringLength(550)]
            public string TenNhaThau { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(50)]
            public string MaST { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(50)]
            public string NguoiLH { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(50)]
            public string DT { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(50)]
            [EmailAddress(ErrorMessage = "Phải là địa chỉ email")]
            public string EmailLH { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(250)]
            public string FileBaoGia { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(250)]
            public string BangBaoGia { get; set; }

            [Column(TypeName = "nvarchar")]
            [StringLength(50)]
            public string HSKhac { get; set; }

            public int? IDNhaThau { get; set; }
    
    }      
}