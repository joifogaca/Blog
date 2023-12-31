# Blog

Projeto utilizado no curso balta.io Fundamentos do ASP.NET em .NET 6.0

## Anota��es sobre o curso

### Versionamento
E importante manter o versionamento da API, para seus consumidores saberem quando h� mudan�a nos dados, pode ser interessante manter 2 vers�es da api ativa, 
assim o consumidor pode ter um tempo ap�s o lan�amento para se preparar para a mudan�a.

### Async e Await 

Async => O met�do ser� executado em uma thread separada
Await => iremos esperar o met�do carregar

Task � um tipo de retorno que em vez de ser o tipo de dado (int, string, List) � um tipo Task que � uma tarefa a ser executada: 
Task<Categories>

Os m�todos do controle tamb�m podem ser Assincronos, assim o servidor n�o ir� esperar uma requisi��o acabar para chamar a pr�xima

### M�todos HTTP para o CRUD

GET => e usado para retornar informa��o do recurso identificado na URI. O c�digo de status  200 OK � retornado em caso de sucesso, com os dados desejados no corpo da resposta.
POST => usado para criar um novo recurso no servidor. Ao realizar a opera��o servidor com o status 201 CREATED, fornecendo URI do recurso criado.
PUT => � o m�todo para atualiza��o do recurso ou criar um recurso se n�o existir. Se bem sucedida devolve o status 200 OK,
DELETE => m�todo para excluir um recurso. Quando concluido com sucesso, o servidor retorna o c�digo de status No Content 204 caso n�o encontre o recurso solicitado para remo��o.

#### Dica do Balta

Colocar um c�digo para cada erro que for lan�ado, isso facilita na hora da rastreabilidade.

### View Models (MVVM)

E um padr�o de arquiterura, onde temos 2 modelos diferentes o que chega da API, e o Modelo que usamos no banco de dados.

Quando temos um modelo que � comum tanto para cria��o, tanto para edi��o existe uma conven��o inicia o nome da classe como editor.

Vantagens do View Model � separar a valida��o que � exclusiva para tela

