import { Component, OnInit } from '@angular/core';
import {OmiljenaStavka} from "./view-models/omiljena-stavka-vm";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {MeniGrupa} from "../meni/view-models/meni-grupa-vm";
import {StavkaNarudzbe} from "../narudzba/view-models/stavka-narudzbe-vm";

@Component({
  selector: 'app-omiljene-stavke',
  templateUrl: './omiljene-stavke.component.html',
  styleUrls: ['./omiljene-stavke.component.css']
})
export class OmiljeneStavkeComponent implements OnInit {
  omiljeneStavke: OmiljenaStavka[] = null;
  public meniGrupe: MeniGrupa[] = null;
  private novaStavkaNarudzbe : StavkaNarudzbe = new StavkaNarudzbe();
  totalPages : number;
  trenutnaKategorija : string;
  currentPage : number;
  itemsPerPage : number = 4;
  pageNumber : number = 1;

  constructor(private httpKlijent : HttpClient) {
  }

  ngOnInit(): void {
    this.getMeniGrupe();
    this.ucitajOmiljeneStavke();
  }

  ucitajOmiljeneStavke(kategorija : string = "", pageNumber : number = 1) {
    this.trenutnaKategorija = kategorija;
    var podaci : any = {
      kategorija : kategorija,
      itemsPerPage : this.itemsPerPage,
      pageNumber : pageNumber
    };
    this.httpKlijent.post(MojConfig.adresa_servera + '/OmiljenaStavka/GetAllPaged', podaci, MojConfig.http_opcije()).subscribe((response : any)=> {
      //console.log(response);
      this.omiljeneStavke = response.dataItems;
      this.totalPages = response.totalPages;
      this.currentPage = response.currentPage;
    })
  }

  createRange(ocjena: number) {
    let velicina = Math.round(ocjena);
    return new Array(velicina);
  }

  createRangeStranica() {
    var niz = new Array(this.totalPages);
    for(let i : number = 0; i < this.totalPages; i++){
      niz[i] = i + 1;
    }
    return niz;
  }

  private getMeniGrupe() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/ControllerKategorija/GetAll").subscribe((result : any)=>{
      this.meniGrupe = result;
    })
  }

  dodajUKorpu(stavka : OmiljenaStavka) {
    this.novaStavkaNarudzbe.meniStavkaId = stavka.id;
    this.httpKlijent.post(MojConfig.adresa_servera+"/Narudzba/AddStavka",this.novaStavkaNarudzbe, MojConfig.http_opcije()).subscribe((response : any)=>{
      document.getElementById('kolicina').innerHTML = response;
    });
  }

  obrisiStavku(stavka : OmiljenaStavka) {
    this.httpKlijent.get(MojConfig.adresa_servera+"/OmiljenaStavka/Delete/" + stavka.omiljenaStavkaId, MojConfig.http_opcije()).subscribe((response : any)=>{
      this.ucitajOmiljeneStavke(stavka.nazivGrupe);
    });
  }

  ucitajStranicu(page : number) {
    this.ucitajOmiljeneStavke(this.trenutnaKategorija, page);
  }

  ucitajStavke() {
    this.ucitajOmiljeneStavke(this.trenutnaKategorija);
  }
}
