import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ModulesMaterial } from '../../shared/components.material.modules';
import { AsyncPipe } from '@angular/common';
import { BreakpointObserver } from '@angular/cdk/layout';
import { IdentityECommerceStore } from '../../core/stores/identity.store.signals';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, ModulesMaterial, AsyncPipe],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit {
  isvisible: boolean = true;
  itemsCount: number = 0;
  store = inject(IdentityECommerceStore);

  constructor(
    private breakpointObserver: BreakpointObserver,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
    this.breakpointObserver.observe('(max-width:762px)')
      .subscribe(state => {
        if (!state.matches) {
          this.isvisible = true;
        }
        else {
          this.isvisible = false;
        }
      });
  }

  loginApp() {
    const isLogged = this.store.token();
    if (isLogged?.access_token != undefined) {
      this.router.navigate(['basket', 1])
    }
    else this.store.loginApp();
  }

  logout() {
    this.store.logoutApp();
    this.router.navigate(['products']);
  }
}
