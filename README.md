# InventoryAPI

This is an API that allows the user to track items within an inventory. The current information that is tracked is the item name, quantity, and type. Each item is assigned a unique id. All the data is returned as a JSON in the standard API format.

## FEATURES:
* Make your application an API
* Make your application a CRUD API
* Add comments to your code explaining how you are using at least 2 of the solid principles

NOTE:
Make sure you have .NET 6.0 installed

# INSTALLATION:
* Click the green "Code" button and select Download ZIP.
* Extract the zip file contents to the desired folder.
* In your desired Terminal program, open the folder in which the zip file was extracted.
* Navigate to the InventoryAPI folder (\InventoryAPI-master\InventoryAPI-master\InventoryAPI)
* Type "dotnet build" and press enter
* Type "dotnet run" and press enter
* You should receive a message that states:  
      info: Microsoft.Hosting.Lifetime[14]  
      Now listening on: https://localhost:7066
  
* Take note of the first address (note: your local address may vary due to your specific system setup) and add "/Swagger/" to the end and press enter (e.g. https://localhost:7066/Swagger/)

On the Swagger page, you can view all the records in the inventory by selecting "Get", add items by selecting "Post", update an item by selecting "Put", and delete an item by selecting "Delete". 

While Swagger is the method used in this example, you may also use other API programs, such as Postman, to execute these requests as well.

# USE:

## CREATE record:

In Swagger - 
 * Click "Post" then "Try it out".
 * Update the following fields to add a record to the database:

{  
  "itemName": "NAME",  
  "itemQuantity": 0,  
  "itemType": "TYPE"  
}  

For Example:  
{  
  "itemName": "EXAMPLE ITEM",  
  "itemQuantity": 5,  
  "itemType": "EXAMPLE ITEM TYPE"  
}  

 * Click "Execute" to create the item

## READ ALL records:
In browser - 
 * Navigate to your local address /api/Inventory (e.g. https://localhost:7066/api/Inventory/) to pull a Get request of all records returned in JSON format.

In Swagger - 
 * Click the first "Get" then "Try it out" and then "Execute".
 * The information in the database will be returned in the "Response body" box under the Get request

## READ ONE record:
In browser - 
 * Navigate to your local address /api/Inventory/ID (e.g. https://localhost:7066/api/Inventory/ID) to pull a Get request of the selected record with that ID returned in JSON format. If no ID is found, the system will return a 404 - "Not Found" message.

In Swagger - 
 * Click the second "Get" button (/api/Inventory/{id}) then "Try it out", enter the desired ID in the ID field, and then click "Execute".
 * The information in the database will be returned in the "Response body" box under the Get request
 * If no ID is found, the system will return a 404 - "Not Found" message.


## UPDATE record
In Swagger - 
 * Click "Put" then "Try it out".
 * In the ID field, enter the ID of the item you would like to update.
 * Update the following fields with the information of the record in the database you would like to update:  

{  
  "id": 0,  
  "itemName": "string",  
  "itemQuantity": 0,  
  "itemType": "string"  
}  

For Example:  
{  
  "id": 1,  
  "itemName": "EXAMPLE ITEM UPDATED",  
  "itemQuantity": 4,  
  "itemType": "EXAMPLE ITEM TYPE"  
}  

 * Click "Execute" to update the item

NOTE: Be sure the ID in the ID field matches the ID provided in the update data. If the IDs don't match or are not in the database, a 404 - "Not Found" message will be returned.

## DELETE record
In Swagger - 
 * Click "Delete" then "Try it out".
 * In the ID field, enter the ID of the item you would like to delete.
 * Click "Execute" to delete the item
