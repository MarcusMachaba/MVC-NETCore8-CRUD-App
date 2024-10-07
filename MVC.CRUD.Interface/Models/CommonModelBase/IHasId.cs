using System.Runtime.Serialization;

namespace MVC.CRUD.Interface.Models.CommonModelBase;

public interface IHasId
{
    long _Id { get; set; }
}
[DataContract]
public abstract class HasId : IHasId
{
    [DataMember]
    public long _Id { get; set; }
}
/// <summary>
/// /////////
/// </summary>
public interface IHasGId
{
    string Id { get; set; }
}
[DataContract]
public abstract class HasGId : IHasGId
{
    public HasGId()
    {
        Id = Guid.NewGuid().ToString();
    }
    [DataMember]
    public string Id { get; set; }
    
}
/// <summary>
/// /////////
/// </summary>
public interface IHasIdOnly
{
    long Id { get; set; }
}
[DataContract]
public class HasIdOnly : IHasIdOnly
{
    [DataMember]
    public long Id { get; set; }
}
