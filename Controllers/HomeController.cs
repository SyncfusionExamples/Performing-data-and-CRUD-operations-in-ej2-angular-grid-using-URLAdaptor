using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UrlAdaptor.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;


namespace UrlAdaptor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
            // Retrieve data from the data source (e.g., database)
            System.Collections.IEnumerable data = OrdersDetails.GetAllRecords();

            DataOperations operation = new(); // Initialize DataOperations instance

            //Sorting
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                data = operation.PerformSorting(data, dm.Sorted);
            }

            //Filtering
            if (dm.Where != null && dm.Where.Count > 0)
            {
                data = operation.PerformFiltering(data, dm.Where, dm.Where[0].Operator);
            }

            //Searching
            if (dm.Search != null && dm.Search.Count > 0)
            {
                data = operation.PerformSearching(data, dm.Search);
            }

            // Paging
            if (dm.Skip != 0)
            {
                data = operation.PerformSkip(data, dm.Skip);
            }
            if (dm.Take != 0)
            {
                data = operation.PerformTake(data, dm.Take);
            }

            // Get the total count of records
            int count = data.Cast<OrdersDetails>().Count();

            // Return data based on the request
            return dm.RequiresCounts ? Ok(new { result = data, count }) : Ok(data);
        }

        // update the record
        public ActionResult Update([FromBody] CRUDModel<OrdersDetails> value)
        {
            var ord = value.value;
            var existingOrder = OrdersDetails.GetAllRecords().FirstOrDefault(or => or.OrderID == ord.OrderID);

            // Update existing order with values from the provided order
            existingOrder = ord;
            return Json(existingOrder);
        }

        //insert the record
        public ActionResult Insert([FromBody] CRUDModel<OrdersDetails> value)
        {

            OrdersDetails.GetAllRecords().Insert(0, value.value);
            return Json(value.value);
        }
        //Delete the record
        public ActionResult Delete([FromBody] CRUDModel<OrdersDetails> value)
        {
            int orderId = int.Parse(value.key.ToString());
            var data = OrdersDetails.GetAllRecords().FirstOrDefault(or => or.OrderID == orderId);
            if (data != null)
            {
                // Remove the record from the data collection
                OrdersDetails.GetAllRecords().Remove(data);
            }
            return Json(value);
        }
        public class CRUDModel<T> where T : class
        {
            public string? action { get; set; }

            public string? table { get; set; }

            public string? keyColumn { get; set; }

            public object? key { get; set; }

            public T value { get; set; }

            public List<T>? added { get; set; }

            public List<T>? changed { get; set; }

            public List<T>? deleted { get; set; }

            public IDictionary<string, object> @params { get; set; }
        }

    }
}