using System.Runtime.Serialization;
using System.Xml.Linq;
namespace EBookLib;
/// <summary>
/// класс Книжка
/// </summary>
[DataContract, KnownType(typeof(PrintEdition))]

public class Book : PrintEdition
{
    [DataMember]
    public string author { get; set; }
    public Book(string name, int pages, string author) : base(name, pages)
    {
        this.author = author;
    }

    public override string ToString()
    {
        return $"name={name}; pages={pages}; author={author}";
    }
}