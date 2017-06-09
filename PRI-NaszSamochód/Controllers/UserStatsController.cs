using Microsoft.AspNet.Identity;
using PRI_NaszSamochód.Models;
using System;
using System.Collections;
using System.Linq;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

namespace PRI_NaszSamochód.Controllers
{
    public class UserStatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserStatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserStats
        public ActionResult FuelChart()
        {

            string Blue =
            @"<Chart BackColor=""#D3DFF0"" BackGradientStyle=""TopBottom"" BackSecondaryColor=""White"" BorderColor=""26, 59, 105""
            BorderlineDashStyle=""Solid"" BorderWidth=""2"" Palette=""BrightPastel"">
            <ChartAreas>
            <ChartArea Name=""Default"" _Template_=""All"" BackColor=""64, 165, 191, 228"" BackGradientStyle=""TopBottom""
            BackSecondaryColor=""White"" BorderColor=""64, 64, 64, 64"" BorderDashStyle=""Solid"" ShadowColor=""Transparent"" />
            </ChartAreas>
            <Legends>
            <Legend _Template_=""All"" BackColor=""Transparent"" Font=""Trebuchet MS, 8.25pt, style=Bold"" IsTextAutoFit=""False"" />
            </Legends>
            <BorderSkin SkinStyle=""Emboss"" />
            </Chart>";
        String id = User.Identity.GetUserId();

            var _context = new ApplicationDbContext();
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();

            var results = (from c in _context.UserStatistics
                           where c.User.Id == id
                           orderby c.RecordTime descending
                           select c).Take(50);

            results.ToList().ForEach(x => xValues.Add(x.RecordTime));
            results.ToList().ForEach(y => yValues.Add(y.FuelUsed));

            new Chart(width: 1200, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Zużyte paliwo")
                .AddSeries("Default", chartType: "Column", xValue: xValues, yValues: yValues)
                .Write("jpeg");

            return null;
        }
        public ActionResult KilometersDrivenChart()
        {
            String id = User.Identity.GetUserId();

            var _context = new ApplicationDbContext();
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();

            var results = (from c in _context.UserStatistics
                           where c.User.Id == id
                           orderby c.RecordTime descending
                           select c).Take(50);

            results.ToList().ForEach(x => xValues.Add(x.RecordTime));
            results.ToList().ForEach(y => yValues.Add(y.KilometersDriven));

            new Chart(width: 1200, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Przejechane kilometry")
                .AddSeries("Default", chartType: "Column", xValue: xValues, yValues: yValues)
                .Write("jpeg");

            return null;
        }
        public ActionResult MaxVelocityChart()
        {
            String id = User.Identity.GetUserId();

            var _context = new ApplicationDbContext();
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();

            var results = (from c in _context.UserStatistics
                           where c.User.Id == id
                           orderby c.RecordTime descending
                           select c).Take(50);

            results.ToList().ForEach(x => xValues.Add(x.RecordTime));
            results.ToList().ForEach(y => yValues.Add(y.MaxVelocity));

            new Chart(width: 1200, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Prędkość maksymalna")
                .AddSeries("Default", chartType: "Column", xValue: xValues, yValues: yValues)
                .Write("jpeg");

            return null;
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult AddStats()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult AddStats([FromBody] UserStatistics stats)
        {
            if (ModelState.IsValid)
            {
                string id = User.Identity.GetUserId();
                DateTime nowDate = DateTime.Now;
                stats.RecordTime = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day, nowDate.Hour, 0, 0);
                stats.User = _context.Users.Single(u=>u.Id == id);
                _context.UserStatistics.Add(stats);
                _context.SaveChanges();
                return RedirectToAction("AddStats");
            }
            return View();
        }

    }
}