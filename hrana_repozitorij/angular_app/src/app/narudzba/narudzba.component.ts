import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {StavkaNarudzbe} from "./view-models/stavka-narudzbe-vm";
import {NarudzbaStavka} from "./view-models/narudzba-stavka-vm";
import {Narudzba} from "./view-models/narudzba-vm";
import {NovaKolicina} from "./view-models/update-kolicina-vm";

@Component({
  selector: 'app-narudzba',
  templateUrl: './narudzba.component.html',
  styleUrls: ['./narudzba.component.css']
})
export class NarudzbaComponent implements OnInit {
  narudzba : Narudzba = null;
  podaci : StavkaNarudzbe = new StavkaNarudzbe();
  updateKolicina : NovaKolicina = new NovaKolicina();
  zakljuciNarudzbu : boolean = false;
  closeModal : boolean = false;
  closeModalObavjestenje : boolean = false;
  obavjestenje : boolean = false;
  obavjestenjeMessage : string = "";

  constructor(private httpKlijent : HttpClient) {
  }

  ngOnInit(): void {
    this.ucitajNarudzbu();
  }

  private ucitajNarudzbu() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Narudzba/GetNarudzba", MojConfig.http_opcije()).subscribe((response : any)=>{
      this.narudzba = response;
    });
  }

  ukloni(stavka : NarudzbaStavka) {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Narudzba/UkloniStavku/" + stavka.id, MojConfig.http_opcije()).subscribe((response : any)=>{
      this.narudzba = response;
    });
  }


  public novaKolicina(stavka : NarudzbaStavka){
    this.updateKolicina.id = stavka.id;
    this.updateKolicina.kolicina = stavka.kolicina;
    this.httpKlijent.post(MojConfig.adresa_servera + "/Narudzba/UpdateKolicina", this.updateKolicina, MojConfig.http_opcije()).subscribe((response : any)=>{
      this.narudzba.cijena = response.cijena;
      document.getElementById('kolicina').innerHTML = response.kolicina;
    });
  }


  zatvoriModal() {
    this.closeModal = true;
    this.animiraj();
    setTimeout(() => {
      this.zakljuciNarudzbu = false;
    },1000);
  }

  posaljiNarudzbu() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Narudzba/Zakljuci/" + this.narudzba.id, MojConfig.http_opcije()).subscribe((response : any)=>{

      this.zatvoriModal();
      this.obavjestenjeMessage = "Cijena Vaše narudžbe iznosi: " + response + " KM";
      this.obavjestenje = true;
      this.ucitajNarudzbu();
      document.getElementById('kolicina').innerHTML = "0";
    })
  }

  animiraj() {
    return this.closeModal == true? 'animate__animated animate__backOutUp' : 'animate__animated animate__backInDown';
  }

  animirajObavjestenje() {
    return this.closeModalObavjestenje == true? 'animate__animated animate__backOutUp' : 'animate__animated animate__backInDown';
  }

  zatvoriModalObavjestenje(){
    this.closeModalObavjestenje = true;
    this.animiraj();
    setTimeout(() => {
      this.obavjestenje = false;
    },1000);
    this.obavjestenjeMessage = "";
  }
}
