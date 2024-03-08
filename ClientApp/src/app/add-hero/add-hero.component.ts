import { Component } from '@angular/core';
import { HeroService } from '../services/hero.service';
import { Hero } from '../models/hero';
import { Brand } from '../models/brand';

@Component({
  selector: 'app-add-hero',
  templateUrl: './add-hero.component.html'
})
export class AddHeroComponent {
  brands: Brand[] = [];
  hero: Hero = new Hero();
  errorMessage: string = '';

  constructor(private heroService: HeroService) { }

  ngOnInit(): void {
    this.getBrands();
  }

  getBrands(): void {
    this.heroService.getAllBrands().subscribe((brands: Brand[]) => this.brands = brands);
    console.log(this.brands);
  }

  addHero(): void {
    this.heroService.addHero(this.hero).subscribe(
      () => {
        // Success
      },
      error => {
        this.errorMessage = error;
      }
    );
  }
}
