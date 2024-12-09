using SpecFlowProjPlaywright.Drivers;
using SpecFlowProjPlaywright.Pages;
using System.Diagnostics;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProjPlaywright.StepDefinitions
{
    [Binding]
    public sealed class EAAPLoginSteps
    {
        private readonly DriverClass _driver;
        private readonly LoginPage _loginPage;

        public EAAPLoginSteps(DriverClass driver) 
        {
            _driver = driver;
            _loginPage =new LoginPage(_driver.page);
        }
        
        [Given(@"I navigate to the application")]
        public void GivenINavigateToTheApplication()
        {
            _driver.page.GotoAsync("http://eaapp.somee.com/");
        }

        [Given(@"I click on login link")]
        public async Task GivenIClickOnLoginLink()
        {
            await _loginPage.LogilinkClick();
        }

        [Given(@"Enter following user details")]
        public async Task GivenEnterFollowingUserDetails(Table table)
        {
           dynamic data = table.CreateDynamicInstance();
            await _loginPage.FillLogin((string)data.UserName,(string)data.Password);
        }

        
        [Then(@"User should login")]
        public async Task ThenUserShouldLogin()
        {
            var isExit = await _loginPage.VerifyLogin();
            isExit.Should().BeTrue();
        }

    }
}
