## Controle de Tarefas
Este projeto é um exemplo de CRUD de tarefas construído com ASP.NET 8. Ele implementa a criação e manutenção de tarefas através de uma API, utilizando operações CRUD simples sem relacionamentos de entidades.

A arquitetura adotada é monolítica e focada exclusivamente em registrar, alterar, listar e deletar tarefas. O objetivo é demonstrar como você pode organizar seu projeto utilizando injeção de dependência, EF Core e Fluent API de maneira simples e com uma leitura clara.

O projeto está orientado a Code First. Sendo assim não esqueça de realizar `update-database`.

`Keep Simples` ❤️

## Let's build 🚀.
Para levantar o ambiente 

- Abrir CMD, acessar a pasta do projeto `cd C:\Git\taskLand\TaskLand.API`, ou onde estiver o projeto em sua máquina

- Use o comando `docker-compose build` ou `docker-compose -d` (que irá buildar e logo em seguida usar o up)

- Ele baixará as dependências e por ultimo utilize o comando `docker-compose up` (caso tenha utilizado o comando `docker-compose build`)

- Depois de levantar os containers você precisará atualizar o database. Em seu arquivo `appsettings.Development.json` modifique a `ConnectionString` dessa forma.

```json
{
  "ConnectionStrings": {
    "Task": "Data Source=localhost,1433;Initial Catalog=taskland;User ID=sa;Password=@task2024;TrustServerCertificate=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```
- Pronto, após isso é só rodar o comando `update-database`, abra o prompt comando `Console do Gerenciador de pacotes` caso esteja usando o VS e digite `update-database -context taskdbcontext` dessa forma você estará selecionando o contexto que quer atualizar.

- Após isso a base de dados será criada modifique o `appsettings.Development.json` para conectar com o container que será gerado e após isso você estará pronto para rodar a aplicação.

````json
{
  "ConnectionStrings": {
    "Task": "Data Source=db;Initial Catalog=taskland;User ID=sa;Password=@task2024;TrustServerCertificate=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
````

- Após isso é só atualizar o container da API e ser feliz 😁


### Observações.
- O projeto está utilizando o `Middleware` de erro para capturar e padronizar as mensagens de retorno de erro.
- Optei por não usar `AutoMapper` devido artigos relatando a falta de performance então crie um serviço de mapper para separar a responsabilidade.
- A `EntityBase` possui uma coluna IsDeleted porém não está sendo usado pois isso depende da regra de negócio, mas sempre acho interessante não deletar informação da base de dados a não ser que a Lei como a LGPD solicite ou o cliente.
- Novamente, `Keep Simple` o software precisa estar de acordo com a regra de negócio.




