using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls
{
    /// <summary>
    /// Lógica de interacción para menuAppIcon.xaml
    /// </summary>
    public partial class menuAppIcon : UserControl
    {
        public menuAppIcon()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("title", typeof(String), typeof(menuAppIcon), new FrameworkPropertyMetadata(string.Empty));
        public String text
        {
            get { return GetValue(TitleProperty).ToString(); }
            set { SetValue(TitleProperty, value); }
        }

        public string IconSource
        {
            get { return imgApp.Source.ToString(); }
            set { imgApp.Source = new BitmapImage(new Uri(value, UriKind.Relative)); }
        }

        public Brush IconColor
        {
            get { return circle.Fill; }
            set { circle.Fill = value; }
        }

        private void imgApp_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu cm = new ContextMenu();
            MenuItem addFav = new MenuItem();
            addFav.Header = "+ Fav";
            addFav.Icon = new BitmapImage(new Uri("Images/Menu/\".png", UriKind.Relative)).ToString();

            addFav.Click += add_Fav;
            cm.Items.Add(addFav);
            ContextMenuService.SetShowOnDisabled(this, false);
            this.ContextMenu = cm;
        }
        
        private void imgApp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }
        
        public void add_Fav(object sender, RoutedEventArgs e)
        {
        }

        //protected override void Finalize()
        //{
        //    base.Finalize();
        //}
    }
}
