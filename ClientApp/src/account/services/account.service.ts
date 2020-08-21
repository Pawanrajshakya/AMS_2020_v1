import { Injectable } from "@angular/core";
import { Base } from "src/_services/base";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { IAccount } from "../model/account-data";

@Injectable({
  providedIn: "root",
})
export class AccountService extends Base {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
    super();
  }

  getById(id: number): Observable<IAccount> {
    if (id === 0) {
      const account: IAccount = {
        id: 0,
      };
      return new Observable((observe) => {
        observe.next(account);
      });
    } else {
      return this.http.get<IAccount>(this.baseUrl + "account/" + id);
    }
  }
}
