namespace LinkEcommerce.Services.Identity.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public LoginRequest Login { get; set; }
    private readonly ILoggerApplicationService<LoginModel> _logger;
    private readonly SignInManager<UserApplication> _signInManager;
    private readonly IUserApplicationServices _services;

    public LoginModel(
        IUserApplicationServices services, 
        ILoggerApplicationService<LoginModel> logger,
        SignInManager<UserApplication> signInManager)
    {
        _services = services ?? throw new ArgumentNullException(nameof(services));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));

        Login = new LoginRequest
        {
            Password = string.Empty,
            UserName = string.Empty,
            ReturnUrl = string.Empty
        };
    }

    public async Task OnGet(string returnUrl)
    {
        Login.ReturnUrl = HttpUtility.UrlDecode(returnUrl);
        _logger.LogInformation($"String url: {Login.ReturnUrl}");
        Login.ReturnUrl ??= Url.Content("~/");
        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _logger.LogInformation("Login request post login");

        if (!ModelState.IsValid)
            return Page();

        // var result = await _signInManager.PasswordSignInAsync(Login.UserName, Login.Password, true, false);
        var result = await _services.LoginAsync(Login);

         //_logger.LogInformation($"Result login : {result.Succeeded}");

        if (result != null)
        {
            _logger.LogInformation($"Login successful returning to: {Login.ReturnUrl}");
          
            if (HttpContext.IsNativeClient())
            {
                _logger.LogInformation("Is Native Client");
                return LocalRedirect(Login.ReturnUrl);
            }
            else
            {
                _logger.LogInformation("No Is Native Client");
                return Redirect(Login.ReturnUrl);
            }
        }
        else
        {
            return Page();
        }
    }
}