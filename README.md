## Controle de Estoque e Lançamento de Pedidos VenderGas API

Este projeto é uma API de controle de estoque e lançamento de pedidos desenvolvido em .NET 6 e Docker.

### Requisitos

- Visual Studio
- .NET 6 SKD
- Docker Desktop



### Inicialização
-Para inicializar o projeto utilizando Docker, siga os passos abaixo:
  1. Certifique-se de ter o Docker instalado em sua máquina.
  2. Altere a inicialização(startup projects) do projeto e inicialize usando o docker-compose.
  3. O projeto deve ser inicializado duas vezes, para criaçaõ do mysql, onde na primeira vez, pode ocorrer um erro
  4. Execute o seguinte comando na raiz do projeto para iniciar os contêineres:

-Caso queria rodar local, é necessário mudar a senha do DB nas variaveis de controle app.settings.json

### Tecnologias Utilizadas

- .NET 6

