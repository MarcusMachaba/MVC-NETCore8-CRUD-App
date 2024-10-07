using System.Runtime.Serialization;

namespace MVC.CRUD.Interface.Models.CommonModelBase;

public interface IHasIdRecord : IHasId, IHasIdOnly
{
    DateTime Created { get; set; }
}

[DataContract]
public abstract class HasIdRecord : HasIdOnly, IHasIdRecord
{
    public HasIdRecord()
    {
        Created = DateTime.Now;
    }
    [DataMember]
    public DateTime Created { get; set; }
    public long _Id { get; set; }
}
/// <summary>
/// ///////////////////////////////////////////////////////////////////////
/// </summary>
public interface IHasGIdRecord : IHasGId
{
    DateTime Created { get; set; }
    DateTime LastUpdate { get; set; }
}

[DataContract]
public abstract class HasGIdRecord : HasGId, IHasGIdRecord
{
    public HasGIdRecord()
    {
        Created = DateTime.Now;
        LastUpdate = DateTime.Now;
    }
    [DataMember]
    public DateTime Created { get; set; }
    [DataMember]
    public DateTime LastUpdate { get; set; }
}
