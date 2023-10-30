namespace EBookLib;
/// <summary>
/// интерфейс с образами.
/// </summary>
public interface IPrinting 
{
    public event EventHandler<PrintEventArgs> OnPrint;
    public void Print();
}