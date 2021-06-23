namespace FiveMClothingAssistant
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media.Animation;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ListBoxViewModel<ClothingModel> _clothingList = new ListBoxViewModel<ClothingModel>();
        private readonly ListBoxViewModel<ClothingTexture> _textureList = new ListBoxViewModel<ClothingTexture>();
        private readonly ListBoxViewModel<ClothingTexture> _assignedTextureList = new ListBoxViewModel<ClothingTexture>();


        public MainWindow()
        {
            InitializeComponent();

            Models.DataContext = _clothingList;
            Textures.DataContext = _textureList;
            AssignedTextures.DataContext = _assignedTextureList;

        }

        private void AddFilesClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Multiselect = true };
            if (dlg.ShowDialog() == true)
            {
                var filePaths = GetValidFileNames(dlg.FileNames);
                if (!filePaths.Any())
                    return;

                foreach (var file in filePaths)
                {
                    switch (Path.GetExtension(file))
                    {
                        case (".ydd"):
                            var model = new ClothingModel
                            {
                                Filename = Path.GetFileName(file),
                                Path = file
                            };
                            _clothingList.Items.Add(model);
                            break;

                        case (".ytd"):
                            var texture = new ClothingTexture
                            {
                                Filename = Path.GetFileName(file),
                                Path = file
                            };
                            _textureList.Items.Add(texture);
                            break;
                    }
                }
            }

        }

        private void ExportClothing(object sender, RoutedEventArgs e)
        {

        }


        private List<string> GetValidFileNames(IEnumerable<string> filePaths, string allowedExtensions = ".ydd;.ytd")
        {
            var files = new List<string>();
            var allowed = allowedExtensions.Split(';');

            var fileNames = filePaths.Where(x =>
            {
                foreach (var allowedExt in allowed)
                {
                    var ext = x.Substring(x.Length - allowedExt.Length);
                    if (ext.Equals(allowedExt, System.StringComparison.CurrentCultureIgnoreCase))
                        return true;
                }

                return false;
            }).ToList();

            // Check for a single file or folder.
            if (!fileNames.Any())
                return null;

            foreach (var file in fileNames)
            {
                // Check if the item is a file.
                if (File.Exists(file))
                {
                    files.Add(file);
                }
            }

            return files;
        }






        //private void clothingItems_Drop(object sender, DragEventArgs args)
        //{
        //    var filePaths = GetFileNames(args);
        //    if (!filePaths.Any())
        //        return;

        //    foreach (var file in filePaths)
        //    {
        //        var item = new ClothingModel
        //        {
        //            Filename = Path.GetFileName(file),
        //            Path = file
        //        };
        //        clothingItems.Items.Add(item);
        //    }

        //}

        // If the data object in args is a single file, this method will return the filename.
        // Otherwise, it returns null.
        //private List<string> GetFileNames(DragEventArgs args, string allowedExtensions = ".ydd;.ytd")
        //{
        //    var files = new List<string>();
        //    // Check for files in the hovering data object.
        //    if (args.Data.GetDataPresent(DataFormats.FileDrop, true))
        //    {
        //        var fileNames = args.Data.GetData(DataFormats.FileDrop, true) as string[];
        //        var allowed = allowedExtensions.Split(';');
        //        fileNames = fileNames?.Where(x =>
        //        {
        //            foreach (var allowedExt in allowed)
        //            {
        //                var ext = x.Substring(x.Length - allowedExt.Length);
        //                if (ext.Equals(allowedExt, System.StringComparison.CurrentCultureIgnoreCase))
        //                    return true;
        //            }

        //            return false;
        //        }).ToArray();

        //        // Check for a single file or folder.
        //        if (!fileNames.Any())
        //            return null;

        //        foreach (var file in fileNames)
        //        {
        //            // Check if the item is a file.
        //            if (File.Exists(file))
        //            {
        //                files.Add(file);
        //            }
        //        }
        //    }
        //    return files;
        //}




    }
}
