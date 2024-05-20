using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text;

namespace Tareas.Pages
{
    public class CaesarCipherModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        public string Result { get; set; }

        // Definir una lista que contenga todas las letras del alfabeto excluyendo la 'W'
        private List<char> alfabetolista = new List<char>
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'X', 'Y', 'Z'
        };


        public void OnPost(string action)
        {
            if (!string.IsNullOrEmpty(Message))
            {
                if (action == "encode")
                {
                    Result = CaesarCipher(Message, 3);
                }
                else if (action == "decode")
                {
                    Result = CaesarCipher(Message, -3);
                }
            }
        }

        private string CaesarCipher(string input, int shift)
        {
            StringBuilder result = new StringBuilder();

            foreach (char i in input.ToUpper())
            {

                if (alfabetolista.Contains(i)) // Verifica si el carácter está en la lista del alfabeto
                {
                    int index = (alfabetolista.IndexOf(i) + shift + alfabetolista.Count) % alfabetolista.Count;
                    result.Append(alfabetolista[index]);
                }
                else
                {
                    result.Append(i);
                }
            }

            return result.ToString();
        }
    }
}
