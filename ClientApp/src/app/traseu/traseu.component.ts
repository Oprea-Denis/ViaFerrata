import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Traseu } from './traseu.models';

@Component({
  selector: 'app-traseu',
  templateUrl: './traseu.component.html'
})
export class TraseuComponent {
  public traseu: Traseu[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.loadTraseu();
  }

  public deleteTraseu(traseu: Traseu) {
    this.http.delete(this.baseUrl + 'api/traseu/' + traseu.id).subscribe(result => {
      this.loadTraseu();
    }, error => console.error(error))
  }

  loadTraseu() {
    this.http.get<Traseu[]>(this.baseUrl + 'api/traseu').subscribe(result => {
      this.traseu = result;
    }, error => console.error(error));
  }
}
