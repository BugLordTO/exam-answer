import { GlobalVarible, Product, Cart } from './../../app/models';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

@IonicPage()
@Component({
  selector: 'page-cart',
  templateUrl: 'cart.html',
})
export class CartPage {

  document: Cart;

  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient) {
  }

  ionViewDidEnter() {
    this.http.get<Cart>(GlobalVarible.host + "/api/Cart")
      .subscribe(data => {
        this.document = data;
      });
  }

}
