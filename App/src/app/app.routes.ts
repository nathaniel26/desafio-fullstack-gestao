import { Routes } from '@angular/router';
import { PageLogin } from './features/page-login/page-login';
import { PageDashboard } from './features/page-dashboard/page-dashboard';
import { PageUsuarios } from './features/page-usuarios/page-usuarios';
import { PageProdutos } from './features/page-produtos/page-produtos';

export const routes: Routes = [
  { path: 'login', component: PageLogin },
  { path: 'dashboard', component: PageDashboard },
  { path: 'usuarios', component: PageUsuarios },
  { path: 'produtos', component: PageProdutos },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];
