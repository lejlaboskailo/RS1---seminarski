import { Component,Input, OnInit } from '@angular/core';
import {Korisnik} from "./view-models/korisnik-vm";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Opstina} from "../registracija/view-models/opstina-vm";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {LoginInformacije} from "../_helpers/login-informacije";
import {Router} from "@angular/router";


@Component({
  selector: 'app-podaci',
  templateUrl: './podaci.component.html',
  styleUrls: ['./podaci.component.css']
})
export class PodaciComponent implements OnInit {
  loginInformacije : LoginInformacije = null;
  korisnik : Korisnik = new Korisnik();
  opstine : Opstina[] = null;
  fieldText: boolean;
  obavjestenje : boolean = false;
  closeModal : boolean = false;
  obavjestenjeNaslov : string = "";
  obavjestenjeSadrzaj : string = "";
  obrisiProfilObavjestenje : boolean = false;
  uspjesnoBrisanje : boolean = false;

  constructor(private httpKlijent : HttpClient, private router : Router) {
    this.loginInformacije = AutentifikacijaHelper.getLoginInfo();
  }

  ngOnInit(): void {
    this.getOpstine();
    this.ucitajPodatke();
  }


  generisiPreview() {
    // @ts-ignore
    var file = document.getElementById("fajl-input").files[0];

    if (file){
      var reader = new FileReader();
      reader.onload = function (){
        document.getElementById("preview-slika").setAttribute("src", reader.result.toString());
      }
      reader.readAsDataURL(file);
    }
  }

  private ucitajPodatke() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/KorisnickiNalog/Get", MojConfig.http_opcije()).subscribe((response : any)=>{
      this.korisnik = response;
      console.info(this.korisnik);
    });
  }

  private getOpstine() {
    return this.httpKlijent.get( MojConfig.adresa_servera + "/Opstina/GetByAll", MojConfig.http_opcije())
      .subscribe((result:any)=>{
        this.opstine = result;
        console.info(this.opstine);
      });
  }


  azurirajPodatkeKorisnik() {
    if (this.validirajFormu()){
      //@ts-ignore
      // console.info("Fetching file...");
      // var file = document.getElementById("fajl-input").files[0];
      // console.info("File", file);
      var data = new FormData();
      // data.append("slika", file.getAttribute("slika"));

        this.httpKlijent.post(MojConfig.adresa_servera + "/Korisnik/Update",this.korisnik, MojConfig.http_opcije()).subscribe((result :any)=>{
      //     this.httpKlijent.post(MojConfig.adresa_servera + "/Korisnik/AddProfileImage/" + result, data).subscribe((result: any)=>{
      //     this.obavjestenje = true;
      //     this.closeModal = false;
      //     this.obavjestenjeNaslov ="Uređen profil";
      //     this.obavjestenjeSadrzaj=this.korisnik.ime+" "+this.korisnik.prezime+", uspješno ste uredili svoje podatke profila";
      //
      // });
      });
    }
    else this.prikaziObavjestenje("Neadekvatno ispunjena forma za promjenu ličnih podataka", "Molimo ispunite sva obavezna polja, pa ponovo pokušajte");
  }

  animirajObavjestenje() {
    return this.closeModal == true? 'animate__animated animate__bounceOutUp' : 'animate__animated animate__bounceInDown';
  }

  zatvoriModalObavjestenje(){
    this.closeModal = true;
    this.animirajObavjestenje();
    setTimeout( () => {
      this.obavjestenje = false;
    },500);
    setTimeout( () => {
      this.obrisiProfilObavjestenje = false;
    },500);
  }

  private validirajFormu() {
    const valid = this.korisnik.korisnickoIme != null && this.korisnik.korisnickoIme?.length > 0
      && this.korisnik.lozinka != null && this.korisnik.lozinka?.length > 0
      && this.korisnik.ime != null && this.korisnik.ime?.length > 0
      && this.korisnik.prezime != null && this.korisnik.prezime?.length > 0
      && this.korisnik.email != null && this.korisnik.email?.length > 0
      && this.korisnik.brojTelefona != null && this.korisnik.brojTelefona?.length > 0
      && this.korisnik.adresaStanovanja != null && this.korisnik.adresaStanovanja?.length > 0

      console.info("Valid data", valid);

      return valid;
  }

  private prikaziObavjestenje(naslov : string, sadrzaj : string) {
    this.obavjestenje = true;
    this.closeModal = false;
    this.obavjestenjeNaslov = naslov;
    this.obavjestenjeSadrzaj = sadrzaj;
  }

  provjeriPolje(polje: any) {
    if (polje.invalid && (polje.dirty || polje.touched)){
      if (polje.errors?.['required']){
        return 'Niste popunili ovo polje!';
      }
      else {
        return '';
      }
    }
    return 'Obavezno polje za unos';
  }

  obrisiProfil() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Korisnik/Delete", MojConfig.http_opcije()).subscribe((response: any) => {
      AutentifikacijaHelper.ocistiMemoriju();
      this.uspjesnoBrisanje = true;
      this.zatvoriModalObavjestenje();
      this.router.navigateByUrl("home");
    });
    if (!this.uspjesnoBrisanje){
      this.zatvoriModalObavjestenje();
      setTimeout(() => {
        this.obrisiProfilObavjestenje = false;
        this.prikaziObavjestenje("Obavještenje", "Trenutno ne možete deaktivirati profil jer su Vaše narudžbe u izradi");
      }, 1000);
    }
  }

  otvoriModal() {
    this.obrisiProfilObavjestenje = true;
    this.prikaziObavjestenje("Upozorenje!", "Da li ste sigurni da želite obrisati svoj profil?");
  }

}

