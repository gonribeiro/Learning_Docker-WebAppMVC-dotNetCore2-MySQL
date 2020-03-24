# O projeto "br.com.Money" é o da documentação fornecida pelo prof. Tomás.
# O projeto "ATM-Bank" é a investida de criar um próprio.

## Conta
### Banco de Dados
- Id
- Nome
- NumeroConta
- Pin
- Saldo


- Transações
- Id
- NumeroContaId
- TipoTransacao
- Transacao

### Requisitos do Projeto

- uma conta por user 
- ver saldo
- sacar
- depositar
- view de user
- inputs
- caixa recebe 500 com notas de 20 diariamente
- tela de vem vindo e insira senha
- usuario loga com numero da conta e pin (ambos 5 numeros) e exibe seu saldo. caso erro, informa e volta ao login
- ao logar, 4 opções, uma sair e três de transações
- saques opção multiplas de 20 e uma de sair
- saque maior que saldo, informa erro solicitando outro valor. valor valido saca e retira da conta (e iforma ao usuario para retiarar o dinheito)
- pode depositar ou cancelar deposito a qualquer momento.
- o deposito ele informa o valor primeiramente e depois inserir o envelope (e confirma) - pode depositar em até dois minutos. recebendo, deposita na conta e voltar a tela principal.
- saindo, tela de despedida