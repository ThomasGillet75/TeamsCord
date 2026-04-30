import {inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {
  SignUpRequest,
  SignInRequest,
  SignInResponse,
  GetUserResponse, User
} from '../models/auth.model';
import {map, Observable} from 'rxjs';
import {AuthTokenService} from './auth-token.service';
import {environment} from '../../../../environments/environment.development';

const BACKEND_API_URL: string | undefined = environment.apiURL;
const AUTH_URL: string = `${BACKEND_API_URL}/auth`;

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly http: HttpClient = inject(HttpClient);
  authTokenService: AuthTokenService = inject(AuthTokenService);

  signUp(payload:SignUpRequest) : Observable<void>{
    return this.http.post<void>(AUTH_URL+"/signup", payload);
  }

  signIn(payload:SignInRequest) : Observable<SignInResponse>{
    return this.http.post<SignInResponse>(AUTH_URL+"/signin", payload);
  }

  getUser(): Observable<User> {
    const token: string = this.authTokenService.getToken();
    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.get<GetUserResponse>(AUTH_URL, { headers }).pipe(
      map((response: GetUserResponse) => new User(response.username))
    );
  }
}
