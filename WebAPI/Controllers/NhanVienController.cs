using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebAPI.Model;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private QL_CFContext db = new QL_CFContext();
        // API NHAN VIEN =====================================================================================================================
        [HttpGet]
        public IActionResult getDSNV()
        {
            try
            {
                return Ok(db.NhanViens.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{Username}")]
        public IActionResult getNhanVienToID(string Username)
        {
            try
            {
                NhanVien a = db.NhanViens.Find(Username);
                if (a == null) return NotFound();
                else return Ok(a);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteNhanVien(int id)
        {
            try
            {
                NhanVien a = db.NhanViens.Find(id);
                if (a == null) return NotFound();
                else
                {
                    db.NhanViens.Remove(a);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult postNhanVien(NhanVien h)
        {
            try
            {
                db.NhanViens.Add(h);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult putNhanVien(NhanVien h)
        {
            try
            {
                NhanVien x = db.NhanViens.Find(h.Username);
                if (x == null)
                    return NotFound();
                x.Fullname = h.Fullname;
                x.NgaySinh = h.NgaySinh;
                x.DiaChi = h.DiaChi;
                x.Phone = h.Phone;
                x.Email = h.Email;
                x.GioiTinh = h.GioiTinh;
                x.Luong = h.Luong;
                x.Anh= h.Anh;
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        // API SẢM PHẨM =====================================================================================================================
        [HttpGet("SanPham")]
        public IActionResult getDsSanPham()
        {
            try
            {
                return Ok(db.Sanphams.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("SanPham/{id}")]
        public IActionResult getSPToID(string id)
        {
            try
            {
                Sanpham a = db.Sanphams.Find(id);
                if (a == null) return NotFound();
                else return Ok(a);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("SanPham")]
        public IActionResult postSanPham(Sanpham h)
        {
            try
            {
                db.Sanphams.Add(h);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("SanPham/{id}")]
        public IActionResult deleteSanPham(string id)
        {
            try
            {
                Sanpham a = db.Sanphams.Find(id);
                if (a == null) return NotFound();
                else
                {
                    db.Sanphams.Remove(a);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("SanPham")]
        public IActionResult putSanPham(Sanpham h)
        {
            try
            {
                Sanpham x = db.Sanphams.Find(h.Sanphamid);
                if (x == null)
                    return NotFound();
                x.TenSp = h.TenSp;
                x.Gia = h.Gia;
                x.HanSuDung = h.HanSuDung;
                x.IdLoai = h.IdLoai;
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // API LOAI ===========================================================================================================================
        [HttpGet("Loai")]
        public IActionResult getDsLoai()
        {
            try
            {
                return Ok(db.Loais.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Loai/{id}")]
        public IActionResult getLoaiToID(int id)
        {
            try
            {
                Loai a = db.Loais.Find(id);
                if (a == null) return NotFound();
                else return Ok(a);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Loai")]
        public IActionResult postLoai(Loai h)
        {
            try
            {
                db.Loais.Add(h);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("Loai/{id}")]
        public IActionResult deleteLoai(int id)
        {
            try
            {
                Loai a = db.Loais.Find(id);
                if (a == null) return NotFound();
                else
                {
                    db.Loais.Remove(a);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("Loai")]
        public IActionResult putLoai(Loai h)
        {
            try
            {
                Loai x = db.Loais.Find(h.Id);
                if (x == null)
                    return NotFound();
                x.Name = h.Name;
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // API SIZE ===========================================================================================================================

        [HttpGet("Size")]
        public IActionResult getDsSize()
        {
            try
            {
                return Ok(db.Sizes.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Size/{id}")]
        public IActionResult getSideToID(int id)
        {
            try
            {
                Size a = db.Sizes.Find(id);
                if (a == null) return NotFound();
                else return Ok(a);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Size")]
        public IActionResult postSize(Size h)
        {
            try
            {
                db.Sizes.Add(h);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("Size/{id}")]
        public IActionResult deleteSize(int id)
        {
            try
            {
                Size a = db.Sizes.Find(id);
                if (a == null) return NotFound();
                else
                {
                    db.Sizes.Remove(a);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("Size")]
        public IActionResult putSize(Size h)
        {
            try
            {
                Size x = db.Sizes.Find(h.Id);
                if (x == null)
                    return NotFound();
                x.Name = h.Name;
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // API  khach Hàng ==============================================================================================================
        [HttpGet("KhachHang")]
        public IActionResult getDsKhachHang()
        {
            try
            {
                return Ok(db.Khachhangs.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("KhachHang/{id}")]
        public IActionResult getKHToID(string id)
        {
            try
            {
                Khachhang a = db.Khachhangs.Find(id);
                if (a == null) return NotFound();
                else return Ok(a);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("KhachHang")]
        public IActionResult postKH(Khachhang h)
        {
            try
            {
                db.Khachhangs.Add(h);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("KhachHang/{id}")]
        public IActionResult deleteKH(string id)
        {
            try
            {
                Khachhang a = db.Khachhangs.Find(id);
                if (a == null) return NotFound();
                else
                {
                    db.Khachhangs.Remove(a);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("KhachHang")]
        public IActionResult putKH(Khachhang h)
        {
            try
            {
                Khachhang x = db.Khachhangs.Find(h.Username);
                if (x == null)
                    return NotFound();
                x.Fullname = h.Fullname;
                x.Address = h.Address;
                x.Phone = h.Phone;
                x.Password = h.Password;
                x.Email = h.Email;
               
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // API  Don Hang ==============================================================================================================
        [HttpGet("DonHang")]
        public IActionResult getDsDonHang()
        {
            try
            {
                return Ok(db.DonHangs.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("DonHang/{id}")]
        public IActionResult getDHToID(string id)
        {
            try
            {
                DonHang a = db.DonHangs.Find(id);
                if (a == null) return NotFound();
                else return Ok(a);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("DonHang")]
        public IActionResult postDH(DonHang h)
        {
            try
            {
                db.DonHangs.Add(h);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("DonHang/{id}")]
        public IActionResult deleteDH(string id)
        {
            try
            {
                DonHang a = db.DonHangs.Find(id);
                if (a == null) return NotFound();
                else
                {
                    db.DonHangs.Remove(a);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("ChitietHoadon/{id}")]
        public IActionResult getDSChitietHoadon(string id)
        {
            try
            {
                List<Ctdonhang> ds = db.Ctdonhangs.Where(t => t.DonHangId == id).ToList();
                if (ds == null) return NotFound();
                else return Ok(ds);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("ChitietSize/{id}")]
        public IActionResult getDSChitietSize(String id)
        {
            try
            {
                List<CtSpSize> ds = db.CtSpSizes.Where(t => t.IdSp == id).ToList();
                if (ds == null) return NotFound();
                else return Ok(ds);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
