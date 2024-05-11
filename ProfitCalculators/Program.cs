using ProfitCalculators.Items;

DefaultItem Head = new Head("RoyalCowl", 5);

foreach (CraftRecipe craft in Head.CraftRecipes)
{
    foreach(KeyValuePair<DefaultItem, int> i in craft.GetCraft())
    {
        Console.WriteLine($"{i.Key.Name} {i.Value}");
    }
    Console.WriteLine();
}