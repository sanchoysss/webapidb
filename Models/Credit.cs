public record Credit {

    public int Id {get;set;} = default!;
    public Customer Customer {get;set;} = default!;
    public string amountOfCredit {get;set;} = default!;

    public int percentPerYear {get;set;} = default!;

    public string startDate {get;set;} = default!;

    public string endDate {get;set;} = default!;

    public string moneyPayed {get;set;} = default!; 
}