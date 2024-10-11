Descrição
Este projeto  é uma API desenvolvida para o controle de estoque, permitindo o gerenciamento do cadastro de produtos e fornecedores. O projeto foi construído com ASP.NET Core 8 e utiliza Entity Framework para manipulação do banco de dados, seguindo os princípios de DDD (Domain-Driven Design), SOLID e Injeção de Dependência. 

Pré-requisitos
Para executar este projeto, você precisará do seguinte:

Visual Studio 2022 com .NET 8 instalado.
Um banco de dados SQL Server. Você precisará criar um banco de dados local e atualizar a string de conexão no arquivo SqlServerSettings.cs.

Tecnologias Utilizadas

ASP.NET Core 8 API: Framework principal para o desenvolvimento da API.
Entity Framework Core: ORM (Object-Relational Mapper) utilizado para o gerenciamento das entidades e mapeamento para o banco de dados.
Domain-Driven Design (DDD): Arquitetura aplicada para organizar o código, separando domínios e mantendo alta coesão e baixo acoplamento.
Princípios SOLID: Seguindo os princípios de design SOLID para um código mais robusto e de fácil manutenção.
Injeção de Dependência: Utilizada para gerenciar dependências e melhorar o desacoplamento entre os componentes do sistema.

Funcionalidades

Gerenciamento de produtos e fornecedores (criação, edição, exclusão, consulta).
Integração com banco de dados utilizando Entity Framework.
Arquitetura robusta baseada em DDD e SOLID.

Estrutura do Projeto

O projeto segue os princípios de Domain-Driven Design, organizando-se em:
Domínio: Contém as entidades, serviços de domínio e interfaces.
Aplicação: Contém os casos de uso, interfaces de repositórios e serviços de aplicação.
Infraestrutura: Implementa os repositórios, configuração do banco de dados e outras integrações.
API: Controladores e endpoints para expor as funcionalidades do sistema.

Configuração do Projeto
Requisitos
.NET 8 SDK: Necessário para compilar e rodar o projeto.
SQL Server ou outro banco de dados compatível com Entity Framework: Para persistência dos dados.

