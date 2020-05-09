using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyChungCu.Models
{
    public class CanHoModel
    {
        public string MaCanHo { get; set; }

        public double? DienTich { get; set; }

        public long? Gia { get; set; }

        public bool? TrangThai { get; set; }

        public int? SoPhong { get; set; }

        public string MaCuDan { get; set; }

        public int? MaKhu { get; set; }
    }
}