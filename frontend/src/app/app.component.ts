import { Component, OnInit } from '@angular/core';
import { API, DataStorageService } from './shared/data-storage.service';
import { Kategoria, Recept } from './shared/interfaces';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  receptek: Recept[] = [];
  receptekView: Recept[] = [];

  kategoriak: Kategoria[] = [];
  kijelolt: Recept = null;
  constructor(private dataStorageService: DataStorageService) {}

  ngOnInit(): void {
    this.dataStorageService
      .get(API.RECEPT.GET)

      .pipe(
        map((data) => {
          const newData: Recept[] = data.map((row_data) => {
            return {
              id: row_data.id,
              nev: row_data.nev,
              katId: row_data.katId,
              kat_nev: row_data.kat.nev,
              kepURL: row_data.kepEleresiUt,
              leiras: row_data.leiras,
            };
          });
          return [...newData];
        }),
        tap({
          next: (data) => {
            this.receptek = data;
            this.receptekView = [...this.receptek.map((data)=>{
              return {...data}
            })]
            console.log(this.receptek);
          },
          error: (error) => {
            console.error(error);
          },
        })
      )
      .subscribe();

    this.dataStorageService
      .get(API.KATEGORIA.GET)
      .pipe(
        tap({
          next: (data: Recept[]) => {
           this.kategoriak = data;
           console.log(this.kategoriak);
          },
          error: (error) => {
            console.error(error);
          },
        })
      )
      .subscribe();
  }

  kijelol(id: number){
   this.kijelolt = this.receptek.find((recept)=>{
    return recept.id == id;
   })
  }

  mutat(id: number){
    console.log(id);
    
    this.receptekView = this.receptek.filter((recept)=>{
      return recept.katId == id || id == -1;
    })
  }
}
