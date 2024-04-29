using ProfitCalculators.Items;

Equipment Tome = new OffHand("TomeOfSpells", 5);

Console.WriteLine(Tome.craftInstruction.GetCraft()[1].Key.name);