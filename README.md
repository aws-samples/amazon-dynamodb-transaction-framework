# DynamoDB Transaction Framework

Amazon DynamoDB is a key-value database store which delivers single-digit millisecond performance and infinite 
scaling capability. The ACID transaction operation is supported in the DynamoDB through its API. By using the API, 
you can enforce the ACID attributes across one or more tables within a single AWS account and region.

This repository is an application design which contains all the .NET C# modules needed to launch and run the application 
utilizing DynamoDB API. This design demonstrates a framework with re-usable pattern for the DynamoDB transaction operations. 

This framework provides a simple and intuitive interface for developers to build the DynamoDB transactions with the 
following benefits:
* Encompass the DynamoDB API with a traditional SQL pattern for the transaction operations.
* Allowing single responsibility principle for DynamoDB transaction with the code sharing and re-use.
* Simplify the transaction operations through its extension library.
* Support for nested transactions.

Following are the three main common interfaces provided by this framework:   

* `TransactScope` - a common transaction interface allows for the client to begin, commit, and rollback transactions, 
instead of dealing with the DynamoDB API directly. This transaction interface supports for nested transactions where the client can begin, commit, or rollback multiple levels of transactions.
* `TransactExtensions` - a common code to translate the DynamoDB item actions into transaction items. With this library, 
developer won't need to write duplicate code for non-transaction item actions and transaction items.
* `AttributeExtensions` - a common code to build regular item actions by translating the entity objects into DynamoDB 
AttributeValue. 

## Prerequisites

In order to get started with this application, set up the following dependencies:

* Install [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/)
* Set up [AWS Credentials](https://docs.aws.amazon.com/sdk-for-java/v1/developer-guide/setup-credentials.html) in your development environment
 

## Getting started

### Load and launch the application

* Load the Visual Studio application with solution BootCampDynamoDB.sln from the folder BootCampDynamoDB into Visual Studio Community.
* Launch the application from Visual Studio Community by running project of BootCampDynamoDB. 
 
### Create three new `Album`, `Book`, amd `Movie` DynamoDB tables
* Within the newly launched screen, click `Create Product Tables` button to create the three DynamoDB tables

### Start a new transaction
* Click the button "Begin Transaction".

### Add Album, Book, or Movie attributes
* Dropdown `Product Type` and select `Album`, `Book`, or `Movie` product type. 
* Enter corresponding product attributes according to the `Product Type`.

### Add Album, Book, or Movie items
* Click `Add Item` button to add the item to transaction scope.

### Commit transaction
* Click `Commit Transaction` button to add the item to Book table.

### Rollback transaction
* Click `Rollback Transaction` button to rollback the transaction.

### Create a Book Item
* Dropdown `Product Type` and select `Book` product type. 
* Enter book author, e.g. "Homer", in the `Book Author` text box.
* Enter or select book publish date in the `Book Publish Date` calendar box.
* Enter book title, e.g. "odyssey" in the `Title` text box.
* Click `Add Item` button to add the item of book to the transaction scope.

### Retrieve the Book Item
* Dropdown `Product Type` and select `Book` product type. 
* Enter Book Author and Title.
* Click `Retrieve Item` button to retrieve book from newly created DynamoDB Book table.

### Delete the Book Item
* Dropdown `Product Type` and select `Book` product type. 
* Enter Book Author and Title.
* Click `Remove Item` button to delete book from newly created DynamoDB Book table.

## Security

See [CONTRIBUTING](CONTRIBUTING.md#security-issue-notifications) for more information.

## License

This library is licensed under the MIT-0 License. See the LICENSE file.
