using ExploreThrill.Entities.Models.Concrete;

public class ActivityViewModel
{
    public int Id { get; set; }
    public string ActivityName { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public decimal Price { get; set; }
    public DateTime ActivityDate { get; set; }

    public int SelectedCategory { get; set; }
    public int SelectedCompany { get; set; }
    public ICollection<int> SelectedCities { get; set; }

    public List<Category>? Categories { get; set; }
    public List<Company>? Companies { get; set; }
    public List<City>? Cities { get; set; }
}
