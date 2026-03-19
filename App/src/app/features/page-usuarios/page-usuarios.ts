import { CommonModule } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsuarioService } from '../../core/services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-usuarios',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './page-usuarios.html',
  styleUrl: './page-usuarios.css',
})
export class PageUsuarios {
  public service = inject(UsuarioService);
  private fb = inject(FormBuilder);
  private router = inject(Router);

  usuarioEmEdicaoId = signal<number | null>(null);

  userForm = this.fb.group({
    nomeCompleto: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    senha: ['', [Validators.required, Validators.minLength(4)]],
  });

  ngOnInit() {
    this.carregar();
  }

  carregar() {
    this.service.listar().subscribe();
  }


  editar(usuario: any) {
    this.usuarioEmEdicaoId.set(usuario.id);
    this.userForm.patchValue({
      nomeCompleto: usuario.nomeCompleto,
      email: usuario.email,
      senha: '', 
    });
  }

  cancelarEdicao() {
    this.usuarioEmEdicaoId.set(null);
    this.userForm.reset();
  }

  salvar() {
    if (this.userForm.valid) {
      const id = this.usuarioEmEdicaoId();

      if (id) {
        this.service.atualizar(id, this.userForm.value).subscribe({
          next: () => this.posSucesso(),
          error: () => alert('Erro ao atualizar usuário'),
        });
      } else {
        this.service.criar(this.userForm.value).subscribe({
          next: () => this.posSucesso(),
          error: () => alert('Erro ao salvar usuário'),
        });
      }
    }
  }

  private posSucesso() {
    this.userForm.reset();
    this.usuarioEmEdicaoId.set(null);
    this.carregar();
  }

  deletar(id: number) {
    if (confirm('Tem certeza?')) {
      this.service.excluir(id).subscribe(() => this.carregar());
    }
  }

  voltar() {
    this.router.navigate(['/dashboard']);
  }
}
