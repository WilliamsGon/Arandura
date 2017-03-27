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
    /// Lógica de interacción para ucTbx.xaml
    /// </summary>
    public partial class ucTbx : UserControl
    {
        //Public Shared ReadOnly tbxTextProperty As DependencyProperty = DependencyProperty.Register("Text", GetType(String), GetType(tbx), New FrameworkPropertyMetadata(String.Empty))
        public ucTbx()
        {
            InitializeComponent();
            Loaded += ucTbx_Loaded;
        }

        public string Text
        {
            get { return tbx.Text; }
            set { tbx.Text = value; }
        }

        private bool IsNumeric_Value;
        public bool IsNumeric
        {
            get { return IsNumeric_Value; }
            set { IsNumeric_Value = value; }
        }

        public int MaxLenght
        {
            get { return tbx.MaxLength; }
            set { tbx.MaxLength = value; }
        }

        private void ucTbx_Loaded(object sender, RoutedEventArgs e)
        {
            tbx.PreviewTextInput += NumericOnly;
        }

        public void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (IsNumeric == true)
            {
                e.Handled = IsTextNumeric(e.Text);
            }
        }

        public bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9-.]");
            return reg.IsMatch(str);
        }
    }
}
