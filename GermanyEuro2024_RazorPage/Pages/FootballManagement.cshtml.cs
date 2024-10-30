using System.Text.RegularExpressions;
using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GermanyEuro2024_RazorPage.Pages;

public class FootballManagement : PageModel
{
    private readonly IFootballPlayerRepository _footballPlayerRepository;
    private readonly IFootballTeamRepository _footballTeamRepository;

    public FootballManagement(IFootballPlayerRepository footballPlayerRepository, IFootballTeamRepository footballTeamRepository)
    {
        _footballPlayerRepository = footballPlayerRepository;
        _footballTeamRepository = footballTeamRepository;
    }
    [BindProperty]
    public FootballPlayer SelectedFootballPlayer { get; set; }
    
    public List<FootballPlayer> FootballPlayers { get; set; }
    
    public List<FootballTeam> FootballTeams { get; set; }
    
    public List<SelectListItem> Teams { get; set; }
    
    public string UserRole{ get; private set; }
    
    public void OnGet()
    {
        UserRole = HttpContext.Session.GetString("UserRole");
        var players = _footballPlayerRepository.GetFootballPlayerList();
        FootballPlayers = players;
        
        var footballTeams = _footballTeamRepository.GetAllTeams();
        Teams = footballTeams.Select(t => new SelectListItem
        {
            Value = t.FootballTeamId,
            Text = t.TeamTitle
        }).ToList();
    }

    public IActionResult OnPostLogout()
    {
        HttpContext.Session.Remove("UserRole");
        return RedirectToPage("/Index");
    }
    public void OnPostSelect(string footballPlayerId)
    {
        UserRole = HttpContext.Session.GetString("UserRole");

        SelectedFootballPlayer = _footballPlayerRepository.GetFootballPlayerById(footballPlayerId);
            var footballTeams = _footballTeamRepository.GetAllTeams();
            Teams = footballTeams.Select(t => new SelectListItem
            {
                Value = t.FootballTeamId,
                Text = t.TeamTitle
            }).ToList();
            FootballPlayers = _footballPlayerRepository.GetFootballPlayerList();

    }

    public string GetFootballTeam(string footballTeamId)
    {
        var team = FootballTeams.FirstOrDefault(t => t.FootballTeamId == footballTeamId);
        return team != null ? team.TeamTitle : "Unknown";
    }

    public void LoadDataInit()
    {
        SelectedFootballPlayer.PlayerId = "";
        SelectedFootballPlayer.PlayerName = "";
        SelectedFootballPlayer.FootballTeamId = "";
        SelectedFootballPlayer.Achievements = "";
        SelectedFootballPlayer.Award = "";
        SelectedFootballPlayer.Birthday = null;
        SelectedFootballPlayer.OriginCountry = "";
        
        FootballPlayers = _footballPlayerRepository.GetFootballPlayerList();
        var footballTeams = _footballTeamRepository.GetAllTeams();
        Teams = footballTeams.Select(t => new SelectListItem
        {
            Value = t.FootballTeamId,
            Text = t.TeamTitle
        }).ToList();
        RedirectToPage("FootballManagement");
        
    }

    public IActionResult OnPostClear()
    {
        LoadDataInit();
        return RedirectToPage("FootballManagement");
    }

