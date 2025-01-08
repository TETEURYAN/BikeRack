# Bike Rack

## Descrição

Este projeto implementa um **bicicletário** que gerencia diversas operações, incluindo:
- Cadastro e gerenciamento de ciclistas.
- Processamento de informações relacionadas a cartões de crédito.
- Gestão de alugueis de bicicletas.

A aplicação foi desenvolvida em **C#** utilizando o framework **ASP.NET Core** e o banco de dados **PostgreSQL**.

---

## Funcionalidades

### Ciclistas
- Cadastro de ciclistas.
- Recuperação de dados de ciclistas.
- Atualização e remoção de informações de ciclistas.

### Alugueis
- Registro de novos alugueis.
- Gerenciamento de status de alugueis (ativo, concluído, cancelado).

### Cartões de Crédito
- Cadastro e gerenciamento de cartões de crédito associados a ciclistas.
- Validação de dados de pagamento.

### Serviços Externos
- Integração com APIs de terceiros para validação de pagamentos e outras funcionalidades.

---

## Tecnologias Utilizadas

### Backend
- **ASP.NET Core** - Framework para desenvolvimento de APIs.
- **Entity Framework Core** - ORM para interação com o banco de dados.
- **PostgreSQL** - Banco de dados relacional.

### Ferramentas Auxiliares
- **Swagger** - Para documentação e teste da API.
- **PgAdmin** - Interface gráfica para gerenciamento do banco de dados PostgreSQL.

---

## Requisitos

1. **.NET 6.0** ou superior.
2. **PostgreSQL 13** ou superior.
3. **Visual Studio 2022** ou outro editor compatível.
4. Configuração do arquivo `appsettings.json` para conexão com o banco de dados.


## Configuração e Execução

### Banco de Dados
1. Certifique-se de que o PostgreSQL está instalado e rodando.
2. Crie o banco de dados manualmente ou deixe que o **Entity Framework** gerencie a criação com as migrações.

### Migrações
Execute os seguintes comandos no **Package Manager Console**:
```bash
Add-Migration InitialCreate
Update-Database
```	

### Executando o Projeto
1. Abra o projeto no Visual Studio.
2. Compile a solução.
3. Configure o arquivo `appsettings.json` para refletir sua conexão com o banco de dados.
4. Execute o projeto (F5 ou botão de executar).

---

## Endpoints da API

A documentação da API está disponível via **Swagger**. Ao rodar o projeto, acesse:
```
https://localhost:{porta}/swagger
```

### Exemplos de Endpoints

#### Ciclistas
- `POST /Ciclistas/` - Cadastra um ciclita
- `GET /Ciclistas/{id}` - Retorna informações do ciclista.
- `PUT /Ciclistas/{id}` - Altera informações de um ciclista.
- `POST /Ciclistas/{id}` - Ativar cadastro do ciclista.

#### Funcionários
- `GET /funcionario` - Recupera funcionários cadastrados.
- `POST /funcionario` - Registra um novo funcionário.

#### Cartões de Crédito
- `GET /CartaoDeCredito/{id}` - Lista cartões associados a um ciclista.
- `PUT /CartaoDeCredito/{id}` - Altera um cartão de crédito.

---

## Estrutura do Projeto
```
Bike Rack
├── Controllers
│   ├── CiclistasController.cs
│   ├── AlugueisController.cs
│   └── CartaoDeCreditoController.cs
├── Data
│   └── AluguelContext.cs
├── Repositories
│   ├── CiclistaRepository.cs
│   ├── FuncionarioRepository.cs
│   ├── GestaoAluguelRepository.cs
│   └── CartaoDeCreditoRepository.cs
├── Services
│   ├── CiclistaService.cs
│   ├── AluguelService.cs
│   └── HttpService.cs
├── appsettings.json
└── Program.cs
```


---

## Licença
Este projeto está licenciado sob a [MIT License](LICENSE).
