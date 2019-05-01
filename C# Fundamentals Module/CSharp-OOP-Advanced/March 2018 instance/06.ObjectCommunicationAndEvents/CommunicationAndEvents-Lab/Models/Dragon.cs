using System;
using System.Collections.Generic;

public class Dragon : IObservableTarget
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private IHandler handler;
    private IList<IObserver> observers;

    public Dragon(string id, int hp, int reward, IHandler handler, IList<IObserver> observers)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.handler = handler;
        this.observers = observers;
    }

    public bool IsDead { get => this.hp <= 0; }
    
    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if(this.IsDead && !eventTriggered)
        {
            Console.WriteLine(THIS_DIED_EVENT, this);
            this.eventTriggered = true;
        }
    }

    public void NotifyObservers()
    {
        foreach (var observer in this.observers)
        {
            observer.Update(this.reward);
        }
    }

    public void Register(IObserver observer) => this.observers.Add(observer);

    public void Unregister(IObserver observer) => this.observers.Remove(observer);

    public override string ToString()
    {
        return this.id;
    }
}
