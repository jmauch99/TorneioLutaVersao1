using System.Collections.Generic;
using TorneioLuta.Models;

namespace TorneioLuta.Services
{
    public interface ILutadorService
    {
        List<Lutador> GetLutadores();
        void InserirNoTorneio(int[] ids);
        void RealizarTorneio();
        Lutador ObterVencedor();


    }
}
