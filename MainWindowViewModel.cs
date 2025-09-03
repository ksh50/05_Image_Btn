using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media;

namespace _05_Image_Btn.ViewModels
{
    // ViewModelはObservableObjectを継承して、プロパティ変更通知を可能にします
    public partial class MainWindowViewModel : ObservableObject
    {
        // 画像の発光エフェクトの表示状態を管理するプロパティ
        // [ObservableProperty]属性を使用することで、自動的にプロパティと通知コードが生成されます
        [ObservableProperty]
        private bool _isGlowVisible;

        // 画像のソースを管理するプロパティ
        public string ImageSourcePath { get; } = "/Images/console.jpg";

        // 発光部分の座標とサイズ
        // 例: 画像の左上角からの位置とサイズ
        // プロパティ変更通知を可能にするためObservableProperty属性を使用します
        [ObservableProperty]
        private double _glowLeft;
        [ObservableProperty]
        private double _glowTop;
        [ObservableProperty]
        private double _glowWidth;
        [ObservableProperty]
        private double _glowHeight;
        
        // 発光部分の色を定義するプロパティ
        public SolidColorBrush GlowColor { get; } = new SolidColorBrush(Colors.Yellow);

        // ボタンのクリックイベントに紐づけるコマンド
        // [RelayCommand]属性を使用することで、自動的にコマンドが生成されます
        [RelayCommand]
        private void ToggleGlow()
        {
            // 発光エフェクトの表示状態を切り替えます
            IsGlowVisible = !IsGlowVisible;
        }

        // 画像のレンダリングサイズとオフセットに基づいてRectangleのプロパティを更新
        public void UpdateGlowPositionAndSize(double renderedWidth, double renderedHeight, double offsetX, double offsetY)
        {
            // 元の画像のサイズ（ViewModelで定義されているもの）
            double originalImageWidth = 800;
            double originalImageHeight = 600;

            // 元のGlowの座標とサイズ（ViewModelで定義されているもの）
            double originalGlowLeft = 150;
            double originalGlowTop = 100;
            double originalGlowWidth = 100;
            double originalGlowHeight = 100;

            // 新しい位置とサイズを計算してプロパティを更新
            GlowLeft = (originalGlowLeft / originalImageWidth) * renderedWidth + offsetX;
            GlowTop = (originalGlowTop / originalImageHeight) * renderedHeight + offsetY;
            GlowWidth = (originalGlowWidth / originalImageWidth) * renderedWidth;
            GlowHeight = (originalGlowHeight / originalImageHeight) * renderedHeight;
        }
    }
}
