using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Data_Vizualizer.Models;
using System.Globalization;

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
            //I need to know the data type of all the collumns 
            //so i will iterate through all the attributes of 
            //the first row as the reference to check other rows
            string[] tempr1 = Result[1].Split(new string[] { "," }, StringSplitOptions.None);
            List<string> dataTypeR1 = new List<string>();
            
            foreach (string item in tempr1)
            {
                DateTime t1;
                double t2;
                int t3;
                
                if (int.TryParse(item, out t3))
                {
                    dataTypeR1.Add("Integer");
                }
                else if (double.TryParse(item, out t2))
                {
                    dataTypeR1.Add("Double");
                }
                else if (DateTime.TryParse(item, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out t1))
                {
                    dataTypeR1.Add("Date");
                }
                else
                {
                    dataTypeR1.Add("String");
                }


            }
            ViewBag.d = dataTypeR1;
            //row count error
            List<int> CountErrList = new List<int>();
            //data type mismatch error
            List<List<int>> dataTypeErrList = new List<List<int>>();
            //Validate Data
            for (int i = 1; i < Result.Length; i++)
            {
                DateTime t1;
                double t2;
                int t3;
                string[] temp = Result[i].Split(new string[] { "," }, StringSplitOptions.None);
                if (temp.Length != Labels.Length)
                {
                    CountErrList.Add(i);
                    continue;
                }
                for(int j=0;j<dataTypeR1.Count;j++)
                {
                    if (dataTypeR1[j] == "Date" && !( DateTime.TryParse( temp[j], CultureInfo.CreateSpecificCulture( "en-US" ), DateTimeStyles.None, out t1 ) || DateTime.TryParse( temp[j], CultureInfo.CreateSpecificCulture("fr-FR"), DateTimeStyles.None, out t1 )) )
                    {
                        List<int> te = new List<int>();
                        te.Add(i);
                        te.Add(j);
                        te.Add(11);
                        dataTypeErrList.Add(te);
                    }
                    else if (dataTypeR1[j] == "Double" && !double.TryParse(temp[j], out t2))
                    {
                        List<int> te = new List<int>();
                        te.Add(i);
                        te.Add(j);
                        te.Add(22);
                        dataTypeErrList.Add(te);
                    }
                    else if (dataTypeR1[j] == "Integer" && !int.TryParse(temp[j], out t3))
                    {
                        List<int> te = new List<int>();
                        te.Add(i);
                        te.Add(j);
                        te.Add(33);
                        dataTypeErrList.Add(te);
                    }
                    
                }
            }

            if (CountErrList.Count >0)
            {
                //error occured dont let user chose the labels for plotting the data
                //just prompt the error

                //set flag
                bool err = true;
                ViewBag.cerr = err;

                //set error message
                ViewBag.cerrMessage = "You have mismatch of #attributes at line(s):-";
                ViewBag.celist = CountErrList;
                

            }
            if (dataTypeErrList.Count >0)
            {
                //set flag
                
                ViewBag.dterr = true;

                //set error message
                ViewBag.dterrMessage = "You have mismatch of datatype at line and collumn:-";
                ViewBag.dtelist = dataTypeErrList;

            }


            
            ViewBag.data = data;
            return View();
        } 
    }
}




/*
 else
{
    //no error in data]

    //let user select which type of graph to plot


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
            //set err flag
            bool perr = true;
            //set message
            string perrmsg = "";
            //render view
        }
                    
    }

    ViewBag.DataPoints = JsonConvert.SerializeObject(ls);
    //yep thats it
}


     */






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
