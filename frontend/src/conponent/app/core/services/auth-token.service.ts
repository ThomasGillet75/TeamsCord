import {Injectable} from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthTokenService{
  private readonly TOKEN: string = 'accessToken';

  public getToken() :string{
    const token : string |null = localStorage.getItem(this.TOKEN);
    if(token != null){
      return token;
    }
    throw "no token";
  }

  public clearAccessToken() :void{
    localStorage.removeItem(this.TOKEN);
  }

  public setAccessToken(accesToken:string) :void{
    localStorage.setItem(this.TOKEN, accesToken);
  }

  public hasToken():boolean{
    return !!localStorage.getItem(this.TOKEN);
  }
}
