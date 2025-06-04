# ApiSOL-TGR1
Api de interoperabilidad para permitir a SOL incorporar el TGR en sus trámites

# Insumos
- Plataform SOL con acceso a funcionario y ciudadano
- Base de Datos SQL Server
- Guía de creación de API en SOL
- Acceso a la API de pruebas de Tesorería General de la República TGR-1

   https://test.sol.sde.gob.hn/sefin/tgr/scalar
  
   https://test.sol.sde.gob.hn/sefin/tgr/swagger

# Procedimiento
1. Verifique el funcionamiento de la API de pruebas para gestioanr TGR-1, se deben identificar los endpoints para obtener los tipos de identificación, listado de instituciones, rubros por institucion y artículos por rubro.
2. Genere en su editor de código de preferencia un nuevo proyecto para construir una API, para este ejemplo se usará Visucl Studio Code y un proyecto API en .NET 9.0.x
3. Revise la documentación de la aplicación de SOL para identificar cuál es el código que se debe usar para hacer un llamado a la API.
4. Escriba el código siguiendo las pautas y recomendaciónes y asegurandose de configurar todos los parámetros requeridos para consultar recibos TGR existentes o crear nuevos recibos TGR
5. Realice las pruebas
6. Publique la API recién creada (o ejecutela de manera local)
7. Verifique el funcionamiento.

# Software necesario
- .NET 9.0.x SDK
- Visual Studio Code
- Postman (en caso no quiera instalar swagger o scala en la API)
