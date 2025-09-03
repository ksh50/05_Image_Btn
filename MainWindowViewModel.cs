// dotnet add package CommunityToolkit.Mvvm

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
        
        // 元の座標とサイズ（画像の原寸に対する比率を計算するために使用）
        private const double originalImageWidth = 800;
        private const double originalImageHeight = 600;
        private const double originalGlowLeft = 150;
        private const double originalGlowTop = 100;
        private const double originalGlowWidth = 100;
        private const double originalGlowHeight = 100;

        // コンストラクタで初期値を設定
        public MainWindowViewModel()
        {
            GlowLeft = originalGlowLeft;
            GlowTop = originalGlowTop;
            GlowWidth = originalGlowWidth;
            GlowHeight = originalGlowHeight;
        }

        // ボタンのクリックイベントに紐づけるコマンド
        // [RelayCommand]属性を使用することで、自動的にコマンドが生成されます
        [RelayCommand]
        private void ToggleGlow()
        {
            // 発光エフェクトの表示状態を切り替えます
            IsGlowVisible = !IsGlowVisible;
        }

        // 発光部分の色を定義するプロパティ
        public SolidColorBrush GlowColor { get; } = new SolidColorBrush(Colors.Yellow);
        
        // 画像のサイズが変更されたときに呼び出されるメソッド
        public void OnImageSizeChanged(double actualWidth, double actualHeight)
        {
            // 画像の伸縮率を計算
            double widthRatio = actualWidth / originalImageWidth;
            double heightRatio = actualHeight / originalImageHeight;
            
            // 新しい位置とサイズを計算してプロパティを更新
            GlowLeft = originalGlowLeft * widthRatio;
            GlowTop = originalGlowTop * heightRatio;
            GlowWidth = originalGlowWidth * widthRatio;
            GlowHeight = originalGlowHeight * heightRatio;
        }
    }
}
