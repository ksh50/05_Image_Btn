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
        public double GlowLeft { get; } = 150;
        public double GlowTop { get; } = 100;
        public double GlowWidth { get; } = 100;
        public double GlowHeight { get; } = 100;

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
    }
}