using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Media.MediaProperties;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Camera
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaCapture mediaCapture = new MediaCapture();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnViewHandler(object sender, RoutedEventArgs e) {
            await mediaCapture.InitializeAsync();
            this.Capture.Source = mediaCapture;
            await mediaCapture.StartPreviewAsync();
        }

        private async void btnSaveHandler(object sender, RoutedEventArgs e) {
            string filename = "Image.jpg";
            filename = Path.GetFileName(filename);
            IStorageFile photo =
                await KnownFolders.PicturesLibrary.CreateFileAsync(
                    filename, CreationCollisionOption.GenerateUniqueName);

            await mediaCapture.CapturePhotoToStorageFileAsync(
                ImageEncodingProperties.CreateJpeg(), photo);

        }
    }
}
