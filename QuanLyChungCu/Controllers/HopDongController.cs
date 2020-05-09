using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuanLyChungCu.Models;

namespace QuanLyChungCu.Controllers
{
    public class HopDongController : ApiController
    {
        //lay toan bo danh sach hop dong
        [HttpGet]
        public List<HopDongModel> LayToanBoHopDong()
        {
            List<HopDongModel> lstHDM = new List<HopDongModel>();
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            List<HopDong> lstHD = context.HopDongs.ToList();
            foreach (HopDong item in lstHD)
            {
                HopDongModel hdm = new HopDongModel();
                hdm.MaHopDong = item.MaHopDong;
                hdm.NgayGiaoDich = item.NgayGiaoDich;
                hdm.MaCanHo = item.MaCanHo;
                hdm.MaCuDan = item.MaCuDan;
                lstHDM.Add(hdm);
            }
            return lstHDM;
        }
        [HttpGet]
        public List<HopDongModel> LayDSHopDongTheoMaCD(string macd)
        {
            List<HopDongModel> lstHDM = new List<HopDongModel>();
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            List<HopDong> lstHD = context.HopDongs.Where(x => x.MaCuDan == macd).ToList();
            foreach (HopDong item in lstHD)
            {
                HopDongModel hdm = new HopDongModel();
                hdm.MaHopDong = item.MaHopDong;
                hdm.NgayGiaoDich = item.NgayGiaoDich;
                hdm.MaCanHo = item.MaCanHo;
                hdm.MaCuDan = item.MaCuDan;
                lstHDM.Add(hdm);
            }
            return lstHDM;
        }
        
        //them hop dong
        [HttpPost]
        public bool LuuHopDong(HopDongModel hdm)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                HopDong hd = new HopDong { MaHopDong = hdm.MaHopDong, NgayGiaoDich = hdm.NgayGiaoDich, MaCuDan = hdm.MaCuDan, MaCanHo = hdm.MaCanHo };
                context.HopDongs.InsertOnSubmit(hd);
                context.SubmitChanges();
                return true;
            }
            catch { }
            return false;
        }
        /*//Sua cu dan
        [HttpPut]
        public bool SuaCuDan(CuDanModel cdm)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                CuDan cd = context.CuDans.FirstOrDefault(x => x.MaCuDan == cdm.MaCuDan);
                if (cd != null)
                {
                    cd.TenCuDan = cdm.TenCuDan;
                    cd.GioiTinh = cdm.GioiTinh;
                    cd.NgaySinh = cdm.NgaySinh;
                    cd.SoDT = cdm.SoDT;
                    cd.SoCMT = cdm.SoCMT;
                    cd.QueQuan = cdm.QueQuan;
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        //Xoa cu dan
        [HttpDelete]
        public bool XoaCuDan(string macd)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                CuDan cd = context.CuDans.FirstOrDefault(x => x.MaCuDan == macd);
                if (cd != null)
                {
                    context.CuDans.DeleteOnSubmit(cd);
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }*/
    }
}
