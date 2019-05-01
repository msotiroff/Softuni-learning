using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CommandInterpreter
{
    private List<Center> allCenters;
    private List<Animal> allAnimals;
    private List<string> adoptedAnimals;

    public CommandInterpreter()
    {
        this.allCenters = new List<Center>();
        this.allAnimals = new List<Animal>();
        this.adoptedAnimals = new List<string>();
    }

    public void RegisterCleansingCenter(string[] commandParams)
    {
        var centerName = commandParams[0];

        Center center = new CleansingCenter(centerName);

        this.allCenters.Add(center);
    }

    public void RegisterAdoptionCenter(string[] commandParams)
    {
        var centerName = commandParams[0];

        Center center = new AdoptionCenter(centerName);

        this.allCenters.Add(center);
    }

    public void RegisterDog(string[] commandParams)
    {
        var name = commandParams[0];
        var age = int.Parse(commandParams[1]);
        var learnedCommands = int.Parse(commandParams[2]);
        var adoptionCenterName = commandParams[3];

        Animal dog = new Dog(name, age, learnedCommands);

        var adoptionCenter = this.allCenters.First(c => c.Name == adoptionCenterName);

        adoptionCenter.StoredAnimals.Add(dog);
    }

    public void RegisterCat(string[] commandParams)
    {
        var name = commandParams[0];
        var age = int.Parse(commandParams[1]);
        var intelligenceCoefficient = int.Parse(commandParams[2]);
        var adoptionCenterName = commandParams[3];

        Animal cat = new Cat(name, age, intelligenceCoefficient);

        var adoptionCenter = this.allCenters.First(c => c.Name == adoptionCenterName);

        adoptionCenter.StoredAnimals.Add(cat);
    }

    public void SendForCleansing(string[] commandParams)
    {
        var adoptionCenter = this
            .allCenters
            .First(c => c.Name == commandParams[0] 
                && c.GetType().Name == nameof(AdoptionCenter));

        var cleansingCenter = this
            .allCenters
            .First(c => c.Name == commandParams[1]
                && c.GetType().Name == nameof(CleansingCenter));

        var animalsToBeSend = adoptionCenter
            .StoredAnimals
            .Where(a => a.CleansingStatus == false);

        cleansingCenter.StoredAnimals.AddRange(animalsToBeSend);
    }

    public string GetStatistics()
    {
        var adoptingCentersCount = this
            .allCenters
            .Count(c => c.GetType().Name == nameof(AdoptionCenter));

        var cleansingCentersCount = this
            .allCenters
            .Count(c => c.GetType().Name == nameof(CleansingCenter));

        var adoptedAnimalsNames = this
            .adoptedAnimals.Any() 
            ? string.Join(", ", this.adoptedAnimals.OrderBy(a => a)) 
            : "None";

        var collectionOfCleansedAnimalsNames = new List<string>(this.adoptedAnimals);

        var cleansedAnimalsNamesFromCenters = this
            .allCenters
            .SelectMany(c => c.StoredAnimals)
            .Where(a => a.CleansingStatus == true)
            .Select(a => a.Name);

        collectionOfCleansedAnimalsNames.AddRange(cleansedAnimalsNamesFromCenters);

        var amountOfAnimalsWaitingForAdoption = this
            .allCenters
            .Where(c => c.GetType().Name == nameof(AdoptionCenter))
            .Sum(ac => ac.StoredAnimals
                .Count(a => a.CleansingStatus == true));

        var amountOfAnimalsWaitingForCleansing = this
            .allCenters
            .Where(c => c.GetType().Name == nameof(CleansingCenter))
            .Sum(cc => cc.StoredAnimals
                .Count(a => a.CleansingStatus == false));

        var cleansedAnimalsNames = collectionOfCleansedAnimalsNames.Any()
            ? string.Join(", ", collectionOfCleansedAnimalsNames.OrderBy(an => an))
            : "None";

        var result = new StringBuilder()
            .AppendLine("Paw Incorporative Regular Statistics")
            .AppendLine($"Adoption Centers: {adoptingCentersCount}")
            .AppendLine($"Cleansing Centers: {cleansingCentersCount}")
            .AppendLine($"Adopted Animals: {adoptedAnimalsNames}")
            .AppendLine($"Cleansed Animals: {cleansedAnimalsNames}")
            .AppendLine($"Animals Awaiting Adoption: {amountOfAnimalsWaitingForAdoption}")
            .Append($"Animals Awaiting Cleansing: {amountOfAnimalsWaitingForCleansing}");

        return result.ToString();
    }

    public void Cleanse(string[] commandParams)
    {
        var cleansingCenterName = commandParams[0];

        var cleansingCenter = this
            .allCenters
            .First(c => c.Name == cleansingCenterName);

        cleansingCenter
            .StoredAnimals
            .ForEach(a => a.MarkAnimalAsCleaned());

        cleansingCenter.StoredAnimals.Clear();
    }

    public void Adopt(string[] commandParams)
    {
        var adoptionCenter = this
            .allCenters
            .First(c => c.Name == commandParams[0]);

        var adoptedAnimalsNames = adoptionCenter
            .StoredAnimals
            .Where(a => a.CleansingStatus == true)
            .Select(a => a.Name);

        this.adoptedAnimals
            .AddRange(adoptedAnimalsNames);

        adoptionCenter
            .StoredAnimals
            .RemoveAll(a => a.CleansingStatus == true);
    }
}
