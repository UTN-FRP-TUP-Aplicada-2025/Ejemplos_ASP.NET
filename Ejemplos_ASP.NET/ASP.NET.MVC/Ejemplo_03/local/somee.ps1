$Server = "Ejemplo01CRUDSimpleDB.mssql.somee.com"
$Database = "Ejemplo01CRUDSimpleDB"
$User = "fernando-dev_SQLLogin_1"
$Password = "bfzixu5w6p"
$ScriptPath = "../MSSQL/somee_script.sql"

Invoke-Sqlcmd -ServerInstance $Server -Database $Database -Username $User -Password $Password -InputFile $ScriptPath