import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cerinte } from './cerinte.models';

@Component({
  selector: 'app-cerinte',
  templateUrl: './cerinte.component.html'
})
export class CerinteComponent {
  public cerinte: Cerinte[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.loadCerinte();
  }

  public deleteCerinte(cerinte: Cerinte) {
    this.http.delete(this.baseUrl + 'api/cerinte/' + cerinte.id).subscribe(result => {
      this.loadCerinte();
    }, error => console.error(error))
  }

  loadCerinte() {
    this.http.get<Cerinte[]>(this.baseUrl + 'api/cerinte').subscribe(result => {
      this.cerinte = result;
    }, error => console.error(error));
  }
}
