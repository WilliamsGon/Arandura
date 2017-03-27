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
    /// Lógica de interacción para toolIcon.xaml
    /// </summary>
    public partial class toolIcon : UserControl
    {
        public toolIcon()
        {
            InitializeComponent();
        }

        public Visibility hideLabel
        {
            get
            {
                return lblLabel.Visibility;
            }
            set
            {
                if ((lblLabel.Visibility != value))
                {
                    lblLabel.Visibility = value;
                    imgIcon.Height = 40;
                    imgIcon.Stretch = Stretch.Uniform;
                }

            }
        }

        public string label
        {
             get
            {
                return lblLabel.Content.ToString();
            }
            set
            {
                lblLabel.Content = value;
            }
        }

        public string img {
        set {
                imgIcon.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
