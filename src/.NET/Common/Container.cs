using Common.Interfaces;
using Common.ORM;
using Unity;

namespace Common;

public class Container
{
    private static IUnityContainer _instance;

    public static T Resolve<T>() where T : class
    {
        if (_instance == null)
        {
            Init();
        }

        return _instance.Resolve<T>();
    }

    private static void Init()
    {
        _instance = new UnityContainer();

        _instance.RegisterType<IDbRepository, DbRepository>();
    }
}
