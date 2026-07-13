# Orders

Repositório criado para praticar mensageria com RabbitMQ, realizando comunicação assíncrona entre dois projetos.

Este projeto atua como o publicador no fluxo de mensageria. Ele envia eventos para a fila stock-service/order-created no RabbitMQ, que são consumidos pelo serviço Stock."

[Projeto Stock "Consumidor"](https://github.com/MatheusDSilver/Stock.git)

## Conceitos e tecnologias utilizados (até o momento)

* MongoDB
* RabbitMQ
* Clean Architecture
* .NET 7
* ASP.NET Core 7