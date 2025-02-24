using Microsoft.EntityFrameworkCore;
using MVC_CORE_PROJE.Data;

namespace ProjeOdevi.Services
{
    //Generic Repository
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected KitapDBContext _context;
        protected DbSet<TEntity> table;

        //ctor injection...
        public BaseRepository(KitapDBContext context)
        {
            _context = context;
            table = context.Set<TEntity>();
        }
        public void Ekle(TEntity entity)
        {
            table.Add(entity);
            _context.SaveChanges();
        }
        public void Guncelle(TEntity entity)
        {
            table.Update(entity);
            _context.SaveChanges();
        }
        public TEntity Ara(int id)
        {
            return table.Find(id);
        }
        public void Sil(int id)
        {
            table.Remove(Ara(id));
            _context.SaveChanges();
        }
        public List<TEntity> Listele()
        {
            return table.ToList();
        }
    }
}
