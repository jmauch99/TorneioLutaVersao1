using TorneioLuta.Models;
using Microsoft.EntityFrameworkCore;

namespace TorneioLuta.Repositories
{
    public class LutadorRepository : ILutadorRepository
    {
        private readonly TorneioContext _dbContext;

        public LutadorRepository(TorneioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Lutador> GetAll()
        {
            return _dbContext.Lutadores.ToList();
        }

        public void Update(Lutador lutadores)
        {
            _dbContext.Lutadores.Update(lutadores);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

