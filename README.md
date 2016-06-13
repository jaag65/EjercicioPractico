Ejercicio Práctico.
===================

+ El nombre del parámetro “message” es ambiguo ya que es de tipo string y bool.
+ Las variables “t” y “l” es posible que no obtengan ningún valor lo que puede ocasionar errores, se recomienda que sean inicializadas.
+ El parámetro “message” se le aplica “Trim()” para eliminar los espacios en blanco pero no es almacenado en ninguna variable.
+ El campo “LogToDatabase” no cumple con las normas de buenas prácticas su nombre debe ser cambiado a “_logToDatabase”.
+ El campo “_initialized” nunca es utilizado.
+ Es una buena práctica de seguridad usar un ORM como Entity Framework para la comunicación con la base de datos.
+ El nombre del archivo en el cual se almacenará el log posee caracteres no validos ya que contiene “\” en la fecha, se recomienda cambiar “.ToShortDateString()” por “.ToString(‘ddMMyyyy’)”.
+ El condicional que evalua si el archivo del log existe se ecuentra invertido generando un error que evita que el archivo sea creado, se recomienda eliminar el signo “!” para corregir el problema.

