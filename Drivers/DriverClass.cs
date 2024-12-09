using Microsoft.Playwright;

namespace SpecFlowProjPlaywright.Drivers
{
    public class DriverClass : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;
        public DriverClass() => _page = InitializePlaywright();

        public IPage page => _page.Result;
        public async Task<IPage> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(
              new BrowserTypeLaunchOptions
              {
                  Headless = false
              });

            return await _browser.NewPageAsync();
        }
        public void Dispose()
        {
            _browser?.CloseAsync();
        }
    }
}
