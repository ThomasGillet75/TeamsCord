import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {SignUpRequest, SignUpResponse} from '../models/auth.model';
import {Observable} from 'rxjs';

const SIGNUP_URL: string = 'https://localhost:7295/api/auth';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly http: HttpClient = inject(HttpClient);
  signUp(payload:SignUpRequest) : Observable<SignUpResponse>{
    return this.http.post<SignUpResponse>(SIGNUP_URL, payload);
  }
}
