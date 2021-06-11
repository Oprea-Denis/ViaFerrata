import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inchiriere } from './inchiriere.models';

@Component({
  selector: 'app-inchiriere',
  templateUrl: './inchiriere.component.html'
})
export class InchiriereComponent {
  public inchiriere: Inchiriere[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.loadInchiriere();
  }

  public deleteInchiriere(inchiriere: Inchiriere) {
    this.http.delete(this.baseUrl + 'api/inchiriere/' + inchiriere.id).subscribe(result => {
      this.loadInchiriere();
    }, error => console.error(error))
  }

  loadInchiriere() {
    this.http.get<Inchiriere[]>(this.baseUrl + 'api/inchiriere').subscribe(result => {
      this.inchiriere = result;
    }, error => console.error(error));
  }
}