    public IActionResult OnPostAdd()
    {
        try
        {
            FootballPlayer newFootballPlayer = new FootballPlayer();
            newFootballPlayer.PlayerId = GetNewId();
            newFootballPlayer.PlayerName = SelectedFootballPlayer.PlayerName;
            if (!isValidName(SelectedFootballPlayer.PlayerName))
            {
                TempData["Error"] = "Please enter a valid name";
                LoadDataInit();
                return OnPostClear();
            }
            newFootballPlayer.Birthday = SelectedFootballPlayer.Birthday;
            if (SelectedFootballPlayer.Birthday > new DateTime(2004, 1, 1))
            {
                TempData["Error"] = "We don't accept players younger than 2004";
                LoadDataInit();
                return OnPostClear();
            }
            newFootballPlayer.Achievements = SelectedFootballPlayer.Achievements;
            newFootballPlayer.Award = SelectedFootballPlayer.Award;
            newFootballPlayer.OriginCountry = SelectedFootballPlayer.OriginCountry;
            newFootballPlayer.FootballTeamId = SelectedFootballPlayer.FootballTeamId;
            _footballPlayerRepository.AddFootballPlayer(newFootballPlayer);
            SelectedFootballPlayer = new FootballPlayer();
            LoadDataInit();
            FootballPlayers = _footballPlayerRepository.GetFootballPlayerList();
            TempData["SuccessMessage"] = "Add player successfully.";
            
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error adding player: " + ex.Message);
            FootballPlayers = _footballPlayerRepository.GetFootballPlayerList();
        }
        return OnPostClear();
    }
    private string GetNewId()
    {
        List<FootballPlayer> footballPlayers = _footballPlayerRepository.GetFootballPlayerList();
        FootballPlayer lastFootballPlayer = footballPlayers.OrderBy(p => p.PlayerId).LastOrDefault();
        int number =  int.Parse(lastFootballPlayer.PlayerId.Substring(2)) + 1;
        return $"PL{number:D5}";
    }

    private bool isValidName(string name)
    {
        var result = !(name.Length < 3 || name.Length > 100);
        if (!Regex.IsMatch(name, @"^[A-Za-z0-9 ]+$"))
        {
            result = false;
        }
        string[] words = name.Split(' ');
        foreach (string word in words)
        {
            if (!Regex.IsMatch(word, @"^[A-Z0-9]"))
            {
                result = false;
            }
        }
        return result;
    }

    public IActionResult OnPostDelete()
    {
            _footballPlayerRepository.RemoveFootballPlayer(SelectedFootballPlayer.PlayerId);
            TempData["SuccessMessage"] = "Delete player successfully.";
            return OnPostClear();
            
    }

    public IActionResult OnPostUpdate()
    {
        FootballPlayer updateFootballPlayer = _footballPlayerRepository.GetFootballPlayerById(SelectedFootballPlayer.PlayerId);
        updateFootballPlayer.PlayerName = SelectedFootballPlayer.PlayerName;
        if (!isValidName(SelectedFootballPlayer.PlayerName))
        {
            TempData["Error"] = "Please enter a valid name";
            LoadDataInit();
            return Page();
        }
        updateFootballPlayer.Birthday = SelectedFootballPlayer.Birthday;
        if (SelectedFootballPlayer.Birthday > new DateTime(2004, 1, 1))
        {
            TempData["Error"] = "We don't accept players younger than 2004";
            LoadDataInit();
            return Page();
        }
        updateFootballPlayer.Achievements = SelectedFootballPlayer.Achievements;
        updateFootballPlayer.Award = SelectedFootballPlayer.Award;
        updateFootballPlayer.OriginCountry = SelectedFootballPlayer.OriginCountry;
        updateFootballPlayer.FootballTeamId = SelectedFootballPlayer.FootballTeamId;
        _footballPlayerRepository.UpdateFootballPlayer(updateFootballPlayer);
        SelectedFootballPlayer = new FootballPlayer();
        FootballPlayers = _footballPlayerRepository.GetFootballPlayerList();
        TempData["SuccessMessage"] = "Update player successfully.";
        LoadDataInit();
        return RedirectToPage("FootballManagement");
            
    }
    
    public IActionResult OnPostSearch(string searchTerm, string searchBy)
    {
        var players = _footballPlayerRepository.GetFootballPlayerList();
        if (!string.IsNullOrEmpty(searchTerm))
        {
            if (searchBy == "name")
            {
                FootballPlayers = _footballPlayerRepository.FindFootballPlayersByName(searchTerm);
            }
            else if (searchBy == "achievement")
            {
                FootballPlayers = _footballPlayerRepository.FindFootballPlayersByAchievements(searchTerm);
            }
        }
        else
        {
           FootballPlayers = players;
        }

        return Page();
    }
   
}