# 📚 Library Management System - API

🚀 **Sistema de gerenciamento de biblioteca** desenvolvido com **.NET, ADO.NET, CQRS e Clean Architecture** - By Bruno Silva.

![GitHub repo size](https://img.shields.io/github/repo-size/brunofsilva1989/LibraryManagementSystem?style=for-the-badge)
![GitHub last commit](https://img.shields.io/github/last-commit/brunofsilva1989/LibraryManagementSystem?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/brunofsilva1989/LibraryManagementSystem?style=for-the-badge)

---

## ⚙️ **Tecnologias Utilizadas**
- **.NET 8.0**
- **C#**
- **SQL Server**
- **ADO.NET**
- **CQRS (Command Query Responsibility Segregation)**
- **Swagger**
- **Clean Architecture**
- **Middleware para Exception Handling**

---

## 🚀 **Configuração Inicial**

Antes de rodar o projeto, siga os passos abaixo para configurar o ambiente corretamente.

### **1️⃣ Clonar o Repositório**

[git clone https://github.com/seu-usuario/seu-repositorio.git](https://github.com/brunofsilva1989/LibraryManagementSystemV2.git)
cd seu-repositorio

### **2️⃣ Configurar a Connection String
O projeto está configurado para acessar um banco de dados SQL Server, mas você precisa atualizar a Connection String com os seus dados locais.

"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=LibraryDB;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;"
}

🔹 Altere SEU_SERVIDOR, SEU_USUARIO e SUA_SENHA conforme o seu ambiente.

🔹 Se estiver rodando no SQL Server Express, use:

### **3️⃣ Criar o Banco de Dados

Antes de executar o projeto, é necessário criar o banco LibraryDB.

CREATE DATABASE LibraryDB;

### **4️⃣ Criar as Tabelas

📂 O projeto contém uma Stored Procedure (SP_SETUP_DATABASE) dentro na pasta LibraryManagementSystem.Infrastructure/SQL que cria todas as tabelas do sistemae e já insere dados.

📌 Para criar as tabelas, execute a proc:

-- Execute dentro do SQL Server no banco LibraryDB
USE LibraryDB;

exec SP_SETUP_DATABASE - (Antes desse comando é necessário abrir a proc no SQL executar dentro do banco, após isso você executa a proc)

✔ Tabelas que serão criadas criadas:

Users → Gerenciamento de usuários.
Books → Cadastro de livros.
Loans → Controle de empréstimos.

### **5️⃣ Criar as Procedures (Procs)
📂 Dentro da pasta LibraryManagementSystem.Infrastructure/SQL, há um conjunto de scripts SQL que criam as procedures do sistema.

🔹 Execute todas as procedures no SQL Server, dentro do LibraryDB:

"SP_GET_BOOKS";

"SP_GET_BOOK_BY_ID";

"SP_UPDATE_BOOKS";

"SP_CREATE_BOOKS";

"SP_DELETE_BOOKS";

"SP_CREATE_LOAN";

"SP_DELETE_LOAN";

"SP_UPDATE_LOAN";

"SP_GET_LOAN_BY_USER";

"SP_MARK_LOAN_LATE";

"SP_RENEW_LOAN";

"SP_RETURN_LOAN";

"SP_GET_USERS";

"SP_GET_USER_BY_ID";

"SP_UPDATE_USER";

"SP_CREATE_USER";

"SP_DELETE_USER";

### **6️⃣ Rodando a API

Agora que o banco está configurado, basta rodar a API.

🔹 No Visual Studio
1️⃣ Abra o projeto
2️⃣ Configure a API como Startup Project
3️⃣ Pressione F5 para rodar o projeto

No Terminal (.NET CLI)
dotnet run --project LibraryManagementSystem.API

A API estará disponível em:
📌 https://localhost:5001/swagger/index.html

***********************************************

🎯 Endpoints Disponíveis

🔹 UserController
Método	Rota	Descrição
POST	/api/users	Cria um novo usuário

GET	/api/users/{id}	Retorna um usuário por ID

GET	/api/users	Lista todos os usuários

PUT	/api/users/{id}	Atualiza um usuário

DELETE	/api/users/{id}	Deleta um usuário

***********************************************

🔹 BookController
Método	Rota	Descrição
POST	/api/books	Adiciona um novo livro

GET	/api/books/{id}	Retorna um livro por ID

GET	/api/books	Lista todos os livros

PUT	/api/books/{id}	Atualiza um livro

DELETE	/api/books/{id}	Deleta um livro

***********************************************

🔹 LoanController
Método	Rota	Descrição
POST	/api/loans	Cria um novo empréstimo

GET	/api/loans/{userId}	Lista empréstimos de um usuário

PUT	/api/loans/renew/{id}	Renova um empréstimo

PUT	/api/loans/return/{id}	Finaliza um empréstimo (devolução)

DELETE	/api/loans/{id}	Remove um empréstimo


**************************************************************

📌 Padrões Implementados

✅ Clean Architecture → Código modular e bem estruturado, separando responsabilidades entre Domain, Application, Infrastructure e API.

✅ CQRS (Command & Query Responsibility Segregation) → Separação entre operações de leitura (Queries) e escrita (Commands) para melhor escalabilidade.

✅ Repository Pattern → Implementação de repositórios genéricos para acesso a dados via ADO.NET e Stored Procedures.

✅ Middleware de Exception Handling → Tratamento global de erros centralizado, evitando a necessidade de capturar exceções manualmente em cada Controller.

✅ Validação Avançada (FluentValidation & DataAnnotations) → Garante que os dados sejam validados antes de serem persistidos no banco de dados.

✅ Fluxo de empréstimos completo → Criar, renovar, devolver e excluir empréstimos, garantindo controle total da jornada de empréstimos de livros.

✅ Injeção de Dependência (Dependency Injection - DI) → Configuração correta no Program.cs, garantindo a injeção de serviços e repositórios sem acoplamento.

✅ Unit of Work (Conceito aplicado) → Controle de transações no banco de dados através de Stored Procedures, garantindo atomicidade nas operações.

✅ SOLID Principles → Código organizado seguindo os princípios SOLID, melhorando a manutenibilidade e extensibilidade.




