import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Experienta } from './experienta.models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-experienta-add',
  templateUrl: './experienta-add.component.html'
})
export class ExperientaAddComponent {

  public experienta: Experienta = <Experienta>{};

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router) { }

  public saveExperienta() {
    this.http.post(this.baseUrl + 'api/experienta', this.experienta).subscribe(result => {
      this.router.navigateByUrl("/experienta");
    }, error => console.error(error))
  }
}
