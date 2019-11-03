public struct DoublesVector
{
    public double x;
	public double y;
	public double z;

	public DoublesVector(double each)
	{
		this.x = each;
		this.y = each;
		this.z = each;
	}
	public DoublesVector(double x, double y, double z)
    {
        this.x = x;
		this.y = y;
		this.z = z;
	}
}