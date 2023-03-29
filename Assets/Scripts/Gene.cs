/// <summary>
/// Represents a gene that contains an array of 4 integers which represent possible child genes.
/// </summary>
public class Gene
{
    /// <summary>
    /// Array of integers that represent the possible child genes.
    /// </summary>
    public int[] OffspringGems;

    // 0 right
    // 1 left
    // 2 up
    // 3 down

    /// <summary>
    /// Initializes a new instance of the <see cref="Gene"/> class with 30 as the maximum number of possible child genes.
    /// </summary>
    public Gene()
        : this(30) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Gene"/> class with a specified maximum number of possible child genes.
    /// </summary>
    /// <param name="GemMax">The maximum number of possible child genes.</param>
    public Gene(int GemMax)
    {
        this.OffspringGems = new int[4];

        for (int i = 0; i < OffspringGems.Length; i++)
        {
            this.OffspringGems[i] = new System.Random().Next(0, GemMax);
        }
    }
}
