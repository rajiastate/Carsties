using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions options) : base(options)
    {
    }

// DbSet uses entities to create table 
// name of property is the name of the table.
// we don't need to define items here because items is contained in Auction entity 
    public DbSet<Auction> Auctions{get;set;}
}