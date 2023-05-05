using BeersApplication.Models;
using BeersApplication.Services;

namespace BeersApplication.Models.Mappers
{
    public class ParrotMapper
    {
        private readonly ISpeciesService speciesService;
        public ParrotMapper(ISpeciesService speciesService)
        {
            this.speciesService = speciesService;
        }
        public Parrot ConvertToModel(ParrotRequestDto dto){
            Parrot model = new Parrot();
            model.Name = dto.Name;
            model.Size = dto.Size;
            model.NoiseLevel = dto.NoiseLevel;
            model.Species = this.speciesService.Get(dto.SpeciesId);
            return model;           
        }
        public ParrotResponseDto ConvertToDto(Parrot parrot)
        {
            ParrotResponseDto dto = new ParrotResponseDto(parrot);
            return dto;
        }
    }
}
