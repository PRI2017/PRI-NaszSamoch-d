using PRI_NaszSamochód.Models;
using System.Collections;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PRI_NaszSamochód.Controllers
{
    public class UserStatsController : Controller
    {
        // GET: UserStats
        public ActionResult FuelChart()
        {
            var _context = new ApplicationDbContext();
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();

            var results = (from c in _context.UserStatistics select c);

            results.ToList().ForEach(x => xValues.Add(x.RecordTime));
            results.ToList().ForEach(y => yValues.Add(y.FuelUsed));

            new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla3D)
                .AddTitle("FUEL USED")
                .AddSeries("Default", chartType: "Column", xValue: xValues, yValues: yValues)
                .Write("jpeg");

            return null;
        }
        public ActionResult KilometersDrivenChart()
        {
            var _context = new ApplicationDbContext();
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();

            var results = (from c in _context.UserStatistics select c);

            results.ToList().ForEach(x => xValues.Add(x.RecordTime));
            results.ToList().ForEach(y => yValues.Add(y.KilometersDriven));

            new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla3D)
                .AddTitle("Kilometers Driven")
                .AddSeries("Default", chartType: "Column", xValue: xValues, yValues: yValues)
                .Write("jpeg");

            return null;
        }
        public ActionResult MaxVelocityChart()
        {
            var _context = new ApplicationDbContext();
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();

            var results = (from c in _context.UserStatistics select c);

            results.ToList().ForEach(x => xValues.Add(x.RecordTime));
            results.ToList().ForEach(y => yValues.Add(y.MaxVelocity));

            new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla3D)
                .AddTitle("Max Velocity")
                .AddSeries("Default", chartType: "Column", xValue: xValues, yValues: yValues)
                .Write("jpeg");

            return null;
        }
    }
}