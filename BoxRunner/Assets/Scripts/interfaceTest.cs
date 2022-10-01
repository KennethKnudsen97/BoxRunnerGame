
public interface IManipulator<T>
{
    void shuffle(T t);
    void sort(T t);
    void reverse( T t );

}



public class Parent<T> : IManipulator<T>
{
    T[] childArray;

    public void shuffle(T t)
    {

    }
    public void sort(T t)
    {

    }
    public void reverse(T t)
    {

    }


}

