public class HumanSizeWrapper : IHumanSize
{
    HumanSizeDelegate humanSize;

    public HumanSizeWrapper(HumanSizeDelegate humanSize)
    {
        this.humanSize = humanSize;
    }

    public float Height()=> humanSize().Height();

    public float Radius()=> humanSize().Radius();
}
public delegate IHumanSize HumanSizeDelegate();