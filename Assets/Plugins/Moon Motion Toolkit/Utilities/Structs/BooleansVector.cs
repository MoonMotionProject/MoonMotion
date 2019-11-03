[System.Serializable]
public struct BooleansVector
{
    public bool x;
	public bool y;
	public bool z;

	public BooleansVector(bool each)
	{
		x = each;
		y = each;
		z = each;
	}
	public BooleansVector(bool x, bool y, bool z)
    {
        this.x = x;
		this.y = y;
		this.z = z;
	}
}