public record Customer(Address address) {
    public string FirstName {get;set;} = default!;
    public string LastName {get;set;} = default!;
    public string Patronymic {get;set;} = default!;
    public string Gender {get;set;} = default!;
    public string PhoneNumber {get;set;} = default!;
    public Address Address {get;set;} = default!;
}