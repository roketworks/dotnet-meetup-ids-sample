import { Injectable } from '@angular/core';
import { UserManager, User } from 'oidc-client';

export { User };

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  _userManager: UserManager;

  constructor() {
    var settings = {
      authority: 'http://localhost:8080',
      client_id: 'sample.client',
      redirect_uri: 'http://localhost/assets/signin-redirect.html',
      silent_redirect_uri: 'http://localhost/assets/silent-callback.html',
      post_logout_redirect_uri: 'http://localhost',
      response_type: 'id_token token',
      scope: 'openid profile email role sample.api'
    };
    this._userManager = new UserManager(settings);
  }

  public getUser(): Promise<User> {
    return this._userManager.getUser();
  }

  public login(): Promise<void> {
    return this._userManager.signinRedirect();
  }

  public renewToken(): Promise<User> {
    return this._userManager.signinSilent();
  }

  public logout(): Promise<void> {
    return this._userManager.signoutRedirect();
  }
}
