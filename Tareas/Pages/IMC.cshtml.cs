using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tareas.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public double Weight { get; set; }
        [BindProperty]
        public double Height { get; set; }
        public double BMI { get; set; }
        public string Classification { get; set; }
        public string RecommendationImage { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (Weight > 0 && Height > 0)
            {
                BMI = Weight / (Height * Height);
                SetClassificationAndImage();
            }
        }

        private void SetClassificationAndImage()
        {
            if (BMI < 18)
            {
                Classification = "Peso Bajo";
                RecommendationImage = "images/bajo.jfif";
            }
            else if (BMI >= 18 && BMI < 25)
            {
                Classification = "Peso Normal";
                RecommendationImage = "images/normal.jfif"; ;
            }
            else if (BMI >= 25 && BMI < 27)
            {
                Classification = "Sobre peso";
                RecommendationImage = "images/alto.jfif";
            }
            else if (BMI >= 27 && BMI < 30)
            {
                Classification = "Obesidad grado I";
                RecommendationImage = "images/grado.png";
            }
            else if (BMI >= 30 && BMI < 40)
            {
                Classification = "Obesidad grado II";
                RecommendationImage = "images/grado.png";
            }
            else
            {
                Classification = "Obesidad grado III";
                RecommendationImage = "images/grado.png";
            }
        }
    }
}
