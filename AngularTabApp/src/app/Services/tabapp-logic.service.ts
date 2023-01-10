import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Entries } from '../Models/Entries'

@Injectable({
  providedIn: 'root'
})
export class TabappLogicService {

  url : string = environment.api;

  constructor(private http: HttpClient) { }

  getAllEntries() : Observable<Entries[]> {
    return this.http.get(this.url + `viewEntries`) as Observable<Entries[]>;
  }
}
