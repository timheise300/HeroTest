import { Component } from '@angular/core';
import { HeroService } from '../services/hero.service';
import { Hero } from '../models/hero';

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.component.html'
})
export class HeroListComponent {
  heroes: Hero[] = [];
  headerNames: string[] = Object.keys(new Hero())
    .filter(header => header != 'brandId');

  constructor(private heroService: HeroService) { }

  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes(): void {
    this.heroService.getAllHeroes().subscribe((heroes: Hero[]) =>
      this.heroes = heroes.filter(h => h.isActive = true));
    console.log(this.heroes);
  }

  deleteHero(id: number): void {
    this.heroService.deleteHero(id).subscribe(() => {
      this.heroes = this.heroes.filter(h => h.id !== id);
      this.getHeroes();
    });
  }
}
