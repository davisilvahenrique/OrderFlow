# 🚀 ROADMAP — OrderFlow

## 📌 Visão Geral

Projeto backend com foco em arquitetura realista, regras de negócio, rastreabilidade e separação entre leitura e escrita (estilo CQRS leve).

Este projeto será desenvolvido com abordagem incremental, simulando um ambiente real de desenvolvimento.

---

## ⏱️ Carga de Trabalho

- Tempo disponível: ~2h por dia
- Frequência: 5 dias por semana
- Carga semanal: ~10h
- Duração estimada:
  - MVP sólido: 6 a 8 semanas
  - Projeto completo: até 10 semanas

---

## 🎯 Objetivo do MVP

Permitir:

- Criar pedidos
- Listar pedidos
- Buscar pedido por ID
- Realizar pagamento
- Visualizar histórico de eventos

---

## 🧱 Stack Tecnológica

- ASP.NET Core Web API
- C#
- Entity Framework Core
- Banco relacional (SQL Server ou PostgreSQL)
- Swagger

---

## 🏗️ Arquitetura

- OrderFlow.API
- OrderFlow.Application
- OrderFlow.Domain
- OrderFlow.Infrastructure

---

# 📅 ROADMAP POR FASES

---

## 🧠 Fase 0 — Planejamento

**Duração:** 2–3 dias (~4h–6h)

### Objetivos

- Definir escopo do MVP
- Definir entidades iniciais
- Definir regras de negócio
- Escolher banco de dados
- Definir arquitetura

### Critério de conclusão

- Escopo claro
- Entidades definidas
- Fluxo principal definido

---

## 🏗️ Fase 1 — Estrutura da Solução

**Duração:** 3–4 dias (~6h–8h)

### Objetivos

- Criar solution
- Criar projetos
- Organizar dependências
- Rodar API base

### Entregáveis

- Solution criada
- Projetos conectados
- API rodando

### Critério de conclusão

Projeto inicia sem erros

---

## 🧩 Fase 2 — Domínio

**Duração:** ~1 semana (~8h–10h)

### Entidades

- Order
- OrderItem
- OrderEvent
- OrderStatus

### Objetivos

- Modelar entidades
- Definir regras de negócio
- Centralizar lógica no domínio

### Regras esperadas

- Pedido nasce com status inicial
- Pedido precisa de itens
- Total é calculado
- Mudanças geram eventos

### Critério de conclusão

Domínio consistente e explicável

---

## 💾 Fase 3 — Persistência

**Duração:** ~1 semana (~8h–10h)

### Objetivos

- Configurar EF Core
- Criar DbContext
- Mapear entidades
- Criar migrations
- Criar banco

### Critério de conclusão

Dados persistindo corretamente

---

## ⚙️ Fase 4 — Application (Casos de Uso)

**Duração:** ~1 semana (~8h–10h)

### Casos de uso

- CreateOrder
- GetOrders
- GetOrderById
- PayOrder
- GetOrderHistory

### Objetivos

- Separar comandos e queries
- Criar DTOs
- Definir contratos

### Critério de conclusão

Fluxos funcionando internamente

---

## 🌐 Fase 5 — API

**Duração:** ~1 semana (~8h–10h)

### Endpoints

- POST /orders
- GET /orders
- GET /orders/{id}
- POST /orders/{id}/pay
- GET /orders/{id}/history

### Objetivos

- Criar controllers
- Integrar com aplicação
- Configurar Swagger

### Critério de conclusão

Fluxo completo testável via Swagger

---

## 🛡️ Fase 6 — Validações e Erros

**Duração:** ~1 semana (~8h–10h)

### Objetivos

- Validar entradas
- Padronizar erros
- Impedir ações inválidas

### Critério de conclusão

API previsível e robusta

---

## 📊 Fase 7 — Eventos e Histórico

**Duração:** 4–5 dias (~6h–8h)

### Objetivos

- Registrar eventos
- Criar histórico do pedido

### Eventos mínimos

- Pedido criado
- Pedido pago
- Mudança de status

### Critério de conclusão

Histórico completo e confiável

---

## 🔁 Fase 8 — Idempotência

**Duração:** 4–5 dias (~6h–8h)

### Objetivos

- Evitar pagamento duplicado
- Simular comportamento real de backend

### Critério de conclusão

Chamadas repetidas não causam efeito duplicado

---

## Fase 9 — Testes e refinamento

**Duração:** 1 semana
**Carga estimada:** 8h a 10h

### Objetivos

- Validar regras críticas
- Aumentar confiabilidade
- Deixar o projeto apresentável

