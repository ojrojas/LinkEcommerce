import { HttpClient, HttpContext, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GuidGenerator } from '../../shared/guid-generator';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {
  private headers: HttpHeaders;
  constructor(
    private httpClient: HttpClient,
    private router: Router
  ) {
    this.headers = new HttpHeaders().set("Content-Type", "application/x-www-form-urlencoded")
      .set("Accept", "*/*");
  }

  signInOutSide(): void {
    const hostAngular = `${window.location.protocol}//${window.location.host}`;
    window.location.href = `/identity/connect/authorize?client_id=identity_swagger&response_type=token&redirect_uri=${hostAngular}/login`;
  }

  signIn(route: string, granttype: string) {

    let formData = new URLSearchParams();
    formData.append("grant_type", granttype);
    formData.append("scope", "ecommerce_scope");
    formData.append("client_id", "ecommerce_spa");
    formData.append("secret_client", "1caa3082-0437-4b16-b150-898a2d4a5227");
    formData.append("response_type", "token");
    const hostAngular = `${window.location.protocol}//${window.location.host}`;
    formData.append("redirect_uri", `${hostAngular}/login`);
    formData.append("state", GuidGenerator.standard());
    console.log("Headers", this.headers);
    console.log("host-angular", hostAngular);
    return this.httpClient.post(`/identity/connect/${route}`, formData, {
      headers: this.headers,
      responseType: 'arraybuffer',
      observe: 'response'
    });
  }



  logout() {
    this.httpClient.get("/identity/connect/logout", { observe: 'response', responseType: 'arraybuffer' })
      .subscribe(result => {
        if (result != undefined && result.url != undefined) {
          this.router.navigate(['products']);
        }
      });
  }
}


