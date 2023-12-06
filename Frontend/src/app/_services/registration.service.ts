import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Code } from '../_models/code';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  baseUrl = environment.localApiUrl;

  constructor(private http:HttpClient) { }

  register(model: any){
    return this.http.post<Code>(this.baseUrl + 'Code/generateCode', model)
  }

  admit(model:any){
    return this.http.post(this.baseUrl + 'Code/attend', model)
  }
}
