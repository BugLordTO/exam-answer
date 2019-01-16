import { HttpHeaders } from "@angular/common/http";

export class PrincipalDetail {
    interestPercentage: number;
    year: number;
    principal: number;
    interest: number;
    newPrincipal: number;
}

export class GlobalVarible {
    static host: string = "http://localhost:5000";

    static httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
}