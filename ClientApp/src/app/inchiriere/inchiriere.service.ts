import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

import { Inchiriere } from './Inchiriere.models';

@Injectable({
  providedIn: 'root'
})
export class InchiriereService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  loadInchiriere() {
    return this.http.get<Inchiriere[]>(this.baseUrl + 'api/inchiriere');
  }

  public saveInchiriere(inchiriere: Inchiriere) {
    return this.http.post(this.baseUrl + 'api/inchiriere', inchiriere);
  }

  deleteInchiriere(inchiriere: Inchiriere) {
    return this.http.delete(this.baseUrl + 'api/inchiriere/' + inchiriere.id);
  }
}
