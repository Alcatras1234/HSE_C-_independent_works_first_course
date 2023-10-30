using System;
/// <summary>
/// в классе обрабатываются целые значения
/// </summary>
class IntPreciseFilter : Precisfilter
{
    public IntPreciseFilter(int precise) : base(precise)
    {

    }
/// <summary>
/// обрабатываются целые данные
/// </summary>
/// <param name="X">целые значения</param>
/// <returns>возвращается значение типа 1 = 001 </returns>
    public override string Filter(double X)
    {
        if (X % 1 == 0)
        {
            return ((int)X).ToString().PadLeft(precise, '0');
        }

        return "";
    }
}