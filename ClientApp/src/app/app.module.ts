import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { TraseuComponent } from './traseu/traseu.component';
import { TraseuAddComponent } from './traseu/traseu-add.component';
import { InchiriereComponent } from './inchiriere/inchiriere.component';
import { InchiriereAddComponent } from './inchiriere/inchiriere-add.component';
import { DificultateComponent } from './dificultate/dificultate.component';
import { DificultateAddComponent } from './dificultate/dificultate-add.component';
import { CerinteComponent } from './cerinte/cerinte.component';
import { CerinteAddComponent } from './cerinte/cerinte-add.component';
import { ExperientaComponent } from './experienta/experienta.component';
import { ExperientaAddComponent } from './experienta/experienta-add.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    TraseuComponent,
    TraseuAddComponent,
    InchiriereComponent,
    InchiriereAddComponent,
    DificultateComponent,
    DificultateAddComponent,
    CerinteComponent,
    CerinteAddComponent,
    ExperientaComponent,
    ExperientaAddComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'traseu', component: TraseuComponent },
      { path: 'traseu-add', component: TraseuAddComponent },
      { path: 'inchiriere', component: InchiriereComponent },
      { path: 'inchiriere-add', component: InchiriereAddComponent },
      { path: 'dificultate', component: DificultateComponent },
      { path: 'dificultate-add', component: DificultateAddComponent },
      { path: 'cerinte', component: CerinteComponent },
      { path: 'cerinte-add', component: CerinteAddComponent },
      { path: 'experienta', component: ExperientaComponent },
      { path: 'experienta-add', component: ExperientaAddComponent },
    ], { relativeLinkResolution: 'legacy' })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
