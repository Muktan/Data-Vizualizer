using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Data_Vizualizer.Models;

namespace Data_Vizualizer.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        // Post: Main/Index
        [HttpPost]
        public ActionResult Index(string data)
        {
            
            string[] result = data.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //ok now here we have the result zero as labels
            string[] labels = result[0].Split(new string[] { "," }, StringSplitOptions.None);
            //now we have all labels from that we will iterate a for loop and keep on adding the datapoints
            List<DataPoint> ls = new List<DataPoint>();
            for (int i = 1; i < result.Length; i++)
            {
                string[] temp = result[i].Split(new string[] { "," }, StringSplitOptions.None);
                ls.Add(new DataPoint(int.Parse(temp[0]),int.Parse(temp[1])));
            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(ls);





            /*Dictionary<string,ArrayList> datad = new Dictionary<string, ArrayList>();
            List<Dictionary<string,int>> arr = new List<Dictionary<string, int>>();
            foreach (var item in labels)
            {
                datad.Add(item, new ArrayList());
            }
            for (int i = 1;i<result.Length;i++)
            {
                string[] temp = result[i].Split(new string[] { "," }, StringSplitOptions.None);
                for (int j=0;j<labels.Length;j++)
                {
                    datad[labels[j]].Add(temp[j]);
                }
            }*/
            /*ViewBag.data = result;
            ViewBag.datad = datad;*/
            /*var maindata = JsonConvert.SerializeObject(datad);
            ViewBag.maindata = maindata;*/
            //qwe

            return View();
        } 
    }
}