(function () {
    "use strict";

    WinJS.UI.Pages.define("/pages/home/home.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            var dataTransferManager = Windows.ApplicationModel.DataTransfer.DataTransferManager.getForCurrentView();
            dataTransferManager.addEventListener("datarequested", dataRequested);
        },
        
        unload: function () { 
            var dataTransferManager = Windows.ApplicationModel.DataTransfer.DataTransferManager.getForCurrentView(); 
            dataTransferManager.removeEventListener("datarequested", dataRequested); 
        } 
    });
    
    function dataRequested(e) {
        var request = e.request;

        var geo = Transhipment.SchemaFactory.create(Transhipment.Schema.geoCoordinates);
        geo.name = "Polar Bear Provincial Park";
        geo.latitude = "54.596931";
        geo.longitude = "-83.283978";

        request.data.properties.title = "Sample data";
        request.data.properties.description = "data for " + geo.type;
        
        Transhipment.SchemaFactory.setStructuredData(request.data, geo);
    }
})();
