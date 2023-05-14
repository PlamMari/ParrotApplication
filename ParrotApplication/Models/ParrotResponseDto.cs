using System.Collections.Generic;
using System.Linq;

namespace ParrotsApplication.Models
{
    public class ParrotResponseDto
    {
        public ParrotResponseDto(Parrot parrotModel) {
            this.Name = parrotModel.Name;
            this.Id = parrotModel.Id;
            this.Size = parrotModel.Size;
            this.NoiseLevel = parrotModel.NoiseLevel;
            this.Species = parrotModel.Species.Name;
            foreach (Video video in parrotModel.Videos)
            {
                this.Videos.Add(video.Value);
            }
            
            this.VideosCount = parrotModel.Videos.Count();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Species { get; set; }
        public double NoiseLevel { get; set; }
        public int VideosCount { get; set; }    
        public List<string> Videos { get; set; } = new List<string>();
    }
}
