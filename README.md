# Challenge Técnico Nubimetrics

## Puesta en marcha

Para hacer la puesta en marcha debe dev:

1. Clonar el repositorio
2. Abra el projecto con visual studio comunity dirijase a view luego a SQL Server Object Explorer 
3. Expanda la solapa que dice localdb, luego la que dice Databases de segundo clic y cree un base de datos con el nombre EvaluacionEj1Context
4. Luego de segundo clic sobre la solapa table y seleccione new query pegue el contenido del archivo dbo.Users.sql y click en Execute o (Ctrl + Shift + E)
5. borre el contenido y luego copie el contenido del archivo populate.sql y de nuevo click en Execute o (Ctrl + Shift + E)
6. luego ejecutelo con IIS Express

## Parte de la evaluación

1. Crear una aplicación (usando framework .Net 4.7 o .Net Core 2.2 en adelante) del tipo REST Web Api que exponga 2 endpoints

-   Se creo una api REST en asp.net core 3.1 con una Clean Arqitecture ya que sus beneficios son los siguiente: 
    -  Independiente de Frameworks: La arquitectura no depende de la existencia de alguna biblioteca de software cargado de funciones. Esto le permite utilizar estos marcos como herramientas, en lugar de tener que abarrotar su sistema con sus limitaciones limitadas.
Comprobable. Las reglas de negocio se pueden probar sin la interfaz de usuario, la base de datos, el servidor web o cualquier otro elemento externo.
    -  Independiente de la interfaz de usuario: La interfaz de usuario puede cambiar fácilmente, sin cambiar el resto del sistema. Una interfaz de usuario web podría reemplazarse por una interfaz de usuario de consola, por ejemplo, sin cambiar las reglas comerciales.
    -  Independiente de la base de datos: Puede cambiar Oracle o SQL Server, por Mongo, BigTable, CouchDB u otra cosa. Sus reglas comerciales no están vinculadas a la base de datos.
    -  Independiente de cualquier agencia externa: De hecho, las reglas de su negocio simplemente no saben nada sobre el mundo exterior.

# API

## Paises

-   Path: domain/api/Paises/AR
-   Acciones Permitidas: GET
-   Formato de respuest: JSON

Utilizado para devolver lo que se encuentra [aqui](https://api.mercadolibre.com/classified_locations/countries/AR)


### Formato de json devuelto:

    {
      "id": "AR",
      "name": "Argentina",
      "locale": "es_AR",
      "currency_id": "ARS",
      "decimal_separator": ",",
      "thousands_separator": ".",
      "time_zone": "GMT-03:00",
      "geo_information": {
          "location": {
              "latitude": -38.416096,
              "longitude": -63.616673
          }
      },
      "states": [
          {
              "id": "TUxBUEJSQWwyMzA1",
              "name": "Brasil"
          }, ...
     }

####  Si se le pasa BR o CO en vez de AR debuelve:

    {
        "type": "https://tools.ietf.org/html/rfc7235#section-3.1",
        "title": "Unauthorized",
        "status": 401,
        "traceId": "|5093324a-4d65848d2a0facc3.",
    }

## Busqueda

-   Path: domain/api/Busqueda/{'producto'}
-   Acciones Permitidas: GET
-   Formato de respuest: JSON

Utilizado para devolver de forma reducida lo que se encuentra en `https://api.mercadolibre.com/sites/MLA/search?q={producto}` donde el producto puede ir cambiando para buscar diferentes productos


### Formato de json devuelto:

    {
      "site_id": "MLA",
      "country_default_time_zone": "GMT-03:00",
      "query": "iphone",
      "paging": {
          "total": 20091,
          "primary_results": 1000,
          "offset": 0,
          "limit": 50
      },
      "results": [
          {
              "id": "MLA913236423",
              "site_id": "MLA",
              "title": "Apple iPhone 11 (128 Gb) - Negro",
              "seller": {
                  "id": 86356879
              },
              "price": 214999,
              "permalink": "https://www.mercadolibre.com.ar/apple-iphone-11-128-gb-negro/p/MLA15149567"
          }, ...
     }

## Lista de Usuarios

-   Modelo : User
-   Path: domain/api/usuarios/
-   Acciones Permitidas: GET
-   Formato de respuest: JSON

Debuelve una lista con todos los usuarios y sus respectivos datos

### Formato de json devuelto:

    [
      {
          "id": 0,
          "nombre": "Jimena",
          "apellido": "Ochoa",
          "email": "JimenaOchoa@gmail.com",
          "password": "2y12ZMIHnn4jEJbtzel3b9T4eIKvViXOt115BQ1hV7CXhtcbr"
      },
      {
          "id": 1,
          "nombre": "Marisol",
          "apellido": "Echeverria",
          "email": "MarisolEcheverria@gmail.com",
          "password": "2y12ZMIHnn4jEJbtzel3b9T4eIKvViXOt115BQ1hV7CXhtcbr"
      },...
    ]
    
## Obtener Usuario

-   Modelo : User
-   Path: domain/api/usuarios/{id}
-   Acciones Permitidas: GET
-   Formato de respuest: JSON

Debuelve un unico usuario y sus respectivos datos

### Formato de json devuelto:

    {
      "id": 8,
      "nombre": "Zahra",
      "apellido": "Font",
      "email": "ZahraFont@gmail.com",
      "password": "2y12ZMIHnn4jEJbtzel3b9T4eIKvViXOt115BQ1hV7CXhtcbr"
    }

## Crear Usuario

-   Modelo : User
-   Path: domain/api/usuarios/{id}
-   Acciones Permitidas: POST
-   Formato de respuest: JSON

Se le pasa un objeto json en row y crea un usuario !! ADVERTENCIA: no le hace hashing a la password pasada !!

### Formato de json enviado:

    {
        "nombre": "Jimena",
        "apellido": "Ochoa",
        "email": "JimenaOchoa@gmail.com",
        "password": "2y12ZMIHnn4jEJbtzel3b9T4eIKvViXOt115BQ1hV7CXhtcbr"
    }

### Formato de json devuelto:

    {
        "id": 38,
        "nombre": "Jimena",
        "apellido": "Ochoa",
        "email": "JimenaOchoa@gmail.com",
        "password": "2y12ZMIHnn4jEJbtzel3b9T4eIKvViXOt115BQ1hV7CXhtcbr"
    }

## Actualizar Usuario

-   Modelo : User
-   Path: domain/api/usuarios/{id}
-   Acciones Permitidas: PUT
-   Formato de respuest: JSON

Se le pasa un objeto json en row y el id del usuario para actualizar un usuario !! ADVERTENCIA: no le hace hashing a la password pasada !!

### Formato de json enviado:

    {
        "id": 38,
        "nombre": "Jimena",
        "apellido": "Haro",
        "email": "JimenaOchoa@gmail.com",
        "password": "2y12ZMIHnn4jEJbtzel3b9T4eIKvViXOt115BQ1hV7CXhtcbr"
    }

### Formato de json devuelto:

    true
    
## Eliminar Usuario

-   Modelo : User
-   Path: domain/api/usuarios/{id}
-   Acciones Permitidas: DELETE
-   Formato de respuest: JSON

Se le pasa ide del usuario para eliminar un usuario 

### Formato de json devuelto:

    true
