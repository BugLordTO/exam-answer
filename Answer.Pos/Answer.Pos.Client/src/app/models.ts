import { HttpHeaders } from "@angular/common/http";

export class Product {
    id: number;
    name: string;
    unitPrice: number;
    quantity: number;
}

export class Cart {
    id: number;
    totalPrice: number;
    discount: number;
    grandTotalPrice: number;
    items: CartItem[];
}

export class CartItem {
    product: Product;
    quantity: number;
    totalPrice: number;
}

export class AddItem {
    productId: number;
    quantity: number;
}

export class GlobalVarible {
    static host: string = "http://localhost:51457";

    static httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
}