using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals.EF;
using System.Data.SqlClient;

namespace Modals.DAO
{
    public class DM_Mau_Dao
    {

        NESDbContext db = null;

        public DM_Mau_Dao()
        {
            db = new NESDbContext();
        }
        public DM_Mau GetById(int ID)
        {
            return db.DM_Maus.SingleOrDefault(x => x.ID == ID);
        }
        public DM_Mau GetByTenDMMau(string TenDanhMucMau)
        {
            return db.DM_Maus.SingleOrDefault(x => x.TenDanhMucMau == TenDanhMucMau);
        }

        public DM_Mau ViewDetail(int ID)
        {
            return db.DM_Maus.Find(ID);
        }

        public IEnumerable<DM_Mau> ListAll()
        {
            IEnumerable<DM_Mau> model = db.DM_Maus.Where(x => x.TrangThai > 0);
            return model.OrderBy(x => x.ID).ToList();
        }
        
        public int Insert(DM_Mau entity)
        {
            db.DM_Maus.Add(entity);
            int res = db.SaveChanges();
            return res;
        }

        public int Update(int ID, string TenDanhMucMau, string NguoiCapNhat, DateTime NgayCapNhat)
        {
            try
            {
                var DMMau = db.DM_Maus.Find(ID);
                DMMau.TenDanhMucMau = TenDanhMucMau;
                DMMau.NguoiCapNhat = NguoiCapNhat;
                DMMau.NgayCapNhat = DateTime.Now;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Update_Status(int id, int TrangThai)
        {
            try
            {
                var DMMau = db.DM_Maus.Find(id);
                DMMau.TrangThai = TrangThai;
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
