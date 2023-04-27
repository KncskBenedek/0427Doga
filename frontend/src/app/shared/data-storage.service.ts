import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DataStorageService {

    constructor(private http: HttpClient) {}
    
    get(api: string){
        return this.http.get<any>(this.alap + api);
    }
    post(api: string, body: any){
        return this.http.post<any>(this.alap + api, body);
    }
    
    delete(api: string){
        return this.http.delete(this.alap + api);
    }
    
  alap: string = "https://localhost:7258/api";
 

    
  
}

export const API = {
    
    KATEGORIA : {
        GET: "/kategoria"
    },
    RECEPT:{
        GET:"/recept",
        POST: "/recept",
        DELETE: "/recept/"
    }
  };