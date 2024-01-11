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

### Métodos de Extension do .NET

* Extende uma classe Nativa do .NET, 
* Devem ser estáticas


### Autenticação e Autorização 

Em api o usuário nunca fica logado direto, ele se autentica a cada requisição. 
O token é encripitado, com uma chave que fica no servidor, só é possivel descripitografar com essa chave.
Autenticação quem é. 
Autorização o que você pode fazer.

Claim => Permite gerar valores na na token criptografado que podem, ser descriptografado sem a chave.

#### Annotations de Autentificação e Autorização

[AllowAnonymous] => Apesar do Authorize do Controller, ele vai liberar o metódo login, sem estar logado
[Authorize(Roles = "user")] => Pode ser usado no método ou no controller todo

Guardar senha no banco geralmente é um problema, a melhor alternativa é logar com facebook ou google, se você salvar no seu banco que seja no minimo encriptografada.

PasswordHasher.Hash sempre gera um hash diferente

#### Modos de autenticação 

##### JWT Bearer

* Feito por usuário e senha

##### APIKEY

* você expõe o método que usamos dessa forma
* Acesso por um rôbo, não usuário final
* Cuidado com a segurança é mais fácil de conseguir acessar 
* Não usa anotation Authorize

## Processo de autenticação e autorização Bearer JWT

1. No endpoint de criação do usuário será gerado um hash da senha.
2. Ao fazer o login verifica se o usuário se encontra no banco, 
3. O usuário estando no banco, verifica se o Hash da senha salva no banco é referente a senha recebida na requisição,
4. Se positivo, e gerado um token, onde através dos Claim, é adicinada um dado ao token, dados como Role, usuário e outros se necessários
5. O response será o token gerado, que deverá ser enviado nas proximas requisições.

https://jwt.io/
Link para decodificar token

## Envio de Email

API_Key_send_grid = "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";

* envio de email, se não tiver um IP dedicado pode ser bloqueado por conta de outros email´do servidor já terem passado como SPAM. 