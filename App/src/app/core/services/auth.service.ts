import { Injectable, signal, computed } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private _token = signal<string | null>(localStorage.getItem('token'));
  isLoggedIn = computed(() => !!this._token());

  saveToken(token: string) {
    localStorage.setItem('token', token);
    this._token.set(token);
  }

  logout() {
    localStorage.removeItem('token');
    this._token.set(null);
  }

  getUserEmail(): string {
    const token = localStorage.getItem('token');
    if (!token) return '';

    const payload = JSON.parse(atob(token.split('.')[1]));
    return payload.email;
  }
}
