using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2P1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP2P1.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TP2P1.Controllers.Tests
{
    
    

    [TestClass()]
    public class SeriesControllerTests
    {
        private SeriesController controller;

        public SeriesControllerTests()
        {
            var builder = new DbContextOptionsBuilder<SeriesDBContext>().UseNpgsql("Server = localhost; port=5432;Database=SeriesDB; uid=postgres;password=postgres;");
            SeriesDBContext context = new SeriesDBContext(builder.Options);
            controller = new SeriesController(context);

        }

        [TestMethod()]
        public  void GetSeriesTest()
        {
            Task<ActionResult<IEnumerable<Serie>>> expectedSeries =  controller.GetSeries();


            // Assert
            CollectionAssert.AreEqual(expectedSeries, actualSeries);

        }
}