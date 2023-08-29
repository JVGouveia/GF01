# GF01-LojaDeRoupas

**Modelo de negócio**: Sistema de Gerenciamento de Vendas de Loja de Roupas

**Classes básicas**:

**Produto**: representa os produtos disponíveis na loja. Contém atributos como nome, descrição, preço e categoria.

**Categoria**: representa as categorias de produtos disponíveis na loja. Contém atributos como nome e descrição.

**Cliente**: representa os clientes da loja. Contém atributos como nome, sobrenome, endereço e número de telefone.

**Venda**: representa a venda de produtos para um cliente em um determinado momento. Contém atributos como o cliente que realizou a compra, os produtos vendidos, a data da venda e o valor total da compra. Associações: Um cliente pode realizar várias compras, sendo que cada venda é referente a um único cliente. Um produto pertence a uma categoria.

## **Requisitos**:

Implemente todas as classes, observando tudo que foi apresentado até o momento durante a disciplina. Garanta que quem vá utilizar seu modelo de negócio consiga ter os objetos devidamente criados, respeitando todas as regras de integridade que precisem.

Implemente uma aplicação Console, onde um menu seja exibido, oferencendo ao usuário opções para trabalhar com todas as funcionalidades. 

Para cada funcionalidade, crie uma classe especifica. Por exemplo: Tal qual será necessário uma pasta Model para as classes apontadas como básicas, crie uma pasta chamada UI. Nela, uma classe para cada funcionalidade, como por exemplo CaregoriaUI, onde UI é User Interface. No exemplo, crie métodos para registrar uma categoria, alterar, buscar todas, buscar uma, com base no ID e remover uma categoria em específico. Algumas destas funcionalidades não foram explicadas em sala, mas serão. Para o momento, utilize seu pré-conhecimento em Linguagem C para resolver.

## **Entrega**: A entrega da atividade deve ser feita por meio de um repositório Git público, contendo o código-fonte completo do sistema e um arquivo README.md com as instruções de como executar a aplicação.

A avaliação será baseada na qualidade do código, na aderência aos requisitos e na funcionalidade geral do sistema.