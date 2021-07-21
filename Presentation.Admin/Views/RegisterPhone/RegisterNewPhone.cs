using CellRepository.ApplicationModels;
using CellRepository.ApplicationService.Areas.Smartphone;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Ninject;
using Presentation.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin.Views.RegisterPhone
{
    public partial class RegisterNewPhone : Form
    {
        private readonly ISmartphoneApplicationService _smartphoneService;

        [Inject()]
        public RegisterNewPhone(ISmartphoneApplicationService smartphoneService)
        {
            _smartphoneService = smartphoneService;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dtLaunch.Format = DateTimePickerFormat.Short;

            //Instantiate the 10 points value
            ddlCamera.SelectedIndex = 9;
            ddlPerformance.SelectedIndex = 9;
            ddlScreen.SelectedIndex = 9;
        }

        private async void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            const int NO_CONTENT_LENGHT = 0;

            var nameOfSmartphone = txtCellphoneName.Text;
            if(nameOfSmartphone.Count() == NO_CONTENT_LENGHT)
            {
                MessageBox.Show("Precisa preencher o nome do smartphone, é obrigatório, por favor preencha");
                return; //Early return
            }

            var osName = txtOsName.Text;
            if(osName.Count() == NO_CONTENT_LENGHT)
            {
                MessageBox.Show("O nome do sistema do celular é obrigatório, por favor preencha");
                return;
            }

            var pontuationOfCamera = int.Parse(ddlCamera.Text);
            var pontuationOfScreen = int.Parse(ddlScreen.Text);
            var pontuationOfPerformance = int.Parse(ddlPerformance.Text);

            var fullDescription = txtDescription.Text;
            if(fullDescription.Count() == NO_CONTENT_LENGHT)
            {
                MessageBox.Show("Preencha a descrição, ela é obrigatória");
                return;
            }

            var weightOfSmartphone = txtWeight.Text;
            if(weightOfSmartphone.Count() == NO_CONTENT_LENGHT)
            {
                MessageBox.Show("Preencha o peso do smartphone, ele é obrigatório");
            }

            var smartphoneToContactDb = new SmartphoneDto()
            {
                SmartphoneName = nameOfSmartphone,
                OsName = osName,
                CameraPoints = pontuationOfCamera,
                PerformancePoints = pontuationOfPerformance,
                ScreenPoints = pontuationOfScreen,

                Description = fullDescription,
                LaunchDate = dtLaunch.Value.Date,
                Weight = int.Parse(weightOfSmartphone)
            };

            (var messageOfResult, var isPersisted) = await RegisterANewSmartphoneAsync(smartphoneToContactDb);

            //salved all right
            if(isPersisted)
            {
                MessageBox.Show("Salvo com sucesso!");
            } //Needs to display some information
            else
            {
                MessageBox.Show(messageOfResult);
            }
        }

        private async Task<(string message, bool status)> RegisterANewSmartphoneAsync(SmartphoneDto smartphoneModel)
        {
            return await _smartphoneService.RegisterANewSmartphoneAsync(smartphoneModel);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyEventsHelper.DonAllowToTypeChars(sender, e);
        }
    }
}
