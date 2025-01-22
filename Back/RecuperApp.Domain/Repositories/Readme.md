
### Read me

This project uses Entityframework core, code first approach, so whenever you need to change the database update/create/delete the corresponding entity (located in the folder Models/EntityModels), 
after all the changes to the enty models have been made

run the following command to generate migrations: `Add-Migration [MigrationName] -o Repositories/Migrations`

After the migration has been generated, run the following command to apply the migration to the database: `Update-Database`

Example: 
`Add-Migration InitialDB -OutputDir Repositories/Migrations` -> `Update-Database`

If there are conflicts on migrations when merging others code. followe this guid to resolve them properly.
[Resolve conflicts on migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/teams)