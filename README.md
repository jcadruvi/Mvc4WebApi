Mvc4WebApi
==========

This is a project that I used to learn more about Web API. This project intially shows a list of stores. The user can filter the stores by entering values in the search fields on the header of the grid. The filter is triggered by the field losing focus or pressing enter. If the user clicks on row on the grid the detail section will be displayed. The detail section will allow the user to save or delete the store. All saves or deletes are  made to a singleton repository and they will only persist while the user is on the page.

This project uses MVC for the view and Web API for the ajax calls. The view contains the initial grid and the detail html. The detail is hidden initialy and knockout is used to show the detail section when a grid row is selected. 


Talk about the following web api things:

How to call an action or a parameter.
ninject
Model binding
Data annotations.
	Do the model state example for the post.


Need to finish the filter of store search.
 

 
 Calls:
	Select stores
	Select store
	Select dropdown
	save store
	delete store
	