function storeViewModel() {

    var self = {};

    self.city = ko.observable();
    self.citySearch = ko.observable();
    self.citySearch.subscribe(function () {
        filterStores();
    });
    self.id = ko.observable();
    self.idSearch = ko.observable();
    self.idSearch.subscribe(function () {
        filterStores();
    });
    self.name = ko.observable();
    self.nameSearch = ko.observable();
    self.nameSearch.subscribe(function () {
        filterStores();
    });
    self.number = ko.observable();
    self.numberSearch = ko.observable();
    self.numberSearch.subscribe(function () {
        filterStores();
    });
    self.districtCombo = null;
    self.retailerIdCombo = null;
    self.retailerNameSearch = ko.observable();
    self.retailerNameSearch.subscribe(function () {
        filterStores();
    });
    self.showDetail = ko.observable();
    self.state = ko.observable();
    self.stateSearch = ko.observable();
    self.stateSearch.subscribe(function () {
        filterStores();
    });
    self.storeGridData = null;
    self.territoryCombo = null;

    var filterStores = function () {
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
                self.districtCombo.value(null);
                self.territoryCombo.value(null);
            },
            type: 'DELETE',
            url: 'api/StoreApi?id=' + id
        });
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
                if (self.districtCombo) {
                    self.districtCombo.value(result.DistrictId);
                }
                if (self.retailerIdCombo) {
                    self.retailerIdCombo.value(result.RetailerId);
                }
                if (self.territoryCombo) {
                    self.territoryCombo.value(result.TerritoryId);
                }
            },
            type: 'GET',
            url: 'api/StoreApi'
        });
    };

    self.onStoreSuccess = function () {
        $('#storeGrid').data('kendoGrid').dataSource.read();
    };

    self.setObservables = function() {
        
        
    };

    return self;
}