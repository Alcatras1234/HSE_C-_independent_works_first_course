using System.Collections;
using System.Runtime.Serialization;

namespace EBookLib;
[DataContract]
public class MyLibrary<T> : IEnumerable<T> where T : PrintEdition
{
    [DataMember]
    public List<T> library;
    public event EventHandler<MyLibraryEventArgs>? onTake;//список объектов
    public string namePrintEdition { get; set; }

    public MyLibrary(List<T> list)
    {

        library = list;
    }
    // take book
    /// <summary>
    /// Убираем книги
    /// </summary>
    /// <param name="start"></param>
    public void TakeBooks(char start)
    {
        onTake?.Invoke(this, new MyLibraryEventArgs(start));
    }
    // added element in list.
    /// <summary>
    /// Добавляем объекты в список.
    /// </summary>
    /// <param name="printed"></param>
    public void Add(T printed)
    {
        library.Add(printed);
    }
    /// <summary>
    /// Далее идет инератор.
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyLibraryEnumerator(library);
    }

    class MyLibraryEnumerator : IEnumerator<T> 
    {
        private int _position;
        private List<T> Library;
      

        public MyLibraryEnumerator(List<T> library)
        {
            Library = library;
            _position = -1;
        }
        public bool MoveNext()
        {
            if (_position < Library.Count - 1)
            {
                _position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            _position = -1;
        }
        public object Current => Library[_position];
        T IEnumerator<T>.Current => Library[_position];
        
        public void Dispose()
        {
     
        }
    }
    public override string ToString()
    {
        int pages = 0;
        
        foreach (var i in library)
        {
            pages += i.pages;
            namePrintEdition += i.name + " ";
        }
        return $"Pages in all = {pages}; " +
               $"PrintEditions - {namePrintEdition}";
        
        
    }
    /// <summary>
    /// Подсчет средних страниц в книгах
    /// </summary>
    public string PagesInBook
    {
        get
        {
            double countPages = 0;
            int countBook = 0;
            double average = 0;
            for (int i = 0; i < library.Count; i++)
            {
                if (library[i] is Book)
                {
                    countPages += library[i].pages;
                    countBook++;
                }
            }
            if (countBook == 0)
                average = 0;
            else
                average = countPages / countBook;

            return $"{average:f2}";
        }
    }
    /// <summary>
    /// Подсчет средних страниц в журналах.
    /// </summary>

    public string PagesInMagazine
    {
        get
        {
            double countPages = 0;
            int countMagazine = 0;
            double average = 0;
            for (int i = 0; i < library.Count; i++)
            {
                if (library[i] is Magazine)
                {
                    countPages += library[i].pages;
                    countMagazine++;
                }
            }
            if (countMagazine == 0)
                average = 0;
            else
                average = countPages / countMagazine;

            return $"{average:f2}";
        }
    }


   
}