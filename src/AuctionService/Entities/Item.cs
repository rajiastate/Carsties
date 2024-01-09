using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities;

[Table("Items")] // needed here because ef won't pluralize the name by default it would use class name as table name
public class Item
{
    public Guid Id { get; set; }
    public string Make {get;set;}
    public string Model {get;set;}
    public int? Year { get; set; }
    public string  Color { get; set; }
    public int? Mileage { get; set; }
    public string  ImageUrl { get; set; }

    public Auction Auction {get;set;}
    public Guid AuctionId {get;set;}
}
