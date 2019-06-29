using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.DataAccess;
using Videotheque.Models;

namespace Videotheque.Services
{
    public class AmiService
    {
        public async Task<List<Personne>> GetAmis()
        {
            var context = await VideothequeDbContext.GetCurrent();
            var amis = context.Personnes;
            return amis.ToList();
        }

        public async Task AddAmi(Personne ami)
        {
            var context = await VideothequeDbContext.GetCurrent();
            context.Add(ami);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAmi(Personne ami)
        {
            var context = await VideothequeDbContext.GetCurrent();
            context.Update(ami);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAmi(Personne ami)
        {
            var context = await VideothequeDbContext.GetCurrent();
            context.Remove(ami);
            await context.SaveChangesAsync();
        }

        public async Task Preter(MediaPersonne mp)
        {
            var context = await VideothequeDbContext.GetCurrent();
            context.Add(mp);
            await context.SaveChangesAsync();
        }

        public async Task Rendre(MediaPersonne mp)
        {
            var context = await VideothequeDbContext.GetCurrent();
            context.Remove(mp);
            await context.SaveChangesAsync();
        }
    }
}
