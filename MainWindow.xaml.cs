using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace _05_Image_Btn;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnImageSizeChanged(object sender, SizeChangedEventArgs e)
    {
        // 画像の実際のレンダリングサイズを取得
        var image = sender as Image;
        if (image.Source == null) return;

        // 画像の元のサイズを取得
        var imageSource = image.Source as BitmapSource;
        if (imageSource == null) return;

        double originalWidth = imageSource.PixelWidth;
        double originalHeight = imageSource.PixelHeight;

        // コンテナのサイズ
        double containerWidth = image.ActualWidth;
        double containerHeight = image.ActualHeight;

        // Uniformストレッチのスケールを計算
        double scale = Math.Min(containerWidth / originalWidth, containerHeight / originalHeight);

        // 実際にレンダリングされた画像のサイズ
        double renderedWidth = originalWidth * scale;
        double renderedHeight = originalHeight * scale;

        // Canvasのサイズを画像のレンダリングサイズに合わせる
        glowCanvas.Width = renderedWidth;
        glowCanvas.Height = renderedHeight;
    }

    private void OnGlowCanvasSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (DataContext is ViewModels.MainWindowViewModel viewModel)
        {
            // 画像のレンダリングサイズに対するViewModelのGlowサイズを再計算
            double newWidth = e.NewSize.Width;
            double newHeight = e.NewSize.Height;

            // 元の画像のサイズ（ViewModelで定義されているもの）
            double originalImageWidth = 800;
            double originalImageHeight = 600;

            // 新しい位置とサイズを計算してプロパティを更新
            viewModel.GlowLeft = (150.0 / originalImageWidth) * newWidth;
            viewModel.GlowTop = (100.0 / originalImageHeight) * newHeight;
            viewModel.GlowWidth = (100.0 / originalImageWidth) * newWidth;
            viewModel.GlowHeight = (100.0 / originalImageHeight) * newHeight;
        }
    }
}