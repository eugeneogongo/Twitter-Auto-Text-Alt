import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IResponse } from './IResponse';

@Injectable({
  providedIn: 'root'
})
export class PostServiceService {
  
  constructor(private httpClient: HttpClient) {

  }
  GetAltText(url:string,formdata: FormData): Observable<IResponse> {
    return this.httpClient.put<IResponse>(url, formdata)
  }
}
