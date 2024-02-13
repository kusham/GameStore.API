# GameStore.API

## Stating SQL server
```powershell
$sa_password = "[MY_PASSWORD]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql
-d --rm --name mssqlgamesstore mcr.microsoft.com/mssql/server:2022-latest
```

# Dotnet
```powershell
dotnet new web -n GameStore.API
dotnet add package [package Name]

dotnet user-secrets init
dotnet user-secrets list

dotnet tool install --global dotnet-ef
dotnet ef migrations add [Name for Migration] --output-dir Data/Migrations
dotnet ef migrations remove
dotnet ef database update
```

## Setting the connection string to secret manager
```powershell	
$sa_password = "[MY_PASSWORD]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost,1433;Database=GameStore;User Id=sa;Password=$sa_password; TrustServerCertificate=True"
```