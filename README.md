Witamy w ProjektNET.

By uruchomić aplikację wraz z bazą danych:

1. Zainstaluj SQL Server 2019 Express Edition
2. Jeśli jeszcze nie jest utworzona, utwórz instancję.
3. Ustaw CONNECTION STRING na "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;"
4. uruchom następujące polecenia:
    dotnet ef migrations add MyBaseMigration --context MyDbContext
    dotnet ef database update
    dotnet run
5. Miłego korzystania z aplikacji!