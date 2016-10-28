# Speakr.DbMigrations


This project setups DB migrations for the Speakr project
You will need to do some setup in order to be able to run the API's code locally.

## Setup: </br>
1. Install MySql workbench (recommended), you will need the MySql engine.
2. Run the following command in an administrator command prompt (windows). You can change the username and password, but it *should* be fine for local dev:
```
setx SPEAKR_DB_SERVER 197.0.0.1 /M | setx SPEAKR_DB_NAME speakrdb /M | setx SPEAKR_DB_USER root /M | setx SPEAKR_DB_PASSWORD root /M
```
3. Create a database (eg. using mysql workbench) named the same way as the above code
4. Navigate to the `/src` folder of this project on the command line. You can then run the migrations (or rollback) using:
```
dotnet migrate --provider mysql --connectionString Server=127.0.0.1;Database=speakrdb;Uid=root;Pwd=root; --task rollback --migrateToVersion 1
dotnet migrate --provider mysql --connectionString Server=127.0.0.1;Database=speakrdb;Uid=root;Pwd=root;
```

And no, the production database is not called that, or uses those credentials :)

