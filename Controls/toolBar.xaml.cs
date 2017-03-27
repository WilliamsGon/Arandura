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
    /// Lógica de interacción para toolBar.xaml
    /// </summary>
    public partial class toolBar : UserControl
    {
        public toolBar()
        {
            InitializeComponent();
            MenuDisabled();
        }

        double InActive = 0.3;
        int Active = 1;

        #region "Propiedades CRUD"
        public void MenuLoad()
        {
            btnNew.Opacity = Active;
            btnNew.IsEnabled = true;
            btnEdit.Opacity = InActive;
            btnEdit.IsEnabled = false;
            btnDelete.Opacity = InActive;
            btnDelete.IsEnabled = false;
            btnSave.Opacity = InActive;
            btnSave.IsEnabled = false;
            btnCancel.Opacity = InActive;
            btnCancel.IsEnabled = false;
        }

        public void MenuEnabled()
        {
            btnNew.Opacity = InActive;
            btnNew.IsEnabled = false;
            btnEdit.Opacity = InActive;
            btnEdit.IsEnabled = false;
            btnDelete.Opacity = InActive;
            btnDelete.IsEnabled = false;
            btnSave.Opacity = Active;
            btnSave.IsEnabled = true;
            btnCancel.Opacity = Active;
            btnCancel.IsEnabled = true;
        }

        public void MenuDisabled()
        {
            btnNew.Opacity = Active;
            btnNew.IsEnabled = true;
            btnEdit.Opacity = Active;
            btnEdit.IsEnabled = true;
            btnDelete.Opacity = Active;
            btnDelete.IsEnabled = true;
            btnSave.Opacity = InActive;
            btnSave.IsEnabled = false;
            btnCancel.Opacity = InActive;
            btnCancel.IsEnabled = false;
        }
        #endregion

        #region "CRUD Events"
        //NEW
        public event btnNew_ClickedEventHandler btnNew_Click;
        public delegate void btnNew_ClickedEventHandler(object sender);
        private void btnNew_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnNew_Click != null)
            {
                btnNew_Click(this);
            }
            MenuEnabled();
        }

        //EDIT
        public event btnEdit_ClickedEventHandler btnEdit_Click;
        public delegate void btnEdit_ClickedEventHandler(object sender);
        private void btnEdit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnEdit_Click != null)
            {
                btnEdit_Click(this);
            }
            MenuEnabled();
        }

        //DELETE
        public event btnDelete_ClickedEventHandler btnDelete_Click;
        public delegate void btnDelete_ClickedEventHandler(object sender);
        private void btnDelete_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnDelete_Click != null)
            {
                btnDelete_Click(this);
            }
        }

        //SAVE
        public event btnSave_ClickedEventHandler btnSave_Click;
        public delegate void btnSave_ClickedEventHandler(object sender);
        private void btnSave_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnSave_Click != null)
            {
                btnSave_Click(this);
            }
            //MenuDisabled();
        }

        //CANCEL
        public event btnCancel_ClickedEventHandler btnCancel_Click;
        public delegate void btnCancel_ClickedEventHandler(object sender);
        private void btnCancel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnCancel_Click != null)
            {
                btnCancel_Click(this);
            }
            //MenuDisabled();
        }

        //CREDIT
        public event btnCredit_ClickedEventHandler btnCredit_Click;
        public delegate void btnCredit_ClickedEventHandler(object sender);
        private void btnCredit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnCredit_Click != null)
            {
                btnCredit_Click(this);
            }
        }

        //APPROVE
        public event btnApprove_ClickedEventHandler btnApprove_Click;
        public delegate void btnApprove_ClickedEventHandler(object sender);
        private void btnApprove_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnApprove_Click != null)
            {
                btnApprove_Click(this);
            }
        }

        //ANULL
        public event btnAnull_ClickedEventHandler btnAnull_Click;
        public delegate void btnAnull_ClickedEventHandler(object sender);
        private void btnAnull_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnAnull_Click != null)
            {
                btnAnull_Click(this);
            }
        }

        //REPORT
        public event btnReport_ClickedEventHandler btnReport_Click;
        public delegate void btnReport_ClickedEventHandler(object sender);
        private void btnReport_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnReport_Click != null)
            {
                btnReport_Click(this);
            }
        }

        //PRINT
        public event btnAnull_ClickedEventHandler btnPrint_Click;
        public delegate void btnPrint_ClickedEventHandler(object sender);
        private void btnPrint_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (btnPrint_Click != null)
            {
                btnPrint_Click(this);
            }
        }

        #endregion

        #region "ShowButtom"
        public Visibility Ver_Reporte
        {
            get { return btnReport.Visibility; }
            set { btnReport.Visibility = value; }
        }

        public Visibility Ver_Imprimir
        {
            get { return btnPrint.Visibility; }
            set { btnPrint.Visibility = value; }
        }
        
        public Visibility Ver_Credito
        {
            get { return btnCredit.Visibility; }
            set { btnCredit.Visibility = value;
                  RectangleCred.Visibility = value; }
        }

        public Visibility Ver_RecCred
        {
            get { return RectangleCred.Visibility; }
            set { RectangleCred.Visibility = value; }
        }
        public Visibility Ver_Aprobar
        {
            get { return btnApprove.Visibility; }
            set { btnApprove.Visibility = value; }
        }

        public Visibility Ver_Anular
        {
            get { return btnAnull.Visibility; }
            set { btnAnull.Visibility = value; }
        }
        #endregion
    }
}
