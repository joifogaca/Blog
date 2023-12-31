# Blog

Projeto utilizado no curso balta.io Fundamentos do ASP.NET em .NET 6.0

## Anotações sobre o curso

### Versionamento
E importante manter o versionamento da API, para seus consumidores saberem quando há mudança nos dados, pode ser interessante manter 2 versões da api ativa, 
assim o consumidor pode ter um tempo após o lançamento para se preparar para a mudança.

### Async e Await 

Async => O metódo será executado em uma thread separada
Await => iremos esperar o metódo carregar

Task é um tipo de retorno que em vez de ser o tipo de dado (int, string, List) é um tipo Task que é uma tarefa a ser executada: 
Task<Categories>

Os métodos do controle também podem ser Assincronos, assim o servidor não irá esperar uma requisição acabar para chamar a próxima

### Métodos HTTP para o CRUD

GET => e usado para retornar informação do recurso identificado na URI. O código de status  200 OK é retornado em caso de sucesso, com os dados desejados no corpo da resposta.
POST => usado para criar um novo recurso no servidor. Ao realizar a operação servidor com o status 201 CREATED, fornecendo URI do recurso criado.
PUT => é o método para atualização do recurso ou criar um recurso se não existir. Se bem sucedida devolve o status 200 OK,
DELETE => método para excluir um recurso. Quando concluido com sucesso, o servidor retorna o código de status No Content 204 caso não encontre o recurso solicitado para remoção.

#### Dica do Balta

Colocar um código para cada erro que for lançado, isso facilita na hora da rastreabilidade.

### View Models (MVVM)

E um padrão de arquiterura, onde temos 2 modelos diferentes o que chega da API, e o Modelo que usamos no banco de dados.

Quando temos um modelo que é comum tanto para criação, tanto para edição existe uma convenção inicia o nome da classe como editor.

Vantagens do View Model é separar a validação que é exclusiva para tela

