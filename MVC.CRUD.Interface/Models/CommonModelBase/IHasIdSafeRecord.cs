using System.Runtime.Serialization;

namespace MVC.CRUD.Interface.Models.CommonModelBase;

public interface IHasIdSafeRecord : IHasIdRecord
{
    bool Archived { get; set; }
    DateTime Updated { get; set; }
    long UpdatedById { get; set; }
}
[DataContract]
public abstract class HasIdSafeRecord : HasIdRecord, IHasIdSafeRecord
{
    public HasIdSafeRecord()
    {
        Updated = DateTime.Now;

    }

    public bool Archived { get; set; }
    public DateTime Updated { get; set; }
    public long UpdatedById { get; set; }
}

///////////////////////////////////////////////////////

public interface IHasGIdSafeRecord : IHasGIdRecord
{
    bool Archived { get; set; }
    DateTime Updated { get; set; }
    Guid UpdatedById { get; set; }
}
[DataContract]
public abstract class HasGIdSafeRecord : HasGIdRecord, IHasGIdSafeRecord
{
    public HasGIdSafeRecord()
    {
        Updated = DateTime.Now;

    }

    public bool Archived { get; set; }
    public DateTime Updated { get; set; }
    public Guid UpdatedById { get; set; }
}

