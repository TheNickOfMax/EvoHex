/// <summary>
/// Represents a genome that contains a set of genes for the offspring.
/// </summary>
public class Genome
{
    /// Gets the set of genes for the offspring.
    public Gene[] OffspringGenes { get; protected set; }

    /// Gets the length of the genome.
    public int Length;

    /// <summary>
    /// Initializes a new instance of the Genome class with the specified genes and length.
    /// </summary>
    /// <param name="GenesLen">The number of genes for the offspring.</param>
    /// <param name="GemsLen">The length of each gene.</param>
    public Genome(int GenesLen, int GemsLen)
    {
        this.Length = GemsLen;
        OffspringGenes = new Gene[GenesLen];
        for (int i = 0; i < OffspringGenes.Length; i++)
        {
            OffspringGenes[i] = new Gene(GemsLen);
        }
    }
}
