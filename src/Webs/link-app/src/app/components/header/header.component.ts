import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ModulesMaterial } from '../../shared/components.material.modules';
import { AsyncPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { BreakpointObserver } from '@angular/cdk/layout';
import { UserViewModel } from '../../core/models/userapplication.model';
import { IdentityService } from '../../core/services/identity-services.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, ModulesMaterial, AsyncPipe],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit {
  userViewModel: Observable<UserViewModel> | undefined;
  isvisible: boolean = true;
  itemsCount: number = 0;

  constructor(
    private breakpointObserver: BreakpointObserver,
    private router: Router,
    private identityService: IdentityService
  ) { }

  ngOnInit(): void {
    this.breakpointObserver.observe('(max-width:762px)')
      .subscribe(state => {
        if (!state.matches) {
          this.isvisible = true;
        }
        else {
          this.isvisible = false;
        }
      })
  }

  navigateToCart() {
    this.router.navigate(['basket', 1])
  }

  logout() {

  }

  SigIn() {
    console.log("Press Sign");
    this.identityService.signIn("authorize", "implicit").subscribe(
      result => {
        if (result != undefined && result.url != undefined)
          console.log("REsult http", result);
          window.location.href = result.url!;
      }
    );
  }
}
