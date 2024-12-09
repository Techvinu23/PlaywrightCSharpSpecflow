using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjPlaywright.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page) => _page = page;
        private ILocator BtnLoginlink => _page.Locator("id=loginLink");
        private ILocator TxtUserName => _page.Locator("id=UserName");
        private ILocator TxtPassword => _page.Locator("css=#Password");
        private ILocator BtnLoginclick => _page.Locator("xpath=//input[@id='loginIn']");
        private ILocator LblVerifyLogin => _page.Locator("text='Employee List'");

        public async Task LogilinkClick()
        {
            await BtnLoginlink.ClickAsync();
        }

        public async Task FillLogin(string username, string password)
        {
            await TxtUserName.FillAsync(username);
            await TxtPassword.FillAsync(password);
            await BtnLoginclick.ClickAsync();
        }
        public async Task<bool> VerifyLogin() => await LblVerifyLogin.IsVisibleAsync();
    }
}
