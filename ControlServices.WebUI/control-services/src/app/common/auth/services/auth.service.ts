import { Injectable, Injector } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { HttpBaseService } from 'src/app/shared/services/http-base.service';
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends HttpBaseService {

  private subjectUsuario: BehaviorSubject<any> = new BehaviorSubject(null);
  private subjectLogin: BehaviorSubject<any> = new BehaviorSubject(false);

  public constructor(protected override readonly injector: Injector) { 
    super(injector);
  }

  public login(login: Login): Observable<any> {
    return this.httpPost('auth/login', { body: login} )
      .pipe(
        map(response => {
          sessionStorage.setItem('token', response.content.tokenJWT);
          this.subjectLogin.next(true);

          return response.content;
        }),
      );
  }

  public logOut(): void {
    sessionStorage.removeItem('token');
    this.subjectLogin.next(false);
  }

  public usuarioEstaLogado(): Observable<any> {
    const token = sessionStorage.getItem('token');
    
    if (token) {
      this.subjectLogin.next(true);
    }

    return this.subjectLogin.asObservable();
  }

}
