namespace Easy.Plugins
{
    public interface IPluginFactory<out T>
    {
        T GetInstance();
    }
}