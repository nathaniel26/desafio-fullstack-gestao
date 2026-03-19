# 🚀 API de Gerenciamento de Usuários e Produtos

API desenvolvida com ASP.NET Core para gerenciamento de usuários e produtos, com autenticação via JWT e upload de imagens.

---

## 📌 Funcionalidades

### 🔐 Autenticação

* Login com e-mail e senha
* Geração de token JWT
* Proteção de rotas com autorização

---

### 👤 Usuários

* Criar usuário
* Listar usuários
* Atualizar usuário
* Deletar usuário
* Validação de e-mail único
* Validação de senha

---

### 📦 Produtos

* Criar produto
* Listar produtos
* Atualizar produto
* Deletar produto
* Upload de imagem
* Validação de estoque (não permite valores negativos)

---

## 🛠️ Tecnologias utilizadas

* ASP.NET Core
* Entity Framework Core
* SQL Server (LocalDB)
* JWT (Autenticação)
* Swagger (documentação e testes)

---

## 🧱 Arquitetura

O projeto segue uma estrutura em camadas:

Controllers → Services → Repositories → Entities

* Controllers: recebem as requisições
* Services: regras de negócio
* Repositories: acesso ao banco
* Entities: modelos do sistema

---

## 🖼️ Upload de Imagens

As imagens dos produtos são:

* Armazenadas em uma pasta local /uploads
* Salvas com nome único
* O banco armazena apenas a URL da imagem

### 🔄 Fluxo

1. O arquivo é enviado via multipart/form-data
2. A API salva o arquivo no servidor
3. O caminho é armazenado no banco

---

## ▶️ Como rodar o projeto

### 1. Configurar o banco de dados

Verifique a string de conexão no appsettings.json:

"ConnectionStrings": {
"DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=NomeDoBanco;Trusted_Connection=True;"
}

---

### 2. Rodar as migrations

dotnet ef database update

---

### 3. Executar o projeto

dotnet run

---

### 6. Acessar o Swagger

[https://localhost:5110/swagger](https://localhost:xxxx/swagger)

---

## 🔑 Autenticação no Swagger

1. Faça login no endpoint /login
2. Copie o token retornado
3. Clique em Authorize
4. Insira:

Bearer SEU_TOKEN

---

## 📌 Exemplos de Endpoints

### 🔐 Login

POST /login

---

### 👤 Usuários

GET /usuarios
POST /usuarios
PUT /usuarios/{id}
DELETE /usuarios/{id}

---

### 📦 Produtos

GET /produtos
POST /produtos
PUT /produtos/{id}
DELETE /produtos/{id}

---

## ✅ Validações implementadas

* E-mail único para usuários
* Senha obrigatória
* Quantidade de estoque não pode ser negativa
* Rotas protegidas por autenticação

---

## 👨‍💻 Autor

Nathaniel Farias
Desenvolvedor Full Stack em formação

---