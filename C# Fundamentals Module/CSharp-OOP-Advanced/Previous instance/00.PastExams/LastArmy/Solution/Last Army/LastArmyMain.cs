public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IWareHouse wareHouse = new WareHouse(ammunitionFactory);
        IArmy army = new Army();

        IMissionController missionController = new MissionController(army, wareHouse);
        ISoldierFactory soldierFactory = new SoldierFactory();
        IMissionFactory missionFactory = new MissionFactory();
        IGameController gameController = new GameController(missionController, soldierFactory, missionFactory, army, wareHouse);

        IEngine engine = new Engine(reader, writer, gameController);
        engine.Run();
    }
}