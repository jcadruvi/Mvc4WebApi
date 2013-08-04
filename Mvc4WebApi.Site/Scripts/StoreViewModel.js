function StoreViewModel() {

    var self = this;

    self.city = null;
    self.id = null;
    self.name = null;
    self.number = null;
    self.districtCombo = null;
    self.retailerIdCombo = null;
    self.showDetail = null;
    self.state = null;
    self.storeGridData = null;
    self.territoryCombo = null;

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
        self.city = ko.observable();
        self.id = ko.observable();
        self.name = ko.observable();
        self.number = ko.observable();
        self.showDetail = ko.observable();
        self.state = ko.observable();
        ko.applyBindings(self);
    };
}