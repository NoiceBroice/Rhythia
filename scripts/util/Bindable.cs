public class Bindable<T> : IBindable<T>
    where T : new()
{
    public T Object { get; set; }

    public Bindable()
    {
        Object = new();
    }
}