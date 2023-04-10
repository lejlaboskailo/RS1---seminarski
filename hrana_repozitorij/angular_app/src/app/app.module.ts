import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule} from "@angular/forms"
import { AppComponent } from './app.component';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistracijaComponent } from './registracija/registracija.component';
import {AutorizacijaLoginProvjera} from "./_guards/autorizacija-login-provjera.service";
import { NotFoundComponent } from './not-found/not-found.component';
import {HomeComponent} from "./home/home.component";
import {PodaciComponent} from "./podaci/podaci.component";
import {MojeNarudzbeComponent} from "./moje-narudzbe/moje-narudzbe.component";
import {MeniComponent} from "./meni/meni.component";
import {NarudzbaComponent} from "./narudzba/narudzba.component";
import {OmiljeneStavkeComponent} from "./omiljene-stavke/omiljene-stavke.component";
import {StarComponent} from "./meni/star/star.component";


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistracijaComponent,
    NotFoundComponent,
    HomeComponent,
    PodaciComponent,
    MojeNarudzbeComponent,
    MeniComponent,
    NarudzbaComponent,
    OmiljeneStavkeComponent,
    StarComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,

  RouterModule.forRoot([
      {path: 'login', component: LoginComponent},
      {path: 'registracija', component: RegistracijaComponent},
      {path: 'home', component: HomeComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'podaci',component:PodaciComponent,canActivate: [AutorizacijaLoginProvjera]},
      {path: 'moje-narudzbe',component:MojeNarudzbeComponent,canActivate: [AutorizacijaLoginProvjera]},
      {path: 'meni',component:MeniComponent,canActivate: [AutorizacijaLoginProvjera]},
      {path: 'narudzba',component:NarudzbaComponent,canActivate: [AutorizacijaLoginProvjera]},
      {path: 'omiljene-stavke',component:OmiljeneStavkeComponent,canActivate: [AutorizacijaLoginProvjera]},
      {path: 'star',component:StarComponent,canActivate: [AutorizacijaLoginProvjera]},
      {path: '**', component: NotFoundComponent, canActivate: [AutorizacijaLoginProvjera]},

    ]),
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    AutorizacijaLoginProvjera,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


