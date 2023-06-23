import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Item} from "../models/item.model";
import {Bike} from "../models/bike.model";

@Injectable({
  providedIn: 'root'
})
export class BikeService {

  baseURL = "http://localhost:8080/api"

  constructor(private http: HttpClient) { }

  getItems(): Observable<Item[]> {
    return this.http.get<Item[]>(this.baseURL + "/item");
  }

  getBike(): Observable<Bike> {
    return this.http.get<Bike>(this.baseURL + "/bike");
  }

  createBike(bike: Bike): Observable<any> {
    return this.http.post<any>(this.baseURL + "/bike", bike, { headers: { "Content-Type": "application/json" }});
  }
}
