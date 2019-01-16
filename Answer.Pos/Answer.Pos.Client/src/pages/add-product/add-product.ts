import { HttpClient } from '@angular/common/http';
import { Product, GlobalVarible, ProductBase } from './../../app/models';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

@IonicPage()
@Component({
  selector: 'page-add-product',
  templateUrl: 'add-product.html',
})
export class AddProductPage {

  document: ProductBase = new ProductBase;

  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient) {
  }

  Add() {
    if (this.document.name == "" || this.document.unitPrice <= 0) {
      alert("Please input name and unit price.");
      return;
    }

    this.http.post(GlobalVarible.host + "/api/Product", JSON.stringify(this.document), GlobalVarible.httpOptions)
      .subscribe(data => {
        alert("Added.");
        this.navCtrl.pop();
      });
  }

}
