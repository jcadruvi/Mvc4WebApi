Mvc4WebApi
==========

This is a project that I used to learn more about Web API. This project intially shows a list of stores. The user can filter the stores by entering values in the search fields on the header of the grid. The filter is triggered by the field losing focus or pressing enter. If the user clicks on row on the grid the detail section will be displayed. The detail section will allow the user to save or delete the store. All saves or deletes are  made to a singleton repository and they will only persist while the user is on the page.

This project uses MVC for the view and Web API for the ajax calls. The view contains the initial grid and the detail html. The detail is hidden initialy and knockout is used to show the detail section when a grid row is selected. When the Store page is first loaded I make the following AJAX calls to get the data for the page:
	1) GetStores which retieves the stores.
	2) GetRetailers which retrieves the retailer for the retailer dropdowns.
	3) GetDistricts which retrieves the districts for the districts dropdowns.
	
AJAX calls to a Web API controller differ in the URL. The following is an example of an AJAX call:

$.ajax({
    url: "api/StoreApi/GetRetailers",
    success: function (result) {
    },
    type: "GET"
});

The first part of the url "api" is used for routing to know it is an Web API call. The second part "StoreApi" is the name of the controller and the third part "GetRetailers" is the name of the action. When a Web API project is created using Visual Studio the following route configuration is used:

config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
);

Notice the first part of the route template is "'api" which matches the first part of AJAX url. Having "api" as the first part of a route will let the web site know it should call a Api Controller. This default route configuration uses the controller, method and parameters to determine which action should be called. My StoreApi controller has several actions that don't have any parameters so I needed to add another configuration that would use the controller, method and action to determine which action should be called. The following is the action configuration:

config.Routes.MapHttpRoute(
    name: "ActionApi",
    routeTemplate: "api/{controller}/{action}/{id}",
    defaults: new { id = RouteParameter.Optional }
);

Notice that "{action}" is between "controller" and "{id}". The WebApiConfig file has all of the Web API route configuration code.

Now that we know how the client AJAX call changes with Web API lets look at how the controller action code differs. The following is the GetRetailers action code:




Take the store empty parameters and show how it would change with web api.
Need to make the retailer name a dropdown.
Talk about the following web api things:

How to call an action or a parameter.
derive from api controller 
ninject
Model binding
Data annotations.
	Do the model state example for the post.


Need to finish the filter of store search.
Fix that territory is not displayed correctly.

 
 Calls:
	Select stores
	Select store
	Select dropdown
	save store
	delete store
	