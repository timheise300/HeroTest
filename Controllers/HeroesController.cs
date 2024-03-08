using HeroTest.Models;
using HeroTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers;
[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{
    private readonly IHeroService _heroService;

    private readonly ILogger<HeroesController> _logger;

    public HeroesController(IHeroService heroService, ILogger<HeroesController> logger)
    {
        _heroService = heroService;
        _logger = logger;
    }

    [HttpGet("getallheroes")]
    public IActionResult GetAllHeroes()
    {
        IEnumerable<Hero> heroes = _heroService.GetAllHeroes();
        _logger.LogDebug(heroes.ToString());
        return Ok(heroes);
    }

    [HttpGet("getallbrands")]
    public IActionResult GetAllBrands()
    {
        IEnumerable<Brand> brands = _heroService.GetAllBrands();
        _logger.LogDebug(brands.ToString());
        return Ok(brands);
    }

    [HttpPost]
    public IActionResult AddHero([FromBody] Hero hero)
    {
        if (ModelState.IsValid)
        {
            _heroService.AddHero(hero);
            return Ok();
        }
        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteHero(int id)
    {
        _heroService.DeleteHero(id);
        return Ok();
    }
}

