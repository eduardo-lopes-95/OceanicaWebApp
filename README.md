# OceanicaWebApp

Passo a passo para rodar aplicação:
* Executar o comando: docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=2Secure*Password2" -p 1450:1433 --name sqlserverdb -h mysqlserver -d mcr.microsoft.com/mssql/server:2019-latest
* Selecionar "Oceanica" no Startup Projects
