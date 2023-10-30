namespace ConsoleApp2;
/// <summary>
/// Класс генерации имени.
/// </summary>
public class GenerateName
{
    private int N { get; set; }
    public GenerateName(){}
    public GenerateName(int n)
    {
        N = n;
        
    }
    /// <summary>
    /// Метод, генерируещий имя.
    /// </summary>
    /// <param name="N"></param>
    /// <returns>имя.</returns>
    public string GetName(int N)
    {
        string name = "";
        Random rand = new Random();
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string alphabetSecond = "abcdefghijklmnopqrstuvwxyz";

        name += alphabet[rand.Next(0, 26)];
        for (int i = 0; i < N - 1; i++)
        {
            name += alphabetSecond[rand.Next(0,26)];
        }
 

        return name;
    }

    
}