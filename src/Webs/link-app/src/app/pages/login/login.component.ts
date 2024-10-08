import { Component, inject, input, isDevMode, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs';
import { IdentityECommerceStore } from '../../core/stores/identity.store.signals';
import { Token } from '../../core/dtos/token.response.dto';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  contentAuthorizer = signal<string>('');
  store = inject(IdentityECommerceStore);
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.activatedRoute.fragment.pipe(map(fragment => new URLSearchParams(fragment!)),
      map(params => ({
        access_token: params.get("access_token"),
        expires_in: params.get("expires_in"),
        state: params.get("state"),
        token_type: params.get("token_type"),
        iss: params.get("iss")
      }))

    ).subscribe(result => {
      if (result.access_token != null) {
        this.store.setToken(result as unknown as Token);
        if (isDevMode())
          console.log("token", this.store.token()?.access_token);
        this.store.getUserInfo(this.store.token()?.access_token!);
        this.router.navigate(['products']);
      }
    });
  }
}


