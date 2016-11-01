How to build the web service?

Pre-Conditions:
*	You have a developer machine with Visual Studio 2013 installed.
*	SQL Express is installed 
*	SQL server is configured to use Windows Authentication mode

Building:
*	Open the ‘QUT.sln’ solution in Visual Studio 2013
*	Rebuild the solution
	(This will get all the missing NuGet packages)
*	Open the ‘Package Manager Console’ 
	(Menu: VIEW  Other Windows  Package Manager Console)
*	Change ‘Default Project’ to ‘MicroServices.DataAccess’
*	Execute ‘Update-Database’ in the console
	(This will create the database.)
*	Run all the unit and integration

Runing the service:
*	Hit F5 to run the web service
	(The web service project name ‘SelfHosting’.)
*		Open a web browser or Postman and type in the following URls:  
		http://localhost:63579/person/  returns a list of persons
		http://localhost:63579/person/1   returns the person with the given id (here 1)


Get 	| http://localhost:63579/person/	| returns a list of persons
Get 	| http://localhost:63579/person/1	| returns the person with the given id (here 1)
Post	| http://localhost:63579/person/ 	| Creates a new person in the database with default values and returns that person
Put		| http://localhost:63579/person/ 	| Creates a new person in the database with default values and returns that person

Post	| http://localhost:63579/person/ 	| Creates a new person in the database with the given values
With the body containg json:
{
    "FirstName": "Peter",
    "Surname": "Smith",
    "DateOfBirth": "30/06/2010",
    "Sex": "m",
    "Email": "p.smith@gmail.com"
}

Post	| http://localhost:63579/person/ 	| Updates the person in the database with the given values
With the body containg json:
{
    "Id": 1,
    "FirstName": "Peter",
    "Surname": "Smith",
    "DateOfBirth": "30/06/2010",
    "Sex": "m",
    "Email": "p.smith@gmail.com"
}

Attention: Post and Put are doing a create or update. 


