import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Traseu } from './traseu.models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-traseu-add',
  templateUrl: './traseu-add.component.html'
})
export class TraseuAddComponent {

  public traseu: Traseu = <Traseu>{};

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router) { }

  public saveTraseu() {
    this.http.post(this.baseUrl + 'api/traseu', this.traseu).subscribe(result => {
      this.router.navigateByUrl("/traseu");
    }, error => console.error(error))
  }
}
