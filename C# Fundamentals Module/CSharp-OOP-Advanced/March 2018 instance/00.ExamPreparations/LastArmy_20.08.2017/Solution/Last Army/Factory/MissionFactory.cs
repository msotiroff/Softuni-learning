using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double scoreToComplete)
    {
        var missionType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(IMission))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == difficultyLevel);
        
        var mission = Activator.CreateInstance(missionType, new object[] { scoreToComplete });

        return (IMission)mission;
    }
}
