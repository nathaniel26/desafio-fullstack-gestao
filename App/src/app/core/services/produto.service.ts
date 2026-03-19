import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ProdutoService {
  private http = inject(HttpClient);
  private readonly API = 'http://localhost:5110/api/produtos';

  produtos = signal<any[]>([]);

  listar() {
    return this.http.get<any[]>(this.API).pipe(
      tap(res => this.produtos.set(res))
    );
  }

  criar(formData: FormData) {
    return this.http.post(this.API, formData);
  }

  atualizar(id: number, formData: FormData) {
    return this.http.put(`${this.API}/${id}`, formData);
  }

  excluir(id: number) {
    return this.http.delete(`${this.API}/${id}`);
  }
}