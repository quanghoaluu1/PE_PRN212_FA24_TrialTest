using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GermanyEuro2024_RazorPage.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IUEFAAccountRepository _uefaAccountRepository;
    public IndexModel(ILogger<IndexModel> logger,IUEFAAccountRepository uefaAccountRepository)
    {
        _logger = logger;
      
        _uefaAccountRepository = uefaAccountRepository;

    }
    
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Password { get; set; }
    
    public string ErrorMessage { get; set; }

    public IActionResult OnPost()
    {
        Uefaaccount uefaAccount = _uefaAccountRepository.GetUEFAAccountByEmail(Email);

        if (uefaAccount != null && uefaAccount.AccountPassword == Password)
        {
            return RedirectToPage("/FootballManagement");
        }
        else
        {
            ErrorMessage = "Invalid email or password";
            return Page();
        }
    }
}