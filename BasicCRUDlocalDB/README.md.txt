.NetCore MVC conectado ao localdb
http://localhost:49765/Users

Erro com package manager, correção:
no powershell adm -> mkdir "C:\Program Files (x86)\Microsoft SDKs\NuGetPackagesFallback"

Referências

===============================================================
https://jakeydocs.readthedocs.io/en/latest/tutorials/first-mvc-app/working-with-sql.html

"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-MvcMovie-4ae3798a;Trusted_Connection=True;MultipleActiveResultSets=true"
  },

===============================================================
https://stackoverflow.com/questions/43098065/entity-framework-core-dbcontextoptionsbuilder-does-not-contain-a-definition-f

We install Microsoft.EntityFrameworkCore.SqlServer NuGet Package.

Microsoft.EntityFrameworkCore.SqlServer

PM > Install-Package Microsoft.EntityFrameworkCore.SqlServer
Then,

   services.AddDbContext<AspDbContext>(options =>
       options.UseSqlServer(config.GetConnectionString("optimumDB")));