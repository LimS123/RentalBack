using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings.Converters
{
    public class NewImageTypeConverter : ITypeConverter<IFormFile, (byte[], string)>
    {
        public (byte[], string) Convert(IFormFile source, (byte[], string) destination, ResolutionContext context)
        {
            using var binaryReader = new BinaryReader(source.OpenReadStream());
            var data = binaryReader.ReadBytes((int)source.Length);

            return (data, source.ContentType);
        }
    }
}
