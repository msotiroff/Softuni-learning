namespace SoftUniClone.Common.Mapping
{
    using AutoMapper;

    public interface ICustomMappingConfiguration
    {
        void ConfigureMapping(Profile mapper);
    }
}