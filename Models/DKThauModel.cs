using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.DKThaus
{
    public class DKThau
    {
        [Key]
        public int ID { get; set; }

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

        public DateTime? Ngay { get; set; }
        
    }
}
