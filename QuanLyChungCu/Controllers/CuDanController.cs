using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuanLyChungCu.Models;

namespace QuanLyChungCu.Controllers
{
    public class CuDanController : ApiController
    {
        //lay toan bo danh sach cu dan
        [HttpGet]
        public List<CuDan> LayToanBoCuDan()
        {
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            List<CuDan> lstCuDan = context.CuDans.ToList();
            foreach (CuDan cd in lstCuDan)
            {
                cd.CanHos.Clear();
                cd.HopDongs.Clear();
            }
            return lstCuDan;
        }
        //lay chi tiet cu dan theo ma
        [HttpGet]
        public CuDan ChiTietCuDan(string id)
        {
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            CuDan cd = context.CuDans.FirstOrDefault(x => x.MaCuDan == id);
            if (cd != null)
            {
                cd.CanHos = null;
                cd.HopDongs = null;
            }
            return cd;
        }
        //lay chi tiet cu dan theo so cmnd
        [HttpGet]
        public CuDan TimCuDanTheoSoCMT(string soCMT)
        {
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            CuDan cd = context.CuDans.FirstOrDefault(x => x.SoCMT == soCMT);
            if (cd != null)
            {
                cd.CanHos = null;
                cd.HopDongs = null;
            }
            return cd;
        }
        //them cu dan
        [HttpPost]
        public bool LuuCuDan(CuDanModel cdm)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                CuDan cd = new CuDan { MaCuDan = cdm.MaCuDan, TenCuDan = cdm.TenCuDan, GioiTinh = cdm.GioiTinh,NgaySinh=cdm.NgaySinh, SoDT = cdm.SoDT, SoCMT = cdm.SoCMT, QueQuan = cdm.QueQuan };
                context.CuDans.InsertOnSubmit(cd);
                context.SubmitChanges();
                return true;
            }
            catch { }
            return false;
        }
        //Sua cu dan
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
        }
    }
}
