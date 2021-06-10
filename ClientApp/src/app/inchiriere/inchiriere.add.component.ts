import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Inchiriere } from './inchiriere.models';

import { InchiriereService } from './inchiriere.service';

@Component({
  selector: 'app-inchiriere-add',
  templateUrl: './inchiriere.add.component.html'
})
export class InchiriereAddComponent {

  public inchiriere: Inchiriere = <Inchiriere>{};

  constructor(
    private inchiriereService: InchiriereService,
    private router: Router) { }

  public saveDuckbill() {
    this.inchiriereService.saveInchiriere(this.inchiriere).subscribe(result => {
      this.router.navigateByUrl("/Inchiriere");
    }, error => console.error(error))
  }
}
