using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tareas.Pages
{
    public class ArregloModel : PageModel
    {
        public List<int> Numbers { get; private set; }
        public int Sum { get; private set; }
        public double Average { get; private set; }
        public List<int> Mode { get; private set; }
        public double Median { get; private set; }

        public void OnGet()
        {
            GenerateRandomNumbers();
            CalculateSum();
            CalculateAverage();
            CalculateMode();
            CalculateMedian();
        }

        private void GenerateRandomNumbers()
        {
            Random random = new Random();
            Numbers = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                Numbers.Add(random.Next(100)); // Genera números aleatorios entre 0 y 100
            }
        }

        private void CalculateSum()
        {
            Sum = Numbers.Sum();
        }

        private void CalculateAverage()
        {
            Average = (double)Sum / Numbers.Count;
        }

        private void CalculateMode()
        {
            var groupedNumbers = Numbers.GroupBy(n => n);
            int maxFrequency = groupedNumbers.Max(g => g.Count());
            Mode = groupedNumbers.Where(g => g.Count() == maxFrequency).Select(g => g.Key).ToList();
        }

        private void CalculateMedian()
        {
            Numbers.Sort();
            if (Numbers.Count % 2 == 0)
            {
                Median = (Numbers[Numbers.Count / 2] + Numbers[Numbers.Count / 2 - 1]) / 2.0;
            }
            else
            {
                Median = Numbers[Numbers.Count / 2];
            }
        }
    }
}
