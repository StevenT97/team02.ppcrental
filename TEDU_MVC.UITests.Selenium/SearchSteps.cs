using System.Linq;
using TechTalk.SpecFlow;
using TEDU_MVC.AcceptanceTests.Common;
using TEDU_MVC.UITests.Selenium;
using TEDU_MVC.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TEDU_MVC.UITests.Selenium.Support;
using Models.FrameWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TEDU_MVC.UITests.Selenium
{
    [Binding, Scope(Tag = "web")]
   public class SearchSteps : SeleniumStepsBase
    {
        /// <summary>
        /// SEARCH NAME
        /// </summary>
        /// <param name="p0"></param>
        [When(@"Tim project bang cum tu '(.*)'")]
        public void WhenTimProjectBangCumTu(string p0)
        {
            Browser.NavigateTo("Home/Index");
            Browser.FieldText("txtSearch", p0);
            Browser.ClickButton("btnSearch");
        }

        [Then(@"Danh sach hien ra chi nen co PropertyName chua ki tu: '(.*)'")]
        public void ThenDanhSachHienRaChiNenCoPropertyNameChuaKiTu(string p0)
        {
            //Arrange
                var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
            //Action

            Browser.SwitchTo().DefaultContent();

            string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
            var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
                             let Name = row.Text
                             select new PROPERTy { PropertyName = Name, };

            //Assert
            PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        }
        /// <summary>
        /// SEARCH TYPE
        /// </summary>
        /// <param name="p0"></param>
        [When(@"Tim project bang chon tu combobox Type '(.*)'")]
        public void WhenTimProjectBangChonTuComboboxType(string p0)
        {
            Browser.NavigateTo("Home/Index");
            Thread.Sleep(1000);
            Browser.ClickButton("select2-Type-container");
            Thread.Sleep(1000);
            Browser.FieldTextByClass("select2-search__field", p0 + Keys.Enter);
            Thread.Sleep(1000);
            Browser.ClickButton("btnSearch");
        }

        [Then(@"Danh sach hien ra chi nen co PropertyType la: '(.*)'")]
        public void ThenDanhSachHienRaChiNenCoPropertyTypeLa(string p0)
        {
            //Arrange
                var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
            //Action

            Browser.SwitchTo().DefaultContent();

            string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
            var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
                             let Name = row.Text
                             select new PROPERTy { PropertyName = Name, };

            //Assert
            PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        }
        /// <summary>
        /// SEARCH DISTRICT
        /// </summary>
        /// <param name="p0"></param>
        [When(@"Tim project bang chon tu combobox District '(.*)'")]
        public void WhenTimProjectBangChonTuComboboxDistrict(string p0)
        {
            Browser.NavigateTo("Home/Index");
            Browser.ClickButton("select2-Quan-container");
            Browser.FieldTextByClass("select2-search__field", p0 + Keys.Enter);
            Browser.ClickButton("btnSearch");
            Thread.Sleep(3000);
        }

        [Then(@"Danh sach hien ra chi nen co: '(.*)'")]
        public void ThenDanhSachHienRaChiNenCo(string p0)
        {
            // Arrange
            var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
            //Action

            Browser.SwitchTo().DefaultContent();

            string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
            var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
                             let Name = row.Text
                             select new PROPERTy { PropertyName = Name, };

            //Assert
            PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        }
        /// <summary>
        /// SEARCH MIN
        /// </summary>
        /// <param name="p0"></param>
        [When(@"Tim project bang chon tu text MinPrice '(.*)'")]
        public void WhenTimProjectBangChonTuTextMinPrice(int p0)
        {
            Browser.NavigateTo("Home/Index");
            Browser.FieldText("minPrice", p0.ToString());
            Browser.ClickButton("btnSearch");
        }

        [Then(@"Danh sach hien ra chi nen co Minprice: '(.*)'")]
        public void ThenDanhSachHienRaChiNenCoMinprice(string p0)
        {
            // Arrange
            var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
            //Action

            Browser.SwitchTo().DefaultContent();

            string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
            var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
                             let Name = row.Text
                             select new PROPERTy { PropertyName = Name, };

            //Assert
            PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        }
        /// <summary>
        /// SAERCH MAX
        /// </summary>
        /// <param name="p0"></param>
        [When(@"Tim project bang chon tu text MaxPrice '(.*)'")]
        public void WhenTimProjectBangChonTuTextMaxPrice(int p0)
        {
            Browser.NavigateTo("Home/Index");
            Browser.FieldText("maxPrice", p0.ToString());
            Browser.ClickButton("btnSearch");
        }

        [Then(@"Danh sach hien ra chi nen co  Maxprice: '(.*)'")]
        public void ThenDanhSachHienRaChiNenCoMaxprice(string p0)
        {
            // Arrange
            var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
            //Action

            Browser.SwitchTo().DefaultContent();

            string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
            var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
                             let Name = row.Text
                             select new PROPERTy { PropertyName = Name, };

            //Assert
            PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        }

        /// <summary>
        /// /////////////
        /// </summary>

        //[Given(@"the following propertys")]
        //public void GivenTheFollowingPropertys()
        //{
        //    Browser.NavigateTo("Home/Index");
        //}

        //// test name
        //[When(@"Tim project bang cum tu '(.*)'")]
        //public void WhenTimProjectBangCumTu(string p0)
        //{

        //    Browser.FieldText("txtSearch", p0);
        //    Browser.ClickButton("btnSearch");
        //}

        //[Then(@"Danh sach hien ra chi nen co PropertyName chua ki tu: '(.*)'")]
        //public void ThenDanhSachHienRaChiNenCoPropertyNameChuaKiTu(string p0)
        //{
        //    //Arrange
        //    var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
        //    //Action

        //    Browser.SwitchTo().DefaultContent();

        //    string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
        //    var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
        //                     let Name = row.Text
        //                     select new PROPERTy { PropertyName = Name, };

        //    //Assert
        //    PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        //}

        //// test type
        //[When(@"Tim project bang chon tu combobox Type '(.*)'")]
        //public void WhenTimProjectBangChonTuComboboxType(string p0)
        //{
        //    //Browser.NavigateTo("Home/Index");
        //    Browser.ClickButton("select2-Type-container");
        //    Browser.FieldTextByClass("select2-search__field", p0 + Keys.Enter);
        //    Browser.ClickButton("btnSearch");
        //}

        //[Then(@"Danh sach hien ra chi nen co PropertyType la: '(.*)'")]
        //public void ThenDanhSachHienRaChiNenCoPropertyTypeLa(string p0)
        //{
        //    //Arrange
        //    var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
        //    //Action

        //    Browser.SwitchTo().DefaultContent();

        //    string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
        //    var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
        //                     let Name = row.Text
        //                     select new PROPERTy { PropertyName = Name, };

        //    //Assert
        //    PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        //}

        //// test district
        //[When(@"Tim project bang chon tu combobox District '(.*)'")]
        //public void WhenTimProjectBangChonTuComboboxDistrict(string p0)
        //{
        //    //Browser.NavigateTo("Home/Index");
        //    Browser.ClickButton("select2-Quan-container");
        //    Browser.FieldTextByClass("select2-search__field", p0 + Keys.Enter);
        //    Browser.ClickButton("btnSearch");
        //}

        //[Then(@"Danh sach hien ra chi nen co: '(.*)'")]
        //public void ThenDanhSachHienRaChiNenCo(string p0)
        //{

        //    //Arrange
        //    var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
        //    //Action

        //    Browser.SwitchTo().DefaultContent();

        //    string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
        //    var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
        //                     let Name = row.Text
        //                     select new PROPERTy { PropertyName = Name, };

        //    //Assert
        //    PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        //}
        ///// <summary>
        ///// test three null
        ///// </summary>
        //[When(@"Search voi cac gia tri null")]
        //public void WhenSearchVoiCacGiaTriNull()
        //{
        //    Browser.ClickButton("btnSearch");
        //}

        //[Then(@"District, PropertyType, PropertyName Hien thi tat ca cac du an '(.*)'")]
        //public void ThenDistrictPropertyTypePropertyNameHienThiTatCaCacDuAn(string p0)
        //{
        //    //Arrange
        //    var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
        //    //Action

        //    Browser.SwitchTo().DefaultContent();

        //    string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
        //    var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
        //                     let Name = row.Text
        //                     select new PROPERTy { PropertyName = Name, };

        //    //Assert
        //    PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        //}
        ///// <summary>
        ///// District vs PropertyType
        ///// </summary>
        ///// <param name="p0"></param>
        ///// <param name="p1"></param>


        //[When(@"Gia tri truyen vao District vs PropertyType l: '(.*)','(.*)'")]
        //public void WhenGiaTriTruyenVaoDistrictVsPropertyTypeL(string p0, string p1)
        //{ 
        //    Browser.ClickButton("select2-Quan-container");
        //    Browser.FieldTextByClass("select2-search__field", p0 + Keys.Enter);

        //    Browser.ClickButton("select2-Type-container");
        //    Browser.FieldTextByClass("select2-search__field", p1 + Keys.Enter);

        //    Browser.ClickButton("btnSearch");
        //}

        //[Then(@"District, PropertyType Danh sach hien thi ra bao gom: '(.*)'")]
        //public void ThenDistrictPropertyTypeDanhSachHienThiRaBaoGom(string p0)
        //{
        //    var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
        //    //Action

        //    Browser.SwitchTo().DefaultContent();

        //    string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
        //    var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
        //                     let Name = row.Text
        //                     select new PROPERTy { PropertyName = Name, };

        //    //Assert
        //    PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="p0"></param>
        ///// <param name="p1"></param>
        //[When(@"Gia tri truyen vao District vs PropertyName ll: '(.*)','(.*)'")]
        //public void WhenGiaTriTruyenVaoDistrictVsPropertyNameLl(string p0, string p1)
        //{
        //    Browser.FieldText("txtSearch", p1);
        //    Browser.ClickButton("select2-Quan-container");
        //    Browser.FieldTextByClass("select2-search__field", p0 + Keys.Enter);
        //    Browser.ClickButton("btnSearch");
        //}

        //[Then(@"District, PropertyName Danh sach hien thi ra bao gom: '(.*)'")]
        //public void ThenDistrictPropertyNameDanhSachHienThiRaBaoGom(string p0)
        //{
        //    //Arrange
        //    var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
        //    //Action

        //    Browser.SwitchTo().DefaultContent();

        //    string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
        //    var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
        //                     let Name = row.Text
        //                     select new PROPERTy { PropertyName = Name, };

        //    //Assert
        //    PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        //}

        //[When(@"Gia tri truyen vao PropertyName vs PropertyName lll: '(.*)','(.*)'")]
        //public void WhenGiaTriTruyenVaoPropertyNameVsPropertyNameLll(string p0, string p1)
        //{
        //    Browser.FieldText("txtSearch", p1);
        //    Browser.ClickButton("select2-Type-container");
        //    Browser.FieldTextByClass("select2-search__field", p0 + Keys.Enter);
        //    Browser.ClickButton("btnSearch");
        //}

        //[Then(@"PropertyType, PropertyName Danh sach hien thi ra bao gom: '(.*)'")]
        //public void ThenPropertyTypePropertyNameDanhSachHienThiRaBaoGom(string p0)
        //{
        //    //Arrange
        //    var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
        //    //Action

        //    Browser.SwitchTo().DefaultContent();

        //    string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
        //    var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
        //                     let Name = row.Text
        //                     select new PROPERTy { PropertyName = Name, };

        //    //Assert
        //    PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        //}

        //[When(@"Gia tri truyen vao District vs PropertyName vs PropertyName llll: '(.*)','(.*)','(.*)'")]
        //public void WhenGiaTriTruyenVaoDistrictVsPropertyNameVsPropertyNameLlll(string p0, string p1, string p2)
        //{
        //    Browser.FieldText("txtSearch", p2);
        //    Browser.ClickButton("select2-Quan-container");
        //    Browser.FieldTextByClass("select2-search__field", p0 + Keys.Enter);
        //    Browser.ClickButton("select2-Type-container");
        //    Browser.FieldTextByClass("select2-search__field", p1 + Keys.Enter);
        //    Browser.ClickButton("btnSearch");
        //}

        //[Then(@"District, PropertyType, PropertyName Danh sach hien thi ra bao gom: '(.*)'")]
        //public void ThenDistrictPropertyTypePropertyNameDanhSachHienThiRaBaoGom(string p0)
        //{
        //    //Arrange
        //    var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
        //    //Action

        //    Browser.SwitchTo().DefaultContent();

        //    string descriptionTextXPath = "//div[contains(@class, 'grid_1_of_3 images_1_of_3')]/h3";
        //    var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
        //                     let Name = row.Text
        //                     select new PROPERTy { PropertyName = Name, };

        //    //Assert
        //    PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        //}




    }
}
