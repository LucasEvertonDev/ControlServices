import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpBaseService {
  private readonly httpClient!: HttpClient;
  private urlApiBase = 'https://localhost:44368/api/v1/';

  constructor(protected readonly injector: Injector) {
    if(injector == null || injector == undefined){
      throw new Error('Injector não pode ser nulo');
    }

    this.httpClient = injector.get(HttpClient);
  }

  protected httpGet(endpoint: string): Observable<any> {
    return this.httpClient.get(`${this.urlApiBase}${endpoint}`);
  }

  protected httpPost(endpoint: string, dados:any): Observable<any> {
    return this.httpClient.post(`${this.urlApiBase}${endpoint}`, dados);
  }

  protected httpPut(endpoint: string, dados:any): Observable<any> {
    return this.httpClient.put(`${this.urlApiBase}${endpoint}`, dados);
  }

  protected httpDelete(endpoint: string): Observable<any> {
    return this.httpClient.delete(`${this.urlApiBase}${endpoint}`);
  }
}
