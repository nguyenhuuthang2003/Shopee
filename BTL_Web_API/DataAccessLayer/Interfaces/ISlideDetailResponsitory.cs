﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface ISlideDetailResponsitory
    {
        List<SlideDetailModel> GetAllSlide();

        bool Create(SlideDetailModel model);

        bool Update(SlideDetailModel model);
        bool Delete(int MaAnh);
        List<SlideDetailModel> Search(int page, int pageSize, out long total, string TieuDe);
    }
}
