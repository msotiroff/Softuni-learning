public class AdoptionCenter : Center
{
    public AdoptionCenter(string name) 
        : base(name)
    {
    }

    public void SendAnimalsForCleansing(Center cleanCenter)
    {
        cleanCenter.StoredAnimals.AddRange(this.StoredAnimals);
    }

    public void AdoptAnimals()
    {

    }
}
