import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {RequestRead} from "../models/request_read.model";
import {RequestWrite} from "../models/request_write.model";

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  baseURL = "http://localhost:8080/api"

  constructor(private http: HttpClient) { }

  getBike(id: number): Observable<RequestRead> {
    return this.http.get<RequestRead>(this.baseURL + "/requests/" + id);
  }

  createBike(requestWrite: RequestWrite): Observable<any> {
    return this.http.post<any>(this.baseURL + "/requests", requestWrite, { headers: { "Content-Type": "application/json" }});
  }
}
