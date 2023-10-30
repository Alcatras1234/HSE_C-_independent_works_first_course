using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Linq;
namespace EBookLib
{
    /// <summary>
    /// класс Журнал.
    /// </summary>
    [DataContract, KnownType(typeof(PrintEdition))]

    public class Magazine : PrintEdition
    {
        [DataMember]
        public int period { get; set; }
        /// <summary>
        /// Проверка что период не меньше 0 и присвоение.
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="pages">страницы</param>
        /// <param name="period">период</param>
        /// <exception cref="ArgumentException"></exception>
        public Magazine(string name, int pages, int period) : base(name, pages)
        {
            if (period <= 0)
                throw new ArgumentException("Period can not be less than zero!!!");
            this.period = period;
        }

        public override string ToString()
        {
            return $"name={name}; pages={pages}; period={period}";
        }
    }
    
}
