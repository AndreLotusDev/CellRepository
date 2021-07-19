using CellRepository.ApplicationService.Areas.Smartphone;
using Ninject;
using Presentation.Admin.Ninject;
using Presentation.Admin.Views.RegisterPhone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin.Views
{
    public partial class MainMenu : Form
    {
        private readonly ISmartphoneApplicationService _smartphoneService;

        [Inject()]
        public MainMenu(ISmartphoneApplicationService smartphoneService)
        {
            _smartphoneService = smartphoneService;
            InitializeComponent();
        }

        private void btnRegisterNewPhone_Click(object sender, EventArgs e)
        {
            var buttonRegisterNewPhone = sender as Button;

            RegisterNewPhone registerNewPhone = CompositionRoot.Resolve<RegisterNewPhone>();

            this.Visible = false;
            registerNewPhone.Visible = true;

            registerNewPhone.FormClosed += (s, arg) => this.Visible = true;
        }
    }
}
