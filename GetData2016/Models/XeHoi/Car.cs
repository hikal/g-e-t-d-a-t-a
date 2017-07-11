using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetData2016.Models.XeHoi
{
    public class Car
    {
        public int MaTin { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string ThongSoCoBan { get; set; }
        public string ThongSoKyThuat { get; set; }
        public string TienNghi { get; set; }

        public int HangXe { get; set; }
        public int DongXe { get; set; }

        public float Gia { get; set; }
        public int NamSanXuat { get; set; }
        public string NgayDang { get; set; }
        public int TinhTrang { get; set; }
        public int XuatXu { get; set; }
        public int HopSo { get; set; }
        public int SoChoNgoi { get; set; }
        public int SoCua { get; set; }
        public int NhienLieu { get; set; }
        public int MauXe { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}
