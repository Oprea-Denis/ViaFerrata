import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cerinte } from './cerinte.models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cerinte-add',
  templateUrl: './cerinte-add.component.html'
})
export class CerinteAddComponent {

  public cerinte: Cerinte = <Cerinte>{};

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router) { }

  public saveCerinte() {
    this.http.post(this.baseUrl + 'api/cerinte', this.cerinte).subscribe(result => {
      this.router.navigateByUrl("/cerinte");
    }, error => console.error(error))
  }
}
