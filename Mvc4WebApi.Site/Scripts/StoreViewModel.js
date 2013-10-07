function storeViewModel() {

    var self = {};

    self.$searchTerritoryData = null;

    self.city = ko.observable();
    self.citySearch = ko.observable();
    self.citySearch.subscribe(function () {
        self.filterStores();
    });
    self.districtData = ko.observableArray();
    $.ajax({
        url: "api/DistrictApi/Districts",
        success: function (result) {
            self.districtData(result);
        },
        type: "GET"
    });
    self.district = ko.observable();
    self.districtOptions = {
        change: function () {
            readTerritoryData();
        }
    };
    self.districtSearchWidget = ko.observable();
    self.id = ko.observable();
    self.idSearch = ko.observable();
    self.idSearch.subscribe(function () {
        self.filterStores();
    });
    self.latitude = ko.observable();
    self.longitude = ko.observable();
    self.name = ko.observable();
    self.nameSearch = ko.observable();
    self.nameSearch.subscribe(function () {
        self.filterStores();
    });
    self.number = ko.observable();
    self.numberSearch = ko.observable();
    self.numberSearch.subscribe(function () {
        self.filterStores();
    });
    self.retailerIdCombo = null;
    self.retailerNameSearch = ko.observable();
    self.retailerNameSearch.subscribe(function () {
        self.filterStores();
    });
    self.sales = ko.observable();
    self.showDetail = ko.observable();
    self.state = ko.observable();
    self.stateSearch = ko.observable();
    self.stateSearch.subscribe(function () {
        self.filterStores();
    });
    self.storeGridData = null;
    self.territory = ko.observable();
    self.territoryData = ko.observableArray();
    self.territoryOptions = {
        autoBind: false,
        cascadeFrom: "districtId",
    };
    self.territorySearch = ko.observable();
    self.territorySearchData = ko.observableArray();

    self.filterStores = function () {
        var filter = new Array();
        var i = 0;
        if (self.retailerNameSearch() && self.retailerNameSearch().length > 0) {
            filter[i] = { field: "RetailerName", operator: "startswith", value: self.retailerNameSearch() };
            i++;
        }
        if (self.citySearch() && self.citySearch().length > 0) {
            filter[i] = { field: "City", operator: "startswith", value: self.citySearch() };
            i++;
        }
        if (self.districtSearchWidget() && self.districtSearchWidget().value().length > 0) {
            filter[i] = { field: "DistrictId", operator: "eq", value: self.districtSearchWidget().value() };
            i++;
        }
        if (self.idSearch() && self.idSearch().length > 0) {
            filter[i] = { field: "id", operator: "eq", value: self.idSearch() };
            i++;
        }
        if (self.nameSearch() && self.nameSearch().length > 0) {
            filter[i] = { field: "Name", operator: "startswith", value: self.nameSearch() };
            i++;
        }
        if (self.numberSearch() && self.numberSearch().length > 0) {
            filter[i] = { field: "Number", operator: "startswith", value: self.numberSearch() };
            i++;
        }
        if (self.stateSearch() && self.stateSearch().length > 0) {
            filter[i] = { field: "State", operator: "startswith", value: self.stateSearch() };
            i++;
        }
        if (self.$searchTerritoryData.value() && self.$searchTerritoryData.value().length > 0) {
            filter[i] = { field: "TerritoryId", operator: "eq", value: self.$searchTerritoryData.value() };
            i++;
        }
        self.storeGridData.dataSource.filter(filter);
    };

    var getSelectedStoreId = function () {
        var dataItem;
        if (!self.storeGridData) {
            return null;
        }
        dataItem = self.storeGridData.dataItem(self.storeGridData.select());
        if (!dataItem) {
            return null;
        }
        return dataItem.Id;
    };

    var readTerritoryData = function () {
        if (!self.district()) {
            return;
        }
        var postData = {};
        postData.DistrictId = self.district();
        $.ajax({
            data: postData,
            dataType: 'json',
            url: "api/TerritoryApi/Territories",
            success: function (result) {
                self.territoryData(result);
            },
            type: "GET"
        });
    };

    self.onDeleteClick = function() {
        var id;
        
        id = getSelectedStoreId();
        
        $.ajax({
            success: function (result) {
                self.storeGridData.dataSource.read();
                self.city(null);
                self.retailerIdCombo.value(null);
                self.id("");
                self.name("");
                self.number("");
                self.state("");
                self.district(null);
                self.territoryCombo.value(null);
            },
            type: 'DELETE',
            url: 'api/StoreApi?id=' + id
        });
    };

    self.onDistrictSearchChange = function () {
        self.filterStores();
    };

    self.onStoreGridChanged = function() {
        var postData = {};

        self.showDetail(true);
        postData.Id = getSelectedStoreId();

        $.ajax({
            data: postData,
            dataType: 'json',
            success: function(result) {
                self.city(result.City);
                self.id(result.Id);
                self.name(result.Name);
                self.number(result.Number);
                self.state(result.State);
                self.district(result.DistrictId);
                if (self.retailerIdCombo) {
                    self.retailerIdCombo.value(result.RetailerId);
                }
                if (self.territoryCombo) {
                    self.territoryCombo.value(result.TerritoryId);
                }
                self.sales(result.Sales);
                self.latitude(result.Latitude);
                self.longitude(result.Longitude);
            },
            type: 'GET',
            url: 'api/StoreApi/'
        });
    };

    self.onStoreSuccess = function () {
        $('#storeGrid').data('kendoGrid').dataSource.read();
    };

    return self;
}