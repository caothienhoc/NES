using Modals.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.DAO
{
    public class Account_Dao
    {
        NESDbContext db = null;
        public Account_Dao()
        {
            db = new NESDbContext();
        }
        public Account GetById(string TaiKhoan)
        {
            return db.Accounts.SingleOrDefault(x => x.TaiKhoan == TaiKhoan);
        }
        public Account ViewDetail(string TaiKhoan)
        {
            return db.Accounts.Find(TaiKhoan);
        }
        public int Login(string TaiKhoan, string MatKhau)
        {
            var result = db.Accounts.SingleOrDefault(x => x.TaiKhoan == TaiKhoan && x.isActive >= 0);
            if (result == null)
            {
                return 0; // Tài khoản không tồn tại
            }
            else
            {
                if (result.isActive != 1)
                {
                    return -1; // Tài khoản đang bị khóa
                }
                else
                {
                    if (result.MatKhau == MatKhau)
                        return 1;
                    return -2; // Mật khẩu không đúng
                }

            }
        }

        public IEnumerable<Account> ListAll()
        {
            IEnumerable<Account> model = db.Accounts.Where(x => x.isActive >= 0);
            return model.OrderBy(x => x.TaiKhoan).ToList();
        }
        public int Insert(Account entity)
        {
            db.Accounts.Add(entity);
            int res = db.SaveChanges();
            return res;
        }
        public int Update(string TaiKhoan, string TenDayDu, int LoaiUser)
        {
            try
            {
                var user = db.Accounts.Find(TaiKhoan);
                user.TenDayDu = TenDayDu;
                user.LoaiUser = LoaiUser;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Delete(string TaiKhoan)
        {
            try
            {
                var user = db.Accounts.Find(TaiKhoan);
                db.Accounts.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Update_Status(string TaiKhoan, int TrangThai)
        {
            try
            {
                var user = db.Accounts.Find(TaiKhoan);
                user.isActive = TrangThai;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int ResetPassword(string TaiKhoan, string MatKhau)
        {
            try
            {
                var user = db.Accounts.Find(TaiKhoan);
                user.MatKhau = MatKhau;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
