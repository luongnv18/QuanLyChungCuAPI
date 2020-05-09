using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyChungCu.Models
{
    public class CuDanModel
    {
        public string MaCuDan { get; set; }

        public string TenCuDan { get; set; }

        public DateTime? NgaySinh { get; set; }

        public System.Nullable<bool> GioiTinh { get; set; }

        public string SoDT { get; set; }

        public string SoCMT { get; set; }

        public string QueQuan { get; set; }
    }
}