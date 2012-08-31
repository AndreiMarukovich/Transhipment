Transhipment
============

WinRT library for structured data sharing (via Share Contract) using Schema.org data formats.

## How To Install

### NuGet
    PM> Install-Package Transhipment


## Usage

### Share data - JavaScript ###

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

### Share data - C# ###

    void DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
    {
        var request = args.Request;

        var geo = SchemaFactory.Create(Schema.GeoCoordinates) as IGeoCoordinates;
        geo.Name = "Polar Bear Provincial Park";
        geo.Latitude = "54.596931";
        geo.Longitude = "-83.283978";

        request.Data.Properties.Title = "Sample data";
        request.Data.Properties.Description = "data for " + geo.Type;
        request.Data.SetStructuredData(geo);
    }

### Retrive shared data (share target) - C# ###

    public async void Activate(ShareTargetActivatedEventArgs args)
    {
        shareOperation = args.ShareOperation;
        var geo = await shareOperation.Data.GetStructuredDataAsync(Schema.GeoCoordinates) as IGeoCoordinates;
        if (geo != null)
        {
            DefaultViewModel["ThingName"] = geo.Name;
            DefaultViewModel["Latitude"] = geo.Latitude;
            DefaultViewModel["Longitude"] = geo.Longitude;
        }

        // ...
    }
