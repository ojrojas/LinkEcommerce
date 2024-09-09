import { Component, inject, input, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs';
import { IdentityService } from '../../core/services/identity-services.service';
import { ECommerceStore } from '../../store.signals';
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
  store = inject(ECommerceStore);
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
      if (result.access_token != null)
      {
        this.store.setToken(result as unknown as Token);
        console.log("token", result.access_token, "type", result.token_type);
        // const claims = atob(result.access_token.split('.')[1]);
        // console.log("Claims", claims);
        this.router.navigate(['products']);
      }
    });
  }
}


