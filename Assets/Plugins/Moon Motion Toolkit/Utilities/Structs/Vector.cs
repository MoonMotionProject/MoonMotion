public struct Vector
{
    public double x;
	public double y;
	public double z;

	public Vector(double each)
	{
		this.x = each;
		this.y = each;
		this.z = each;
	}
	public Vector(double x, double y, double z)
    {
        this.x = x;
		this.y = y;
		this.z = z;
	}
}