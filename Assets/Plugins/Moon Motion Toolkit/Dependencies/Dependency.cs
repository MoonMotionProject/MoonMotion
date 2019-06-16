// Dependency
// • a Dependency is a pair of both a Dependency Requisite and a Dependency Requisition
//   · see 'Dependencies' for further context
[System.Serializable]
public class Dependency
{
	// variables //

	
	// settings //
	public DependencyRequisition requisition;       // the Dependency Requisition of this Dependency (by which this Dependency is either dependent as 'when' or 'when not' matching the state of this Dependency's Dependency Requisite)
	public DependencyRequisite requisite;       // the Dependency Requisite (Moon Motion feature upon which its state may be depended) of this Dependency




	// constructors //

	
	public Dependency()
	{
		requisition = DependencyRequisition.when;
	}
	public Dependency(DependencyRequisition requisition)
	{
		this.requisition = requisition;
	}
	public Dependency(DependencyRequisite requisite)
	{
		requisition = DependencyRequisition.when;
		this.requisite = requisite;
	}
	public Dependency(DependencyRequisition requisition, DependencyRequisite requisite)
	{
		this.requisition = requisition;
		this.requisite = requisite;
	}
}