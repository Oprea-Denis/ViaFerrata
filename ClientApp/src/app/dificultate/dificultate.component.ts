import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Dificultate } from './dificultate.models';

@Component({
  selector: 'app-dificultate',
  templateUrl: './dificultate.component.html'
})
export class DificultateComponent {
  public dificultate: Dificultate[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.loadDificultate();
  }

  public deleteDificultate(dificultate: Dificultate) {
    this.http.delete(this.baseUrl + 'api/dificultate/' + dificultate.id).subscribe(result => {
      this.loadDificultate();
    }, error => console.error(error))
  }

  loadDificultate() {
    this.http.get<Dificultate[]>(this.baseUrl + 'api/dificultate').subscribe(result => {
      this.dificultate = result;
    }, error => console.error(error));
  }
}
