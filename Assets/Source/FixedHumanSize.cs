public class FixedHumanSize : IHumanSize
{
    float height;
    float radius;
    public FixedHumanSize(float height, float radius)
    {
        this.height = height;
        this.radius = radius;
    }
    public float Height() => height;
    public float Radius() => radius;
}