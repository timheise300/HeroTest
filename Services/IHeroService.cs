using HeroTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Services;

public interface IHeroService
{
    IEnumerable<Hero> GetAllHeroes();
    IEnumerable<Brand> GetAllBrands();
    void AddHero(Hero hero);
    void DeleteHero(int id);
}

public class HeroService : IHeroService
{
    private readonly SampleContext _context;

    public HeroService(SampleContext context)
    {
        _context = context;
    }

    public IEnumerable<Hero> GetAllHeroes()
    {
        return _context.Heroes.Include(h => h.Brand);
    }

    public IEnumerable<Brand> GetAllBrands()
    {
        return _context.Brands;
    }

    public void AddHero(Hero hero)
    {
        hero.CreatedOn = DateTime.Now;
        hero.UpdatedOn = DateTime.Now;
        hero.IsActive = true;
        _context.Heroes.Add(hero);
        _context.SaveChanges();
    }

    public void DeleteHero(int id)
    {
        var hero = _context.Heroes.Find(id);
        if (hero != null)
        {
            hero.IsActive = false;
            _context.SaveChanges();
        }
    }
}
