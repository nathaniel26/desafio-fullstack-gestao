# Painel de Controle - Gestão de Usuários e Produtos (Frontend Angular)
Este projeto é a interface de usuário de uma aplicação Full Stack de gerenciamento, desenvolvido com Angular 18/19. O sistema foi projetado para ser performático, seguro e moderno, utilizando as funcionalidades mais recentes do framework para consumir uma API RESTful de forma eficiente.

---

## 🚀 Funcionalidades Principais
### Segurança e Autenticação
* **Login Reativo: Interface integrada ao serviço de autenticação JWT do Backend com validação de credenciais.

* HttpInterceptor: Implementação de um interceptor global que anexa automaticamente o Token de acesso no cabeçalho de todas as requisições HTTP.

* Sessão Persistente: Uso de localStorage para garantir que o usuário permaneça logado mesmo após recarregar a página.

* Decodificação de Payload: Extração de contexto (como e-mail) diretamente do Token JWT para personalização da interface e controle de estado.

### Gestão de Usuários
* CRUD Completo: Listagem, criação, edição e exclusão de usuários com feedback em tempo real.

* Signals: Gerenciamento de estado reativo, garantindo que a tabela e os contadores atualizem instantaneamente sem necessidade de refresh.

* Validações Robustas: Formulários reativos com tratamento de erros para e-mail, requisitos de senha e campos obrigatórios.

### Gestão de Produtos
* Upload de Imagens: Envio de arquivos binários via FormData para integração com o serviço de arquivos da API.

* Galeria Visual: Exibição das fotos dos produtos consumidas diretamente do servidor de arquivos estáticos do Backend.

* Controle de Inventário: Gestão de quantidades em estoque com travas de segurança contra valores negativos.

### 🛠️ Tecnologias Utilizadas
* Angular 18/19: Arquitetura baseada em Componentes Standalone.

* Angular Signals: Para detecção de mudanças granular e alta performance.

* Reactive Forms: Controle total sobre a validação e fluxo dos dados de entrada.

H* ttpClient: Comunicação assíncrona e tipada com serviços externos.

* Router: Gerenciamento de rotas protegidas e navegação entre telas.

* CSS Nativo: Estilização modular focada em uma interface limpa e profissional.

### 🏗️ Arquitetura e Estrutura
O projeto segue uma organização pensada em escalabilidade e separação de responsabilidades:

* Core Services: Centralizam a lógica de comunicação com a API (Autenticação, Usuários e Produtos).

* Features: Componentes de página isolados (Login, Dashboard, Usuários e Produtos).

* Interceptors: Lógica desacoplada para tratamento global de segurança e injeção de tokens.

## 💡 Diferenciais Técnicos

Destaques para Apresentação:

* Manipulação de FormData: A tela de produtos lida com objetos Multipart, permitindo enviar a foto e os dados do produto em uma única requisição.

* Reatividade com Signals: Uso de computed signals para identificar estados complexos (como status de login) em tempo real, reduzindo processamento desnecessário.

* Decodificação Nativa: Extração de informações do JWT utilizando métodos nativos (atob e JSON.parse), mantendo o projeto leve e sem dependências externas.

## 🔧 Como executar o projeto
Certifique-se de estar dentro da pasta `/App`

Bash
npm install
Configurar a API:

Ajuste a URL da API nos arquivos de serviço para apontar para a porta correta da sua API .NET.

Rodar a aplicação:

Bash
ng serve
Acesse no navegador pelo endereço: http://localhost:4200

### 👤 Autor
Nathaniel Farias Desenvolvedor Full Stack em formação