using CellRepository.ApplicationModels;
using CellRepository.ApplicationService.Areas.User;
using CellRepository.Domain.Enum;
using CellRepository.Shared.Functions;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Presentation.Admin.Config;
using Presentation.Admin.Ninject;
using Presentation.Admin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
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

            chckLogin.Checked = true;
            chckLogin_CheckedChanged(chckLogin, null);

            txtEmail.Text = "a@yahoo.com";
            txtPassword.Text = "12345678910";
        }
        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void chckLogin_CheckedChanged(object sender, EventArgs e)
        {
            var chkBoxLogin = (CheckBox)sender;

            if(chkBoxLogin.Checked)
            {
                setFieldEmailVis(false);

                btnLoginRegister.Text = "Login";
            }
            else
            {
                setFieldEmailVis(true);

                btnLoginRegister.Text = "Register";
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

        private async void btnLoginRegister_Click(object sender, EventArgs e)
        {
            (var user, var message, var status) = await TryLogin((Button)sender);

            var userSession = new UserSession();

            if (user is null)
            {
                MessageBox.Show("Usuário não encontrado!");
                return;
            }

            userSession.UpdateNameLogged(user.NameInSite);
            userSession.UpdateRole(user.Role);

            this.Visible = false;

            MainMenu mainMenu = CompositionRoot.Resolve<MainMenu>();
            mainMenu.Visible = true;
            mainMenu.FormClosed += (s, arg) => this.Visible = true;
        }

        private async Task<(UserLoginDto user, string message, bool status)> TryLogin(Button sender)
        {
            var buttonLoginOrRegister = sender;

            UserLoginDto user = new UserLoginDto { Email = txtEmail.Text, Password = txtPassword.Text };

            user.Password = Sha256.Encrypt(user.Password, ConfigSession.EncryptKey);

            if (buttonLoginOrRegister.Text == "Login")
            {
                return await _appService.LoginAsync(user);
            }

            return (null, "", false);
        }
    }
}
