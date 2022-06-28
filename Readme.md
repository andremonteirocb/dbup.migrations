
# Estudando a biblioteca DBup para execução de scripts
## Configurações
### Execute o docker run abaixo para subir o container
#### Altere a senha para a desejada e efetue o login com o usuário sa
docker run -d -p 1433:1433 --name sqlserver -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=suasenha' -v sqlserver-volume:/var/opt/mssql mcr.microsoft.com/mssql/server:2019-latest

