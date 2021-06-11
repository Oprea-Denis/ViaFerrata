import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Dificultate } from './dificultate.models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dificultate-add',
  templateUrl: './dificultate-add.component.html'
})
export class DificultateAddComponent {

  public dificultate: Dificultate = <Dificultate>{};

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router) { }

  public saveDificultate() {
    this.http.post(this.baseUrl + 'api/dificultate', this.dificultate).subscribe(result => {
      this.router.navigateByUrl("/dificultate");
    }, error => console.error(error))
  }
}
