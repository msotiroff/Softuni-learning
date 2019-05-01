using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IWareHouse wareHouse = new WareHouse(ammunitionFactory);
        IArmy army = new Army();

        ISoldierFactory soldierFactory = new SoldierFactory();
        IMissionFactory missionFactory = new MissionFactory();
        IMissionController missionController = new MissionController(army, wareHouse);
        IGameController gameController = new GameController(missionController, army, wareHouse, soldierFactory, missionFactory);

        IEngine engine = new Engine(gameController, reader, writer);
        engine.Run();
    }
}
