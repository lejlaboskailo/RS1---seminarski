import { Component, OnInit } from '@angular/core';
import {MojaNarudzba} from "./view-models/moja-narudzba-vm";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";


@Component({
  selector: 'app-moje-narudzbe',
  templateUrl: './moje-narudzbe.component.html',
  styleUrls: ['./moje-narudzbe.component.css']
})
export class MojeNarudzbeComponent implements OnInit {
  currentPage: number = 1;
  totalPages: number;
  mojeNarudzbe : MojaNarudzba[] = null;
  obavjestenje : boolean = false;
  closeModal : boolean = false;
  obavjestenjeNaslov : string = "";
  obavjestenjeSadrzaj : string = "";

  constructor(private httpKlijent : HttpClient) { }

  ngOnInit(): void {
    this.ucitajNarudzbe();
  }

  private ucitajNarudzbe() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Narudzba/GetAllPaged/" + this.currentPage,MojConfig.http_opcije()).subscribe((response : any)=>{
      this.totalPages = response.totalPages;
      this.mojeNarudzbe = response.dataItems;
    })
  }

  naruci(narudzba : MojaNarudzba) {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Narudzba/Naruci/" + narudzba.id, MojConfig.http_opcije()).subscribe((response : any)=>{
      narudzba.status = response.status;
      this.obavjestenje = true;
      this.closeModal = false;
      this.obavjestenjeNaslov = "Vaša narudžba je uspješno poslana";
      this.obavjestenjeSadrzaj = "Uspješno ste ponovo naručili odabranu narudžbu po cijeni od: " + narudzba.cijena + " KM";
    });
  }

  obrisi(narudzba : MojaNarudzba) {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Narudzba/Delete/" + narudzba.id, MojConfig.http_opcije()).subscribe((response : any)=>{
      this.obavjestenje = true;
      this.closeModal = false;
      this.obavjestenjeNaslov = "Vaša narudžba je uspješno obrisana";
      this.obavjestenjeSadrzaj = "Uspješno ste obrisali odabranu narudžbu";
      this.ucitajNarudzbe();
    });
  }

  animirajObavjestenje() {
    return this.closeModal == true? 'animate__animated animate__bounceOut' : 'animate__animated animate__bounceIn';
  }

  zatvoriModalObavjestenje(){
    this.closeModal = true;
    this.animirajObavjestenje();
    setTimeout(() => {
      this.obavjestenje = false;
    },1000);
  }

  createRangeStranica() {
    var niz = new Array(this.totalPages);
    for(let i : number = 0; i < this.totalPages; i++){
      niz[i] = i + 1;
    }
    return niz;
  }

  ucitajStranicu(page : number) {
    this.currentPage = page;
    this.ucitajNarudzbe();
  }
}
