namespace FiveMClothingAssistant
{
    using System.Collections.ObjectModel;

    public class ClothingTexture : IDropTargetItemViewModel<ClothingTexture>
    {
        public bool CanAcceptChildren { get; set; } = false;
        public ObservableCollection<ClothingTexture> Children { get; set; } = null;



        public string Filename { get; set; }
        public string Path { get; set; }


        public override string ToString()
        {
            return Filename;
        }

    }
}
