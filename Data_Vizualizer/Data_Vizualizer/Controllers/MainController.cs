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

        [HttpPost]
        // Post: Main/Index
        public ActionResult Index(string data)
        {
            //get all the rows
            string[] Result = data.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //ok now here we have the Result zero as labels
            string[] Labels = Result[0].Split(new string[] { "," }, StringSplitOptions.None);
            List<int> CountErrList = new List<int>();
            //Validate Data
            for (int i = 1; i < Result.Length; i++)
            {
                string[] temp = Result[i].Split(new string[] { "," }, StringSplitOptions.None);
                if (temp.Length != Labels.Length)
                {
                    CountErrList.Add(i);
                }
            }
            if (CountErrList.Count >0 && CountErrList.Count <10)
            {
                //error occured dont let user chose the labels for plotting the data
                //just prompt the error

                //set flag
                //set error message
                //render the view
                
            }
            else if(CountErrList.Count > 10)
            {
                //set flag
                //set error message
                //render the view
                
            }
            else
            {
                //no error in data
                //now we can just plot the data 

                //now we have all labels from that we will iterate a for loop and keep on adding the datapoints
                List<DataPoint> ls = new List<DataPoint>();
                //loop
                for (int i = 1; i < Result.Length; i++)
                {
                    string[] temp = Result[i].Split(new string[] { "," }, StringSplitOptions.None);
                    //here it won't always be just temp[0] or temp[1] it totally depends on against
                    //which labels user want to plot the graphs
                    try
                    {
                        ls.Add(new DataPoint(int.Parse(temp[0]), int.Parse(temp[1])));
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                    
                }

                ViewBag.DataPoints = JsonConvert.SerializeObject(ls);
                //yep thats it
            }



            return View();
        } 
    }
}







/*Dictionary<string,ArrayList> datad = new Dictionary<string, ArrayList>();
List<Dictionary<string,int>> arr = new List<Dictionary<string, int>>();
foreach (var item in labels)
{
    datad.Add(item, new ArrayList());
}
for (int i = 1;i<Result.Length;i++)
{
    string[] temp = Result[i].Split(new string[] { "," }, StringSplitOptions.None);
    for (int j=0;j<labels.Length;j++)
    {
        datad[labels[j]].Add(temp[j]);
    }
}*/
/*ViewBag.data = Result;
ViewBag.datad = datad;*/
/*var maindata = JsonConvert.SerializeObject(datad);
ViewBag.maindata = maindata;*/
//qwe
