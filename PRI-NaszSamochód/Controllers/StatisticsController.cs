using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRI_NaszSamochód.Models;

namespace PRI_NaszSamochód.Controllers
{
    public class StatisticsController
    {
        private readonly ApplicationDbContext _context;

        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}