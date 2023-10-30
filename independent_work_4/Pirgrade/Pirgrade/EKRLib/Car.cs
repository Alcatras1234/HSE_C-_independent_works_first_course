namespace EKRLib;
/// <summary>
/// класс наследник. Построение объекта Car
/// </summary>
public class Car : Transport
{
    public Car(string model, uint power) : base(model, power)
    {
    }

    public override string StartEngine()
    {
        return $"{Model}:Vroom";
    }

    public override string ToString()
    {
        return $"Car. {base.ToString()}";
    }
}