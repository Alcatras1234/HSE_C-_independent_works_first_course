namespace EBookLib;
/// <summary>
/// Класс буфер для OnTake.
/// </summary>
public class MyLibraryEventArgs : EventArgs 
{
    public char Info { get; set; }

    public MyLibraryEventArgs(char info)
    {
        Info = info;
    }
}