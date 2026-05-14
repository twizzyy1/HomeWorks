using System;

class Bidder
{
    public string Name { get; set; }

    public Bidder(string name)
    {
        Name = name;
    }

    public void OnPriceChanged(string bidderName, decimal newPrice)
    {
        if (bidderName != Name)
        {
            Console.WriteLine($"{Name} получил уведомление: новая ставка {newPrice} от {bidderName}");
        }
    }
}

class AuctionLot
{
    public string LotName { get; set; }
    public decimal CurrentPrice { get; set; }

    public delegate void PriceChangedHandler(string bidderName, decimal newPrice);
    public event PriceChangedHandler PriceChanged;

    public AuctionLot(string lotName, decimal startPrice)
    {
        LotName = lotName;
        CurrentPrice = startPrice;
    }

    public void PlaceBid(Bidder bidder, decimal newPrice)
    {
        if (newPrice > CurrentPrice)
        {
            CurrentPrice = newPrice;

            Console.WriteLine($"\n{bidder.Name} сделал ставку: {newPrice}");

            PriceChanged?.Invoke(bidder.Name, newPrice);
        }
        else
        {
            Console.WriteLine($"Ставка {newPrice} должна быть выше текущей цены {CurrentPrice}");
        }
    }
}

class Program
{
    static void Main()
    {
        AuctionLot lot = new AuctionLot("Ноутбук", 1000);

        Bidder bidder1 = new Bidder("Алекс");
        Bidder bidder2 = new Bidder("Макс");
        Bidder bidder3 = new Bidder("Иван");

        lot.PriceChanged += bidder1.OnPriceChanged;
        lot.PriceChanged += bidder2.OnPriceChanged;
        lot.PriceChanged += bidder3.OnPriceChanged;

        lot.PlaceBid(bidder1, 1200);
        lot.PlaceBid(bidder2, 1500);
        lot.PlaceBid(bidder3, 1800);
    }
}