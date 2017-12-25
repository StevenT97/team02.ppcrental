using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TEDU_MVC.AcceptanceTests.Drivers.Search;
using TEDU_MVC.AcceptanceTests.Drivers.PropertyDetails;


namespace TEDU_MVC.AcceptanceTests.StepDefintions
{
    [Binding, Scope(Tag = "automated")]
    public class SearchDemoSteps
    {
      
        private readonly SearchDriver _searchDriver;

        public SearchDemoSteps(SearchDriver drivers)
        {
            _searchDriver = drivers;
          
        }

        [When(@"Tim property cac cum tu lll Name Quan Type Min Max '(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenTimPropertyCacCumTuLllNameQuanTypeMinMax(string p0, string p1, string p2, int p3, int p4)
        {
        
            _searchDriver.Search(p0, p1, p2, p3.ToString(), p4.ToString());
        }

        [Then(@"Danh sach property hien ra chi nen co PropertyName chua ki tu: '(.*)'")]
        public void ThenDanhSachPropertyHienRaChiNenCoPropertyNameChuaKiTu(string p0)
        {
            _searchDriver.ShowBooks(p0);
        }

        [When(@"Khong co truong du lieu nao duoc nhap")]
        public void WhenKhongCoTruongDuLieuNaoDuocNhap()
        {
            _searchDriver.Search("","","","","");
        }

        [Then(@"Danh sanh tat ca duoc hien thi")]
        public void ThenDanhSanhTatCaDuocHienThi(Table table)
        {
            _searchDriver.ShowBooks(table);
        }



    }
}
