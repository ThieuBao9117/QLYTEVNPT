using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.ThongTinNhaThaus
{
    public class ThongTinNhaThau
    {
        [Key]
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

        public int? PhanLoai { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(150)]
        public string DT { get; set; }

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
    }
}
