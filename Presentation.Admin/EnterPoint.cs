using CellRepository.ApplicationService.Areas.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin
{
    public partial class EnterPoint : Form
    {
        private readonly IUserApplicationService _appService;

        public EnterPoint(IUserApplicationService appService)
        {
            InitializeComponent();

            _appService = appService;
        }

        private void chckLogin_CheckedChanged(object sender, EventArgs e)
        {
            var chkBoxLogin = (CheckBox)sender;

            if(chkBoxLogin.Checked)
            {
                setFieldEmailVis(false);
            }
            else
            {
                setFieldEmailVis(true);
            }
        }

        /// <summary>
        /// Set the visibility of the register
        /// </summary>
        /// <param name="visibility"></param>
        private void setFieldEmailVis(bool visibility)
        {
            txtUser.Visible = visibility;
            lblUser.Visible = visibility;
        }
    }
}
