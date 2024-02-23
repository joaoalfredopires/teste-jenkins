#language: pt-BR
Funcionalidade: Login

Testa a funcionalidade de Login do Portal de Integração.

@SmokeTest
Cenário: Login Portal de Integração (sucesso)
	Dado que estou na página de login do Portal de integração
	Quando insiro usuário e senha VÁLIDOS
	Então o login deve ocorrer com sucesso, direcionando para página inicial

Cenário: Login Portal de Integração (Falha)
	Dado que estou na página de login do Portal de integração
	Quando insiro usuário ou senha INVÁLIDOS
	Então o login deve falhar, exibindo um Toast que informa o erro deve ser exibida em tela