### Eventos mínimos

- Criação de pedido
- Cálculo de total
- Pagamento válido
- Pagamento inválido
- Histórico gerado
- Regras de transição de status

### Entregáveis

- Testes unitários das regras principais
- Possível teste de integração básico
- Correções estruturais
- Limpeza do projeto

### Critério de conclusão

Você deve conseguir demonstrar que as regras mais importantes estão protegidas por testes.

---

### Critério de conclusão

Você deve conseguir demonstrar que as regras mais importantes estão protegidas por testes e que alterações no domínio não quebram comportamentos já esperados.

---

## Fase 10 — Documentação final e apresentação

**Duração estimada:** 3 a 4 dias  
**Carga estimada:** 4h a 6h

### Objetivos

- deixar o projeto pronto para GitHub e portfólio
- documentar decisões técnicas
- preparar discurso de apresentação

### Entregáveis

- README.md
- ROADMAP.md
- descrição da arquitetura
- instruções para rodar
- explicação dos diferenciais
- lista de melhorias futuras

### Critério de conclusão

Qualquer pessoa deve conseguir entender o projeto, rodar localmente e perceber claramente por que ele não é um CRUD genérico.

---

# Ordem real de construção

## Parte 1 — Base

- solution
- projetos
- referências
- configuração inicial

## Parte 2 — Negócio

- entidades
- regras
- enum
- eventos

## Parte 3 — Dados

- contexto
- mapeamentos
- migrations
- banco

## Parte 4 — Aplicação

- commands
- queries
- DTOs
- contratos

## Parte 5 — API

- controllers
- respostas
- swagger
- testes manuais

## Parte 6 — Qualidade

- validações
- exceções
- idempotência
- testes

## Parte 7 — Apresentação

- README
- documentação
- GitHub
- discurso técnico

---

# Definição de pronto do MVP

O MVP será considerado pronto quando for possível:

- criar um pedido com itens
- salvar corretamente no banco
- consultar pedido por id
- listar pedidos
- pagar pedido
- impedir pagamento inválido
- registrar histórico do pedido
- testar tudo via Swagger
- explicar a arquitetura e as decisões tomadas

---

# Melhorias futuras

Estas ficam fora do MVP, mas podem entrar depois:

- autenticação
- autorização por perfil
- frontend web
- mensageria
- outbox pattern
- cache para leitura
- paginação
- filtros avançados
- observabilidade com logs estruturados
- Docker
- CI/CD

---

# Modo de trabalho do projeto

Este projeto será desenvolvido como estudo guiado com foco em aprendizado real.

A cada etapa:

- primeiro entender o objetivo
- depois entender por que ela existe
- depois implementar
- depois revisar
- depois ajustar
- depois avançar

### Princípios de desenvolvimento

- evitar copiar código sem entender
- priorizar regras de negócio sobre tecnologia
- manter organização desde o início
- escrever código pensando em explicação futura
- tratar o projeto como se fosse produção

### Definition of Done (DoD)

Uma etapa será considerada concluída quando:

- o código compila e roda sem erro
- o comportamento implementado está correto
- as regras de negócio foram respeitadas
- o código está organizado e legível
- você consegue explicar o que fez e por quê
- não há "gambiarras" evidentes

---

# Backlog inicial

## Funcionalidades principais (MVP)

- criação de pedido
- listagem de pedidos
- consulta por id
- pagamento de pedido
- histórico de eventos

## Regras críticas

- pedido deve ter itens
- total deve ser consistente
- pagamento não pode ser duplicado
- status deve seguir fluxo válido

## Técnicos

- estrutura em camadas
- persistência com EF Core
- migrations
- Swagger

---

# Riscos do projeto

- tentar implementar tudo ao mesmo tempo
- misturar regra de negócio com controller
- pular modelagem de domínio
- não validar regras antes de persistir
- focar demais em frontend cedo

---

# Estratégia para evitar problemas

- implementar sempre do domínio para fora
- validar cada etapa antes de avançar
- manter escopo controlado (MVP primeiro)
- revisar antes de evoluir
- testar manualmente cada fluxo

---

# Forma de execução com apoio (mentoria)

O desenvolvimento será feito de forma guiada, com foco em aprendizado:

1. entender o problema antes de codar  
2. modelar a solução  
3. implementar com intenção  
4. revisar decisões  
5. evoluir para próxima etapa  

O objetivo não é apenas terminar o projeto, mas:

- entender arquitetura
- saber justificar decisões
- ganhar segurança para entrevistas técnicas
