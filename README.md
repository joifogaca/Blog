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

### M�todos de Extension do .NET

* Extende uma classe Nativa do .NET, 
* Devem ser est�ticas


### Autentica��o e Autoriza��o 

Em api o usu�rio nunca fica logado direto, ele se autentica a cada requisi��o. 
O token � encripitado, com uma chave que fica no servidor, s� � possivel descripitografar com essa chave.
Autentica��o quem �. 
Autoriza��o o que voc� pode fazer.

Claim => Permite gerar valores na na token criptografado que podem, ser descriptografado sem a chave.

#### Annotations de Autentifica��o e Autoriza��o

[AllowAnonymous] => Apesar do Authorize do Controller, ele vai liberar o met�do login, sem estar logado
[Authorize(Roles = "user")] => Pode ser usado no m�todo ou no controller todo

Guardar senha no banco geralmente � um problema, a melhor alternativa � logar com facebook ou google, se voc� salvar no seu banco que seja no minimo encriptografada.

PasswordHasher.Hash sempre gera um hash diferente

#### Modos de autentica��o 

##### JWT Bearer

* Feito por usu�rio e senha

##### APIKEY

* voc� exp�e o m�todo que usamos dessa forma
* Acesso por um r�bo, n�o usu�rio final
* Cuidado com a seguran�a � mais f�cil de conseguir acessar 
* N�o usa anotation Authorize

## Processo de autentica��o e autoriza��o Bearer JWT

1. No endpoint de cria��o do usu�rio ser� gerado um hash da senha.
2. Ao fazer o login verifica se o usu�rio se encontra no banco, 
3. O usu�rio estando no banco, verifica se o Hash da senha salva no banco � referente a senha recebida na requisi��o,
4. Se positivo, e gerado um token, onde atrav�s dos Claim, � adicinada um dado ao token, dados como Role, usu�rio e outros se necess�rios
5. O response ser� o token gerado, que dever� ser enviado nas proximas requisi��es.

https://jwt.io/
Link para decodificar token

## Envio de Email

API_Key_send_grid = "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";

* envio de email, se n�o tiver um IP dedicado pode ser bloqueado por conta de outros email�do servidor j� terem passado como SPAM. 