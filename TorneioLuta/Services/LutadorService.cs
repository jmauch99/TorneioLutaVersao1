using TorneioLuta.Repositories;
using System.Collections.Generic;
using TorneioLuta.Models;
using TorneioLuta.Controllers;

namespace TorneioLuta.Services
{
    public class LutadorService : ILutadorService
    {
        private readonly ILutadorRepository _lutadorRepository;

        public LutadorService(ILutadorRepository lutadorRepository)
        {
            _lutadorRepository = lutadorRepository;
        }

        public void InserirNoTorneio(int[] ids)
        {
            foreach (var id in ids)
            {
                var lutador = _lutadorRepository.GetAll().FirstOrDefault(l => l.Id == id);
                if (lutador != null)
                {
                    lutador.ParticipaDoTorneio = true;
                    _lutadorRepository.Update(lutador);
                }
            }
            _lutadorRepository.SaveChanges();
        }

        public List<Lutador> GetLutadores()
        {
            var lutadores = _lutadorRepository.GetAll();

            foreach (var lutador in lutadores)
            {
                lutador.EstilosDeLutaList = lutador.GetEstilosDeLutaList();
            }

            return lutadores;
        }
        public void RealizarTorneio()
        {
            var lutadores = _lutadorRepository.GetAll().Where(l => l.ParticipaDoTorneio).ToList();

            while (lutadores.Count >= 2)
            {
                var vencedores = new List<Lutador>();

                for (int i = 0; i < lutadores.Count; i += 2)
                {
                    var lutador1 = lutadores[i];
                    var lutador2 = lutadores[i + 1];

                    var vencedorLuta = DeterminarVencedorLuta(lutador1, lutador2);
                    vencedores.Add(vencedorLuta);
                }

                lutadores = vencedores;
            }

            var vencedorFinal = lutadores.FirstOrDefault();
            if (vencedorFinal != null)
            {
                vencedorFinal.QtdTorneiosGanhos++;
                _lutadorRepository.Update(vencedorFinal);
            }

            _lutadorRepository.SaveChanges();
        }

        private Lutador DeterminarVencedorLuta(Lutador lutador1, Lutador lutador2)
        {
            var porcentagemVitoriasLutador1 = (double)lutador1.Vitorias / (lutador1.Vitorias + lutador1.Derrotas);
            var porcentagemVitoriasLutador2 = (double)lutador2.Vitorias / (lutador2.Vitorias + lutador2.Derrotas);

            if (porcentagemVitoriasLutador1 > porcentagemVitoriasLutador2)
            {
                AtualizarEstatisticas(lutador1, lutador2);
                return lutador1;
            }
            else if (porcentagemVitoriasLutador2 > porcentagemVitoriasLutador1)
            {
                AtualizarEstatisticas(lutador2, lutador1);
                return lutador2;
            }
            else
            {
                if (lutador1.QtdEstilosDominados > lutador2.QtdEstilosDominados)
                {
                    AtualizarEstatisticas(lutador1, lutador2);
                    return lutador1;
                }
                else if (lutador2.QtdEstilosDominados > lutador1.QtdEstilosDominados)
                {
                    AtualizarEstatisticas(lutador2, lutador1);
                    return lutador2;
                }
                else
                {
                    if (lutador1.QtdLutas > lutador2.QtdLutas)
                    {
                        AtualizarEstatisticas(lutador1, lutador2);
                        return lutador1;
                    }
                    else
                    {
                        AtualizarEstatisticas(lutador2, lutador1);
                        return lutador2;
                    }
                }
            }
        }

        private void AtualizarEstatisticas(Lutador vencedor, Lutador perdedor)
        {
            vencedor.Vitorias ??= 0;
            perdedor.Derrotas ??= 0;
            vencedor.QtdLutas ??= 0;
            perdedor.QtdLutas ??= 0;

            vencedor.Vitorias++;
            perdedor.Derrotas++;
            vencedor.QtdLutas++;
            perdedor.QtdLutas++;
        }

        public Lutador ObterVencedor()
        {
            var todosLutadores = _lutadorRepository.GetAll();

            var vencedor = todosLutadores
                .OrderByDescending(l => l.QtdTorneiosGanhos)
                .FirstOrDefault() ?? new Lutador();

            if (vencedor.Id != 0)
            {
                vencedor.QtdTorneiosGanhos ??= 0;
                vencedor.QtdTorneiosGanhos++;
                _lutadorRepository.Update(vencedor);
                _lutadorRepository.SaveChanges();
            }

            return vencedor;
        }
    }
}

    
    
