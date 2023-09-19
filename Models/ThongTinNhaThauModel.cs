using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
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
        

        public static implicit operator List<object>(ThongTinNhaThau v)
        {
            throw new NotImplementedException();
        }

        // public List<App.Models.DKThaus.DKThau> dsach { get; set; }
    }
}
