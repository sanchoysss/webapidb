public record Address() {

    public string AddressId {get;set;} = default!;
    public string Country {get;set;} = default!;
    public string City {get;set;} = default!;
    public string Street {get;set;} = default!;
    public string Home {get;set;} = default!;
    public string Floor {get;set;} = default!;
}