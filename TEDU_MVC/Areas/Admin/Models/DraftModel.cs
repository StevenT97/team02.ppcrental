using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEDU_MVC.Areas.Admin.Models
{
    public class DraftModel
    {
    
        public string PropertyName { get; set; }
        public string Avatar { get; set; }
        public string Images { get; set; }
        public int PropertyType_ID { get; set; }
        public string Content { get; set; }
        public int Street_ID { get; set; }
        public int Ward_ID { get; set; }
        public int District_ID { get; set; }
        public int Price { get; set; }
        public string UnitPrice { get; set; }
        public string Area { get; set; }
        public int BedRoom { get; set; }
        public int BathRoom { get; set; }
        public int PackingPlace { get; set; }
        public int UserID { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Create_post { get; set; }
        public int Status_ID { get; set; }
        public string Note { get; set; }
        public DateTime Updated_at { get; set; }
        public int Sale_ID { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public HttpPostedFileBase ImageFile2 { get; set; }
    }
}