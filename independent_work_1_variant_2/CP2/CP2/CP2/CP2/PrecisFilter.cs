using System;
/// <summary>
/// обрабатывает числа
/// </summary>
class Precisfilter
{
    protected int precise;

    public Precisfilter(int precise)
    {
        this.precise = precise;
    }

    public int Precise
    {
        get
        {
            return precise;
        }
        set
        {
            if (precise < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
/// <summary>
/// обрабатываает значения 
/// </summary>
/// <param name="X">вещественные числа</param>
/// <returns>возвращается отформатированнное число с тремя знаками после запятой</returns>
    public virtual string Filter(double X)
    {

        return X.ToString($":f3");
    }
}