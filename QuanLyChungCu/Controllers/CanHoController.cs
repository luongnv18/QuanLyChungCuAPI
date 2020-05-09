using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuanLyChungCu.Models;
namespace QuanLyChungCu.Controllers
{
    public class CanHoController : ApiController
    {
        //lay toan bo danh sach can ho
        [HttpGet]
        public List<CanHoModel> LayToanBoCanHo()
        {
            List<CanHoModel> lstchm = new List<CanHoModel>();
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            List<CanHo> lstCanHo = context.CanHos.ToList();
            foreach (CanHo ch in lstCanHo)
            {
                CanHoModel canho = new CanHoModel()
                {
                    MaCanHo = ch.MaCanHo,
                    DienTich = ch.DienTich,
                    Gia = ch.Gia,
                    TrangThai = ch.TrangThai,
                    SoPhong = ch.SoPhong,
                    MaCuDan = ch.MaCuDan,
                    MaKhu = ch.MaKhu
                };
                lstchm.Add(canho);
            }
            return lstchm;
        }
        //lay chi tiet can ho theo ma
        [HttpGet]
        public CanHoModel ChiTietCanHo(string id)
        {
            CanHoModel chm = new CanHoModel();
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            CanHo ch = context.CanHos.FirstOrDefault(x => x.MaCanHo == id);
            if (ch != null)
            {
                chm.MaCanHo = ch.MaCanHo;
                chm.DienTich = ch.DienTich;
                chm.Gia = ch.Gia;
                chm.TrangThai = ch.TrangThai;
                chm.SoPhong = ch.SoPhong;
                chm.MaCuDan = ch.MaCuDan;
                chm.MaKhu = ch.MaKhu;

            }
            return chm;
        }
        //lay danh sach can ho theo khu can ho
        [HttpGet]
        public List<CanHo> DanhSachCanHoTheoKhuCanHo(int maKCH)
        {
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            List<CanHo> lstch = context.CanHos
                                        .Where(x => x.MaKhu == maKCH)
                                        .ToList();
            foreach (CanHo ch in lstch)
            {
                ch.HopDongs.Clear();
                ch.KhuCanHo = null;
                ch.CuDan = null;
            }
            return lstch;
        }
        //lay danh sach can ho cua cu dan
        [HttpGet]
        public List<CanHo> DanhSachCanHoTheoCuDan(string maCD)
        {
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            List<CanHo> lstch = context.CanHos
                                        .Where(x => x.MaCuDan == maCD)
                                        .ToList();
            foreach (CanHo ch in lstch)
            {
                ch.HopDongs.Clear();
                ch.KhuCanHo = null;
                ch.CuDan = null;
            }
            return lstch;
        }
        //them can ho
        [HttpPost]
        public bool LuuCanHo(CanHoModel chm)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                CanHo ch = new CanHo { MaCanHo = chm.MaCanHo, DienTich = chm.DienTich, Gia = chm.Gia, TrangThai = chm.TrangThai, SoPhong = chm.SoPhong, MaCuDan = chm.MaCuDan, MaKhu = chm.MaKhu };
                context.CanHos.InsertOnSubmit(ch);
                context.SubmitChanges();
                return true;
            }
            catch { }
            return false;
        }
        //Sua can ho
        [HttpPut]
        public bool SuaCanHo(CanHoModel chm)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                CanHo ch = context.CanHos.FirstOrDefault(x => x.MaCanHo == chm.MaCanHo);
                if (ch != null)
                {
                    ch.DienTich = chm.DienTich;
                    ch.Gia = chm.Gia;
                    ch.TrangThai = chm.TrangThai;
                    ch.SoPhong = chm.SoPhong;
                    ch.MaCuDan = chm.MaCuDan;
                    ch.MaKhu = chm.MaKhu;
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        //Xoa can ho
        [HttpDelete]
        public bool XoaCanHo(string mach)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                CanHo ch = context.CanHos.FirstOrDefault(x => x.MaCanHo == mach);
                if (ch != null)
                {
                    context.CanHos.DeleteOnSubmit(ch);
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
