namespace WebStore.Domain.Entities.Interfaces
{

	public interface IEntityNamed
		: IEntityBase
	{
		string Name { get; set; }
	}

}
