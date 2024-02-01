Autor Fidel Mateos
programa en .net c#, windows form
Programa para importar datos de excell a sql server, se pasa por parametro el nombre de la tabla; una vez a arriba la información, tiene opcional ejecutar un stored procedure, para correr algun proceso adicional

Configurar en el Config


    <add key="UserWin" value="" />
    
    <!-- Tabla donde se deposita los datos-->
    <add key="TablaTEMP" value="Tabla_SQL" />
    
    <!-- Nombre del Stored Procedure que se ejecuta despues de importar la tabla, NOTA: Dejar en blanco si no desea ejecutar SP-->
    <add key="NombreSP" value="SP_Correr_AfterUpload" /> <!---->
	  <!--<add key="NombreSP" value="" />-->
        
    <!-- Parametro 1 que se pasa al Stored Procedure para identificar la carga, NOTA: Dejar en blanco si no se desea usar el parametro-->
    <add key="Parametro1_SP" value="@FileName" />
    <!-- Parametro 2 que se pasa al Stored Procedure para identificar Quien realiza la carga, NOTA: Dejar en blanco si no se desea usar el parametro-->
    <add key="Parametro2_SP" value="" />
