namespace SoftUniClone.Tests
{
    using AutoMapper;
    using SoftUniClone.Common.Mapping;

    public class TestSetup
    {
        private static object sync = new object();
        private static bool mapperInitialized = false;

        public static void Initialize()
        {
            lock (sync)
            {
                if (!mapperInitialized)
                {
                    Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

                    mapperInitialized = true;
                }
            }
        }
    }
}
