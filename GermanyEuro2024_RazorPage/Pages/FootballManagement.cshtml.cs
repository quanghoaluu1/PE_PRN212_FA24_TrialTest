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
    
    public void OnGet()
    {
        var players = _footballPlayerRepository.GetFootballPlayerList();
        FootballPlayers = players;
        
        var footballTeams = _footballTeamRepository.GetAllTeams();
        Teams = footballTeams.Select(t => new SelectListItem
        {
            Value = t.FootballTeamId,
            Text = t.TeamTitle
        }).ToList();
    }

    public IActionResult OnPostSelect(string footballPlayerId)
    {
        
            SelectedFootballPlayer = _footballPlayerRepository.GetFootballPlayerById(footballPlayerId);
            var footballTeams = _footballTeamRepository.GetAllTeams();
            Teams = footballTeams.Select(t => new SelectListItem
            {
                Value = t.FootballTeamId,
                Text = t.TeamTitle
            }).ToList();
            FootballPlayers = _footballPlayerRepository.GetFootballPlayerList();

        return Page();
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
            newFootballPlayer.PlayerId = SelectedFootballPlayer.PlayerId;
            newFootballPlayer.PlayerName = SelectedFootballPlayer.PlayerName;
            newFootballPlayer.Birthday = SelectedFootballPlayer.Birthday;
            newFootballPlayer.Achievements = SelectedFootballPlayer.Achievements;
            newFootballPlayer.Award = SelectedFootballPlayer.Award;
            newFootballPlayer.OriginCountry = SelectedFootballPlayer.OriginCountry;
            newFootballPlayer.FootballTeamId = SelectedFootballPlayer.FootballTeamId;
            _footballPlayerRepository.AddFootballPlayer(newFootballPlayer);
            SelectedFootballPlayer = new FootballPlayer();
            FootballPlayers = _footballPlayerRepository.GetFootballPlayerList();
            TempData["SuccessMessage"] = "Add player successfully.";
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error adding player: " + ex.Message);
            FootballPlayers = _footballPlayerRepository.GetFootballPlayerList();
        }
        return Page();
    }

    public IActionResult OnPostDelete()
    {
        _footballPlayerRepository.RemoveFootballPlayer(SelectedFootballPlayer.PlayerId);
        SelectedFootballPlayer = new FootballPlayer();
        FootballPlayers = _footballPlayerRepository.GetFootballPlayerList();
        TempData["SuccessMessage"] = "Delete player successfully.";
        return Page();
    }

    public IActionResult OnPostUpdate()
    {
        FootballPlayer updateFootballPlayer = _footballPlayerRepository.GetFootballPlayerById(SelectedFootballPlayer.PlayerId);
        updateFootballPlayer.PlayerName = SelectedFootballPlayer.PlayerName;
        updateFootballPlayer.Birthday = SelectedFootballPlayer.Birthday;
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