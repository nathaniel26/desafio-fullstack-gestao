import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UsuarioService {
  private http = inject(HttpClient);
  private readonly API = 'http://localhost:5110/api/Usuarios';

  usuarios = signal<any[]>([]);

  listar() {
    return this.http.get<any[]>(this.API).pipe(tap((res) => this.usuarios.set(res)));
  }

  criar(usuario: any) {
    return this.http.post(this.API, usuario);
  }

  atualizar(id: number, usuario: any) {
    return this.http.put(`${this.API}/usuarios/${id}`, usuario);
  }

  excluir(id: number) {
    return this.http.delete(`${this.API}/usuarios/${id}`);
  }
}
