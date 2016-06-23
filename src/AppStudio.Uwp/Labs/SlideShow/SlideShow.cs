﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Foundation;

namespace AppStudio.Uwp.Labs
{
    public partial class SlideShow : Control
    {
        private Grid _container = null;
        private RectangleGeometry _clip = null;

        public SlideShow()
        {
            this.DefaultStyleKey = typeof(SlideShow);
            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
            this.SizeChanged += OnSizeChanged;
        }

        #region DelayInterval
        public double DelayInterval
        {
            get { return (double)GetValue(DelayIntervalProperty); }
            set { SetValue(DelayIntervalProperty, value); }
        }

        public static readonly DependencyProperty DelayIntervalProperty = DependencyProperty.Register("DelayInterval", typeof(double), typeof(SlideShow), new PropertyMetadata(3000.0));
        #endregion

        #region FadeInterval
        public double FadeInterval
        {
            get { return (double)GetValue(FadeIntervalProperty); }
            set { SetValue(FadeIntervalProperty, value); }
        }

        public static readonly DependencyProperty FadeIntervalProperty = DependencyProperty.Register("FadeInterval", typeof(double), typeof(SlideShow), new PropertyMetadata(3000.0));
        #endregion

        #region ItemTemplate
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(SlideShow), new PropertyMetadata(null));
        #endregion

        protected override void OnApplyTemplate()
        {
            _container = base.GetTemplateChild("container") as Grid;
            _clip = base.GetTemplateChild("clip") as RectangleGeometry;

            base.OnApplyTemplate();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!_isStarted)
            {
                this.Start();
            }
            else
            {
                this.Resume();
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            this.Stop();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Sized");
            if (_clip != null)
            {
                _clip.Rect = new Rect(new Point(), e.NewSize);
            }
        }
    }
}
