import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inchiriere } from './inchiriere.models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inchiriere-add',
  templateUrl: './inchiriere-add.component.html'
})
export class InchiriereAddComponent {

  public inchiriere: Inchiriere = <Inchiriere>{};

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router) { }

  public saveInchiriere() {
    this.http.post(this.baseUrl + 'api/inchiriere', this.inchiriere).subscribe(result => {
      this.router.navigateByUrl("/inchiriere");
    }, error => console.error(error))
  }
}
