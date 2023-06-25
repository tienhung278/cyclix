import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Option} from "../models/option.model";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class OptionService {

  constructor(private http: HttpClient) { }

  getOptions(): Observable<Option[]> {
    return this.http.get<Option[]>(environment.baseUrl + "/options");
  }
}
