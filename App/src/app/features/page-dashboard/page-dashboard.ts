import { Component, inject } from '@angular/core';
import { AuthService } from '../../core/services/auth.service';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-page-dashboard',
  imports: [CommonModule, RouterLink],
  templateUrl: './page-dashboard.html',
  styleUrl: './page-dashboard.css',
})
export class PageDashboard {
  private authService = inject(AuthService);
  private router = inject(Router);

  userEmail = this.authService.getUserEmail(); 

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

}
