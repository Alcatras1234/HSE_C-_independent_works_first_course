using System;
using System.Runtime.Serialization;
namespace EKRLib;
/// <summary>
/// класс с конструкторами для работы ошибки
/// </summary>
public class TransportException : Exception
{
    public TransportException() : base() { }
    public TransportException(string message) : base(message) { }
    public TransportException(string message, Exception inner) : base(message, inner) { }
    protected TransportException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}