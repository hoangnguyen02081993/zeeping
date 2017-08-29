using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Model.Local;
using static ZeepingAdminDashboard.Resources.DelegateClass;

namespace ZeepingAdminDashboard.View.Sub
{
    public partial class ImageAttachModelView : UserControl
    {
        public event ImageAttachChoosed OnImageAttachChoosed;
        private ImageAttachModel _ImageAttach;
        public ImageAttachModel ImageAttach
        {
            set
            {
                _ImageAttach = value;
                pic.Image = Image.FromFile(value.Link);
            }
            get
            {
                return _ImageAttach;
            }
        }
        private bool _IsChoose;
        public bool IsChoose
        {
            set
            {
                _IsChoose = value;
                this.BackColor = (_IsChoose) ? Color.Blue : SystemColors.Control;
            }
            get
            {
                return _IsChoose;
            }
        }
        public ImageAttachModelView()
        {
            InitializeComponent();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("[" + _ImageAttach.id.ToString() + "]");
        }

        private void pic_Click(object sender, EventArgs e)
        {
            IsChoose = true;
            if(OnImageAttachChoosed != null)
            {
                OnImageAttachChoosed(this, _ImageAttach.id);
            }
        }
    }
}
