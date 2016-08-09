Biblioteca de integração PagSeguro em .NET
==========================================
---
Descrição
---------
---

Este é um *fork* da biblioteca original e corresponde ao [pacote NuGet](https://www.nuget.org/packages/Uol.PagSeguro/) publicado. Esta versão é a 2.6.0.0. 

Precisei fazer este *fork* porque, aparentemente, a UOL perdeu o interesse de atualizar sua biblioteca, mesmo com o apelo de vários e vários usuários pedindo modificações e mandando *pull requests* que não são atendidos. Também custo a compreender como canais como *Issues* e *Wiki* não são mantidos, sendo eles de enorme importância para o desenvolvimento e uso da biblioteca. 

Resisti um bom tempo antes de colocar a mão na massa, até que apareceu um sistema que tive que fazer que utiliza a biblioteca, e não posso usar uma configuração XML em separado do arquivo de configuração da aplicação (até porque esse tipo de *design* não faz muito sentido). Ainda assim, mantive o suporte retroativo a este arquivo, mesmo não concordando com ele. 

Se a UOL tiver interese em reassumir o desenvolvimento, posso fazer um *pull request* sem problemas. Por ora, o desenvolvimento da biblioteca ficará por aqui.

==========================================
---
Descrição
---------
---
A biblioteca PagSeguro em .NET é um conjunto de classes de domínio que facilitam, para o desenvolvedor .NET, a utilização das funcionalidades que o PagSeguro oferece na forma de APIs. Com a biblioteca instalada e configurada, você pode facilmente integrar funcionalidades como:


 - Criar [requisições de pagamentos]
 - Criar [requisições de assinaturas]
 - Cancelar [assinaturas]
 - Consultar [assinaturas]
 - Consultar [transações por código]
 - Consultar [transações por intervalo de datas]
 - Consultar [transações abandonadas]
 - Receber [notificações]


Requisitos
----------
---
 - [.NET Framework] 4+


Instalação
----------
---

## NuGet

[instale o pacote mais recente](https://www.nuget.org/packages/Uol.PagSeguro/) usando o seguinte comando:

    > Install-Package Uol.PagSeguro
    

## Fontes

 - Baixe o repositório como arquivo zip ou faça um clone;
 - Descompacte os arquivos em seu computador;
 - Dentro do diretório *source* existem dois diretórios, o *Uol.PagSeguro* e o *Examples*. O diretório *Examples* contém exemplos de chamadas utilizando a API e o diretório *Uol.PagSeguro* contém a biblioteca propriamente dita;
 - Inclua o projeto `Uol.PagSeguro.csproj` dentro de sua solução;
 - Adicione uma referência ao projeto `Uol.PagSeguro.csproj` em seu projeto.

Configuração
------------
---
Visando garantir a segurança dos seus dados no PagSeguro, é necessário que você informe suas credenciais de acesso ao executar funções da biblioteca que realizam chamadas via API. As credenciais de acesso são formadas pelo e-mail de cadastro no PagSeguro e um token, que funciona como uma senha.

As chamadas via API exigem que você passe uma instância da classe `AccountCredentials` que é responsável por encapsular suas credenciais.

## Configuração usando *config sections*

Este é um exemplo de `App.config` (que pode ser `Web.config` também, tanto faz). Apenas pegamos o XML original e colocamos em formato de :

```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    <section name="PagSeguro" type="Uol.PagSeguro.Configuration.PagSeguroConfigurationSection, Uol.PagSeguro, Version=2.6.0.0, Culture=neutral, PublicKeyToken=f3c2cf8865d9ba24" requirePermission="false" />
  </configSections>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
  </startup>
  <PagSeguro>
    <Urls>
      <Payment>
        <Link>https://ws.pagseguro.uol.com.br/v2/checkout</Link>
      </Payment>
      <PaymentRedirect>
        <Link>https://pagseguro.uol.com.br/v2/checkout/payment.html</Link>
      </PaymentRedirect>
      <Notification>
        <Link>https://ws.pagseguro.uol.com.br/v3/transactions/notifications</Link>
      </Notification>
      <Search>
        <Link>https://ws.pagseguro.uol.com.br/v3/transactions</Link>
      </Search>
      <SearchAbandoned>
        <Link>https://ws.pagseguro.uol.com.br/v2/transactions</Link>
      </SearchAbandoned>
      <Cancel>
        <Link>https://ws.pagseguro.uol.com.br/v2/transactions/cancels</Link>
      </Cancel>
      <Refund>
        <Link>https://ws.pagseguro.uol.com.br/v2/transactions/refunds</Link>
      </Refund>
      <PreApproval>
        <Link>https://ws.pagseguro.uol.com.br/v2/pre-approvals/request</Link>
        <PreApprovalRequest>
          <Link>https://ws.pagseguro.uol.com.br/v2/pre-approvals/request</Link>
        </PreApprovalRequest>
        <PreApprovalRedirect>
          <Link>https://pagseguro.uol.com.br/v2/pre-approvals/request.html</Link>
        </PreApprovalRedirect>
        <PreApprovalNotification>
          <Link>https://ws.pagseguro.uol.com.br/v2/pre-approvals/notifications</Link>
        </PreApprovalNotification>
        <PreApprovalSearch>
          <Link>https://ws.pagseguro.uol.com.br/v2/pre-approvals</Link>
        </PreApprovalSearch>
        <PreApprovalCancel>
          <Link>https://ws.pagseguro.uol.com.br/v2/pre-approvals/cancel</Link>
        </PreApprovalCancel>
        <PreApprovalPayment>
          <Link>https://ws.pagseguro.uol.com.br/v2/pre-approvals/payment</Link>
        </PreApprovalPayment>
      </PreApproval>
      <DirectPayment>
        <Session>
          <Link>https://ws.pagseguro.uol.com.br/v2/sessions</Link>
        </Session>
        <Installment>
          <Link>https://ws.pagseguro.uol.com.br/v2/installments</Link>
        </Installment>
        <Transactions>
          <Link>https://ws.pagseguro.uol.com.br/v2/transactions</Link>
        </Transactions>
      </DirectPayment>
      <Authorization>
        <AuthorizationRequest>
          <Link>https://ws.pagseguro.uol.com.br/v2/authorizations/request</Link>
        </AuthorizationRequest>
        <AuthorizationURL>
          <Link>https://pagseguro.uol.com.br/v2/authorization/request.jhtml</Link>
        </AuthorizationURL>
        <AuthorizationSearch>
          <Link>https://ws.pagseguro.uol.com.br/v2/authorizations/</Link>
        </AuthorizationSearch>
        <AuthorizationNotification>
          <Link>https://ws.pagseguro.uol.com.br/v2/authorizations/notifications/</Link>
        </AuthorizationNotification>
      </Authorization>
    </Urls>
    <Credential>
      <Email>backoffice@lojamodelo.com.br</Email>
      <Token>256422BF9E66458CA3FE41189AD1C94A</Token>
      <SandboxEmail>backoffice@lojamodelo.com.br</SandboxEmail>
      <SandboxToken>256422BF9E66458CA3FE41189AD1C94A</SandboxToken>
      <AppId>app8888888888</AppId>
      <AppKey>82EBFA59F1F1469FF47B3FBB8D2526BC</AppKey>
      <SandboxAppId>app8888888888</SandboxAppId>
      <SandboxAppKey>82EBFA59F1F1469FF47B3FBB8D2526BC</SandboxAppKey>
    </Credential>
    <Configuration>
      <LibVersion>2.6.0</LibVersion> 
      <FormUrlEncoded>application/x-www-form-urlencoded</FormUrlEncoded>
      <Encoding>ISO-8859-1</Encoding>
      <RequestTimeout>10000</RequestTimeout>
    </Configuration>
  </PagSeguro>
</configuration>
```

Ou seja, insira no seu `App.config` ou `Web.config`, como primeira tag após `<configuration>`, o seguinte:

```
  <configSections>
    <section name="PagSeguro" type="Uol.PagSeguro.Configuration.PagSeguroConfigurationSection, Uol.PagSeguro, Version=2.6.0.0, Culture=neutral, PublicKeyToken=f3c2cf8865d9ba24" requirePermission="false" />
  </configSections>
```

É recomendado inserir a tag `<PagSeguro>` ao final do arquivo para evitar confusão, assim como no exemplo.

Mais informações estão disponíveis na [documentação oficial].


Dúvidas?
----------
---
Caso tenha dúvidas ou precise de suporte, acesse o [fórum do PagSeguro] ou abra uma *issue* aqui.


Changelog
---------
---

2.6.0.0

- Adicionado suporte à configuração por *config sections*, mantendo suporte retroativo ao XML isolado.

2.5.1

- Possibilidade de definir parcelamento sem juros.

2.5.0

- Integração com serviço de consulta de Assinaturas (PreApproval) por código de notificação.

2.4.0

- Integração com serviço de modelo de aplicações.
- Possibilidade de definir descontos por meio de pagamento durante a requisição do código de checkout - Ver exemplo createPaymentRequest.php
- Ajustes em geral.

2.3.0

- Adicionado classes e métodos para utilização do Checkout Transparente.

2.2.0

- Integração com serviço de solicitação de estorno.
- Integração com serviço de solicitação de cancelamento.
- Integração com serviço de consulta de transações por código de referência.
- Integração com serviço de consulta de transações abandonadas.
- Ajustes em geral.
- Obs.: Algumas das funcionalidades descritas ainda não estão disponíveis comercialmente para todos os vendedores. Em caso de dúvidas acesse nosso [fórum].

2.1.1

- Ajustes diversos

2.1.0

- Implementação do environment Sandbox
- Validação da implementação de Assinaturas (PreApproval). https://github.com/pagseguro/dotnet/pull/4


2.0.6

 - Opção para retornar apenas o código de checkout no método Register.
 - Atualização do exemplo CreatePayment.

2.0.5

 - Correção no TransactionSearchResult.

2.0.4

 - Atualização dos códigos de meios de pagamento.

2.0.3

 - Atualização da arquitetura em diretorios.
 - Alterado método de envio para HTTP.
 - Adicionado possibilidade de envio de SenderCPF, MetaData e Parameter Generics.

2.0.0 - 2.0.2

 - Classes de domínios que representam pagamentos, notificações e transações.
 - Criação de checkouts via API.
 - Controller para processar notificações de pagamento enviadas pelo PagSeguro.
 - Módulo de consulta de transações.


Licença
-------
---
Copyright 2013-2016 PagSeguro Internet LTDA.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.


Notas
-----
---
 - O PagSeguro somente aceita pagamento utilizando a moeda Real brasileiro (BRL).
 - Certifique-se que o email e o token informados estejam relacionados a uma conta que possua o perfil de vendedor ou empresarial.


Contribuições
-------------
---
Achou e corrigiu um bug ou tem alguma feature em mente e deseja contribuir?

* Faça um fork.
* Adicione sua feature ou correção de bug.
* Envie um pull request no [GitHub].

  [requisições de assinaturas]: http://download.uol.com.br/pagseguro/docs/pagseguro-assinatura-automatica.pdf
  [assinaturas]: http://download.uol.com.br/pagseguro/docs/pagseguro-assinatura-automatica.pdf
  [requisições de pagamentos]: https://pagseguro.uol.com.br/v2/guia-de-integracao/api-de-pagamentos.html
  [notificações]: https://pagseguro.uol.com.br/v3/guia-de-integracao/api-de-notificacoes.html
  [Checkout Transparente]: https://pagseguro.uol.com.br/receba-pagamentos.jhtml#checkout-transparent
  [transações por código]: https://pagseguro.uol.com.br/v3/guia-de-integracao/consulta-de-transacoes-por-codigo.html
  [transações por intervalo de datas]: https://pagseguro.uol.com.br/v2/guia-de-integracao/consulta-de-transacoes-por-intervalo-de-datas.html
  [transações abandonadas]: https://pagseguro.uol.com.br/v2/guia-de-integracao/consulta-de-transacoes-abandonadas.html
  [fórum do PagSeguro]: http://forum.pagseguro.uol.com.br/
  [.NET Framework]: http://www.microsoft.com/net
  [GitHub]: https://github.com/DesignLiquido/pagseguro-dotnet
  [documentação oficial]: https://pagseguro.uol.com.br/v2/guia-de-integracao/documentacao-da-biblioteca-pagseguro-netframework.html
