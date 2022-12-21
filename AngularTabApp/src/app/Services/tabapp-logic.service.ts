import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cosminis } from '../Models/Entries';

@Injectable({
  providedIn: 'root'
})
export class TabappLogicService {

  constructor(private http: HttpClient) { }
}
