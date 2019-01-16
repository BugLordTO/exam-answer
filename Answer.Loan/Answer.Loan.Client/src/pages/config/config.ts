import { HttpClient } from '@angular/common/http';
import { GlobalVarible } from './../../app/models';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';


@IonicPage()
@Component({
  selector: 'page-config',
  templateUrl: 'config.html',
})
export class ConfigPage {

  interestPercentage: number;

  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient) {
  }

  Save() {
    this.http.put(GlobalVarible.host + "/api/Loan/Interest/Percentage/" + this.interestPercentage, null, GlobalVarible.httpOptions)
      .subscribe(data => {
        this.navCtrl.pop();
      });
  }

  ionViewDidEnter() {
    this.http.get<number>(GlobalVarible.host + "/api/Loan/Interest/Percentage")
      .subscribe(data => {
        this.interestPercentage = data;
      });
  }

}
