using System.Runtime.Serialization;
using System.Xml.Linq;
namespace EBookLib;
/// <summary>
/// Класс родитель.
/// </summary>
[DataContract, KnownType(typeof(Book)), KnownType(typeof(Magazine))]
public abstract class PrintEdition : IPrinting
{
    [DataMember]
    public string name { get; set; }
    [DataMember]
    public int pages { get; set; }

    public PrintEdition(string name, int pages)
    {
        this.name = name;
        if (pages <= 0)
        {
            throw new ArgumentException("Pages can not be less than zero!!!");
        }

        this.pages = pages;
    }
    public event EventHandler<PrintEventArgs> OnPrint;
    /// <summary>
    /// Метод для вызова события
    /// </summary>
    public void Print()
    {
        OnPrint?.Invoke(this, new PrintEventArgs(ToString()));
    }

    public override string ToString()
    {
        return $"name={name}; pages={pages}.";
    }
}