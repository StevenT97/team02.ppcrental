using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.FrameWork;

namespace TEDU_MVC.DataViewModel
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string FeartureName { get; set; }

        public IEnumerable<PROPERTy> pROPERTY { get; set; }
        public IEnumerable<FEATURE> fEATURE { get; set; }
        public List<Feature> GetFeatureList { get; set; }
        public string[] listfeature { get; set; }
    }
}