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
    DateTime? CreatedDate { get; set; }
    DateTime? LastUpdateDate { get; set; }
}

[DataContract]
public abstract class HasGIdRecord : HasGId, IHasGIdRecord
{
    public HasGIdRecord()
    {
        CreatedDate = DateTime.Now;
        //LastUpdateDate = DateTime.Now;
    }
    [DataMember]
    public DateTime? CreatedDate { get; set; }
    [DataMember]
    public DateTime? LastUpdateDate { get; set; }
}
