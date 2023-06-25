import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {AnotherOption} from "../models/another-option.model";

@Injectable({
  providedIn: 'root'
})
export class AnotherOptionService {

  constructor(private http: HttpClient) { }

  getAnotherOptions(): Observable<AnotherOption[]> {
    return this.http.get<AnotherOption[]>(environment.baseUrl + "/anotheroptions");
  }
}
