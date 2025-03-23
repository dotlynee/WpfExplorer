using Jamesnet.Wpf.Controls;
using System.Windows;
using System.Windows.Controls;

namespace WpfExplorer.Forms.UI.Units
{
    public class DarkWindow : JamesWindow 
    {
        static DarkWindow() => DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));


        // 초기 크기 속성을 위한 플래그
        private bool _initialSizeSet = false;

        public DarkWindow()
        {
            // 로드 이벤트에서 초기 크기 설정
            this.Loaded += DarkWindow_Loaded;
        }

        private void DarkWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 이미 초기 크기가 설정되었으면 아무것도 하지 않음
            if (_initialSizeSet)
                return;

            // Width 또는 Height가 명시적으로 설정되었는지 확인
            bool widthSet = this.ReadLocalValue(WidthProperty) != DependencyProperty.UnsetValue;
            bool heightSet = this.ReadLocalValue(HeightProperty) != DependencyProperty.UnsetValue;

            // 둘 다 설정되었으면 초기 크기 설정 완료로 표시
            if (widthSet && heightSet)
            {
                this.Width = (double) this.ReadLocalValue(WidthProperty);
                this.Height = (double) this.ReadLocalValue(HeightProperty);
                _initialSizeSet = true;
            }
        }
    }
}
