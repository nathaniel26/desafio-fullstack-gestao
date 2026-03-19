import { CommonModule } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProdutoService } from '../../core/services/produto.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-produtos',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './page-produtos.html',
  styleUrl: './page-produtos.css',
})
export class PageProdutos {
  public service = inject(ProdutoService);
  private fb = inject(FormBuilder);
  private router = inject(Router);

  produtoEmEdicaoId = signal<number | null>(null);
  arquivoSelecionado = signal<File | null>(null);

  produtoForm = this.fb.group({
    titulo: ['', Validators.required],
    descricao: ['', Validators.required],
    quantidade: [0, [Validators.required, Validators.min(0)]],
  });

  ngOnInit() {
    this.carregar();
  }

  carregar() {
    this.service.listar().subscribe();
  }

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) this.arquivoSelecionado.set(file);
  }

  salvar() {
    if (this.produtoForm.valid) {
      const fd = new FormData();
      fd.append('titulo', this.produtoForm.value.titulo!);
      fd.append('descricao', this.produtoForm.value.descricao!);
      fd.append('quantidade', this.produtoForm.value.quantidade!.toString());

      if (this.arquivoSelecionado()) {
        fd.append('imagem', this.arquivoSelecionado()!);
      }

      const id = this.produtoEmEdicaoId();
      const acao = id ? this.service.atualizar(id, fd) : this.service.criar(fd);

      acao.subscribe({
        next: () => {
          this.produtoForm.reset();
          this.arquivoSelecionado.set(null);
          this.produtoEmEdicaoId.set(null);
          this.carregar();
        },
        error: () => alert('Erro ao processar produto'),
      });
    }
  }

  editar(p: any) {
    this.produtoEmEdicaoId.set(p.id);
    this.produtoForm.patchValue({
      titulo: p.titulo,
      descricao: p.descricao,
      quantidade: p.quantidade,
    });
  }

  cancelarEdicao() {
    this.produtoEmEdicaoId.set(null);
    this.arquivoSelecionado.set(null);
    this.produtoForm.reset({
      titulo: '',
      descricao: '',
      quantidade: 0,
    });
  }

  deletar(id: number) {
    if (confirm('Excluir este produto?')) {
      this.service.excluir(id).subscribe(() => this.carregar());
    }
  }

  voltar() {
    this.router.navigate(['/dashboard']);
  }
}
