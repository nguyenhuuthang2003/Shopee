﻿using DataAccessLayer.Helper;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial class SanPhamResponsitory : ISanPhamResponsitory
    {
        private IDatabaseHelper _dbHelper;

        public SanPhamResponsitory(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public SanPhamDetailModel Getbyid(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_sanpham_id",
                     "@MaSanPham", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamDetailModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_sanpham",
                    "@MaDanhMuc", model.MaDanhMuc,
                    "@Madanhmucuudai", model.Madanhmucuudai,
                    "@TenSanPham", model.TenSanPham,
                    "@AnhDaiDien", model.AnhDaiDien,
                    "@Gia", model.Gia,
                    "@GiaGiam", model.GiaGiam,
                    "@SoLuong", model.SoLuong,
                    "@TrangThai", model.TrangThai,
                    "@LuotXem", model.LuotXem,
                    "@TrongLuong", model.TrongLuong,
                    "@list_json_chitiet_sanpham", model.list_json_chitiet_sanpham != null ? MessageConvert.SerializeObject(model.list_json_chitiet_sanpham) : null,
                    "@list_json_sanpham_nhaphanphoi", model.list_json_sanpham_nhaphanphoi != null ? MessageConvert.SerializeObject(model.list_json_sanpham_nhaphanphoi) : null,
                    "@list_json_anhsanpham", model.list_json_anhsanpham != null ? MessageConvert.SerializeObject(model.list_json_anhsanpham) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Update(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_sanpham",
                    "@MaSanPham", model.@MaSanPham,
                    "@MaDanhMuc", model.MaDanhMuc,
                    "@Madanhmucuudai", model.Madanhmucuudai,
                    "@TenSanPham", model.TenSanPham,
                    "@AnhDaiDien", model.AnhDaiDien,
                    "@Gia", model.Gia,
                    "@GiaGiam", model.GiaGiam,
                    "@SoLuong", model.SoLuong,
                    "@TrangThai", model.TrangThai,
                    "@LuotXem", model.LuotXem,
                    "@TrongLuong", model.TrongLuong,
                    "@list_json_chitiet_sanpham", model.list_json_chitiet_sanpham != null ? MessageConvert.SerializeObject(model.list_json_chitiet_sanpham) : null,
                    "@list_json_sanpham_nhaphanphoi", model.list_json_sanpham_nhaphanphoi != null ? MessageConvert.SerializeObject(model.list_json_sanpham_nhaphanphoi) : null,
                    "@list_json_anhsanpham", model.list_json_anhsanpham != null ? MessageConvert.SerializeObject(model.list_json_anhsanpham) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Delete(int MaSanPham)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_sanpham",
                    "@MaSanPham", MaSanPham);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<SanPhamDetailModel> Search(int pageIndex, int pageSize, out long total, string TenSanPham, string TenDanhMuc, string Tendanhmucuudai, Decimal Gia, string TenHang, string TenNhaPhanPhoi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenSanPham", TenSanPham,
                    "@TenDanhMuc", TenDanhMuc,
                    "@Tendanhmucuudai", Tendanhmucuudai,
                    "@Gia", Gia,
                    "@TenHang", TenHang,
                    "@TenNhaPhanPhoi", TenNhaPhanPhoi
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamDetailModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
