import {inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {AuthTokenService} from './auth-token.service';
import {Observable} from 'rxjs';
import {AddChannelRequest, GetChannelsRequest, GetChannelsResponse} from '../models/channel.model';
import {AddServersRequest, GetServersResponse} from '../models/server.model';

const AUTH_URL: string = 'https://localhost:7295/api/server';
const GET_CHANNELS_URL: string = AUTH_URL + '/all/channels';
const GET_SERVERS_URL: string = AUTH_URL + '/all/servers';
const ADD_SERVER_URL: string = AUTH_URL + '/add/server';
const ADD_CHANNEL_URL: string = AUTH_URL + '/add/channel';

@Injectable({providedIn: 'root'})
export class ServerService {
  private readonly http: HttpClient = inject(HttpClient);
  authTokenService: AuthTokenService = inject(AuthTokenService);

  getChannels(payload:GetChannelsRequest): Observable<GetChannelsResponse>{
    const token = this.authTokenService.getToken();
    const headers : HttpHeaders = new HttpHeaders({Authorization: `Bearer ${token}`});

    const params = new HttpParams()
      .set('serverId', payload.serverId);
    return this.http.get<GetChannelsResponse>(GET_CHANNELS_URL, {headers, params});
  }

  addChannel(payload : AddChannelRequest) : Observable<void>{
    const token = this.authTokenService.getToken();
    const headers : HttpHeaders = new HttpHeaders({Authorization: `Bearer ${token}`});
    const params = new HttpParams()
      .set('serverId', payload.serverId)
      .set('name', payload.name);
    return this.http.post<void>(ADD_CHANNEL_URL, payload, {headers, params});
  }

  getServers(): Observable<GetServersResponse>{
    const token = this.authTokenService.getToken();
    const headers : HttpHeaders = new HttpHeaders({Authorization: `Bearer ${token}`});
    return this.http.get<GetServersResponse>(GET_SERVERS_URL, {headers});
  }

  addServer(payload : AddServersRequest) : Observable<void>{
    const token = this.authTokenService.getToken();
    const headers : HttpHeaders = new HttpHeaders({Authorization: `Bearer ${token}`});
    const params = new HttpParams()
      .set('name', payload.name);
    return this.http.post<void>(ADD_SERVER_URL, payload, {headers, params});
  }
}
