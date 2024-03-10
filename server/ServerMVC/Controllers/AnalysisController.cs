using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using ServerMVC.Infrastructure.Statistics;

namespace ServerMVC.Controllers
{
    public class AnalysisController : Controller
    {

        //IWebHostEnvironment _appEnvironment;
        //public AnalysisController(IWebHostEnvironment appEnvironment)
        //{
        //    _appEnvironment = appEnvironment;
        //}
        public IActionResult Index()
        {
            ViewBag.Title = "Анализ";
            return View();
        }
        OneFactorData[] RangeData(OneFactorData[] d)
        {
            Dictionary<double, double> monolithRankedArray = new Dictionary<double, double>();
            int n = 0;
            foreach (OneFactorData o in d)
                n += o.Length;
            double[] monolithSortedArr = new double[n];
            int cntr = 0;
            for (int i = 0; i < d.Length; i++)
            {
                for (int j = 0; j < d[i].Length; j++)
                {
                    monolithSortedArr[cntr] = d[i][j];
                    cntr++;
                }
            }
            Array.Sort(monolithSortedArr);
            int rnk = 1;
            double tmp = rnk;
            double k = 1;
            for (int i = 0; i < monolithSortedArr.Length; i++)
            {
                if (i != monolithSortedArr.Length - 1 && monolithSortedArr[i] == monolithSortedArr[i + 1])
                {
                    rnk++;
                    tmp += rnk;
                    k++;
                }
                else
                {
                    monolithRankedArray.Add(monolithSortedArr[i], tmp / k);
                    k = 1;
                    rnk++;
                    tmp = rnk;
                }
            }

            OneFactorData[] rankedData = new OneFactorData[d.Length];
            for (int i = 0; i < d.Length; i++)
            {
                double[] rankedArr = new double[d[i].Length];
                for (int j = 0; j < d[i].Length; j++)
                {
                    rankedArr[j] = monolithRankedArray[d[i][j]];
                }
                OneFactorData rankedGroup = new OneFactorData(rankedArr);
                rankedData[i] = rankedGroup;
            }
            return rankedData;
        }
        [HttpGet]
        public PartialViewResult _SpawnAnalyze(string inputData)
        {
            if (inputData == null)
                return PartialView("_SpawnAnalyze", null);
            string[] strGroups = inputData.Split(new char[] { '\n' });
            OneFactorData[] inputAnovaData = new OneFactorData[strGroups.Length];
            int i = 0;
            foreach(string strGroup in strGroups)
            {
                List<double> listObservations = new List<double>();
                string[] strObs = strGroup.Split(new char[] { ',' });
                foreach(string s in strObs)
                {
                    if (double.TryParse(s, out var number))
                        listObservations.Add(number);
                    else 
                        return PartialView("_SpawnAnalyze", null);

                }
                double[] observations = listObservations.ToArray();
                inputAnovaData[i] = new OneFactorData(observations);
                i++;
            }
            Anova anova = new Anova(inputAnovaData);
            Anova nonParametricAnova = new Anova(RangeData(inputAnovaData));
            anova.Frnk = nonParametricAnova.F;
            anova.Prnk = nonParametricAnova.p;
            return PartialView("_SpawnAnalyze", anova);
        }
        //[HttpPost]
        //public async Task<PartialViewResult> _UploadData(IFormFile upload)
        //{
        //    List<string[]> dataForTable = new List<string[]>();
        //    if (upload != null && Path.GetExtension(upload.FileName) == ".csv")
        //    {
        //        string path = _appEnvironment.WebRootPath + "\\Files\\" + upload.FileName;
        //        using (var fileStream = new FileStream(path, FileMode.Create))
        //        {
        //            await upload.CopyToAsync(fileStream);
        //        }
        //        using (TextFieldParser tfp = new TextFieldParser(path))
        //        {
        //            tfp.TextFieldType = FieldType.Delimited;
        //            tfp.SetDelimiters(",");
        //            while (!tfp.EndOfData)
        //            {
        //                string[] fields = tfp.ReadFields();
        //                dataForTable.Add(fields);
        //            }
        //        }
        //    }
        //    return PartialView(dataForTable);
        //}
        public ActionResult Header() => PartialView("_Header");
        public ActionResult Footer() => PartialView("_Footer");
    }
}
