using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using TorneioLuta.Models;

namespace TorneioLuta.Repositories

{
    public interface ILutadorRepository
    {
        List<Lutador> GetAll();
        void Update(Lutador lutador);
        void SaveChanges();
    }
}



