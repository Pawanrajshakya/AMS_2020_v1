import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Base } from "src/_services/base";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { IRelationship } from '../models/relationship-data';

@Injectable({
  providedIn: "root",
})
export class RelationshipService extends Base {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
    super();
  }

  getById(id: number): Observable<IRelationship> {
    if (id === 0) {
      const relationship: IRelationship = {
        id: 0,
      };
      return new Observable((observe) => {
        observe.next(relationship);
      });
    } else {
      return this.http.get<IRelationship>(this.baseUrl + "relationship/" + id);
    }
  }

  get(): Observable<IRelationship[]> {
    return this.http.get<IRelationship[]>(this.baseUrl + "relationship");
  }
}
