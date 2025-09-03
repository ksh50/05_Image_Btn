using System.Windows;

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

    // 画像のサイズ変更イベントハンドラ
    private void OnImageSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (DataContext is ViewModels.MainWindowViewModel viewModel)
        {
            // ViewModelのメソッドを呼び出して、長方形の位置とサイズを更新
            viewModel.OnImageSizeChanged(mainImage.ActualWidth, mainImage.ActualHeight);
        }
    }

}