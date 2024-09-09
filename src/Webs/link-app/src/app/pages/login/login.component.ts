import { Component, input, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { IdentityService } from '../../core/services/identity-services.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  contentAuthorizer = signal<string>('');
  constructor(
    private activatedRoute: ActivatedRoute,
    private identityService: IdentityService
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
        console.log(result.access_token);
    });
  }
}


