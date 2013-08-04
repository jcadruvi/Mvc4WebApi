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

Now that we know how the client AJAX calls change with Web API lets look at how the server side code differs. The first difference is that the StoreApiController inherits from ApiController. This lets ASP.NET know that the controller is a Web API controller. The second difference is in the action method. The following is the GetRetailers action method:

	public IEnumerable<KeyValuePair<string, string>> GetRetailers()
	{
		ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();
		response.Add(new KeyValuePair<string, string>("1", "Best Buy"));
		response.Add(new KeyValuePair<string, string>("2", "Frys"));
		response.Add(new KeyValuePair<string, string>("3", "Wal Mart"));
		response.Add(new KeyValuePair<string, string>("4", "Target"));
		response.Add(new KeyValuePair<string, string>("5", "Safeway"));
		response.Add(new KeyValuePair<string, string>("6", "Knob Hill"));
		response.Add(new KeyValuePair<string, string>("7", "Luckys"));
		return response;
	}

The main difference is in MVC the method would return JsonResult which would always return JSON. In Web API the data is returned and Web API uses the Request's Accept Header value to determine the format of the data returned to the client. This process is called content negotiation.

[Need to have a link sentance.]
When the user selects a row in the store grid an AJAX call is made to get the store. The following is the AJAX statement:

	var postData = {};
    postData.Id = getSelectedStoreId();

    $.ajax({
        data: postData,
        dataType: 'json',
        success: function(result) {
		
        },
        type: 'GET',
        url: 'api/StoreApi'
    });
	
The AJAX url only has the controller. Web API will use the HTTP verb "GET" and the data being sent to determine which action method to call. In the StoreApi controller there is one HttpGet method that has a parameter of id called GetStore. The follow is the GetStore method:

public Store GetStore(int id)
{
    return (from s in _storeService.GetStores()
            where s.Id == id
            select s).First();
}

With the Web API configuration I have sent up I can either use parameters or the action to determine which Web API method should be called. If Web API can not figure out which action should be called an error is thrown. In this case all that you need to do is use the correct action.


Figure out how I add in the ninject issue.

Talk about the following web api things:
Add in if the model state is not valid.
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
	