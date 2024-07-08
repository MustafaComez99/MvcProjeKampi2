using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcProjeKampi2.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context _context = new Context();
        public ActionResult Index()
        {// Toplam kategori sayısı
            var totalCategories = _context.Categories.Count();

            // "Yazılım" kategorisine ait başlık sayısı
            var softwareCategoryId = _context.Categories
                .FirstOrDefault(c => c.CategoryName.ToLower() == "yazılım")?.CategoryID;
            var softwareTitlesCount = _context.Headings
                .Count(t => t.CategoryID == softwareCategoryId);

            // Yazar adında 'a' harfi geçen yazar sayısı
            var authorsWithA = _context.Writers
                .Count(a => a.WriterName.ToLower().Contains("a"));

            //En fazla başlığa sahip kategori adı
            var mostTitlesCategory = _context.Categories
                .Select(c => new
                {
                    c.CategoryName,
                    TitleCount = c.Headings.Count
                })
                .OrderByDescending(c => c.TitleCount)
                .FirstOrDefault()?.CategoryName;

            // Durumu true olan ve false olan kategoriler arasındaki fark
            var trueCategoriesCount = _context.Categories.Count(c => c.CategoryStatus == true);
            var falseCategoriesCount = _context.Categories.Count(c => c.CategoryStatus == false);
            var statusDifference = trueCategoriesCount - falseCategoriesCount;

            // Verileri View'a taşıma
            ViewBag.TotalCategories = totalCategories;
            ViewBag.SoftwareTitlesCount = softwareTitlesCount;
            ViewBag.AuthorsWithA = authorsWithA;
            ViewBag.MostTitlesCategory = mostTitlesCategory;
            ViewBag.TrueCategoriesCount = trueCategoriesCount;
            ViewBag.FalseCategoriesCount = falseCategoriesCount;
            ViewBag.StatusDifference = statusDifference;

            return View();

        }
    }
}