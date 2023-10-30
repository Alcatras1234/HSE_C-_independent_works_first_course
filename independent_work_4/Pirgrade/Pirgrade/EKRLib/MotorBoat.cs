namespace EKRLib;
/// <summary>
/// класс наследник. Построение объекта MotorBoat
/// </summary>
public class MotorBoat : Transport
{
    public MotorBoat(string model, uint power) : base(model, power)
    {
    }

    public override string StartEngine()
    {
        return $"{Model}:Brrrbrr";
    }

    public override string ToString()
    {
        return $"MotorBoat. {base.ToString()}";
    }
}