using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models.FrameWork;
using PagedList;
using System.IO;
using System.Web;
using System.Data.Common;
using System.Configuration;




namespace Models
{
   public class AccountModel
    {
      
        // PPC_RentalEntities db = null;
        DemoPPCRentalEntities db = null;
        public AccountModel()
        {
            db = new DemoPPCRentalEntities();
        }
        public long Insert(USER entity)
        {
            if (entity.Email == null)
            {
                return -1;
            }
            else { 
            db.USERs.Add(entity);
            db.SaveChangesAsync();
            return entity.ID;
            }
        }
        public bool CheckUserName(string email)
        {

            return db.USERs.Count(x => x.Email == email) > 0;
        }
        public bool CheckPropertyName(string property)
        {

            return db.PROPERTies.Count(x => x.PropertyName == property) > 0;
        }
        public long InsertProjectFeature(PROPERTY_FEATURE entity)
        {
            db.PROPERTY_FEATURE.Add(entity);
            db.SaveChangesAsync();
            return entity.ID;
        }

        public long InsertProperty(PROPERTy entity)
        {
           
            if (entity.ImageFile2 == null)
            {
                entity.Avatar = "ImagesNull.png";
               
            }
            //if (entity.District_ID ==null)
            //{
            //    entity.District_ID = null ;
            //}
            //if (entity.Status_ID == null)
            //{
            //    entity.District_ID = null;
            //}
            entity.UnitPrice = "VND";

            db.PROPERTies.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var property = db.PROPERTies.Find(id);
                db.PROPERTies.Remove(property);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public PROPERTy ViewDetail(int id)
        {
            return db.PROPERTies.Find(id);
        }
        public USER EditUser(int id)
        {
            return db.USERs.Find(id);
        }
        public bool UpdateUser(USER users)
        {
            try
            {
                var user = db.USERs.Find(users.ID);
                user.FullName = users.FullName;
                user.Phone = users.Phone;
                user.Address = users.Address;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(PROPERTy entitys)
        {
            try
            {
                var property = db.PROPERTies.Find(entitys.ID);

                property.PropertyName = entitys.PropertyName;
               // save images
                //if (entitys.ImageFile == null)
                //{
                //    //entitys.Images = "ImagesNull.png";
                //}
                //else
                //{
                //    property.Images = entitys.Images;
                //}
                // save avatar
                if (entitys.ImageFile2 == null)
                {
                    //entitys.Avatar = "AvatarNull.png";
                }
                else
                {
                    property.Avatar = entitys.Avatar;
                }

                //property.Avatar = entitys.Avatar;
                //property.Images = entitys.Images;
                property.PropertyType_ID = entitys.PropertyType_ID;
                property.Content = entitys.Content;
                property.Street_ID = entitys.Street_ID;
                property.Ward_ID = entitys.Ward_ID;
                property.District_ID = entitys.District_ID;
                property.Price = entitys.Price;
                property.UnitPrice = entitys.UnitPrice;
                property.Area = entitys.Area;
                property.BedRoom = entitys.BedRoom;
                property.BathRoom = entitys.BathRoom;
                property.PackingPlace = entitys.PackingPlace;
                property.UserID = entitys.UserID;
                //property.Created_at = DateTime.Parse(DateTime.Now.ToString("yyyy-mm-dd"));
                //property.Create_post = DateTime.Parse(DateTime.Now.ToString("yyyy-mm-dd"));
                property.Status_ID = entitys.Status_ID;
                property.Note = entitys.Note;
                //property.Updated_at = DateTime.Parse(DateTime.Now.ToString("yyyy-mm-dd"));
                property.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                property.Sale_ID = entitys.Sale_ID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
             
        }
        public IEnumerable<PROPERTy> ListAllPaging(int page, int pageSize)
        {
            return db.PROPERTies.OrderByDescending(x=> x.Created_at).ToPagedList(page, pageSize);
        }
        public IEnumerable<PROPERTy> ListAllPagingHome(int page, int pageSize)
        {
            return db.PROPERTies.Where(x=>x.Status_ID == 3).OrderByDescending(x => x.Created_at).ToPagedList(page, pageSize);
        }
        public IEnumerable<USER> ListAllPagingUser(int page, int pageSize)
        {
            return db.USERs.OrderByDescending(x => x.FullName).ToPagedList(page, pageSize);
        }
        //public IEnumerable<PROPERTy> ListAllAgency(int page, int pageSize)
        //{
        //    return db.PROPERTies.Where(x=>x.UserID==id).ToPagedList(page, pageSize);
        //}
        public USER GetID(string userName)
        {
            return db.USERs.SingleOrDefault(x => x.Email == userName);

        }
        public List<string> GetListCredentials(string userName)
        {
            var user = db.USERs.Single(x => x.Email == userName);

            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                       join c in db.Roles on a.RoleID equals c.ID
                       where b.ID ==user.GroupID
                       select new 
                       {
                          RoleID = a.RoleID,
                          UserGroupID = a.UserGroupID
                       }).AsEnumerable().Select(x=> new Credential() {
                           RoleID = x.RoleID,
                           UserGroupID = x.UserGroupID
                       });
            return data.Select(x => x.RoleID).ToList();
            
        }
        public List<string> GetListFeature(int id)
        {
            var property = db.PROPERTies.Single(x => x.ID == id);
            var data = (from a in db.PROPERTY_FEATURE
                        join b in db.FEATUREs on a.Feature_ID equals b.ID
                        join c in db.PROPERTies on a.Property_ID equals c.ID
                        where b.ID == property.ID
                        select new
                        {
                            Property_ID = a.Property_ID,
                            Feature_ID = a.Feature_ID
                        }).AsEnumerable().Select(x => new PROPERTY_FEATURE()
                        {
                            Property_ID = x.Property_ID,
                            Feature_ID = x.Feature_ID
                        });
            return data.Select(x=>x.FEATURE.FeatureName).ToList();
        }
      
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {

            // sing or find
            var res = db.USERs.SingleOrDefault(x => x.Email == userName);

            if (res == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (res.GroupID.Equals(CommonConstants.SALE_GROUP) || res.GroupID == CommonConstants.AGENCY_GROUP|| res.GroupID == CommonConstants.IT_GROUP)
                    {
                        if (res.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (res.Password == passWord)
                           
                                
                                return 1;
                          

                            else
                                return -2;

                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (res.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (res.Password == passWord)
                            return 1;
                        else
                            return -2;

                    }
                }


            }




        }
    }
}
