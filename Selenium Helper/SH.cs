using OpenQA.Selenium.Interactions;

namespace Selenium_Helper;

public static class SH
{
    public static IWebDriver driver = null;
    public static void Start()
    {
        ChromeOptions co = new ChromeOptions();
        co.AddArgument("--start-maximized");
        co.AddArgument("--ignore-certificate-errors");
        co.AddArgument("--disable-popup-blocking");
        co.AddArgument("--disable-geolocation");
        co.AddArguments("--profile-directory=Selenium");
        co.AddArguments(@"--user-data-dir=C:\Users\" + Environment.UserName + @"\AppData\Local\Google\Chrome\User Data2\");
        driver = new ChromeDriver("C:\\", co);
    }
    public static void GetCookies(string path) => WriteAllLines(path, driver.Manage().Cookies.AllCookies.Select(x => x.Name + "|" + x.Value));
    public static void LoadCookies(string path, string url)
    {
        GoTo(url);
        ReadAllLines(path).ToList().ForEach(x => driver.Manage().Cookies.AddCookie(new Cookie(x.Split("|")[0], x.Split("|")[1])));
        GoTo(url);
    }
    public static void GoTo(string url)
    {
        while (true)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                break;
            }
            catch
            {
                GoTo(url);
                Sleep(10000);
            }
        }
    }
    public static void ScrollDown(int count)
    {
        Actions actions = new Actions(driver);
        for (int i = 0; i < count; i += 1)
        {
            actions.SendKeys(Keys.PageDown).Build().Perform();
            Sleep(15);
        }
    }
    public static void Unload() => driver.Quit();
}
