
# Controle de Trem API

## Autores
Criado por Eduardo Klug, João Artur Ramos Belli e Mateus de Faria da Silva.

## Descrição
Esta API é responsável por controlar um trem com base em comandos recebidos em formato de lista de strings, como `["DIREITA", "ESQUERDA"]`. O trem responde aos comandos movendo-se para a direita ou esquerda conforme especificado.

## Funcionalidades
- **Endpoint principal**: Recebe uma lista de comandos (`["DIREITA", "ESQUERDA"]`) e executa as ações correspondentes para controlar o movimento do trem.
- **Testes Unitários**: Garantem a integridade e o correto funcionamento da API.

## Tecnologias Utilizadas
- .NET Core 8
- C#
- xUnit para testes unitários

## Endpoints

### POST /api/v1/autonomous-train
Recebe uma lista de comandos para controlar o trem.

#### Exemplo de Requisição
```json
[
  "DIREITA", "ESQUERDA"
]
```

#### Exemplo de Resposta
```json
{
  1
}
```

## Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/JoaooArtur/autonomous-train.git
   ```
   
2. Navegue até o diretório do projeto:
   ```bash
   cd seu-repositorio
   ```

3. Restaure as dependências do projeto:
   ```bash
   dotnet restore
   ```

4. Execute o projeto:
   ```bash
   dotnet run
   ```

## Executando Testes Unitários

Para rodar os testes unitários e verificar se tudo está funcionando corretamente, execute o comando:

```bash
dotnet test
```
