using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuanLyChungCu.Models;

namespace QuanLyChungCu.Controllers
{
    public class KhuCanHoController : ApiController
    {
        //lay toan bo danh sach khu can ho
        [HttpGet]
        public List<KhuCanHo> LayToanBoKhuCanHo()
        {
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            List<KhuCanHo> lstKCH = context.KhuCanHos.ToList();
            foreach (KhuCanHo kch in lstKCH)
            {
                kch.CanHos.Clear();
            }
            return lstKCH;
        }
        //lay chi tiet khu cu dan theo ma
        [HttpGet]
        public KhuCanHo ChiTietKCH(int id)
        {
            DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
            KhuCanHo kch = context.KhuCanHos.FirstOrDefault(x => x.MaKhu == id);
            if (kch != null)
            {
                kch.CanHos.Clear();
            }
            return kch;
        }
        //them khu can ho
        [HttpPost]
        public bool LuuKCH(KhuCanHoModel cdm)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                KhuCanHo kch = new KhuCanHo { TenKhu = cdm.TenKhu, SoTang = cdm.SoTang, SoCanHo = cdm.SoCanHo, DiaChi = cdm.DiaChi };
                context.KhuCanHos.InsertOnSubmit(kch);
                context.SubmitChanges();
                return true;
            }
            catch { }
            return false;
        }
        //Sua KhuCanHo
        [HttpPut]
        public bool SuaKCH(KhuCanHoModel cdm)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                KhuCanHo kch = context.KhuCanHos.FirstOrDefault(x => x.MaKhu == cdm.MaKhu);
                if (kch != null)
                {
                    kch.TenKhu = cdm.TenKhu;
                    kch.SoTang = cdm.SoTang;
                    kch.SoCanHo = cdm.SoCanHo;
                    kch.DiaChi = cdm.DiaChi;
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        //Xoa KhuCanHo
        [HttpDelete]
        public bool XoaKCH(int maKCH)
        {
            try
            {
                DB_QuanLyChungCuDataContext context = new DB_QuanLyChungCuDataContext();
                KhuCanHo kch = context.KhuCanHos.FirstOrDefault(x => x.MaKhu == maKCH);
                if (kch != null)
                {
                    context.KhuCanHos.DeleteOnSubmit(kch);
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
