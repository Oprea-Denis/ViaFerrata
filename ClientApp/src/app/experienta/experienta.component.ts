import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Experienta } from './experienta.models';

@Component({
  selector: 'app-experienta',
  templateUrl: './experienta.component.html'
})
export class ExperientaComponent {
  public experienta: Experienta[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.loadExperienta();
  }

  public deleteExperienta(experienta: Experienta) {
    this.http.delete(this.baseUrl + 'api/experienta/' + experienta.id).subscribe(result => {
      this.loadExperienta();
    }, error => console.error(error))
  }

  loadExperienta() {
    this.http.get<Experienta[]>(this.baseUrl + 'api/experienta').subscribe(result => {
      this.experienta = result;
    }, error => console.error(error));
  }
}
