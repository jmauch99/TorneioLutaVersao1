using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TorneioLuta.Models
{
    public class Lutador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Range(1, 100, ErrorMessage = "A idade deve estar entre 1 e 100.")]
        public int Idade { get; set; }

        public List<string> EstilosDeLutaList { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O número de vitórias deve ser um valor não negativo.")]
        public int? Vitorias { get; set; } // Permitindo valor nulo

        [Range(0, int.MaxValue, ErrorMessage = "O número de derrotas deve ser um valor não negativo.")]
        public int? Derrotas { get; set; } // Permitindo valor nulo

        public int? QtdTorneiosGanhos { get; set; } // Permitindo valor nulo

        public int? QtdEstilosDominados { get; set; } // Permitindo valor nulo

        public int? QtdLutas { get; set; } // Permitindo valor nulo

        public bool ParticipaDoTorneio { get; set; }

        public List<string> GetEstilosDeLutaList()
        {
            return EstilosDeLutaList ?? new List<string>();
        }
    }
}
