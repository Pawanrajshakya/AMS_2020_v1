import { Injectable } from "@angular/core";
import { Base } from "src/_services/base";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { IAccountType } from "../models/accountType-data";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class AccountTypeService extends Base {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
    super();
  }

  getById(id: number): Observable<IAccountType> {
    if (id === 0) {
      const accountType: IAccountType = {
        id: 0,
      };
      return new Observable((observe) => {
        observe.next(accountType);
      });
    } else {
      return this.http.get<IAccountType>(this.baseUrl + "account/" + id);
    }
  }

  get(): Observable<IAccountType[]> {
    return this.http.get<IAccountType[]>(this.baseUrl + "accountType");
  }
}
