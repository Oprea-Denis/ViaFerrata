import { Component } from '@angular/core';
import { Inchiriere } from './inchiriere.models';
import { InchiriereService } from './inchiriere.service';

@Component({
  selector: 'app-inchiriere',
  templateUrl: './inchirirere.component.html'
})
export class InchiriereComponent {
  public inchiriere: Inchiriere[];

  constructor(private InchiriereService: InchiriereService) {
    this.loadInchiriere();
  }

  public deleteInchiriere(inchiriere: Inchiriere) {
    this.InchiriereService.deleteInchiriere(inchiriere).subscribe(result => {
      this.loadInchiriere();
    }, error => console.error(error))
  }

  loadInchiriere() {
    this.InchiriereService.loadInchiriere().subscribe(result => {
      this.inchiriere = result;
    }, error => console.error(error));
  }
}
