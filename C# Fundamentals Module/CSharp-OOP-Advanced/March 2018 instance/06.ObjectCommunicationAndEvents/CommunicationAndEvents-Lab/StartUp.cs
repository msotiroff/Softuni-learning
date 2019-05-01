using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        IHandler combatLogger = new CombatLogger();
        IHandler eventLogger = new EventLogger();

        combatLogger.SetSuccessor(eventLogger);

        var warriorOne = new Warrior("Gosho", 10, combatLogger);
        var warriorTwo = new Warrior("Misho", 10, combatLogger);

        IAttackGroup attackGroup = new Group();
        attackGroup.AddMember(warriorOne);
        attackGroup.AddMember(warriorTwo);

        var dragon = new Dragon("Pesho", 100, 25, combatLogger, new List<IObserver>());

        IExecutor executor = new CommandExecutor();

        ICommand groupTarget = new GroupTargetCommand(attackGroup, dragon);
        ICommand groupAttack = new GroupAttackCommand(attackGroup);

        executor.ExecuteCommand(groupTarget);
        executor.ExecuteCommand(groupAttack);
    }
}
