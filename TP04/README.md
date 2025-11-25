# Trabalho Prático 04: Web API com ASP.NET Core e CRUD

Este repositório contém a solução desenvolvida para o **Trabalho Prático 04** da disciplina de CBTSWE2 (ADS 671) do IFSP - Campus Cubatão.

O projeto consiste no desenvolvimento de uma Web API RESTful utilizando ASP.NET Core, integrada a uma biblioteca de classes (DLL) para acesso a dados, e uma interface web para interação com o usuário.

## 📋 Integrante
* **Nome:** Alice Marinho
* **Professor:** Wellington Tuler Moraes

## 📹 Video
<https://youtu.be/6zyK1Yn8-JQ>

## 🚀 Funcionalidades

O sistema permite o gerenciamento completo (CRUD) da entidade **Produto**, atendendo aos requisitos do trabalho:

* **API REST:** Endpoints para Criar (POST), Ler (GET), Atualizar (PUT) e Deletar (DELETE) produtos.
* **Interface Web:** Página front-end para consumir a API e realizar as operações via formulários.
* **Persistência de Dados:** Utilização do Entity Framework Core conectado a um banco de dados (SQL Server/SQLite).
* **Arquitetura em Camadas (DLL):** Separação das regras de negócio e acesso a dados em uma DLL externa (`DAL`), integrada à API.

## 🛠️ Tecnologias Utilizadas

* **Framework:** .NET 8 (ASP.NET Core Web API).
* **ORM:** Entity Framework Core.
* **Banco de Dados:** SQLite.
* **Front-end:** ASP.NET Core MVC / Razor Pages (com chamadas AJAX/Fetch à API).

## 📂 Estrutura do Projeto

A solução está organizada para atender ao requisito de integração com DLLs:

* `Solution`
    * 📂 **MyProject.API**: Projeto principal da Web API (Controladores e Injeção de Dependência).
    * 📂 **MyProject.DAL**: Class Library (DLL) contendo o `DbContext`, as Entidades (`Produto`) e as Configurações (`IEntityTypeConfiguration`).
    * 📂 **MyProject.Web**: Contém a página `index.html` e scripts para interação com o usuário.
    * 📂 **MyProject.Tests**: Projeto de testes unitários para validar a lógica.

## ⚙️ Configuração e Execução

### Pré-requisitos
* .NET SDK instalado.
* Banco de Dados configurado.
