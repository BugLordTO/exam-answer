import { AddProductPage } from './../add-product/add-product';
import { CartPage } from './../cart/cart';
import { HttpClient } from '@angular/common/http';
import { Product, GlobalVarible, AddItem } from './../../app/models';
import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  documents: Product[];

  constructor(public navCtrl: NavController, private http: HttpClient) {

  }

  GoCart() {
    this.navCtrl.push(CartPage);
  }

  GoAddProduct() {
    this.navCtrl.push(AddProductPage);
  }

  AddToCart(product: Product) {
    if (product.quantity == null || product.quantity <= 0) {
      alert("Please input amount.");
      return;
    }

    var addItem = new AddItem();
    addItem.productId = product.id;
    addItem.quantity = product.quantity;

    this.http.post(GlobalVarible.host + "/api/Cart", JSON.stringify(addItem), GlobalVarible.httpOptions)
      .subscribe(data => {
        alert("Added.");
      });
  }

  ionViewDidEnter() {
    this.http.get<Product[]>(GlobalVarible.host + "/api/Product")
      .subscribe(data => {
        this.documents = data;
        for (let document of this.documents) {
          document.quantity = 1;
        }
      });
  }

}
