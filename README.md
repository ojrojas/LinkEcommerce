LinkECommerce

Para ejecutar la prueba debemos tener estas dependencias instaladas en el sistema:

WINDOWS 
* Docker ó Podman
    especificar si se tiene podman en la variable de entorno del sistema
        - DOTNET_ASPIRE_CONTAINER_RUNTIME=podman

* Worload .Net Aspire
* Workload AspNet Web Development (Visual Studio 2022)
* Dotnet SDK 8.0.401
* Nodejs 20.117
    ejecutar npm install en el proyecto web link-app antes de ejectutar la aplicacion por visual studio 2022

LINUX - MAC 
* Docker ó Podman
    especificar si se tiene podman en la variable de entorno del sistema
        - DOTNET_ASPIRE_CONTAINER_RUNTIME=podman

* Worload .Net Aspire
    * run scripts:
        $ dotnet workload update 
        $ dotent workload install aspire
        $ dotnet restore LinkEcommerce.sln

* Workload AspNet Web Development (Visual Studio 2022)
* Dotnet SDK 8.0.401
* Nodejs 20.117
        ejecutar npm install en el proyecto web link-app antes de ejectutar la aplicacion por visual estudio code


todas las base de datos se crean en el inicio de la aplicación por ser entorno de desarrollo