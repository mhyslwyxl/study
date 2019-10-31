using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspEFCore.Web.Models;
using AspEFCore.Data;
using AspEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace AspEFCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AspEFCoreContext _context;
        public HomeController(AspEFCoreContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var province = new Province
            //{
            //    Name = "上海",
            //    Population = 22_000_000
            //};
            //var company = new Company
            //{
            //    Name = "神行科技",
            //    LegalPerson = "张大山",
            //    EstablishDate = DateTime.Parse("2012-3-22")
            //};
            //var province1 = new Province
            //{
            //    Name = "北京",
            //    Population = 20_000_000
            //};
            //var province2 = new Province
            //{
            //    Name = "广东",
            //    Population = 15_000_000
            //};
            //var province3 = new Province
            //{
            //    Name = "济南",
            //    Population = 10_000_000
            //};
            //构造方法中没有注入context使用该方式
            //using (var context = new AspEFCoreContext())
            //{
            //    context.Provinces.Add(province);
            //}
            //构造方法中注入了context,以下2种方式都可以
            //_context.Provinces.Add(province);
            //_context.Add(province); //加入内存

            //批量增加方法1
            //_context.AddRange(province, province1, province2, province3);   
            //批量增加方法2
            //_context.AddRange(new List<Province> { province, province1, province2, province3 });
            //int count = _context.SaveChanges(); //保存改变到数据库，提交
            //Console.WriteLine("---------------------------");
            //Console.WriteLine(count);
            //Console.WriteLine(province.Id);
            return View();
        }

        public IActionResult Update()
        {
            //var province = new Province
            //{
            //    Name = "山东",
            //    Population = 8_000_000,
            //    Cities = new List<City>
            //    {
            //        new City{Name="青岛", AreaCode="0532"},
            //        new City{Name="德州", AreaCode="0533"},
            //        new City{Name="潍坊", AreaCode="0534"},
            //        new City{Name="烟台", AreaCode="0535"}
            //    }
            //};
            //_context.Provinces.Add(province);
            //_context.SaveChanges();

            //List<City> Cities = new List<City>
            //{
            //    new City{Name="广州", AreaCode="0221",ProvinceId=17},
            //    new City{Name="深圳", AreaCode="0222",ProvinceId=17},
            //    new City{Name="东莞", AreaCode="0223",ProvinceId=17},
            //    new City{Name="珠江", AreaCode="0224",ProvinceId=17}
            //};
            //_context.Citys.AddRange(Cities);
            //_context.SaveChanges();

            var province = _context.Provinces.SingleOrDefault(x => x.Name == "广东");
            var cities = _context.Citys.Where(x => EF.Functions.Like(x.AreaCode, "022%"));
            //foreach (City city in cities)
            //{
            //    //city.Province = province;
            //    //province.Cities.Add(city);
            //}
            province.Cities.AddRange(cities);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Query()
        {
            string city = "北京";
            //var provinces = _context.Provinces
            //    .SingleOrDefault(x => x.Name == city);
            //var provinces = (from p in _context.Provinces
            //                 where p.Id > 0
            //                 orderby p.Population descending
            //                 select p)
            //                .ToList();

            //var rows = _context.Citys
            //    .Include(x => x.Province)
            //    .Include(x => x.CityCompanies)
            //    .Include(x => x.Mayor)
            //    .ToList();
            //var rows = _context.Provinces
            //    .Select(x => new
            //    {
            //        x.Id,
            //        x.Name,
            //        Cities = x.Cities
            //        .Select(y => new
            //        {
            //            y.Id,
            //            y.Name
            //        })
            //        .Where(y => y.Name == "潍坊")
            //        .ToList()
            //    })
            //    .ToList();
            var rows = _context.Provinces
                .Where(x => x.Cities.Any(y => y.Name == "潍坊"))
                .ToList();


            return View(rows);
        }

        public IActionResult Delete()
        {
            _context.Database.ExecuteSqlCommand("delete from provinces where id = 16");
            //_context.Provinces.FromSql("delete from province where id = 16");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
