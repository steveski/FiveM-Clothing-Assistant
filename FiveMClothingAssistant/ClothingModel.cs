namespace FiveMClothingAssistant
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ClothingModel : IDropTargetItemViewModel<ClothingModel>
    {
        public bool CanAcceptChildren { get; set; } = true;
        public ObservableCollection<ClothingModel> Children { get; set; } = new ObservableCollection<ClothingModel>();



        public string Filename { get; set; }
        public string Path { get; set; }

        public List<ClothingTexture> Textures { get; set; }
        
        public override string ToString()
        {
            return Filename;
        }


    }
}
