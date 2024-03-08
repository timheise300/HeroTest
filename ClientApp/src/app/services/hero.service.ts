import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Hero } from '../models/hero';
import { Brand } from '../models/brand';

@Injectable({
  providedIn: 'root'
})
export class HeroService {
  private baseUrl = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    baseUrl = baseUrl;
  }

  getAllHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(`${this.baseUrl}heroes/getallheroes`);
  }

  getAllBrands(): Observable<Brand[]> {
    return this.http.get<Brand[]>(`${this.baseUrl}heroes/getallbrands`);
  }

  addHero(hero: Hero): Observable<any> {
    return this.http.post(`${this.baseUrl}heroes`, hero);
  }

  deleteHero(id: number): Observable<any> {
    const url = `${this.baseUrl}heroes/${id}`;
    return this.http.delete(url);
  }
}

