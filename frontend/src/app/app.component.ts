import { Component, OnInit } from '@angular/core';
import { API, DataStorageService } from './shared/data-storage.service';
import { Kategoria, Recept } from './shared/interfaces';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit{

  receptek: Recept[] = [];
  kategoriak: Kategoria[] = []
  constructor(private dataStorageService: DataStorageService) {}
  
  
  ngOnInit(): void {
    this.dataStorageService.get(API.RECEPT.GET)
    .pipe(
      tap({
        next: (data)=>{
          console.log(data);
          
        },
        error: (error)=>{
          console.error(error);
          
        }
      })
      )
    .subscribe();

    this.dataStorageService.get(API.KATEGORIA.GET)
    .pipe(
      tap({
        next: (data)=>{
          console.log(data);
          
        },
        error: (error)=>{
          console.error(error);
          
        }
      })
    )
    .subscribe()
    ;
  }


}
