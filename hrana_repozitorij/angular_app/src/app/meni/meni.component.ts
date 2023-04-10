import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MeniStavka} from "./view-models/meni-stavka-vm";
import {MojConfig} from "../moj-config";
import {MeniGrupa} from "./view-models/meni-grupa-vm";
import {Router} from "@angular/router";
import {MeniStavkaKorisnik} from "./view-models/meni-korisnik-vm";
import {StavkaNarudzbe} from "../narudzba/view-models/stavka-narudzbe-vm";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";


@Component({
  selector: 'app-meni',
  templateUrl: './meni.component.html',
  styleUrls: ['./meni.component.css']
})
export class MeniComponent implements OnInit {
  meniStavke : MeniStavka[] = null;
  meniStavkeKorisnik : MeniStavkaKorisnik[] = null;
  meniGrupe : MeniGrupa[] = null;
  novaStavkaNarudzbe : StavkaNarudzbe = new StavkaNarudzbe();
  id : number = null;

  loginInformacije : LoginInformacije = null;
  odabranaStavkaMenija: MeniStavka = null;
  ocijenjenaStavkaMenija:MeniStavkaKorisnik=new MeniStavkaKorisnik();
  trenutnaKategorija: string = "Slano";
  obavjestenje : boolean = false;
  closeModal : boolean = false;
  obavjestenjeNaslov : string = "";
  obavjestenjeSadrzaj : string = "";

  title = "star-angular";
  stars = [1, 2, 3, 4, 5];
  rating = 0;
  hoverState = 0;

  constructor(private httpKlijent : HttpClient, private router : Router) {
    this.loginInformacije = AutentifikacijaHelper.getLoginInfo();
  }

  ngOnInit(): void {
    this.getMeniGrupe();
    if (this.loginInformacije.isPermisijaKorisnik) this.ucitajMeniStavkeKorisnik();
    else this.ucitajMeniStavke();
  }
  public ucitajMeniStavke(kategorija : string = "Slano") {
    this.trenutnaKategorija = kategorija;
    this.httpKlijent.get(MojConfig.adresa_servera + "/Meni/GetAllPaged?nazivKategorije=" + kategorija).subscribe((result : any)=>{
      this.meniStavke = result;
      this.odabranaStavkaMenija=null;
    })
  }

  public ucitajMeniStavkeKorisnik(kategorija : string = "Slano") {
    this.trenutnaKategorija = kategorija;
    let podaci : any = {
      kategorija : kategorija
    };
    this.httpKlijent.post(MojConfig.adresa_servera + "/Meni/GetAllPaged", podaci, MojConfig.http_opcije()).subscribe((result : any)=>{
      this.meniStavkeKorisnik = result;
    });
  }


  createRange(ocjena: number) {
    let velicina = Math.round(ocjena);
    return new Array(velicina);
  }

  private getMeniGrupe() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/ControllerKategorija/GetALL").subscribe((result : any)=>{
      this.meniGrupe = result;
    })
  }


  brisanje(s : MeniStavka) {
    console.log(s);
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Meni/Delete/" + s.id, MojConfig.http_opcije()).subscribe((response : any)=>{
      this.zatvoriModal();
      this.ucitajMeniStavke(s.nazivKategorije);
      this.obavjestenje = true;
      this.closeModal = false;
      this.obavjestenjeNaslov="Uspješno obrisana meni stavka";
      this.obavjestenjeSadrzaj="Uspješno ste obrisali meni stavku  "+s.naziv;
    });
  }



  public prikazi_brisanje(stavka : MeniStavka){
    this.odabranaStavkaMenija = stavka;
    this.closeModal = false;
  }

  dodajUKorpu(stavka : MeniStavkaKorisnik) {
    this.novaStavkaNarudzbe.meniStavkaId = stavka.id;
    this.httpKlijent.post(MojConfig.adresa_servera+"/Narudzba/AddStavka",this.novaStavkaNarudzbe, MojConfig.http_opcije())
      .subscribe((response : any)=>{
      document.getElementById('kolicina').innerHTML = response;
    });
  }
  prikaziOcjenjivanje(stavka : MeniStavkaKorisnik) {
    this.ocijenjenaStavkaMenija=stavka;
  }
  enter(i:any) {
    this.hoverState = i;
  }
  leave($event: number) {
    this.hoverState = 0;
  }
  updateRating(i:any) {
    this.rating = i;
    this.obavjestenje = true;
    this.closeModal = false;
    this.obavjestenjeNaslov = "Vaša ocjena je uspješno poslana";
    this.obavjestenjeSadrzaj = this.ocijenjenaStavkaMenija.naziv + " stavku ste ocijenili ocjenom " + this.rating;
  }
  upravljajOmiljenomStavkom(stavka : MeniStavkaKorisnik) {
    if (stavka.omiljeno){
      stavka.omiljeno = false;
      this.ukloniOmiljenuStavku(stavka);
    }
    else {
      stavka.omiljeno = true;
      this.dodajOmiljenuStavku(stavka);
    }
  }

  private ukloniOmiljenuStavku(stavka: MeniStavkaKorisnik) {
    var podaci : any = {
      stavkaId : stavka.id
    };
    this.httpKlijent.post(MojConfig.adresa_servera + '/OmiljenaStavka/DeleteById', podaci, MojConfig.http_opcije()).subscribe((response : any)=>{

    });
  }

  private dodajOmiljenuStavku(stavka: MeniStavkaKorisnik) {
    var podaci : any = {
      meniStavkaId : stavka.id
    };
    this.httpKlijent.post(MojConfig.adresa_servera + '/OmiljenaStavka/Add', podaci, MojConfig.http_opcije()).subscribe((response : any)=>{

    });
    this.obavjestenje = true;
    this.closeModal = false;
    this.obavjestenjeNaslov = "Stavka dodana u sekciju omiljenih stavki";
    this.obavjestenjeSadrzaj = stavka.naziv + " stavka je dodana u omiljene";
  }



  animirajObavjestenje() {
    return this.closeModal == true? 'animate__animated animate__bounceOut' : 'animate__animated animate__bounceIn';
  }

  zatvoriModalObavjestenje(){
    this.closeModal = true;
    this.animirajObavjestenje();
    setTimeout(()=>{
      this.obavjestenje = false;
    },500);
  }

  zatvoriModal(){
    this.closeModal = true;
    this.animirajObavjestenje();

    setTimeout(()=>{
      this.odabranaStavkaMenija = null;
    },1000);
  }
}
