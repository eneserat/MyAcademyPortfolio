using Microsoft.AspNetCore.Mvc;

namespace MyAcademyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CvSettingController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CvSettingController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            

            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFile cvFile)
        {
            // Dosya seçilmiş mi?
            if (cvFile == null || cvFile.Length == 0)
            {
                TempData["Message"] = "Lütfen bir PDF dosyası seçiniz.";
                return RedirectToAction("Index");
            }

            // PDF uzantısı kontrolü
            string extension = Path.GetExtension(cvFile.FileName).ToLower();

            if (extension != ".pdf")
            {
                TempData["Message"] = "Sadece PDF dosyası yükleyebilirsiniz.";
                return RedirectToAction("Index");
            }

          

            // CV klasörünün yolu
            string folderPath = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "uploads",
                "cv"
            );

            // Klasör yoksa oluştur
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Dosya adı
            string filePath = Path.Combine(folderPath, "CV.pdf");

            // Eski CV varsa sil
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            // Yeni CV'yi kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                cvFile.CopyTo(stream);
            }

            TempData["Message"] = "CV başarıyla yüklendi.";

            return RedirectToAction("Index");
        }
    }
}
