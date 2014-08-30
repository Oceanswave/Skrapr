namespace BaristaLabs.Skrapr.Common.EntitySchemes
{
    using MyCouch.EntitySchemes;
    using MyCouch.EntitySchemes.Reflections;

    /// <summary>
    /// EntityReflector that allows the entity id property to be set via a JsonProperty attribute.
    /// </summary>
    public class JsonNetEntityReflector : IEntityReflector
    {
        public IEntityMember IdMember { get; protected set; }
        public IEntityMember RevMember { get; protected set; }

        public JsonNetEntityReflector(IDynamicPropertyFactory dynamicPropertyFactory)
        {
            IdMember = new JsonNetEntityIdMember(dynamicPropertyFactory);
            RevMember = new EntityRevMember(dynamicPropertyFactory);
        }
    }
}
