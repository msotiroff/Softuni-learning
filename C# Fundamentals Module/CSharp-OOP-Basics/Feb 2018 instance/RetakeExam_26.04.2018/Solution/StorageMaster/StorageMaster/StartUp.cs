using StorageMaster.Core;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var storageMaster = new StorageMaster.Core.StorageMaster();

            var engine = new Engine(storageMaster);

            engine.Run();
        }
    }
}
