import {inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {
  SignUpRequest,
  SignUpResponse,
  SignInRequest,
  SignInResponse,
  GetUserResponse
} from '../models/auth.model';
import {Observable} from 'rxjs';
import {AuthTokenService} from './auth-token.service';

const AUTH_URL: string = 'https://localhost:7295/api/auth';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly http: HttpClient = inject(HttpClient);
  authTokenService: AuthTokenService = inject(AuthTokenService);

  signUp(payload:SignUpRequest) : Observable<SignUpResponse>{
    return this.http.post<SignUpResponse>(AUTH_URL+"/signup", payload);
  }

  signIn(payload:SignInRequest) : Observable<SignInResponse>{
    return this.http.post<SignInResponse>(AUTH_URL+"/signin", payload);
  }

  getUser(): Observable<GetUserResponse>{
    const token: string = this.authTokenService.getToken();
    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
    return this.http.get<GetUserResponse>(AUTH_URL, { headers });
  }
}
