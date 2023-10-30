using System;
/// <summary>
/// Класс работает с вещественными числами
/// </summary>
class DoublePreciseFilter : Precisfilter
{
    public DoublePreciseFilter(int precise) : base(precise)
    {

    }
/// <summary>
/// В данном методе обрабатывааются вещественные числа
/// </summary>
/// <param name="X">вещественное число</param>
/// <returns>возвращается отфарматированнное число типа 1.500 = 1.5</returns>
    public override string Filter(double X)
    {
        return X.ToString($"F{precise}");
    }
}