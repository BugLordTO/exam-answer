import { ConfigPage } from './../config/config';
import { PrincipalDetail, GlobalVarible } from './../../app/models';
import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  interestPercentage: number;
  principal: number = 10000;
  year: number = 3;
  documents: PrincipalDetail[];

  constructor(public navCtrl: NavController, private http: HttpClient) {

  }

  GoConfig() {
    this.navCtrl.push(ConfigPage);
  }

  Calculate() {
    this.http.get<PrincipalDetail[]>(GlobalVarible.host + "/api/Loan/Principal/" + this.principal + "/" + this.year)
      .subscribe(data => {
        this.documents = data;
      });
  }

  ionViewDidEnter() {
    this.http.get<number>(GlobalVarible.host + "/api/Loan/Interest/Percentage")
      .subscribe(data => {
        this.interestPercentage = data;
      });
  }

}
